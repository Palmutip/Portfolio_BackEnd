using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Tecnologia.RDStation.Model
{
    public class Token
    {
        //public Token(string acessToken, string expiresIn, string refreshToken) 
        //{
        //    AccessToken = acessToken;
        //    ExpiresIn = expiresIn;
        //    RefreshToken = refreshToken;
        //}

        public string AccessToken { get; set; }
        public string ExpiresIn { get; set; }
        public string RefreshToken { get; set; }

    }
}
