using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beecrowd
{
    public static class _1002
    {
        public static void Resolve()
        {
            double pi = 3.14159;
            double raio = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(string.Concat("A=",((raio * raio) * pi).ToString("F4")));
        }
    }
}
