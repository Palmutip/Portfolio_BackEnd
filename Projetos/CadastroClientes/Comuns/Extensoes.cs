using System;
using System.Collections.Generic;
using System.Text;

namespace Comuns
{
    public static class Extensoes
    {
        public static bool IsNullOrEmpty(this object dado)
        {
            if (dado == null)
                return true;
            if (dado.ToString() == "" || dado.ToString() == string.Empty)
                return true;
            return false;
        }
    }
}
