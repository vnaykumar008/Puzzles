using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerPassCount
{
    public class PlayerPassCount
    {
        public static int PassCount(int playersCount, int maxPasses, int shiftLeftOrRightCount)
        {
            int passCount = 0;
            int i = 0;
            int[] playerPassCount = new int[playersCount];

            playerPassCount[i] = 1;
            while (!playerPassCount.Any(p => p == maxPasses))
            {
                if (playerPassCount[i] % 2 == 0)
                {
                    i = (((i - shiftLeftOrRightCount) % playersCount) + playersCount) % playersCount;
                }
                else
                {
                    i = (i + shiftLeftOrRightCount) % playersCount;
                }

                playerPassCount[i]++;
                passCount++;
            }

            return passCount;
        }
    }

}
