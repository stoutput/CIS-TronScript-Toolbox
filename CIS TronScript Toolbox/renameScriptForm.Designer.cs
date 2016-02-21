namespace CIS_TronScript_Toolbox
{
    partial class renameScriptForm
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
            this.scriptNameListbox = new System.Windows.Forms.ListBox();
            this.selectScriptLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.newNameLabel = new System.Windows.Forms.Label();
            this.newNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // scriptNameListbox
            // 
            this.scriptNameListbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.scriptNameListbox.FormattingEnabled = true;
            this.scriptNameListbox.ItemHeight = 16;
            this.scriptNameListbox.Location = new System.Drawing.Point(12, 27);
            this.scriptNameListbox.Name = "scriptNameListbox";
            this.scriptNameListbox.Size = new System.Drawing.Size(175, 132);
            this.scriptNameListbox.TabIndex = 1;
            // 
            // selectScriptLabel
            // 
            this.selectScriptLabel.AutoSize = true;
            this.selectScriptLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.selectScriptLabel.Location = new System.Drawing.Point(12, 8);
            this.selectScriptLabel.Name = "selectScriptLabel";
            this.selectScriptLabel.Size = new System.Drawing.Size(99, 17);
            this.selectScriptLabel.TabIndex = 0;
            this.selectScriptLabel.Text = "Select a Script";
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.saveButton.Location = new System.Drawing.Point(15, 245);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(77, 35);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cancelButton.Location = new System.Drawing.Point(110, 245);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(77, 35);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // newNameLabel
            // 
            this.newNameLabel.AutoSize = true;
            this.newNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.newNameLabel.Location = new System.Drawing.Point(12, 164);
            this.newNameLabel.Name = "newNameLabel";
            this.newNameLabel.Size = new System.Drawing.Size(80, 17);
            this.newNameLabel.TabIndex = 2;
            this.newNameLabel.Text = "New Name:";
            // 
            // newNameTextBox
            // 
            this.newNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.newNameTextBox.Location = new System.Drawing.Point(15, 185);
            this.newNameTextBox.Name = "newNameTextBox";
            this.newNameTextBox.Size = new System.Drawing.Size(172, 23);
            this.newNameTextBox.TabIndex = 3;
            // 
            // renameScriptForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(202, 292);
            this.Controls.Add(this.newNameTextBox);
            this.Controls.Add(this.newNameLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.selectScriptLabel);
            this.Controls.Add(this.scriptNameListbox);
            this.KeyPreview = true;
            this.Name = "renameScriptForm";
            this.Text = "renameScriptForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox scriptNameListbox;
        private System.Windows.Forms.Label selectScriptLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label newNameLabel;
        private System.Windows.Forms.TextBox newNameTextBox;
    }
}