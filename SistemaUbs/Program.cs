using System;

namespace SistemaUbs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Comum comum = new Comum();
            Preferencial preferencial = new Preferencial();
            DadosPaciente dados = new DadosPaciente();
            int cont = 0;

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
                        //informando a data de nascimento.
                        Console.Write("Informe o ano em que você nasceu:");
                        int nascimento = int.Parse(Console.ReadLine());
                        int senha = new Random().Next(111, 999);

                        if (2022 - nascimento >= 60)
                        { //retira senha preferencial
                            preferencial.push(new SenhaPreferencial(senha));
                        }
                        else
                        {//retira senha comum
                            comum.push(new SenhaComum(senha));
                        }
                        Console.WriteLine("Pressione ENTER para voltar ao menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "2":
                        //chamar senha para cadastro e triagem.
                        if (cont < 2 && !preferencial.empty())
                        {
                            Console.Clear();
                            preferencial.pop();
                            cont++;
                            Console.WriteLine("\nDeseja cadastrar o paciente? (S ou N)");
                            string cadastro = Console.ReadLine().ToUpper();
                            if (cadastro == "S")
                            {
                                Console.Clear();
                                Console.WriteLine("**Cadastro do Paciente**");
                                Console.WriteLine("Nome do paciente:"); string nome = Console.ReadLine();
                                Console.WriteLine("Ano de Nascimento do paciente:"); int ano = int.Parse(Console.ReadLine());
                                Console.WriteLine("CPF do paciente:"); string CPF = Console.ReadLine();
                                Console.WriteLine("Ha quantos dias o paciente está com sintomas:"); int dias = int.Parse(Console.ReadLine());
                                Console.WriteLine("Paciente tem comorbidade? (S ou N):"); string comorb = Console.ReadLine().ToUpper();
                                Console.WriteLine("Paciente teve perda de Paladar? (S ou N):"); string perda = Console.ReadLine().ToUpper();
                                Console.WriteLine("Temperatura do paciente:"); int temp = int.Parse(Console.ReadLine());
                                Console.WriteLine("Saturação de oxigênio do paciente"); int sat = int.Parse(Console.ReadLine());
                                dados.push(new Paciente(nome, ano, CPF, comorb, perda, temp, sat, dias));

                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Pressione ENTER para voltar ao menu...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        else
                        {
                            Console.Clear();
                            comum.pop();
                            cont = 0;
                            Console.WriteLine("\nDeseja cadastrar o paciente? (S ou N)");
                            string cadastro = Console.ReadLine().ToUpper();
                            if (cadastro == "S")
                            {
                                Console.Clear();
                                Console.WriteLine("**Cadastro do Paciente**");
                                Console.WriteLine("Nome do paciente:"); string nome = Console.ReadLine();
                                Console.WriteLine("Ano de Nascimento do paciente:"); int ano = int.Parse(Console.ReadLine());
                                Console.WriteLine("CPF do paciente:"); string CPF = Console.ReadLine();
                                Console.WriteLine("Ha quantos dias o paciente está com sintomas:"); int dias = int.Parse(Console.ReadLine());
                                Console.WriteLine("Paciente tem comorbidade? (S ou N):"); string comorb = Console.ReadLine().ToUpper();
                                Console.WriteLine("Paciente teve perda de Paladar? (S ou N):"); string perda = Console.ReadLine().ToUpper();
                                Console.WriteLine("Temperatura do paciente:"); int temp = int.Parse(Console.ReadLine());
                                Console.WriteLine("Saturação de oxigênio do paciente"); int sat = int.Parse(Console.ReadLine());
                                dados.push(new Paciente(nome, ano, CPF, comorb, perda, temp, sat, dias));
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Pressione ENTER para voltar ao menu...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
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
