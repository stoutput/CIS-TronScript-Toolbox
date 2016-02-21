using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Xml.Linq;

namespace CIS_TronScript_Toolbox
{
    public partial class Toolbox : Form
    {
        public class Process
        {
            public string File { get; set; }
            public string Args { get; set; }
            public Process()
            {
                File = "";
                Args = "";
            }
        }
        public Queue<Process> Processes = new Queue<Process>();

        //List of manual tools paths to run on click
        private string[] manualTools = Directory.GetFiles(@"J:\CIS-TronScript-Toolbox-master\tron\resources\stage_8_manual_tools", "*.exe");
        
        
        public Toolbox()
        {
            InitializeComponent();

            //Initializing the list
            foreach (string fileName in manualTools)
            {
                    manualToolsListBox.Items.Add(Path.GetFileName(fileName));
            }

            //Initializing the Script drop-down menu items
            XElement config = XElement.Load(@"J:\CIS-TronScript-Toolbox-master\CIS TronScript Toolbox\scriptConfig.xml");
            IEnumerable<XElement> scripts = config.Elements();
            int count = config.Descendants("name").Count();

            ToolStripMenuItem[] Scripts = new ToolStripMenuItem[count];
            int i = 0;
            foreach (var script in scripts)
            {
                //This code was sort of bad
                //scriptsToolStripMenuItem.DropDownItems.Add(script.Element("name").Value);
                //scriptsToolStripMenuItem.DropDownItemClicked += new ToolStripItemClickedEventHandler(RunScript);

                //This dynamically creates new menu item with the name of the script
                //It also links the menu item with a dynamic event-handler
                Scripts[i] = new ToolStripMenuItem();
                Scripts[i].Name = script.Element("file").Value;
                Scripts[i].Tag = script.Element("file").Value;
                Scripts[i].Text = script.Element("name").Value;
                Scripts[i].Click += new EventHandler(RunScript);
                i++;
            }

            //Add each script as a drop down item
            scriptsToolStripMenuItem.DropDownItems.AddRange(Scripts);

            //Don't minimize this window on load
            this.WindowState = FormWindowState.Normal;
            
        }

        void RunScript(Object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

           
            XElement xelement = XElement.Load(@"J:\CIS-TronScript-Toolbox-master\CIS TronScript Toolbox\scriptConfig.xml");
            var files = from file in xelement.Elements("Script")
                        where (string)file.Element("name") == clickedItem.ToString()
                        select file.Element("file");
            foreach (XElement xEle in files)
               label1.Text = String.Concat(xEle.Nodes());

            label2.Text = clickedItem.ToString();
                //These options also work for different things
                //clickedItem.Name.ToString(); //clickedItem.Tag.ToString();
            
        }

        private void newProcess(string file, string args)
        {
            //if process is already running or processes are queued
            if (consoleControl.IsProcessRunning || Processes.Count > 0)
            {
                //create new process struct
                Process qProcess = new Process();
                qProcess.File = file;
                qProcess.Args = args;
                //push process into queue
                Processes.Enqueue(qProcess);
                //wait until current process finishes
                while (consoleControl.IsProcessRunning) ;
                //pull next process from queue
                qProcess = Processes.Dequeue();
                //start next process
                consoleControl.StartProcess(qProcess.File, qProcess.Args);
            }
            else
            {
                //start new process
                consoleControl.StartProcess(file, args);
            }
            //update form title
            this.Text = "CIS Tronscript Toolbox - " + consoleControl.ProcessInterface.ProcessFileName;
        }

