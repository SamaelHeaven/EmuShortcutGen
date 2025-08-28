using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;
using GScraper.Google;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Png;

namespace EmuShortcutGen;

public partial class MainForm : Form
{
    [ComImport]
    [Guid("00021401-0000-0000-C000-000000000046")]
    internal class ShellLink
    {
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214F9-0000-0000-C000-000000000046")]
    internal interface IShellLink
    {
        void GetPath([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxPath, out IntPtr pfd, int fFlags);
        void GetIDList(out IntPtr ppidl);
        void SetIDList(IntPtr pidl);
        void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, int cchMaxName);
        void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);
        void GetWorkingDirectory([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, int cchMaxPath);
        void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);
        void GetArguments([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, int cchMaxPath);
        void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);
        void GetHotkey(out short pwHotkey);
        void SetHotkey(short wHotkey);
        void GetShowCmd(out int piShowCmd);
        void SetShowCmd(int iShowCmd);
        void GetIconLocation([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath, int cchIconPath, out int piIcon);
        void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);
        void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, int dwReserved);
        void Resolve(IntPtr hwnd, int fFlags);
        void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0000010b-0000-0000-C000-000000000046")]
    internal interface IPersistFile
    {
        // ReSharper disable once InconsistentNaming
        void GetClassID(out Guid pClassID);
        void IsDirty();
        void Load([In, MarshalAs(UnmanagedType.LPWStr)] string pszFileName, uint dwMode);
        void Save([In, MarshalAs(UnmanagedType.LPWStr)] string pszFileName, [In, MarshalAs(UnmanagedType.Bool)] bool fRemember);
        void SaveCompleted([In, MarshalAs(UnmanagedType.LPWStr)] string pszFileName);
        void GetCurFile([In, MarshalAs(UnmanagedType.LPWStr)] string ppszFileName);
    }

    private static readonly HttpClient HttpClient = new();
    private readonly string _iconsFolder;

    public MainForm()
    {
        InitializeComponent();
        txtOutputFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        
        _iconsFolder = Path.Combine(Application.StartupPath, "Icons");
        Directory.CreateDirectory(_iconsFolder);
        
        HttpClient.DefaultRequestHeaders.Add("User-Agent", "ShortcutGen/1.0");
    }

