using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;

namespace CIS_TronScript_Toolbox
{
    public partial class Toolbox : Form
    {
        public class Process
        {
            public string File {get; set;}
            public string Args {get; set;}
            public Process()
            {
                File = "";
                Args = "";
            }
        }

        //Thread-safe concurrent process collection
        public BlockingCollection<Process> Processes = new BlockingCollection<Process>();
        //Thread-safe background worker
        private BackgroundWorker runProcess;

        //Current user
        public string User = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        public Toolbox()
        {
            InitializeComponent();
        }

        private void runProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            Process process = (Process) e.Argument;
            //run console control process
            consoleControl.StartProcess(process.File, process.Args);
            //write process details to console
            consoleControl.WriteOutput("Running " + process.File + process.Args + " as " + User + "...\n", Color.Green);
            //update form title
            this.Text = "CIS Tronscript Toolbox - " + consoleControl.ProcessInterface.ProcessFileName;
        }

        private void newProcess(string file, string args)
        {
            //create new process struct
            Process process = new Process();
            process.File = file;
            process.Args = args;
            //queue process
            Processes.Add(process);
        }
                
        private void showConsoleButton_Click(object sender, EventArgs e)
        {
            if(consoleControl.Height == 0)
            {
                showConsoleButton.Text = "Hide Console";
                while(consoleControl.Height <= 180)
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
            //Enable console input
            consoleControl.IsInputEnabled = true;

            //Start script processing task
            Task.Run(() =>
            {
                bool processing = false;

                while (!Processes.IsCompleted)
                {
                    Process process = null;
                    //Blocks if number.Count == 0
                    try
                    {
                        process = Processes.Take();
                    }
                    catch (InvalidOperationException) { }

                    if (process != null)
                    {
                        //start new process
                        runProcess = new BackgroundWorker();
                        runProcess.RunWorkerAsync(process);
                        //set processing flag
                        processing = true;
                    }
                    else if (!consoleControl.IsProcessRunning && processing)
                    {
                        //update form title
                        this.Text = "CIS Tronscript Toolbox";
                        //reset processing flag
                        processing = false;
                    }
                }
            });

            if (SystemInformation.BootMode != BootMode.FailSafeWithNetwork)
            {
                DialogResult dialogResult = MessageBox.Show("Boot into safe mode with networking?", "Reboot", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    newProcess("ipconfig", "/all");
                    newProcess("ping", "google.com");
                    //Let process task consumer know we are done adding tasks
                    //Ends processing task
                    Processes.CompleteAdding();

                    //windows 8+
                    //newProcess("bcdedit", " /set {current} safeboot network");
                    //windows 7-
                    //newProcess("bcdedit", " /set {default} safeboot network");
                }
            }
            else
            {
                //bcdedit /deletevalue {default} safeboot (network???) 
            }
        }
    }
}