        private void showConsoleButton_Click(object sender, EventArgs e)
        {
            if (consoleControl.Height == 0)
            {
                showConsoleButton.Text = "Hide Console";
                while (consoleControl.Height <= 200)
                {
                    consoleControl.Height++;
                    Application.DoEvents();
                }
            }
            else
            {
                showConsoleButton.Text = "Show Console";
                while (consoleControl.Height > 0)
                {
                    consoleControl.Height--;
                    Application.DoEvents();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Checks if the computer is booted into safe-mode with networking
            if (SystemInformation.BootMode != BootMode.FailSafeWithNetwork)
            {
                DialogResult dialogResult = MessageBox.Show("Boot into safe mode with networking?", "Reboot", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    newProcess("ipconfig", "/all");
                    newProcess("bcdedit", " /set {current} safeboot network");
                }
            }
            
        }

        private void tronOptionsCheckedListBox_MouseMove(object sender, MouseEventArgs e)
        {
            //This code allows the user to hold a mouse button and check or uncheck the options to run tron
            for (int i = 0; i < tronOptionsCheckedListbox.Items.Count; i++)
            {
                if (tronOptionsCheckedListbox.GetItemRectangle(i).Contains(tronOptionsCheckedListbox.PointToClient(MousePosition)))
                {
                    switch (tronOptionsCheckedListbox.GetItemCheckState(i))
                    {
                        case CheckState.Checked:
                            if (e.Button == MouseButtons.Right)
                            {
                                tronOptionsCheckedListbox.SetItemCheckState(i, CheckState.Unchecked);
                            }
                            break;
                        case CheckState.Indeterminate:
                        case CheckState.Unchecked:
                            if (e.Button == MouseButtons.Left)
                            {
                                tronOptionsCheckedListbox.SetItemCheckState(i, CheckState.Checked);
                            }
                            break;
                    }

                }
            }
        }


        private void applyChangesButton_Click(object sender, EventArgs e)
        {

            //Initial location of tron.bat to be modified
            string path = @"J:\CIS-TronScript-Toolbox-master\tron\tron.bat";

            //Takes inventory of what items are checked by the user
            List<string> checkedItems = new List<string>();
            foreach (var item in tronOptionsCheckedListbox.CheckedItems)
            {
                checkedItems.Add(item.ToString());
            }

            //Create a filestream to read and write the file
            FileStream tronWrite;
            tronWrite = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            StringBuilder sb = new StringBuilder();


            using (BufferedStream bs = new BufferedStream(tronWrite))
            using (StreamReader tronRead = new StreamReader(bs))
            {
                string line;
                while ((line = tronRead.ReadLine()) != null)
                {
                    string lineToChange = line;

                    if (line.Contains("set AUTORUN=no") && checkedItems.Contains("Automatic Mode"))
                    {
                        lineToChange = line.Replace("set AUTORUN=no", "set AUTORUN=yes");
                    }
                    else if (line.Contains("set AUTORUN=yes") && !checkedItems.Contains("Automatic Mode"))
                    {
                        lineToChange = line.Replace("set AUTORUN=yes", "set AUTORUN=no");
                    }

                    if (line.Contains("set DEV_MODE=no") && checkedItems.Contains("Dev Override"))
                    {
                        lineToChange = line.Replace("set DEV_MODE=no", "set DEV_MODE=yes");
                    }
                    else if (line.Contains("set DEV_MODE=yes") && !checkedItems.Contains("Dev Override"))
                    {
                        lineToChange = line.Replace("set DEV_MODE=yes", "set DEV_MODE=no");
                    }

                    if (line.Contains("set EULA_ACCEPTED=no") && checkedItems.Contains("Accept EULA"))
                    {
                        lineToChange = line.Replace("set EULA_ACCEPTED=no", "set EULA_ACCEPTED=yes");
                    }
                    else if (line.Contains("set EULA_ACCEPTED=yes") && !checkedItems.Contains("Accept EULA"))
                    {
                        lineToChange = line.Replace("set EULA_ACCEPTED=yes", "set EULA_ACCEPTED=no");
                    }
                    
                    if (line.Contains("set EMAIL_REPORT=no") && checkedItems.Contains("Email Report"))
                    {
                        lineToChange = line.Replace("set EMAIL_REPORT=no", "set EMAIL_REPORT=yes");
                    }
                    else if (line.Contains("set EMAIL_REPORT=yes") && !checkedItems.Contains("Email Report"))
                    {
                        lineToChange = line.Replace("set EMAIL_REPORT=yes", "set EMAIL_REPORT=no");
                    }

                    if (line.Contains("set PRESERVE_METRO_APPS=no") && checkedItems.Contains("Preserve OEM Metro"))
                    {
                        lineToChange = line.Replace("set PRESERVE_METRO_APPS=no", "set PRESERVE_METRO_APPS=yes");
                    }
                    else if (line.Contains("set PRESERVE_METRO_APPS=yes") && !checkedItems.Contains("Preserve OEM Metro"))
                    {
                        lineToChange = line.Replace("set PRESERVE_METRO_APPS=yes", "set PRESERVE_METRO_APPS=no");
                    }

                    if (line.Contains("set NO_PAUSE=no") && checkedItems.Contains("No Pause"))
                    {
                        lineToChange = line.Replace("set NO_PAUSE=no", "set NO_PAUSE=yes");
                    }
                    else if (line.Contains("set NO_PAUSE=yes") && !checkedItems.Contains("No Pause"))
                    {
                        lineToChange = line.Replace("set NO_PAUSE=yes", "set NO_PAUSE=no");
                    }

                    if (line.Contains("set AUTO_SHUTDOWN=no") && checkedItems.Contains("Power Off"))
                    {
                        lineToChange = line.Replace("set AUTO_SHUTDOWN=no", "set AUTO_SHUTDOWN=yes");
                    }
                    else if (line.Contains("set AUTO_SHUTDOWN=yes") && !checkedItems.Contains("Power Off"))
                    {
                        lineToChange = line.Replace("set AUTO_SHUTDOWN=yes", "set AUTO_SHUTDOWN=no");
                    }

                    if (line.Contains("set PRESERVE_POWER_SCHEME=no") && checkedItems.Contains("Preserve Power Settings"))
                    {
                        lineToChange = line.Replace("set PRESERVE_POWER_SCHEME=no", "set PRESERVE_POWER_SCHEME=yes");
                    }
                    else if (line.Contains("set PRESERVE_POWER_SCHEME=yes") && !checkedItems.Contains("Preserve Power Settings"))
                    {
                        lineToChange = line.Replace("set PRESERVE_POWER_SCHEME=yes", "set PRESERVE_POWER_SCHEME=no");
                    }

                    if (line.Contains("set AUTO_REBOOT_DELAY=0") && checkedItems.Contains("Reboot Automatically"))
                    {
                        lineToChange = line.Replace("set AUTO_REBOOT_DELAY=0", "set AUTO_REBOOT_DELAY=1");
                    }
                    else if (line.Contains("set AUTO_REBOOT_DELAY=1") && !checkedItems.Contains("Reboot Automatically"))
                    {
                        lineToChange = line.Replace("set AUTO_REBOOT_DELAY=1", "set AUTO_REBOOT_DELAY=0");
                    }

                    if (line.Contains("set SKIP_ANTIVIRUS_SCANS=no") && checkedItems.Contains("Skip AV Scans"))
                    {
                        lineToChange = line.Replace("set SKIP_ANTIVIRUS_SCANS=no", "set SKIP_ANTIVIRUS_SCANS=yes");
                    }
                    else if (line.Contains("set SKIP_ANTIVIRUS_SCANS=yes") && !checkedItems.Contains("Skip AV Scans"))
                    {
                        lineToChange = line.Replace("set SKIP_ANTIVIRUS_SCANS=yes", "set SKIP_ANTIVIRUS_SCANS=no");
                    }

                    if (line.Contains("set SKIP_DEBLOAT=no") && checkedItems.Contains("Skip De-Bloat"))
                    {
                        lineToChange = line.Replace("set SKIP_DEBLOAT=no", "set SKIP_DEBLOAT=yes");
                    }
                    else if (line.Contains("set SKIP_DEBLOAT=yes") && !checkedItems.Contains("Skip De-Bloat"))
                    {
                        lineToChange = line.Replace("set SKIP_DEBLOAT=yes", "set SKIP_DEBLOAT=no");
                    }

                    if (line.Contains("set SKIP_DEFRAG=no") && checkedItems.Contains("Skip Defrag"))
                    {
                        lineToChange = line.Replace("set SKIP_DEFRAG=no", "set SKIP_DEFRAG=yes");
                    }
                    else if (line.Contains("set SKIP_DEFRAG=yes") && !checkedItems.Contains("Skip Defrag"))
                    {
                        lineToChange = line.Replace("set SKIP_DEFRAG=yes", "set SKIP_DEFRAG=no");
                    }

                    if (line.Contains("set SKIP_EVENT_LOG_CLEAR=no") && checkedItems.Contains("Skip Event Log"))
                    {
                        lineToChange = line.Replace("set SKIP_EVENT_LOG_CLEAR=no", "set SKIP_EVENT_LOG_CLEAR=yes");
                    }
                    else if (line.Contains("set SKIP_EVENT_LOG_CLEAR=yes") && !checkedItems.Contains("Skip Event Log"))
                    {
                        lineToChange = line.Replace("set SKIP_EVENT_LOG_CLEAR=yes", "set SKIP_EVENT_LOG_CLEAR=no");
                    }

                    if (line.Contains("set SKIP_FILEPERMS_RESET=no") && checkedItems.Contains("Skip Permissions Reset"))
                    {
                        lineToChange = line.Replace("set SKIP_FILEPERMS_RESET=no", "set SKIP_FILEPERMS_RESET=yes");
                    }
                    else if (line.Contains("set SKIP_FILEPERMS_RESET=yes") && !checkedItems.Contains("Skip Permissions Reset"))
                    {
                        lineToChange = line.Replace("set SKIP_FILEPERMS_RESET=yes", "set SKIP_FILEPERMS_RESET=no");
                    }

                    if (line.Contains("set SKIP_KASPERSKY_SCAN=no") && checkedItems.Contains("Skip KVRT Scan"))
                    {
                        lineToChange = line.Replace("set SKIP_KASPERSKY_SCAN=no", "set SKIP_KASPERSKY_SCAN=yes");
                    }
                    else if (line.Contains("set SKIP_KASPERSKY_SCAN=yes") && !checkedItems.Contains("Skip KVRT Scan"))
                    {
                        lineToChange = line.Replace("set SKIP_KASPERSKY_SCAN=yes", "set SKIP_KASPERSKY_SCAN=no");
                    }

                    if (line.Contains("set SKIP_MBAM_INSTALL=no") && checkedItems.Contains("Skip MBAM Install"))
                    {
                        lineToChange = line.Replace("set SKIP_MBAM_INSTALL=no", "set SKIP_MBAM_INSTALL=yes");
                    }
                    else if (line.Contains("set SKIP_MBAM_INSTALL=yes") && !checkedItems.Contains("Skip MBAM Install"))
                    {
                        lineToChange = line.Replace("set SKIP_MBAM_INSTALL=yes", "set SKIP_MBAM_INSTALL=no");
                    }

                    if (line.Contains("set SKIP_PATCHES=no") && checkedItems.Contains("Skip Software Patches"))
                    {
                        lineToChange = line.Replace("set SKIP_PATCHES=no", "set SKIP_PATCHES=yes");
                    }
                    else if (line.Contains("set SKIP_PATCHES=yes") && !checkedItems.Contains("Skip Software Patches"))
                    {
                        lineToChange = line.Replace("set SKIP_PATCHES=yes", "set SKIP_PATCHES=no");
                    }

                    if (line.Contains("set SKIP_PAGEFILE_RESET=no") && checkedItems.Contains("Skip PageFile Reset"))
                    {
                        lineToChange = line.Replace("set SKIP_PAGEFILE_RESET=no", "set SKIP_PAGEFILE_RESET=yes");
                    }
                    else if (line.Contains("set SKIP_PAGEFILE_RESET=yes") && !checkedItems.Contains("Skip PageFile Reset"))
                    {
                        lineToChange = line.Replace("set SKIP_PAGEFILE_RESET=yes", "set SKIP_PAGEFILE_RESET=no");
                    }

                    if (line.Contains("set SKIP_REGPERMS_RESET=no") && checkedItems.Contains("Skip Registry Reset"))
                    {
                        lineToChange = line.Replace("set SKIP_REGPERMS_RESET=no", "set SKIP_REGPERMS_RESET=yes");
                    }
                    else if (line.Contains("set SKIP_REGPERMS_RESET=yes") && !checkedItems.Contains("Skip Registry Reset"))
                    {
                        lineToChange = line.Replace("set SKIP_REGPERMS_RESET=yes", "set SKIP_REGPERMS_RESET=no");
                    }

                    if (line.Contains("set SKIP_SOPHOS_SCAN=no") && checkedItems.Contains("Skip SAV Scan"))
                    {
                        lineToChange = line.Replace("set SKIP_SOPHOS_SCAN=no", "set SKIP_SOPHOS_SCAN=yes");
                    }
                    else if (line.Contains("set SKIP_SOPHOS_SCAN=yes") && !checkedItems.Contains("Skip SAV Scan"))
                    {
                        lineToChange = line.Replace("set SKIP_SOPHOS_SCAN=yes", "set SKIP_SOPHOS_SCAN=no");
                    }

                    if (line.Contains("set SKIP_TELEMETRY_REMOVAL=no") && checkedItems.Contains("Skip Telemetry Reset"))
                    {
                        lineToChange = line.Replace("set SKIP_TELEMETRY_REMOVAL=no", "set SKIP_TELEMETRY_REMOVAL=yes");
                    }
                    else if (line.Contains("set SKIP_TELEMETRY_REMOVAL=yes") && !checkedItems.Contains("Skip Telemetry Reset"))
                    {
                        lineToChange = line.Replace("set SKIP_TELEMETRY_REMOVAL=yes", "set SKIP_TELEMETRY_REMOVAL=no");
                    }

                    if (line.Contains("set SKIP_WINDOWS_UPDATES=no") && checkedItems.Contains("Skip Windows Updates"))
                    {
                        lineToChange = line.Replace("set SKIP_WINDOWS_UPDATES=no", "set SKIP_WINDOWS_UPDATES=yes");
                    }
                    else if (line.Contains("set SKIP_WINDOWS_UPDATES=yes") && !checkedItems.Contains("Skip Windows Updates"))
                    {
                        lineToChange = line.Replace("set SKIP_WINDOWS_UPDATES=yes", "set SKIP_WINDOWS_UPDATES=no");
                    }

                    if (line.Contains("set VERBOSE=no") && checkedItems.Contains("Verbose Mode"))
                    {
                        lineToChange = line.Replace("set VERBOSE=no", "set VERBOSE=yes");
                    }
                    else if (line.Contains("set VERBOSE=yes") && !checkedItems.Contains("Verbose Mode"))
                    {
                        lineToChange = line.Replace("set VERBOSE=yes", "set VERBOSE=no");
                    }

                    sb.AppendLine(lineToChange);
                }
                //Close the file
                tronWrite.Close();
            }

            //Write the file
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Write, FileShare.None))
            {
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine(sb.ToString());
                streamWriter.Close();
                fileStream.Close();
            }
            //Inform user of change
            MessageBox.Show("Changes saved", "Operation Complete",
                MessageBoxButtons.OK);
        }
        
