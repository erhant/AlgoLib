using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class TextAlgorithms
    {
        public static string ReverseText(string text)
        {
            char[] textArr = text.ToArray();
            char tmpc;
            for (int i = 0; i < text.Length / 2; i++)
            {
                tmpc = textArr[i];
                textArr[i] = textArr[text.Length - i - 1];
                textArr[text.Length - i - 1] = tmpc;
            }
            return new string(textArr);
        }
        public static int[] SearchRecurrence(string text, string search)
        {
            List<int> positions = new List<int>();
            char[] textArr = text.ToArray();
            char[] searchArr = search.ToArray();
            int k;
            for (int i = 0; i < text.Length - search.Length; i++)
            {
                if (textArr[i] == searchArr[0])
                {
                    k = i;
                    while (k < search.Length + i && textArr[k] == searchArr[k - i])
                    {
                        k++;
                    }
                    if (k == search.Length + i)
                    {
                        positions.Add(i);
                    }
                }
                /* We dont do i = k after this because there might be cases like below:
                 * TEXT : patpatpatpat
                 * SEARCH : patpat
                 * If we did i = k:
                 * We would find 2 patpat's,
                 * If we dont do that we find 3 patpat's.
                 * So when the text we search has recurring words in it itself this issue becomes important
                 */
            }
            return positions.ToArray();
        }
        public static string ToRobotLanguage(string text)
        {
            text = text.Replace("a", "4");
            text = text.Replace("A", "4");
            text = text.Replace("e", "3");
            text = text.Replace("E", "3");
            text = text.Replace("o", "0");
            text = text.Replace("O", "0");
            text = text.Replace("i", "1");
            text = text.Replace("I", "1");
            text = text.Replace("z", "7");
            text = text.Replace("Z", "7");
            return text;
        }
    }
}
