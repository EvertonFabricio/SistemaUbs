using System;

namespace SistemaUbs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t>>> Sistema Auxiliar de Atendimento <<<\n");
            Console.WriteLine("Por favor, informe a quantidade de leitos disponíveis:");
            int leitos = int.Parse(Console.ReadLine());
            Console.Clear();
            do
            {
                Console.WriteLine($"No momento, temos {leitos} leitos disponíveis\n");
                Console.WriteLine("\t>>> Sistema Auxiliar de Atendimento <<<\n\nEscolha a opção desejada: \n");
                Console.WriteLine("1 - Retirar senha");
                Console.WriteLine("2 - Chamar senha para cadastro e triagem");
                Console.WriteLine("3 - Ver fila para fazer exame");
                Console.WriteLine("4 - Ver fila de positivados aguardando internação");
                Console.WriteLine("5 - Ver lista de internados, por ordem de internação");
                Console.WriteLine("6 - Emergência - internação imediata");
                Console.WriteLine("7 - Ver lista de pacientes liberados");
                Console.WriteLine("0 - Sair do Sistema\n");
                Console.Write("Opção: ");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        //retira senha, informando a data de nascimento.
                        Console.Write("Informe o ano em que vcoê nasceu:");
                        int nascimento = int.Parse(Console.ReadLine());
                        int senha = new Random().Next(111, 999);
                        if (2022 - nascimento >= 60)
                        {
                            //retira senha preferencial
                            Console.WriteLine($"Sua senha é: P-{senha}\n");
                        }
                        else
                        {
                            //retira senha comum
                            Console.WriteLine($"Sua senha é: C-{senha}\n");
                        }
                        Console.WriteLine("Pressione ENTER para voltar ao menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "2":
                        //chamar senha para cadastro e triagem.

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "3":

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "4":

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "5":

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "6":

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "7":

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "0":

                        Console.WriteLine("Obrigado por utilizar nossos serviços!\n");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Pressione ENTER e tente novamente...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
                if (menu == "0")
                {
                    break;
                }
            } while (true);








        }
    }
}
