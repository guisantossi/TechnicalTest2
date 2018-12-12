using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCDNiTaas
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                string input = Console.ReadLine();

                string[] values = input.Trim().Split(' ');
                Solution s = new Solution();

                if (values.Count() == 2)
                {
                    Console.Write(s.Start(values[0], values[1], null, null));
                    Console.ReadLine();
                    break;
                }
                else if (values.Count() == 4)
                {
                    Console.Write(s.Start(values[0], values[1], values[2], values[3]));
                    Console.ReadLine();
                    break;
                }
                else
                    Console.Write("Something is wrong\nTry again\n");
            } while (true);

        }
    }
}
