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
        txtArguments = new TextBox();
        txtSearchQuery = new TextBox();
        btnGenerateShortcuts = new Button();
        lblStatus = new Label();
        lblGamesFolder = new Label();
        lblEmulatorPath = new Label();
        lblOutputFolder = new Label();
        lblArguments = new Label();
        lblSearchQuery = new Label();
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
        // lblArguments
        // 
        lblArguments.AutoSize = true;
        lblArguments.Location = new Point(12, 180);
        lblArguments.Name = "lblArguments";
        lblArguments.Size = new Size(72, 15);
        lblArguments.TabIndex = 11;
        lblArguments.Text = "Arguments:";
        // 
        // txtArguments
        // 
        txtArguments.Location = new Point(12, 198);
        txtArguments.Name = "txtArguments";
        txtArguments.Size = new Size(681, 23);
        txtArguments.TabIndex = 12;
        // 
        // lblSearchQuery
        // 
        lblSearchQuery.AutoSize = true;
        lblSearchQuery.Location = new Point(12, 235);
        lblSearchQuery.Name = "lblSearchQuery";
        lblSearchQuery.Size = new Size(82, 15);
        lblSearchQuery.TabIndex = 13;
        lblSearchQuery.Text = "Icon Search Query:";
        // 
        // txtSearchQuery
        // 
        txtSearchQuery.Location = new Point(12, 253);
        txtSearchQuery.Name = "txtSearchQuery";
        txtSearchQuery.Size = new Size(681, 23);
        txtSearchQuery.TabIndex = 14;
        txtSearchQuery.Text = "icon";
        // 
        // btnGenerateShortcuts
        // 
        btnGenerateShortcuts.Location = new Point(12, 290);
        btnGenerateShortcuts.Name = "btnGenerateShortcuts";
        btnGenerateShortcuts.Size = new Size(150, 30);
        btnGenerateShortcuts.TabIndex = 15;
        btnGenerateShortcuts.Text = "Generate Shortcuts";
        btnGenerateShortcuts.UseVisualStyleBackColor = true;
        btnGenerateShortcuts.Click += btnGenerateShortcuts_Click;
        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(12, 335);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(42, 15);
        lblStatus.TabIndex = 16;
        lblStatus.Text = "Ready";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(720, 375);
        Controls.Add(lblStatus);
        Controls.Add(btnGenerateShortcuts);
        Controls.Add(txtSearchQuery);
        Controls.Add(lblSearchQuery);
        Controls.Add(txtArguments);
        Controls.Add(lblArguments);
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
    private TextBox txtArguments;
    private TextBox txtSearchQuery;
    private Button btnGenerateShortcuts;
    private Label lblStatus;
    private Label lblGamesFolder;
    private Label lblEmulatorPath;
    private Label lblOutputFolder;
    private Label lblArguments;
    private Label lblSearchQuery;
}
