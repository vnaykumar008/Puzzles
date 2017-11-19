using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileUtillities;
using System.Diagnostics;

namespace GetProcessLockingFile
{
    class Program
    {
        static void Main(string[] args)
        {
            DetectOpenFiles objDetectOpenFiles = new DetectOpenFiles();
            List<Process> lst = new List<Process>();
            Stopwatch t = Stopwatch.StartNew();
            
            {
                t.Start();
                lst = DetectOpenFiles.GetProcessesUsingFile(@"C:\Users\Vinay Nadiminti\Desktop\1.docx");
                foreach (Process process in lst)
                {
                    Console.WriteLine(process.ProcessName);
                }
                Console.WriteLine(t.ElapsedMilliseconds);
                t.Reset();
            }
            
            Console.WriteLine("-------------------Other Way---------------");

            {
                t.Start();
                lst = FileUtillities.FileUtilities_OtherApproach.WhoIsLocking(@"c:\Users\Vinay Nadiminti\Desktop\1.docx");
                foreach (Process process in lst)
                {
                    Console.WriteLine(process.ProcessName);
                }
                Console.WriteLine(t.ElapsedMilliseconds);
                t.Stop();
            }
            
            Console.Read();
        }
    }
}

