using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerPassCount
{
    class RecursiveExample
    {
        public int Getfactorial(int factorialNumber)
        {
            if (factorialNumber == 0)
                return 1;

            return factorialNumber * Getfactorial(factorialNumber - 1);
        }

        public void GetFilesAndFoldersInsideTheDiretory(string directoryName)
        {
            DirectoryInfo fileOrDirectory = new DirectoryInfo(directoryName);

            if (fileOrDirectory.Exists)
            {
                FileInfo[] fileInfoArray = fileOrDirectory.GetFiles();
                foreach (FileInfo fileInfo in fileInfoArray)
                {
                    Console.WriteLine(fileInfo.FullName);
                }

                DirectoryInfo[] directoryInfoArray = fileOrDirectory.GetDirectories();
                foreach (DirectoryInfo directoryInfo in directoryInfoArray)
                {
                    Console.WriteLine(directoryInfo.FullName);
                    GetFilesAndFoldersInsideTheDiretory(directoryInfo.FullName);
                }
            }

        }
    }
}
