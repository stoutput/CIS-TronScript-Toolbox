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
        public Queue<Process> Processes = new Queue<Process>();

        public Toolbox()
        {
            InitializeComponent();
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
    }
}
