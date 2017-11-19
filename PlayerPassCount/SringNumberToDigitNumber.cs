using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerPassCount
{

    class SringNumberToDigitNumber
    {
        string[] stringNumbersArray = new string[5];
        public SringNumberToDigitNumber()
        {
            stringNumbersArray[0] = "One";
            stringNumbersArray[1] = "One thousand one hundred six";
            stringNumbersArray[2] = "nine hundred";
            stringNumbersArray[3] = "seventy five";
            stringNumbersArray[4] = "two thousand four hundred thirty eight";
        }

        public void ConvertStringToInt()
        {
            for (int i = 0; i < stringNumbersArray.Length; i++)
            {
                string sNumbers = stringNumbersArray[i];
                string[] sNumber = sNumbers.Split(' ');
                int result = 0;
                int temp = 0;
                //TODO - InComplete
                for (int j = 0; j < sNumber.Length; j++)
                {
                    temp = ConvertStringIntoSingleDigit(sNumber[j]);
                    if(temp == 100 || temp == 1000)
                    {
                        if (result == 0)
                            result = temp;
                        result *= result;
                    }
                }


            }
        }

        private int ConvertStringIntoSingleDigit(string sDigit)
        {
            switch (sDigit.ToLower())
            {
                case "one": return 1;
                case "two": return 2;
                case "three": return 3;
                case "four": return 4;
                case "five": return 5;
                case "six": return 6;
                case "seven": return 7;
                case "eight": return 8;
                case "nine": return 9;
                case "hundred": return 100;
                case "thousand": return 1000;
                
                default: return 0;
            }
        }

        enum Numbers
        {
            One, Two, Three, Four, Five, Six, Seven, Eight, Nine, zero
        }
    }
}
