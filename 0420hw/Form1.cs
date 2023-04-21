using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _0420hw
{
    public partial class Form1 : Form
    {
        Process[] processes;
        public Form1()
        {
            InitializeComponent();
            LoadProcesses();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadProcesses();

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                if(process.ProcessName== listView1.SelectedItems[0].Text)
                {
                    process.Kill();
                    LoadProcesses();
                    break;
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                Process proc = new Process();
                proc.StartInfo.FileName = textBox1.Text;
                proc.Start();
                LoadProcesses();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void LoadProcesses()
        {
            processes = Process.GetProcesses();
            foreach (Process process in processes)
                listView1.Items.Add(process.ProcessName).SubItems.Add(process.Id.ToString());
        }
    }
}
