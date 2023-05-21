using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beecrowd
{
    public static class _1004
    {
        public static void Resolve()
        {
            int A = Convert.ToInt32(Console.ReadLine());
            int B = Convert.ToInt32(Console.ReadLine());
            int PROD = A * B;
            Console.WriteLine(string.Concat("PROD = ", PROD));
        }
    }
}
