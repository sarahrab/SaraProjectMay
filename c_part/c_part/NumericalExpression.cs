using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_part
{
    public class NumericalExpression
    {
        private long number;

        private Dictionary<long, string> translations = new Dictionary<long, string>()
        {
            { 0, "zero" },
            { 1, "one" },
            { 2, "two" },
            { 3, "three" },
            { 4, "four" },
            { 5, "five" },
            { 6, "six" },
            { 7, "seven" },
            { 8, "eight" },
            { 9, "nine" },
            { 10, "ten" },
            { 11, "eleven" },
            { 12, "twelfe" },
            { 13, "thirteen" },
            { 14, "fourteen" },
            { 15, "fifteen" },
            { 16, "sixteen" },
            { 17, "seventeen" },
            { 18, "eigthteen" },
            { 19, "nineteen" },
            { 20, "twenty" },
            { 30, "thirty" },
            { 40, "fourty" },
            { 50, "fifty" },
            { 60, "sixty" },
            { 70, "seventy" },
            { 80, "eighty" },
            { 90, "ninety" },
            { 100, "hundred" },
            { 1000, "thousand" },
            { 1000000, "million" },
            { 1000000000, "billion" },
            { 1000000000000, "trillion" },
        };

        public NumericalExpression(long number)
        {
            this.number = number;
        }

        public long GetValue()
        {
            return number;
        }

        public override string ToString()
        {
            return LongToString(number);
        }

        private string LongToString(long num)
        {
            if (num <= 20)
            {
                return translations[num];
            }
            string result = "";
            string inputString = num.ToString();
            int len = inputString.Length;
            int divided = len / 3;
            if (len % 3 > 0)
            {
                divided++;
            }
            for (int i = 0; i < divided; i++)
            {
                int count = 3;
                int pos = len - 3 * (i + 1);
                if (pos < 0)
                {
                    count = 3 + pos;
                    pos = 0;
                }
                string trio = inputString.Substring(pos, count);
                string translated = TrioTranslate(trio);
                long decideZeros = (long)Math.Pow(10, i * 3);
                string decided = i == 0 ? "" : " " + translations[decideZeros];
                result = translated + decided + " " + result;
            }
            return result;
        }

        private string TrioTranslate(string trio)
        {
            string result = "";
            int trioNum = int.Parse(trio);
            int hundreds = trioNum / 100;
            if(hundreds > 0)
            {
                result = translations[hundreds] + " " + translations[100];
            }
            trioNum -= hundreds * 100;
            if (trioNum<= 20)
            {
                result += " "+ translations[trioNum];
            }
            else
            {
                int tens = trioNum / 10;
                if(tens > 0)
                {
                     result += " "+ translations[tens * 10];
                }
                trioNum -= tens * 10;
                if(trioNum > 0)
                {
                    result += " " + translations[trioNum];
                }
            }
            return result;
        }

        public int SumLetters(int num)
        {
            return LongToString(num).Replace(" ", "").Length;
        }

        //polymorphism
        public int SumLetters(NumericalExpression numericalExpression)
        {
            return LongToString(numericalExpression.GetValue()).Replace(" ", "").Length;
        }

        public string LongToString(long num, Func<long, string> translate)
        {
            if (num <= 20)
            {
                return translate(num);
            }
            string result = "";
            string inputString = num.ToString();
            int len = inputString.Length;
            int divided = len / 3;
            if (len % 3 > 0)
            {
                divided++;
            }
            for (int i = 0; i < divided; i++)
            {
                int count = 3;
                int pos = len - 3 * (i + 1);
                if (pos < 0)
                {
                    count = 3 + pos;
                    pos = 0;
                }
                string trio = inputString.Substring(pos, count);
                string translated = TrioTranslate(trio, translate);
                long decideZeros = (long)Math.Pow(10, i * 3);
                string decided = i == 0 ? "" : " " + translate(decideZeros);
                result = translated + decided + " " + result;
            }
            return result;
        }

        private string TrioTranslate(string trio, Func<long, string> translate)
        {
            string result = "";
            int trioNum = int.Parse(trio);
            int hundreds = trioNum / 100;
            if (hundreds > 0)
            {
                result = translate(hundreds) + " " + translate(100);
            }
            trioNum -= hundreds * 100;
            if (trioNum <= 20)
            {
                result += " " + translate(trioNum);
            }
            else
            {
                int tens = trioNum / 10;
                if (tens > 0)
                {
                    result += " " + translate(tens * 10);
                }
                trioNum -= tens * 10;
                if (trioNum > 0)
                {
                    result += " " + translate(trioNum);
                }
            }
            return result;
        }
    }
}