        //Allows manual tools to run from the listbox.
        //They should run as administrator.
        private void manualToolsRunButton_Click(object sender, EventArgs e)
        {
            string tool = manualToolsListBox.Items.ToString();
            int i = manualToolsListBox.SelectedIndex;
            System.Diagnostics.Process.Start(manualTools[i]);
        }

        //Add a script menu button
        private void addAScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Initializing the variables
            string scriptName;
            string scriptLocation;

            //Open file dialog to get the script location
            OpenFileDialog scriptDialog = new OpenFileDialog();
            scriptDialog.DefaultExt = "*.*";
            DialogResult scriptDialogResult = scriptDialog.ShowDialog();
            if (scriptDialogResult == DialogResult.OK)
            {
                scriptLocation = scriptDialog.FileName;
                label1.Text = scriptLocation;
                //addScriptForm testDialog = new addScriptForm();

                //Open the form for user to input the name of the script
                using (addScriptForm testDialog = new addScriptForm())
                { // Show testDialog as a modal dialog and determine if DialogResult = OK.
                    testDialog.ShowDialog();
                    label2.Text = testDialog.ScriptName;
                    scriptName = testDialog.ScriptName;
                }


                //Open scriptConfig.xml to modify and save new script
                XElement xnewScript = XElement.Load(@"J:\CIS-TronScript-Toolbox-master\CIS TronScript Toolbox\scriptConfig.xml");

                //Add name of script and file
                //XML elements will look like <Script>
                //                               <name> user input </name>
                //                               <file> filelocation </file>
                //                            </Script>
                //Modify this for further options if necessary
                xnewScript.Add(new XElement("Script", 
                    new XElement("name", scriptName),
                    new XElement("file", scriptLocation)));

                //Save xml
                xnewScript.Save(@"J:\CIS-TronScript-Toolbox-master\CIS TronScript Toolbox\scriptConfig.xml");

            }
            else
                return;


            

        }

