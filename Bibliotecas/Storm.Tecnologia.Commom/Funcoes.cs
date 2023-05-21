using System.Data.Common;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO.Compression;
using System.Net.Mail;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace SS.Tecnologia.Commom
{
    /// <summary>
    /// Classe estática contendo funções genéricas aplicaveis a qualquer projeto
    /// </summary>
    public static class Funcoes
    {
        /// <summary>
        /// Método para validar o CNPJ
        /// </summary>
        /// <param name="cnpj">string referente ao CNPJ</param>
        /// <returns></returns>
        public static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        /// <summary>
        /// Método para validar o CPF
        /// </summary>
        /// <param name="cpf">string referente ao cpf</param>
        /// <returns></returns>
        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        /// <summary>
        /// Método para enviar um e-mail estático a partir de um arquivo HTML
        /// </summary>
        /// <param name="destinatario">endereço de e-mail do destinatário</param>
        /// <param name="assunto">assunto do e-mail</param>
        /// <param name="caminhoHtml">caminho completo referente ao local do arquivo HTML. Ex: C:\Email\template.html</param>
        /// <param name="emailRemetente">endereço de e-mail do remetente</param>
        /// <param name="senhaEmailRemetente">senha do endereço de e-mail do remetente</param>
        /// <param name="smtpHost">endereço do host do smtp. Necessário pegar dados com o provador do e-mail.</param>
        /// <param name="smptPort">endereço da porta do host do smtp. Necessário pegar dados com o provador do e-mail.</param>
        /// <returns>retorna true se o e-mail foi enviado com sucesso</returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool EnviaEmail(string destinatario, string assunto, string caminhoHtml, string emailRemetente, string senhaEmailRemetente, string smtpHost, int smptPort)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    string html = File.ReadAllText(caminhoHtml);

                    mail.From = new MailAddress(emailRemetente);
                    mail.To.Add(destinatario);
                    mail.Subject = assunto;
                    mail.Body = html.ToString();
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient(smtpHost, smptPort))
                    {
                        smtp.Credentials = new NetworkCredential(emailRemetente, senhaEmailRemetente);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Erro ao enviar e-mail: " + e.Message.ToString());
            }
        }
        
        /// <summary>
        /// Método para enviar um e-mail parametrizado a partir de um arquivo HTML
        /// </summary>
        /// <param name="destinatario">endereço de e-mail do destinatário</param>
        /// <param name="assunto">assunto do e-mail</param>
        /// <param name="caminhoHtml">caminho completo referente ao local do arquivo HTML. Ex: C:\Email\template.html</param>
        /// <param name="emailRemetente">endereço de e-mail do remetente</param>
        /// <param name="senhaEmailRemetente">senha do endereço de e-mail do remetente</param>
        /// <param name="smtpHost">endereço do host do smtp. Necessário pegar dados com o provador do e-mail.</param>
        /// <param name="smptPort">endereço da porta do host do smtp. Necessário pegar dados com o provador do e-mail.</param>
        /// <param name="substituir">dicionario referente aos parametros que serão substituidos no e-mail. Ex: '<!--Parametro 1-->', 'conteudo da string que será substituido no html pelo parametro 1' </param>
        /// <returns>retorna true se o e-mail foi enviado com sucesso</returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool EnviaEmail(string destinatario, string assunto, string caminhoHtml, string emailRemetente, string senhaEmailRemetente, string smtpHost, int smptPort, Dictionary<string, string> substituir)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {


                    string html = File.ReadAllText(caminhoHtml);

                    foreach (KeyValuePair<string, string> valores in substituir)
                    {
                        html = SubstituirUltimaOcorrencia(html, valores.Key, valores.Value);
                    }

                    mail.From = new MailAddress(emailRemetente);
                    mail.To.Add(destinatario);
                    mail.Subject = assunto;
                    mail.Body = html.ToString();
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient(smtpHost, smptPort))
                    {
                        smtp.Credentials = new NetworkCredential(emailRemetente, senhaEmailRemetente);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Erro ao enviar e-mail: " + e.Message.ToString());
            }
        }

        /// <summary>
        /// Substitui uma ocorrencia de string por outra string a escolha.
        /// </summary>
        /// <param name="Source">origem do texto</param>
        /// <param name="Find">string a ser substituida</param>
        /// <param name="Replace">conteúdo da string para entrar no lugar do 'Find'</param>
        /// <returns>retorna o resultado da substituição</returns>
        public static string SubstituirUltimaOcorrencia(string Source, string Find, string Replace)
        {
            int place = Source.LastIndexOf(Find);

            if (place == -1)
                return Source;

            string result = Source.Remove(place, Find.Length).Insert(place, Replace);
            return result;
        }

        /// <summary>
        /// Método para converter um DataTable em Objeto do tipo models
        /// </summary>
        /// <typeparam name="T">Modelo da classe que será convertido</typeparam>
        /// <param name="dt">DataTable que será convertido</param>
        /// <returns>Retorna um models </returns>   
        public static List<T> ToList<T>(DataTable dt)
        {

            // Cria as variáveis
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
            var properties = typeof(T).GetProperties();

            // Realiza a conversão
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name.ToLower()))
                    {
                        try
                        {
                            if (row[pro.Name].ToString().Equals("")) { pro.SetValue(objT, null, null); }
                            else
                            {
                                if (row[pro.Name].GetType().Equals(typeof(int))) { pro.SetValue(objT, row[pro.Name].ToLong(), null); }
                                else { pro.SetValue(objT, row[pro.Name], null); }
                            } 
                        } 
                        catch { throw; }
                    } 
                } 
                return objT;
            }).ToList();

        }

        /// <summary>
        /// Método para remover os acentos de uma string
        /// </summary>
        /// <param name="texto">conteúdo do texto que se deseja verificar os caracteres</param>
        /// <returns></returns>
        public static string RetiraAcentos(string texto)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = texto.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letra in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letra) != UnicodeCategory.NonSpacingMark)
                { sbReturn.Append(letra); }
            }

            return sbReturn.ToString();
        }

        /// <summary>
        /// Método para converter um dia da semana em extenso
        /// </summary>
        /// <param name="diaSemana">inteiro referente ao dia da semana. Ex: DateTime.Now.Day/param>
        /// <returns>Extenso do dia da semana</returns>
        public static string ExtensoDiaSemana(int diaSemana)
        {
            switch (diaSemana)
            {
                case 1: return "Domingo";
                case 2: return "Segunda-Feira";
                case 3: return "Terça-Feira";
                case 4: return "Quarta-Feira";
                case 5: return "Quinta-Feira";
                case 6: return "Sexta-Feira";
                case 7: return "Sábado";
                default: return "";
            }
        }

        /// <summary>
        /// Método para inserir a primeira letra em maiúsculo
        /// </summary>
        /// <param name="texto">Informação em string</param>
        /// <returns>Retorna os dados com a primeira letra em maiúsculo</returns>
        public static string PrimeiraLetraMaiscula(string texto)
        {
            return string.Concat(texto.First().ToString().ToUpper(), texto.Substring(1, texto.Length - 1).ToLower());
        } 

        /// <summary>
        /// Verifica se string possui apenas número
        /// </summary>
        /// <returns>Retorna true se houver somente números caso contrário irá retornar false</returns>
        public static bool SomenteNumero(string texto)
        {
            if (texto.Where(c => char.IsLetter(c)).Count() > 0) { return false; }
            else { return true; }
        } 

        /// <summary>
        /// Método para validar a força da senha
        /// </summary>
        /// <param name="senha">string representando a senha</param>
        /// <exception cref="ArgumentException"></exception>
        public static void ValidaRequisitosSenha(string senha)
        {
            if (senha.Length < 8)
            {
                throw new ArgumentException("Senha muito curta, minimo 8 caracteres");
            }

            if (!senha.Any(x => char.IsDigit(x)))
            {
                throw new ArgumentException("Deve Conter numeros");
            }

            if (!senha.Any(x => char.IsUpper(x)))
            {
                throw new ArgumentException("Deve Conter Letra Maiuscula");
            }

            if (!senha.Any(x => char.IsLower(x)))
            {
                throw new ArgumentException("Deve Conter Letras Minusculas");
            }

        }

        /// <summary>
        /// Gera digitos aleatorios, 
        /// </summary>
        /// <param name="quantidade">Numero de digitos, padrão 1</param>
        public static string GeraDigitosAleatorio(int quantidade = 1)
        {
            string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var resultado = new char[quantidade];
            var rondom = new Random();

            for (int i = 0; i < resultado.Length; i++)
            {
                resultado[i] = caracteres[rondom.Next(caracteres.Length)];
            }

            return string.Join("", resultado.Select(x => x.ToString()));
        }

        /// <summary>
        /// Método para realizar criptografia em MD5
        /// </summary>
        /// <param name="input">Informação que será criptografada</param>
        /// <returns>Retorna a informação criptografada em MD5</returns>
        public static string GerarMD5(string input)
        {

            // Cria uma nova intância do objeto que implementa o algoritmo para criptografia MD5
            System.Security.Cryptography.MD5 md5Hasher = System.Security.Cryptography.MD5.Create();

            // Criptografa a informação passada
            byte[] infoCriptografado = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Cria um StringBuilder para passarmos os bytes gerados
            StringBuilder strBuilder = new StringBuilder();

            // Converte cada byte em um valor hexadecimal e adiciona ao string builder e formata em um hexadecimal string.
            for (int i = 0; i < infoCriptografado.Length; i++)
            {
                strBuilder.Append(infoCriptografado[i].ToString("x2"));
            }

            // Retorna o valor criptografado como string
            return strBuilder.ToString();

        }

        /// <summary>
        /// Método para comparar uma informação string x criptografada MD5
        /// </summary>
        /// <param name="input">Informação sem criptografia</param>
        /// <param name="hash">Informação criptografada</param>
        /// <returns>Retorna a informação criptografada em MD5</returns>
        static bool ComparaMD5(string input, string hash)
        {
            // Chama o método para criptografar a informação
            string hashOfInput = GerarMD5(input);

            // Cria um StringComparer para comparar as hashes
            StringComparer Comparar = StringComparer.OrdinalIgnoreCase;

            // Retorna o status da validação da comparação
            return 0 == Comparar.Compare(hashOfInput, hash) ? true : false;

        } 

        /// <summary>
        /// Método para compactar em Base64
        /// </summary>
        /// <param name="text"></param>
        /// <param name="NomeArquivo"></param>
        /// <returns></returns>
        public static byte[] CompactaZipBase64(string text, string NomeArquivo)
        {
            byte[] fileBytes = Encoding.UTF8.GetBytes(text);
            byte[] compressedBytes;

            using (var outStream = new MemoryStream())
            {

                using (var archive = new ZipArchive(outStream, ZipArchiveMode.Create, true))
                {
                    var fileInArchive = archive.CreateEntry(NomeArquivo, CompressionLevel.Optimal);

                    using (var entryStream = fileInArchive.Open())
                    using (var fileToCompressStream = new MemoryStream(fileBytes))
                    {
                        fileToCompressStream.CopyTo(entryStream);
                    }
                }

                compressedBytes = outStream.ToArray();
            }

            return compressedBytes;
        }

        /// <summary>
        /// Método para Descompactar em Base64
        /// </summary>
        /// <param name="textoCompactadoBase64"></param>
        /// <param name="nomeArquivoDentroDoZip"></param>
        /// <returns></returns>
        public static string DescompactaZipBase64(byte[] textoCompactadoBase64, string nomeArquivoDentroDoZip)
        {

            // Criação das variáveis
            string textodescompactado = "";
            byte[] Buffer = textoCompactadoBase64;

            //
            MemoryStream ms = new MemoryStream(Buffer)
            {
                Position = 0
            };

            //
            ZipArchive archive = new ZipArchive(ms);

            foreach (ZipArchiveEntry entry in archive.Entries)
            {

                if (entry.FullName.Equals(nomeArquivoDentroDoZip, StringComparison.OrdinalIgnoreCase))
                {
                    Stream unzippedEntryStream = entry.Open(); // .Open will return a stream
                    StreamReader reader = new StreamReader(unzippedEntryStream);
                    textodescompactado = reader.ReadToEnd();
                }
            }

            return textodescompactado;
        }

        /// <summary>
        /// Método para converter Base64 em string
        /// </summary>
        /// <param name="dados">Informação que será convertida</param>
        /// <returns></returns>
        public static string ConverteBase64ToStringUTF8(string dados)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(dados));
        } 

        /// <summary>
        /// Método para validar uma data através de uma string
        /// </summary>
        /// <param name="data">String de data no formato dd/mm/yyyy</param>
        /// <returns>Retorna o status false se possui alguma inconsistência ou true se todos as informações necessárias foram informadas</returns>
        public static bool IsDate(string data)
        {
            Regex r = new Regex(@"(\d{2}\/\d{2}\/\d{4})");
            return r.Match(data).Success;
        } 

        /// <summary>
        /// Método para retornar o valor um periodo entre duas datas.
        /// </summary>
        /// <param name="charInterval">String que recebe o "d" para comparar por dia, "m" por mês ou "y" por ano</param>
        /// <param name="dttFromDate">DateTime da data inicial</param>
        /// <param name="dttToDate">DateTime da data final</param>
        /// <returns>Retorna o valor de um periodo entre duas datas. Pode ser por ano, mês ou dia</returns>
        public static long DateDiff(string charInterval, DateTime dttFromDate, DateTime dttToDate)
        {
            TimeSpan tsDuration;
            tsDuration = dttToDate - dttFromDate;

            if (charInterval == "d")
            {
                // Resultado em Dias
                return tsDuration.Days;
            }
            else if (charInterval == "m")
            {
                // Resultado em Meses
                double dblValue = 12 * (dttFromDate.Year - dttToDate.Year) + dttFromDate.Month - dttToDate.Month;
                return Convert.ToInt32(Math.Abs(dblValue));
            }
            else if (charInterval == "y")
            {
                // Resultado em Anos
                return Convert.ToInt32((tsDuration.Days) / 365);
            }
            else
            {
                return 0;
            }
        }
    }
}