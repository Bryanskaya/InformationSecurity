using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04
{
    class MathFuncs
    {
        public static bool IsSimple(int num)
        {
            double temp = Math.Sqrt(num);

            for (int i = 2; i < temp; i++)
                if (num % i == 0)
                    return false;

            return true;                
        }

        public static int fi(int p, int q)
        {
            return (p - 1) * (q - 1);
        }

        public static int GCD(int a, int b)
        {
            int tempA;

            while (b != 0)
            {
                tempA = b;
                b = a - b;
                a = tempA;
            }

            return a;
        }
    }
}
