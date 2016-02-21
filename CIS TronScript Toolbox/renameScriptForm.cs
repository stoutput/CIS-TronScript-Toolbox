using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;

namespace CIS_TronScript_Toolbox
{
    public partial class renameScriptForm : Form
    {
        public renameScriptForm()
        {
            InitializeComponent();
            XElement config = XElement.Load(@"J:\CIS-TronScript-Toolbox-master\CIS TronScript Toolbox\scriptConfig.xml");
            IEnumerable<XElement> scripts = config.Elements();
            int count = config.Descendants("name").Count();

            String[] Scripts = new String[count];
            int i = 0;
            foreach (var script in scripts)
            {
                Scripts[i] = script.Element("name").Value;
                i++;
            }

            //Add each script as a listbox item
            scriptNameListbox.Items.AddRange(Scripts);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (scriptNameListbox.SelectedItem != null)
            {
                //Debug script
                //label1.Text = scriptNameListbox.SelectedItem.ToString();
                XElement root = XElement.Load(@"J:\CIS-TronScript-Toolbox-master\CIS TronScript Toolbox\scriptConfig.xml");

                IEnumerable<XElement> script =
                    from el in root.Elements("Script")
                    where (string)el.Element("name") == scriptNameListbox.SelectedItem.ToString()
                    select el;

                foreach (XElement el in script)
                {
                    el.Element("name").Value = newNameTextBox.Text;
                }

                root.Save(@"J:\CIS-TronScript-Toolbox-master\CIS TronScript Toolbox\scriptConfig.xml");

                //Empty the listbox
                scriptNameListbox.Items.Clear();

                //Reload the listbox
                XElement config = XElement.Load(@"J:\CIS-TronScript-Toolbox-master\CIS TronScript Toolbox\scriptConfig.xml");
                IEnumerable<XElement> scripts = config.Elements();
                int count = config.Descendants("name").Count();

                String[] Scripts = new String[count];
                int i = 0;
                foreach (var userScript in scripts)
                {
                    Scripts[i] = userScript.Element("name").Value;
                    i++;
                }

                //Add each script as a listbox item
                scriptNameListbox.Items.AddRange(Scripts);
            }
            else
            {
                MessageBox.Show("Select A Script", "First select a script to rename.",
                    MessageBoxButtons.OKCancel);
                scriptNameListbox.Focus();
            }

            this.Close();
        }
    }
}
