using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIS_TronScript_Toolbox
{
    public partial class addScriptForm : Form
    {

        public addScriptForm()
        {
            InitializeComponent();
        }

        public void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string ScriptName
        {
            get { return scriptNameTextBox.Text; }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
