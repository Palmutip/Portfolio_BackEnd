using Beecrowd;

namespace Beecrowd_Answers;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Seja Bem Vindo ao projeto Beecrowd Answers");
        Console.WriteLine("Digite o numero do desafio que deseja simular e o console ja ficará preparado para simular o desafio.");
        Console.WriteLine("\nExemplo de Entrada:");
        Console.WriteLine("1000 [Enter]");
        Console.WriteLine("\nDesafios inclusos no projeto:");
        Console.WriteLine("- 1000 | 1001 | 1002 | 1003 | 1004 ");
        Console.WriteLine("- 1005 | 1006 | 1007 | 1008 | 1009 ");
        Console.WriteLine("- 1010 | 1011 | 1012 | 1013 | 1014 ");
        Console.WriteLine("- 1015 | 1016 | 1017 | 1018 | 1019 ");
        Console.WriteLine("\nPode Digitar abaixo =)");

        var entrada = Console.ReadLine();

        try
        {
            var numeroDesafio = Convert.ToInt32(entrada);
            switch (numeroDesafio)
            {
                case 1000:
                    Console.Clear();
                    _1000.Resolve();
                    Console.WriteLine("\nPresisone [Enter] para testar outro desafio.");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                    break;
                case 1001:
                    Console.Clear();
                    _1001.Resolve();
                    Console.WriteLine("\nPresisone [Enter] para testar outro desafio.");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                    break;
                case 1002:
                    Console.Clear();
                    _1002.Resolve();
                    Console.WriteLine("\nPresisone [Enter] para testar outro desafio.");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                    break;
                case 1003:
                    Console.Clear();
                    _1003.Resolve();
                    Console.WriteLine("\nPresisone [Enter] para testar outro desafio.");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                    break;
                case 1004:
                    Console.Clear();
                    _1004.Resolve();
                    Console.WriteLine("\nPresisone [Enter] para testar outro desafio.");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                    break;
                case 1005:
                    Console.Clear();
                    _1005.Resolve();
                    Console.WriteLine("\nPresisone [Enter] para testar outro desafio.");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                    break;
                case 1006:
                    Console.Clear();
                    _1006.Resolve();
                    Console.WriteLine("\nPresisone [Enter] para testar outro desafio.");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                    break;
                case 1007:
                    Console.Clear();
                    _1007.Resolve();
                    Console.WriteLine("\nPresisone [Enter] para testar outro desafio.");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                    break;
                case 1008:
                    Console.Clear();
                    _1008.Resolve();
                    Console.WriteLine("\nPresisone [Enter] para testar outro desafio.");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                    break;
                case 1009:
                    Console.Clear();
                    _1009.Resolve();
                    Console.WriteLine("\nPresisone [Enter] para testar outro desafio.");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                    break;
                case 1010:
                    Console.Clear();
                    _1010.Resolve();
                    Console.WriteLine("\nPresisone [Enter] para testar outro desafio.");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                    break;
                case 1011:
                    Console.Clear();
                    _1011.Resolve();
                    Console.WriteLine("\nPresisone [Enter] para testar outro desafio.");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                    break;
                case 1012:
                    Console.Clear();
                    _1012.Resolve();
                    Console.WriteLine("\nPresisone [Enter] para testar outro desafio.");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                    break;
                case 1013:
                    Console.Clear();
                    _1013.Resolve();
                    Console.WriteLine("\nPresisone [Enter] para testar outro desafio.");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                    break;
                case 1014:
                    Console.Clear();
                    _1014.Resolve();
                    Console.WriteLine("\nPresisone [Enter] para testar outro desafio.");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                    break;
                case 1015:
                    Console.Clear();
                    _1015.Resolve();
                    Console.WriteLine("\nPresisone [Enter] para testar outro desafio.");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                    break;
                case 1016:
                    Console.Clear();
                    _1016.Resolve();
                    Console.WriteLine("\nPresisone [Enter] para testar outro desafio.");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                    break;
                case 1017:
                    Console.Clear();
                    _1017.Resolve();
                    Console.WriteLine("\nPresisone [Enter] para testar outro desafio.");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                    break;
                case 1018:
                    Console.Clear();
                    _1018.Resolve();
                    Console.WriteLine("\nPresisone [Enter] para testar outro desafio.");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                    break;
                case 1019:
                    Console.Clear();
                    _1019.Resolve();
                    Console.WriteLine("\nPresisone [Enter] para testar outro desafio.");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                    break;
                default:
                    Console.WriteLine("Desafio não encontrado. ");
                    Console.WriteLine("\nPresisone [Enter] para tentar novamente.");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            Console.WriteLine("\nPresisone [Enter] para tentar novamente.");
            Console.ReadLine();
            Console.Clear();
            Main(args);
        }
    }
}
