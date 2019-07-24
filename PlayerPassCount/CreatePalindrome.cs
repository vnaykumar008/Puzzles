using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerPassCount
{
    public class CreatePalindrome
    {
        public int PalindromeMakingCount(string input)
        {
            List<char> arrayList = input.ToList();
            int makingCount = 0;
            for (int startindex = 0, endindex = input.Length - 1; startindex < endindex; startindex++)
            {
                if (arrayList[startindex] == arrayList[endindex])
                {
                    endindex--;
                    continue;
                }
                else
                {
                    arrayList.Insert(endindex + 1, arrayList[startindex]);
                    makingCount++;
                }
            }
            return makingCount;
        }
    }
}
