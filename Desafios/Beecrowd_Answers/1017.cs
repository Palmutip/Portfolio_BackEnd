using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beecrowd
{
    public static class _1017
    {
        public static void Resolve()
        {
            int tempo;
            int velo;
            tempo = Convert.ToInt32(Console.ReadLine());
            velo = Convert.ToInt32(Console.ReadLine());
            double media, t, v;
            t = tempo;
            v = velo;
            media = (t * v) / 12;
            Console.WriteLine(media.ToString("F3"));
        }
    }
}
