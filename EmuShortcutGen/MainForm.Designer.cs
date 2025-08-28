namespace EmuShortcutGen;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        txtGamesFolder = new TextBox();
        btnBrowseGames = new Button();
        txtEmulatorPath = new TextBox();
        btnBrowseEmulator = new Button();
        txtOutputFolder = new TextBox();
        btnBrowseOutput = new Button();
        btnGenerateShortcuts = new Button();
        lblStatus = new Label();
        lblGamesFolder = new Label();
        lblEmulatorPath = new Label();
        lblOutputFolder = new Label();
        SuspendLayout();
        // 
        // lblOutputFolder
        // 
        lblOutputFolder.AutoSize = true;
        lblOutputFolder.Location = new Point(12, 15);
        lblOutputFolder.Name = "lblOutputFolder";
        lblOutputFolder.Size = new Size(88, 15);
        lblOutputFolder.TabIndex = 0;
        lblOutputFolder.Text = "Output Folder:";
        // 
        // txtOutputFolder
        // 
        txtOutputFolder.Location = new Point(12, 33);
        txtOutputFolder.Name = "txtOutputFolder";
        txtOutputFolder.Size = new Size(600, 23);
        txtOutputFolder.TabIndex = 1;
        // 
        // btnBrowseOutput
        // 
        btnBrowseOutput.Location = new Point(618, 33);
        btnBrowseOutput.Name = "btnBrowseOutput";
        btnBrowseOutput.Size = new Size(75, 23);
        btnBrowseOutput.TabIndex = 2;
        btnBrowseOutput.Text = "Browse...";
        btnBrowseOutput.UseVisualStyleBackColor = true;
        btnBrowseOutput.Click += btnBrowseOutput_Click;
        // 
        // lblGamesFolder
        // 
        lblGamesFolder.AutoSize = true;
        lblGamesFolder.Location = new Point(12, 70);
        lblGamesFolder.Name = "lblGamesFolder";
        lblGamesFolder.Size = new Size(87, 15);
        lblGamesFolder.TabIndex = 3;
        lblGamesFolder.Text = "Games Folder:";
        // 
        // txtGamesFolder
        // 
        txtGamesFolder.Location = new Point(12, 88);
        txtGamesFolder.Name = "txtGamesFolder";
        txtGamesFolder.Size = new Size(600, 23);
        txtGamesFolder.TabIndex = 4;
        // 
        // btnBrowseGames
        // 
        btnBrowseGames.Location = new Point(618, 88);
        btnBrowseGames.Name = "btnBrowseGames";
        btnBrowseGames.Size = new Size(75, 23);
        btnBrowseGames.TabIndex = 5;
        btnBrowseGames.Text = "Browse...";
        btnBrowseGames.UseVisualStyleBackColor = true;
        btnBrowseGames.Click += btnBrowseGames_Click;
        // 
        // lblEmulatorPath
        // 
        lblEmulatorPath.AutoSize = true;
        lblEmulatorPath.Location = new Point(12, 125);
        lblEmulatorPath.Name = "lblEmulatorPath";
        lblEmulatorPath.Size = new Size(89, 15);
        lblEmulatorPath.TabIndex = 6;
        lblEmulatorPath.Text = "Emulator Path:";
        // 
        // txtEmulatorPath
        // 
        txtEmulatorPath.Location = new Point(12, 143);
        txtEmulatorPath.Name = "txtEmulatorPath";
        txtEmulatorPath.Size = new Size(600, 23);
        txtEmulatorPath.TabIndex = 7;
        // 
        // btnBrowseEmulator
        // 
        btnBrowseEmulator.Location = new Point(618, 143);
        btnBrowseEmulator.Name = "btnBrowseEmulator";
        btnBrowseEmulator.Size = new Size(75, 23);
        btnBrowseEmulator.TabIndex = 8;
        btnBrowseEmulator.Text = "Browse...";
        btnBrowseEmulator.UseVisualStyleBackColor = true;
        btnBrowseEmulator.Click += btnBrowseEmulator_Click;
        // 
        // btnGenerateShortcuts
        // 
        btnGenerateShortcuts.Location = new Point(12, 185);
        btnGenerateShortcuts.Name = "btnGenerateShortcuts";
        btnGenerateShortcuts.Size = new Size(150, 30);
        btnGenerateShortcuts.TabIndex = 9;
        btnGenerateShortcuts.Text = "Generate Shortcuts";
        btnGenerateShortcuts.UseVisualStyleBackColor = true;
        btnGenerateShortcuts.Click += btnGenerateShortcuts_Click;
        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(12, 230);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(42, 15);
        lblStatus.TabIndex = 10;
        lblStatus.Text = "Ready";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(720, 270);
        Controls.Add(lblStatus);
        Controls.Add(btnGenerateShortcuts);
        Controls.Add(btnBrowseEmulator);
        Controls.Add(txtEmulatorPath);
        Controls.Add(lblEmulatorPath);
        Controls.Add(btnBrowseGames);
        Controls.Add(txtGamesFolder);
        Controls.Add(lblGamesFolder);
        Controls.Add(btnBrowseOutput);
        Controls.Add(txtOutputFolder);
        Controls.Add(lblOutputFolder);
        Name = "MainForm";
        Text = "Emulator Shortcut Generator";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox txtGamesFolder;
    private Button btnBrowseGames;
    private TextBox txtEmulatorPath;
    private Button btnBrowseEmulator;
    private TextBox txtOutputFolder;
    private Button btnBrowseOutput;
    private Button btnGenerateShortcuts;
    private Label lblStatus;
    private Label lblGamesFolder;
    private Label lblEmulatorPath;
    private Label lblOutputFolder;
}
