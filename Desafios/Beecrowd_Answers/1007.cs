using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beecrowd
{
    public static class _1007
    {
        public static void Resolve()
        {
            int A = Convert.ToInt32(Console.ReadLine());
            int B = Convert.ToInt32(Console.ReadLine());
            int C = Convert.ToInt32(Console.ReadLine());
            int D = Convert.ToInt32(Console.ReadLine());
            var DIFERENCA = (A * B) - (C * D);
            Console.WriteLine(string.Concat("DIFERENCA = ", DIFERENCA.ToString()));
        }
    }
}
