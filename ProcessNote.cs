using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProcessNote
{
    public partial class ProcessNote : Form
    {
        public ProcessNote()
        {
            InitializeComponent();
            dataGridView2.Visible = false;
            RefreshSelected.Visible = false;
        }

        private void ProcessNote_Load(object sender, EventArgs e)
        {
            LoadAllProcesses();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                dataGridView2.Visible = false;
                dataGridView2.Rows.RemoveAt(0);
            }
            LoadSelectedProcess();
            dataGridView2.Visible = true;
            RefreshSelected.Visible = true;
        }

        private void RefreshAll_Click(object sender, EventArgs e)
        {            
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            RefreshSelected.Visible = false;
            dataGridView1.Rows.Clear();
            LoadAllProcesses();
            dataGridView1.Visible = true;
        }

        private void RefreshSelected_Click(object sender, EventArgs e)
        {
            
            dataGridView2.Visible = false;
            dataGridView2.Rows.RemoveAt(0);
            LoadSelectedProcess();
            dataGridView2.Visible = true;

        }

        private void SaveNotes_Click(object sender, EventArgs e)
        {
            string notes = textBox1.Text;
            Note.Notes = notes;
            SaveNotes.Text = "All saved";
            SaveNotes.BackColor = Color.SpringGreen;

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            SaveNotes.Text = "Save Notes";
            SaveNotes.BackColor = Color.LightSalmon;
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.TopMost = true;
            } else
            {
                this.TopMost = false;
            }
        }

        private void LoadAllProcesses()
        {
            List<Array> allProcess = RunningProcesses.GetProcess();

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

        private void LoadSelectedProcess()
        {
            int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            List<Array> selectedProcess = RunningProcesses.GetProcessById(selectedId);

            dataGridView2.ColumnCount = 6;
            dataGridView2.Columns[0].Name = "Process ID";
            dataGridView2.Columns[1].Name = "Process Name";
            dataGridView2.Columns[2].Name = "CPU usage";
            dataGridView2.Columns[3].Name = "Memory usage";
            dataGridView2.Columns[4].Name = "Running time";
            dataGridView2.Columns[5].Name = "Start time";


            string id = (string)selectedProcess.ElementAt(0).GetValue(0);
            string rowName = (string) selectedProcess.ElementAt(0).GetValue(1);
            string cpu = (string)selectedProcess.ElementAt(0).GetValue(2);
            string memory = (string)selectedProcess.ElementAt(0).GetValue(3);
            string runningTime = (string)selectedProcess.ElementAt(0).GetValue(4);
            string startTime = (string)selectedProcess.ElementAt(0).GetValue(5);

            dataGridView2.Rows.Add(id, rowName, cpu, memory, runningTime, startTime);  
        }

    }
}
