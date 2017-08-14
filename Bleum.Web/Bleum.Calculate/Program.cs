using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bleum.Calculate
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 1; i < 31; i++)
            {
                Console.WriteLine("The {0} value is {1}",i,Calculate(i));
            }
            Console.ReadKey();
        }

        static int Calculate(int source)
        {
            if (source==1||source==2)
            {
                return 1;
            }
            else
            {
                return Calculate(source - 1) + Calculate(source - 2);
            }
        }
    }
}