        //Close the program
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void removeScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (removeScriptForm testDialog = new removeScriptForm())
            { 
                testDialog.ShowDialog();
            }

        }

        private void renameScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Can perhaps take the code from removeScriptForm and modify it so that it returns user selection
            //and the script gets removed or added here. It'd make this main form code a little longer, though. Perhaps best to keep them isolated.
           // using ()

            using (renameScriptForm testDialog = new renameScriptForm())
            {
                testDialog.ShowDialog();
            }

            //Need to write code to refresh the dropdown menu with the updated name here. Otherwise this works.

            scriptsToolStripMenuItem.DropDownItems.Clear();

            //Initializing the Script drop-down menu items
            XElement config = XElement.Load(@"J:\CIS-TronScript-Toolbox-master\CIS TronScript Toolbox\scriptConfig.xml");
            IEnumerable<XElement> scripts = config.Elements();
            int count = config.Descendants("name").Count();

            ToolStripMenuItem[] Scripts = new ToolStripMenuItem[count];
            int i = 0;
            foreach (var script in scripts)
            {
                //This code was sort of bad
                //scriptsToolStripMenuItem.DropDownItems.Add(script.Element("name").Value);
                //scriptsToolStripMenuItem.DropDownItemClicked += new ToolStripItemClickedEventHandler(RunScript);

                //This dynamically creates new menu item with the name of the script
                //It also links the menu item with a dynamic event-handler
                Scripts[i] = new ToolStripMenuItem();
                Scripts[i].Name = script.Element("file").Value;
                Scripts[i].Tag = script.Element("file").Value;
                Scripts[i].Text = script.Element("name").Value;
                Scripts[i].Click += new EventHandler(RunScript);
                i++;
            }

            //Add each script as a drop down item
            scriptsToolStripMenuItem.DropDownItems.AddRange(Scripts);

            //Don't minimize this window on load
            this.WindowState = FormWindowState.Normal;
            

        }



   
    }
}
