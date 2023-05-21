using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beecrowd
{
    public static class _1005
    {
        public static void Resolve()
        {
            double A = Convert.ToDouble(Console.ReadLine());
            double B = Convert.ToDouble(Console.ReadLine());
            var MEDIA = ((A * 3.5) + (B * 7.5)) / 11;
            Console.WriteLine(string.Concat("MEDIA = ", MEDIA.ToString("F5")));
        }
    }
}
