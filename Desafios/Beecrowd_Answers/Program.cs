using Beecrowd;

namespace Beecrowd_Answers;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Seja Bem Vindo ao projeto Beecrowd Answers");
        Console.WriteLine("Digite o numero do desafio que deseja simular e o console ja ficará preparado para simular o desafio.");
        Console.WriteLine("\nExemplo de Entrada:");
        Console.WriteLine("1017 [Enter]");
        Console.WriteLine("\nDesafios inclusos no projeto:");
        Console.WriteLine("- 1017 |");
        Console.WriteLine("\nPode Digitar abaixo =)");

        var entrada = Console.ReadLine();

        try
        {
            var numeroDesafio = Convert.ToInt32(entrada);
            switch (numeroDesafio)
            {
                case 1017:
                    Console.Clear();
                    _1017.Resolve();
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                    break;
                default:
                    throw new Exception("Desafio não encontrado. ");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
