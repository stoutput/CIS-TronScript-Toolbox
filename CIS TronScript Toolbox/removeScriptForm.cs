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
    public partial class removeScriptForm : Form
    {
        public removeScriptForm()
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
            scriptsListBox.Items.AddRange(Scripts);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
           if(scriptsListBox.SelectedItem != null)
           {
               //Debug script
               //label1.Text = scriptsListBox.SelectedItem.ToString();
               XElement root = XElement.Load(@"J:\CIS-TronScript-Toolbox-master\CIS TronScript Toolbox\scriptConfig.xml");

               IEnumerable<XElement> script =
                   from el in root.Elements("Script")
                   where (string)el.Element("name") == scriptsListBox.SelectedItem.ToString()
                   select el;

               foreach (XElement el in script)
               {
                   el.Remove();
               }

               root.Save(@"J:\CIS-TronScript-Toolbox-master\CIS TronScript Toolbox\scriptConfig.xml");

               //Empty the listbox
               scriptsListBox.Items.Clear();

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
               scriptsListBox.Items.AddRange(Scripts);
           }
           else
           {
               MessageBox.Show("Select A Script", "First select a script to delete.",
                   MessageBoxButtons.OKCancel);
               scriptsListBox.Focus();
           }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
