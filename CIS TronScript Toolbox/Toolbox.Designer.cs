namespace CIS_TronScript_Toolbox
{
    partial class Toolbox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.consoleControl = new ConsoleControl.ConsoleControl();
            this.showConsoleButton = new System.Windows.Forms.Button();
            this.tronOptionsCheckedListbox = new System.Windows.Forms.CheckedListBox();
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.manualToolsLabel = new System.Windows.Forms.Label();
            this.manualToolsListBox = new System.Windows.Forms.ListBox();
            this.manualToolsRunButton = new System.Windows.Forms.Button();
            this.tronOptionsLabel = new System.Windows.Forms.Label();
            this.toolboxMenuScript = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.removeScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolboxMenuScript.SuspendLayout();
            this.SuspendLayout();
            // 
            // consoleControl
            // 
            this.consoleControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.consoleControl.IsInputEnabled = true;
            this.consoleControl.Location = new System.Drawing.Point(12, 365);
            this.consoleControl.Name = "consoleControl";
            this.consoleControl.SendKeyboardCommandsToProcess = false;
            this.consoleControl.ShowDiagnostics = false;
            this.consoleControl.Size = new System.Drawing.Size(751, 0);
            this.consoleControl.TabIndex = 1;
            // 
            // showConsoleButton
            // 
            this.showConsoleButton.Location = new System.Drawing.Point(271, 342);
            this.showConsoleButton.Name = "showConsoleButton";
            this.showConsoleButton.Size = new System.Drawing.Size(259, 23);
            this.showConsoleButton.TabIndex = 0;
            this.showConsoleButton.Text = "Show Console";
            this.showConsoleButton.UseVisualStyleBackColor = true;
            this.showConsoleButton.Click += new System.EventHandler(this.showConsoleButton_Click);
            // 
            // tronOptionsCheckedListbox
            // 
            this.tronOptionsCheckedListbox.CheckOnClick = true;
            this.tronOptionsCheckedListbox.FormattingEnabled = true;
            this.tronOptionsCheckedListbox.Items.AddRange(new object[] {
            "Automatic Mode",
            "Dev Override",
            "Accept EULA",
            "Email Report",
            "Preserve OEM Metro",
            "No Pause",
            "Power Off",
            "Preserve Power Settings",
            "Reboot Automatically",
            "Skip AV Scans",
            "Skip De-Bloat",
            "Skip Defrag",
            "Skip Event Log",
            "Skip Permissions Reset",
            "Skip KVRT Scan",
            "Skip MBAM Install",
            "Skip Software Patches",
            "Skip PageFile Reset",
            "Skip Registry Reset",
            "Skip SAV Scan",
            "Skip Telemetry Reset",
            "Skip Windows Updates",
            "Verbose Mode"});
            this.tronOptionsCheckedListbox.Location = new System.Drawing.Point(24, 60);
            this.tronOptionsCheckedListbox.Name = "tronOptionsCheckedListbox";
            this.tronOptionsCheckedListbox.Size = new System.Drawing.Size(188, 229);
            this.tronOptionsCheckedListbox.TabIndex = 2;
            this.tronOptionsCheckedListbox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tronOptionsCheckedListBox_MouseMove);
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.Location = new System.Drawing.Point(53, 295);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(127, 35);
            this.saveChangesButton.TabIndex = 3;
            this.saveChangesButton.Text = "Save Changes";
            this.saveChangesButton.UseVisualStyleBackColor = true;
            this.saveChangesButton.Click += new System.EventHandler(this.applyChangesButton_Click);
            // 
            // manualToolsLabel
            // 
            this.manualToolsLabel.AutoSize = true;
            this.manualToolsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.manualToolsLabel.Location = new System.Drawing.Point(543, 44);
            this.manualToolsLabel.Name = "manualToolsLabel";
            this.manualToolsLabel.Size = new System.Drawing.Size(93, 17);
            this.manualToolsLabel.TabIndex = 4;
            this.manualToolsLabel.Text = "Manual Tools";
            // 
            // manualToolsListBox
            // 
            this.manualToolsListBox.FormattingEnabled = true;
            this.manualToolsListBox.HorizontalScrollbar = true;
            this.manualToolsListBox.Location = new System.Drawing.Point(546, 64);
            this.manualToolsListBox.Name = "manualToolsListBox";
            this.manualToolsListBox.Size = new System.Drawing.Size(217, 225);
            this.manualToolsListBox.TabIndex = 5;
            // 
            // manualToolsRunButton
            // 
            this.manualToolsRunButton.Location = new System.Drawing.Point(569, 295);
            this.manualToolsRunButton.Name = "manualToolsRunButton";
            this.manualToolsRunButton.Size = new System.Drawing.Size(133, 35);
            this.manualToolsRunButton.TabIndex = 6;
            this.manualToolsRunButton.Text = "Run";
            this.manualToolsRunButton.UseVisualStyleBackColor = true;
            this.manualToolsRunButton.Click += new System.EventHandler(this.manualToolsRunButton_Click);
            // 
            // tronOptionsLabel
            // 
            this.tronOptionsLabel.AutoSize = true;
            this.tronOptionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tronOptionsLabel.Location = new System.Drawing.Point(21, 40);
            this.tronOptionsLabel.Name = "tronOptionsLabel";
            this.tronOptionsLabel.Size = new System.Drawing.Size(91, 17);
            this.tronOptionsLabel.TabIndex = 7;
            this.tronOptionsLabel.Text = "Tron Options";
            // 
            // toolboxMenuScript
            // 
            this.toolboxMenuScript.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.scriptsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.toolboxMenuScript.Location = new System.Drawing.Point(0, 0);
            this.toolboxMenuScript.Name = "toolboxMenuScript";
            this.toolboxMenuScript.Size = new System.Drawing.Size(775, 24);
            this.toolboxMenuScript.TabIndex = 8;
            this.toolboxMenuScript.Text = "scriptMenuBar";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAScriptToolStripMenuItem,
            this.toolStripSeparator1,
            this.removeScriptToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // addAScriptToolStripMenuItem
            // 
            this.addAScriptToolStripMenuItem.Name = "addAScriptToolStripMenuItem";
            this.addAScriptToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addAScriptToolStripMenuItem.Text = "Add A Script";
            this.addAScriptToolStripMenuItem.Click += new System.EventHandler(this.addAScriptToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // removeScriptToolStripMenuItem
            // 
            this.removeScriptToolStripMenuItem.Name = "removeScriptToolStripMenuItem";
            this.removeScriptToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removeScriptToolStripMenuItem.Text = "Remove Script";
            this.removeScriptToolStripMenuItem.Click += new System.EventHandler(this.deleteScriptToolStripMenuItem_Click);
            // 
            // scriptsToolStripMenuItem
            // 
            this.scriptsToolStripMenuItem.Name = "scriptsToolStripMenuItem";
            this.scriptsToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.scriptsToolStripMenuItem.Text = "Scripts";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "label2";
            // 
            // Toolbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(775, 383);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tronOptionsLabel);
            this.Controls.Add(this.manualToolsRunButton);
            this.Controls.Add(this.manualToolsListBox);
            this.Controls.Add(this.manualToolsLabel);
            this.Controls.Add(this.saveChangesButton);
            this.Controls.Add(this.tronOptionsCheckedListbox);
            this.Controls.Add(this.showConsoleButton);
            this.Controls.Add(this.consoleControl);
            this.Controls.Add(this.toolboxMenuScript);
            this.MainMenuStrip = this.toolboxMenuScript;
            this.MinimumSize = new System.Drawing.Size(791, 421);
            this.Name = "Toolbox";
            this.Text = "CIS TronScript Toolbox";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolboxMenuScript.ResumeLayout(false);
            this.toolboxMenuScript.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ConsoleControl.ConsoleControl consoleControl;
        private System.Windows.Forms.Button showConsoleButton;
        private System.Windows.Forms.CheckedListBox tronOptionsCheckedListbox;
        private System.Windows.Forms.Button saveChangesButton;
        private System.Windows.Forms.Label manualToolsLabel;
        private System.Windows.Forms.ListBox manualToolsListBox;
        private System.Windows.Forms.Button manualToolsRunButton;
        private System.Windows.Forms.Label tronOptionsLabel;
        private System.Windows.Forms.MenuStrip toolboxMenuScript;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

