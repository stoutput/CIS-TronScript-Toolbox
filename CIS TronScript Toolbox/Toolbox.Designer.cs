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
            this.showConsoleButton.Location = new System.Drawing.Point(258, 327);
            this.showConsoleButton.Name = "showConsoleButton";
            this.showConsoleButton.Size = new System.Drawing.Size(259, 23);
            this.showConsoleButton.TabIndex = 0;
            this.showConsoleButton.Text = "Show Console";
            this.showConsoleButton.UseVisualStyleBackColor = true;
            this.showConsoleButton.Click += new System.EventHandler(this.showConsoleButton_Click);
            // 
            // Toolbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(775, 382);
            this.Controls.Add(this.showConsoleButton);
            this.Controls.Add(this.consoleControl);
            this.MinimumSize = new System.Drawing.Size(791, 421);
            this.Name = "Toolbox";
            this.Text = "CIS TronScript Toolbox";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ConsoleControl.ConsoleControl consoleControl;
        private System.Windows.Forms.Button showConsoleButton;
    }
}

