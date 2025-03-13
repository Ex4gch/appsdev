using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace calc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Console.WriteLine(calc(s));
        }

        static double calc(string s)
        {
            string num = "";
            int j = 0;
            double total = 0;
            bool isFirst = true;
            char last = '\0';

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '+' || s[i] == '-')
                {
                    if (last == '/' || last =='*')
                    {
                        num = "";
                        last = s[i]; 
                        continue;
                    }

                    if (isFirst)
                    {
                        total += double.Parse(num);
                        isFirst = false;
                        last = s[i];
                    }
                    else
                    {
                        if (last == '+') total += double.Parse(num);
                        else total -= double.Parse(num);
                        last = s[i];
                    }
                    num = "";
                }
                else if (s[i] == '/' || s[i] == '*')
                {
                    last = s[i];
                    num = "";
                }
                else num += s[i];
            
                if(i == s.Length - 1 && (last != '/' && last != '*'))
                {
                    if (last == '+') total += double.Parse(num);
                    else total -= double.Parse(num);
                }
            }

            return total;
        }
    }
}
