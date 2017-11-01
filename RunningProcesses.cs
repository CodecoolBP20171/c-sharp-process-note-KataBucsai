using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace ProcessNote
{
    public class RunningProcesses
    {
        public static List<Array> GetProcess()
        {
            List<Array> allProcess = new List<Array>();
            allProcess.Clear();
            Process[] processArray = Process.GetProcesses();
            foreach (Process process in processArray)
            {
                InitProcessData(process, allProcess);
            }
            return allProcess;
        }

        public static List<Array> GetProcessById(int Id)
        {
            Process process = Process.GetProcessById(Id);
            List<Array> selectedProcess = new List<Array>();
            InitProcessData(process, selectedProcess);
            return selectedProcess;
        }

        private static void InitProcessData(Process process, List<Array> Process)
        {
            try
            {
                string[] processDetails = new string[6];
                processDetails[0] = process.Id.ToString();
                processDetails[1] = process.ProcessName.ToString();
                processDetails[2] = process.TotalProcessorTime.ToString();
                processDetails[3] = process.PagedMemorySize64.ToString();
                processDetails[4] = (DateTime.Now - process.StartTime).ToString();
                processDetails[5] = process.StartTime.ToString();
                Process.Add(processDetails);

            }
            catch (Exception e)
            {
            }
        }
    }
}