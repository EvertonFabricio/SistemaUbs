using System;

namespace SistemaUbs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Comum comum = new Comum();
            Preferencial preferencial = new Preferencial();
            AguardaExame dados = new AguardaExame();
            int cont = 0;

            Console.WriteLine("\t>>> Sistema Auxiliar de Atendimento <<<\n");
            Console.WriteLine("Por favor, informe a quantidade de leitos disponíveis:");
            int leitos = int.Parse(Console.ReadLine());
            Console.Clear();
            do
            {
                Menu(leitos);
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
                        { //retira senha comum
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
                            int ID = preferencial.Head.Numero;
                            preferencial.pop(); //chamo a senha e removo ela da lista de senhas.
                            cont++;
                            Console.WriteLine("\nDeseja cadastrar o paciente? (S ou N)");
                            string cadastro = Console.ReadLine().ToUpper();
                            if (cadastro == "S")
                            {
                                Console.Clear();
                                string nome, CPF, comorb;
                                int ano, dias, temp, sat;
                                Informacoes(out nome, out ano, out CPF, out dias, out comorb, out temp, out sat);
                                dados.push(new Paciente(ID, nome, ano, CPF, comorb, temp, sat, dias, null));
                                dados.verifica1();
                                ID = 0;
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
                            if (comum.empty())
                            {
                                Console.WriteLine("Não existem senhas para chamar.\nPressione ENTER para voltar ao menu...");
                                Console.ReadKey();
                                Console.Clear();

                            }
                            else
                            {

                                Console.Clear();
                                int ID = comum.Head.Numero;
                                comum.pop();
                                cont = 0;
                                Console.WriteLine("\nDeseja cadastrar o paciente? (S ou N)");
                                string cadastro = Console.ReadLine().ToUpper();
                                if (cadastro == "S")
                                {
                                    Console.Clear();
                                    string nome, CPF, comorb;
                                    int ano, dias, temp, sat;
                                    Informacoes(out nome, out ano, out CPF, out dias, out comorb, out temp, out sat);
                                    dados.push(new Paciente(ID, nome, ano, CPF, comorb, temp, sat, dias, null));
                                    dados.verifica1();
                                    ID = 0;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Pressione ENTER para voltar ao menu...");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                        }
                        break;

                    case "3":
                            //chamar da fila "aguarda exame", dentro de paciente, pra fazer exame
                        if (dados.empty())
                        {
                            Console.WriteLine("Não existem pacientes aguardando exame.\nPressione ENTER para voltar ao menu...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine($"Senha {dados.Head.ID}\nPaciente {dados.Head.Nome}");
                            Console.WriteLine($"Informe o resultado do exame do(a) paciente {dados.Head.Nome}:");
                            Console.WriteLine("1 - Positivo\n2 - Negativo");
                            string resultado = Console.ReadLine();
                            if (resultado == "1")
                                dados.Head.Exame = new Exames("Positivo");
                            else if (resultado == "2")
                                dados.Head.Exame = new Exames("Negativo");

                            dados.verifica2();

                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;

                    case "4":
                        dados.print();
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

        private static void Menu(int leitos)
        {
            Console.WriteLine($"No momento, temos {leitos} leitos disponíveis\n");
            Console.WriteLine("\t>>> Sistema Auxiliar de Atendimento <<<\n\nEscolha a opção desejada: \n");
            Console.WriteLine("1 - Retirar senha");
            Console.WriteLine("2 - Chamar senha para cadastro e triagem");
            Console.WriteLine("3 - Chamar para fazer exame");
            Console.WriteLine("4 - Ver fila de positivados aguardando internação");
            Console.WriteLine("5 - Ver lista de internados, por ordem de internação");
            Console.WriteLine("6 - Emergência - internação imediata");
            Console.WriteLine("7 - Ver lista de pacientes liberados");
            Console.WriteLine("0 - Sair do Sistema\n");
            Console.Write("Opção: ");
        }

        private static void Informacoes(out string nome, out int ano, out string CPF, out int dias, out string comorb, out int temp, out int sat)
        {
            Console.WriteLine("**Cadastro do Paciente**");
            Console.WriteLine("Nome do paciente:"); nome = Console.ReadLine();
            Console.WriteLine("Ano de Nascimento do paciente:"); ano = int.Parse(Console.ReadLine());
            Console.WriteLine("CPF do paciente:"); CPF = Console.ReadLine();
            Console.WriteLine("Ha quantos dias o paciente está com sintomas:"); dias = int.Parse(Console.ReadLine());
            Console.WriteLine("Paciente tem comorbidade? (S ou N):"); comorb = Console.ReadLine().ToUpper();
            Console.WriteLine("Temperatura do paciente:"); temp = int.Parse(Console.ReadLine());
            Console.WriteLine("Saturação de oxigênio do paciente"); sat = int.Parse(Console.ReadLine());
        }
    }
}
