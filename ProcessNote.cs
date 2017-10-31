using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProcessNote
{
    public partial class ProcessNote : Form
    {
        public ProcessNote()
        {
            InitializeComponent();
            dataGridView2.Visible = false;
        }

        private void ProcessNote_Load(object sender, EventArgs e)
        {
            LoadAllProcesses();
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void LoadAllProcesses()
        {
            List<Array> allProcess = RunningProcesses.getProcess();

            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Process ID";
            dataGridView1.Columns[1].Name = "Process Name";

            foreach (Array process in allProcess)
            {
                string rowName = (string)process.GetValue(1);
                string id = (string)process.GetValue(0);
                dataGridView1.Rows.Add(id, rowName);
            }
        }
    }
}
