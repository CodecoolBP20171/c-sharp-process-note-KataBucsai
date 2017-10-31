using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace ProcessNote
{
    public class RunningProcesses
    {

        public static Process[] getProcessAllArray()
        {
            return Process.GetProcesses();
        }

        public static List<Array> getProcess()
        {
            List<Array> allProcess = new List<Array>();

            Process[] processArray = Process.GetProcesses();
            foreach (Process process in processArray)
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
                    allProcess.Add(processDetails);
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }    
            }
            return allProcess;
        }
    }

}