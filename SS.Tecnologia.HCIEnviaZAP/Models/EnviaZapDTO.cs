using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Tecnologia.HCIEnviaZAP.Models
{
    public class EnviaZapDTO
    {
        private int intervaloDisparo;
        private string mensagem;
        private string numeroTelefone;
        private string Ddd;
        public string Ddi;


        public EnviaZapDTO() 
        {
            DDI = string.Empty;
            DDD = string.Empty;
            NumeroTelefone = string.Empty;
            Mensagem = string.Empty;
        }

        /// <summary>
        /// Numero inteiro que representa o intervalo em segundos entre o disparo entre mais de uma mensagem
        /// </summary>
        public int IntervaloDisparo
        {
            get
            {
                return intervaloDisparo;
            }
            set
            {
                if (value > 30)
                {
                    throw new Exception("Não é possivel definir um intervalo de disparo superior a 30 segundos");
                }
                else if (value < 0)
                {
                    throw new Exception("Não é possivel definir um intervalo de disparo inferior a zero.");
                }
                else if (value == 0 || (value > 0 && value <= 30))
                {
                    value = 5;
                    this.intervaloDisparo = value;
                }
            }
        }

        /// <summary>
        /// Código do País Brasil (+55)
        /// </summary>
        public string DDI
        {
            get
            {
                return Ddi;
            }
            set
            {
                this.Ddi = value;
            }
        }

        /// <summary>
        /// Código de área da região (11,21,35, etc)
        /// </summary>
        public string DDD
        {
            get
            {
                return Ddd;
            }
            set
            {
                this.Ddd = value;
            }
        }

        /// <summary>
        /// Numero de telefone que está associado ao aplicativo WhatsApp
        /// </summary>
        public string NumeroTelefone
        {
            get
            {
                return numeroTelefone;
            }
            set
            {
                this.numeroTelefone = value;
            }
        }

        /// <summary>
        /// Mensagem a ser enviada para o numero de telefone que foi definido
        /// </summary>
        public string Mensagem
        {
            get
            {
                return mensagem;
            }
            set
            {
                this.mensagem = value;
            }
        }
    }
}