    private void btnBrowseGames_Click(object sender, EventArgs e)
    {
        using var dialog = new FolderBrowserDialog();
        dialog.Description = "Select games folder";
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            txtGamesFolder.Text = dialog.SelectedPath;
        }
    }

    private void btnBrowseEmulator_Click(object sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog();
        dialog.Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*";
        dialog.Title = "Select emulator executable";
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            txtEmulatorPath.Text = dialog.FileName;
        }
    }

    private void btnBrowseOutput_Click(object sender, EventArgs e)
    {
        using var dialog = new FolderBrowserDialog();
        dialog.Description = "Select output folder for shortcuts";
        dialog.SelectedPath = txtOutputFolder.Text;
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            txtOutputFolder.Text = dialog.SelectedPath;
        }
    }

    private void btnGenerateShortcuts_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtGamesFolder.Text) || !Directory.Exists(txtGamesFolder.Text))
        {
            MessageBox.Show("Please select a valid games folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtEmulatorPath.Text) || !File.Exists(txtEmulatorPath.Text))
        {
            MessageBox.Show("Please select a valid emulator executable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtOutputFolder.Text) || !Directory.Exists(txtOutputFolder.Text))
        {
            MessageBox.Show("Please select a valid output folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        GenerateShortcuts();
    }

    private async void GenerateShortcuts()
    {
        try
        {
            btnGenerateShortcuts.Enabled = false;
            btnBrowseGames.Enabled = false;
            btnBrowseEmulator.Enabled = false;
            btnBrowseOutput.Enabled = false;
            var gamesFolder = txtGamesFolder.Text;
            var emulatorPath = txtEmulatorPath.Text;
            var outputPath = txtOutputFolder.Text;

            var gameFiles = Directory.GetFiles(gamesFolder, "*.*", SearchOption.TopDirectoryOnly)
                .Where(file => !Path.GetExtension(file).Equals(".lnk", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            if (gameFiles.Length == 0)
            {
                lblStatus.Text = "No game files found in the selected folder.";
                return;
            }

            var shortcutsCreated = 0;

            foreach (var gameFile in gameFiles)
            {
                var gameName = Path.GetFileNameWithoutExtension(gameFile);
                var shortcutPath = Path.Combine(outputPath, $"{gameName}.lnk");

                lblStatus.Text = $"Processing {gameName}... ({shortcutsCreated + 1}/{gameFiles.Length})";
                Application.DoEvents();

                var iconPath = await GetGameIconAsync(gameName);
                CreateShortcut(shortcutPath, emulatorPath, $"\"{gameFile}\"", Path.GetDirectoryName(emulatorPath), $"Launch {gameName} with emulator", iconPath);
                shortcutsCreated++;
            }

            lblStatus.Text = $"Successfully created {shortcutsCreated} shortcuts in output folder.";
            MessageBox.Show($"Generated {shortcutsCreated} shortcuts successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            lblStatus.Text = "Error occurred while creating shortcuts.";
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnGenerateShortcuts.Enabled = true;
            btnBrowseGames.Enabled = true;
            btnBrowseEmulator.Enabled = true;
            btnBrowseOutput.Enabled = true;
        }
    }

    public static async Task<string?> GetFirstImageUrlAsync(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            throw new ArgumentException("Query cannot be empty.", nameof(query));

        try
        {
            using var scraper = new GoogleScraper();
            var results = await scraper.GetImagesAsync(query);
            return results.FirstOrDefault()?.Url;
        }
        catch
        {
            return null;
        }
    }

    private async Task<string?> GetGameIconAsync(string gameName)
    {
        try
        {
            if (!Directory.Exists(_iconsFolder))
                Directory.CreateDirectory(_iconsFolder);
            
            var cachedIconPath = Path.Combine(_iconsFolder, $"{SanitizeFileName(gameName)}.ico");
            if (File.Exists(cachedIconPath))
                return cachedIconPath;

            var imageUrl = await GetFirstImageUrlAsync($"{gameName} icon");
            if (!string.IsNullOrEmpty(imageUrl))
            {
                return await DownloadAndConvertIconAsync(imageUrl, cachedIconPath);
            }
        }
        // ReSharper disable once EmptyGeneralCatchClause
        catch
        {
        }
        
        return null;
    }



    private async Task<string?> DownloadAndConvertIconAsync(string imageUrl, string iconPath)
    {
        try
        {
            var targetDirectory = Path.GetDirectoryName(iconPath);
            if (!string.IsNullOrEmpty(targetDirectory) && !Directory.Exists(targetDirectory))
                Directory.CreateDirectory(targetDirectory);
            
            var imageBytes = await HttpClient.GetByteArrayAsync(imageUrl);
            using var ms = new MemoryStream(imageBytes);
            using var image = await SixLabors.ImageSharp.Image.LoadAsync(ms);
            
            SaveImageAsIcon(image, iconPath);
            return iconPath;
        }
        catch
        {
            return null;
        }
    }

    private static void SaveImageAsIcon(SixLabors.ImageSharp.Image image, string iconPath)
    {
        using var resized = image.Clone(ctx => ctx.Resize(256, 256, KnownResamplers.Lanczos3));
        using var pngStream = new MemoryStream();
        resized.Save(pngStream, new PngEncoder());
        pngStream.Seek(0, SeekOrigin.Begin);
        
        SavePngStreamAsIco(pngStream, iconPath);
    }

    private static void SavePngStreamAsIco(MemoryStream pngStream, string icoPath)
    {
        var pngBytes = pngStream.ToArray();
        
        using var fs = new FileStream(icoPath, FileMode.Create);
        using var bw = new BinaryWriter(fs);
        
        bw.Write((short)0);
        bw.Write((short)1);
        bw.Write((short)1);

        bw.Write((byte)0);
        bw.Write((byte)0);
        bw.Write((byte)0);
        bw.Write((byte)0);
        bw.Write((short)0);
        bw.Write((short)32);
        bw.Write(pngBytes.Length);
        bw.Write(6 + 16);
        bw.Write(pngBytes);
    }

    private static string SanitizeFileName(string fileName)
    {
        var invalidChars = Path.GetInvalidFileNameChars();
        return string.Join("_", fileName.Split(invalidChars, StringSplitOptions.RemoveEmptyEntries));
    }

    [SuppressMessage("ReSharper", "SuspiciousTypeConversion.Global")]
    private static void CreateShortcut(string shortcutPath, string targetPath, string arguments, string? workingDirectory, string description, string? iconPath = null)
    {
        var link = (IShellLink)new ShellLink();
        
        link.SetDescription(description);
        link.SetPath(targetPath);
        link.SetArguments(arguments);
        
        if (!string.IsNullOrEmpty(workingDirectory))
            link.SetWorkingDirectory(workingDirectory);

        if (!string.IsNullOrEmpty(iconPath) && File.Exists(iconPath))
            link.SetIconLocation(iconPath, 0);

        var file = (IPersistFile)link;
        file.Save(shortcutPath, false);
    }
}
