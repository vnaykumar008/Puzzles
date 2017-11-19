using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerPassCount
{

    #region palindrome
    /// <summary>
    /// How to find given data(different type of datatype inputs) is palindrom or not.
    /// </summary>
    public class Palindrome
    {
        public void IsPalindrome(string name)
        {
            //2.Palindrome
            //Palindrome<string> palindromeStirng = new Palindrome<string>();
            //Console.WriteLine(palindromeStirng.IsPalindrome("abb").ToString());
            //Console.ReadKey();

            //Palindrome<int> palindromeint = new Palindrome<int>();
            //Console.WriteLine(palindromeint.IsPalindrome(242));
            //Console.ReadKey();

            //3.Palindrome
            string strObj = "abcba";
            StringBuilder str1 = new StringBuilder();
            StringBuilder str2 = new StringBuilder();

            for (int i = 0, j = strObj.Length - 1; i < strObj.Length / 2; i++, j--)
            {
                str1.Append(strObj[i]);
                str2.Append(strObj[j]);
            }

            if (str1.Equals(str2))
                Console.Write("Palindrome");

        }
    }


    public class Palindrome<T>
    {
        public bool IsPalindrome(T objInpput)
        {
            Type objType = objInpput.GetType();

            switch (objType.Name)
            {
                case "String":
                    char[] strArray = new char[objInpput.ToString().Length];
                    for (int i = objInpput.ToString().Length - 1, j = 0; i >= 0; i--, j++)
                    {
                        strArray[j] = objInpput.ToString().ElementAt(i);
                    }
                    string tempComp = new string(strArray);
                    if (tempComp == objInpput.ToString())
                        return true;
                    break;
                case "Int16":
                case "Int32":
                    object temp = objInpput;
                    int num, reverse = 0, remainder = 0;
                    num = (int)temp;
                    while (num > 0)
                    {
                        remainder = num % 10;
                        reverse = reverse * 10 + remainder;
                        num /= 10;
                    }

                    if ((int)temp == reverse)
                        return true;
                    break;
                default:
                    return false;

            }
            return false;
        }
    }

    #endregion

}
