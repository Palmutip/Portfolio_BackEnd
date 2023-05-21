using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beecrowd
{
    public static class _1009
    {
        public static void Resolve()
        {
            string nome = Convert.ToString(Console.ReadLine());
            double salario = Convert.ToDouble(Console.ReadLine());
            double vendas = Convert.ToDouble(Console.ReadLine());
            var TOTAL = salario + (vendas * 0.15);
            Console.WriteLine(string.Concat("TOTAL = R$ ", TOTAL.ToString("F2")));
        }
    }
}
