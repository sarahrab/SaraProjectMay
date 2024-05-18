using System;
using System.Collections.Generic;
using System.Linq;

namespace c_part
{
    class Program
    {
        static void Main(string[] args)
        {
            NumericalExpression numericalExpression = new NumericalExpression(1234567890);
            string res = numericalExpression.ToString();
            Console.WriteLine(res);

            Translatttt(numericalExpression);
            //IEnumerable<char> s = res.ToArray().Where(c => c != ' ');
            //Console.WriteLine(new string(s.ToArray()));
        }

        static void Translatttt(NumericalExpression numericalExpression)
        {
            Console.WriteLine(numericalExpression.ToString());
            Console.WriteLine(numericalExpression.LongToString(numericalExpression.GetValue(), TranslateItalian));
        }

        static string TranslateItalian(long num)
        {
            Dictionary<long, string> translations = new Dictionary<long, string>()
            {
                { 0, "zero" },
                { 1, "uno" },
                { 2, "due" },
                { 3, "tre" },
                { 4, "quatro" },
                { 5, "cinque" },
                { 6, "sei" },
                { 7, "sette" },
                { 8, "otto" },
                { 9, "nove" },
                { 10, "dieci" },
                { 11, "eleven" },
                { 12, "dodici" },
                { 13, "tredici" },
                { 14, "quatordici" },
                { 15, "cinquedici" },
                { 16, "sixteen" },
                { 17, "seventeen" },
                { 18, "eigthteen" },
                { 19, "dicinove" },
                { 20, "venti" },
                { 30, "trenta" },
                { 40, "quaranta" },
                { 50, "cinquanta" },
                { 60, "sesanta" },
                { 70, "seventy" },
                { 80, "eighty" },
                { 90, "ninety" },
                { 100, "cento" },
                { 1000, "mila" },
                { 1000000, "million" },
                { 1000000000, "billion" },
                { 1000000000000, "trillion" },
            };
            return translations[num];
        }
    }
}
