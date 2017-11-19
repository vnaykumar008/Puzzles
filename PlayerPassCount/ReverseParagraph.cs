using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerPassCount
{
    class ReverseParagraph
    {
        string _paragraph;
        StringBuilder reverseParagraphBuilder = new StringBuilder();
        public ReverseParagraph(string paragraph)
        {
            _paragraph = paragraph;
        }

        public string GetReverseParagraph()
        {
            string[] words = _paragraph.Split('\n','\r', ' ');
            foreach (string word in words)
            {
                reverseParagraphBuilder.Append(ReverseString(word) + " ");
            }
            return reverseParagraphBuilder.ToString();
        }

        private string ReverseString(string stringReverse)
        {
            StringBuilder wordSB = new StringBuilder();
            for (int i = stringReverse.Length-1; i >= 0; i--)
            {
                wordSB.Append(stringReverse[i]);
            }
            return wordSB.ToString();
        }
    }
}
