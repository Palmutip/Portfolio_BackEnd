using System;
using System.Collections.Generic;
using System.Text;

namespace Comuns
{
    public class Criptografia
    {
        public static string Cript(string pStrCript)
        {
            int contEcpt;
            int raizEcpt;
            int charEcpt;
            raizEcpt = 1;
            string strCript = string.Empty;

            if (pStrCript == string.Empty)
            {
                return string.Empty;
            }

            for (contEcpt = pStrCript.Length; contEcpt >= 1; --contEcpt)
            {
                var valor = pStrCript.Substring(contEcpt - 1, 1);
                charEcpt = Asc(valor);
                charEcpt = charEcpt - raizEcpt;
                strCript = Chr(280 - charEcpt) + strCript;
                raizEcpt = raizEcpt + 2;

                if (raizEcpt >= 6)
                {
                    raizEcpt = raizEcpt - 5;
                }
            }

            return strCript;
        }

        public static int Asc(string letra)
        {
            return (int)(Convert.ToChar(letra));
        }

        public static char Chr(int codigo)
        {

            return (char)codigo;
        }

    }
}
