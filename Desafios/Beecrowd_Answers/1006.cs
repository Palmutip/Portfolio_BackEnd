using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beecrowd
{
    public static class _1006
    {
        public static void Resolve()
        {
            double A = Convert.ToDouble(Console.ReadLine());
            double B = Convert.ToDouble(Console.ReadLine());
            double C = Convert.ToDouble(Console.ReadLine());
            var MEDIA = ((A * 2) + (B * 3) + (C * 5)) / 10;
            Console.WriteLine(string.Concat("MEDIA = ", MEDIA.ToString("F1")));
        }
    }
}
