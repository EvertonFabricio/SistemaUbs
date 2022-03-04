using System;

namespace SistemaUbs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FilaComum comum = new FilaComum();
            FilaPreferencial preferencial = new FilaPreferencial();
            FilaExame filaExame = new FilaExame();
            FilaInternacao filaInternacao = new FilaInternacao();
            Internacoes internacoes = new Internacoes(0);
            int cont = 0;//faz a contagem das senhas chamadas pra chamar 2 pra 1

            Console.WriteLine("\t>>> Sistema Auxiliar de Atendimento <<<\n");
            Console.WriteLine("Por favor, informe a quantidade de leitos disponíveis:");
            int leitos = int.Parse(Console.ReadLine());
            internacoes.Leitos = leitos;
            Console.Clear();
            do
            {
                MenuPrincipal(internacoes);

                string menu = Console.ReadLine();
                Console.Clear();
                switch (menu)
                {
                    case "1":  //informa a data de nascimento pra ver se a senha é preferencial ou comum.

                        Console.Write("Informe o ano em que você nasceu:");
                        int nascimento = int.Parse(Console.ReadLine());
                        int senha = new Random().Next(111, 999);

                        if (2022 - nascimento >= 60)  //retira senha preferencial
                        {
                            preferencial.push(new SenhaPreferencial(senha));
                        }
                        else //retira senha comum
                        {
                            comum.push(new SenhaComum(senha));
                        }
                        Console.WriteLine("\nPressione ENTER para voltar ao menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;


                    case "2": //chamar senha para cadastro e triagem.

                        if (cont < 2 && !preferencial.empty()) //chama 2 preferencial.
                        {
                            Console.Clear();
                            int ID = preferencial.Head.Numero; //fixa o numero da senha como ID do paciente.
                            preferencial.pop(); //chamo a senha na tela e removo ela da lista de senhas.
                            cont++;
                            Console.WriteLine("\nDeseja cadastrar o paciente? (S ou N)");
                            bool flag = false;
                            do
                            {
                                string cadastro = Console.ReadLine().ToUpper();
                                if (cadastro == "S") // escolheu cadastrar o paciente, entra aqui pra informar os dados.
                                {
                                    flag = true;
                                    Console.Clear();
                                    string nome, CPF, comorb;
                                    int ano, dias, temp, sat;
                                    Informacoes(out nome, out ano, out CPF, out dias, out comorb, out temp, out sat);
                                    filaExame.push(new Paciente(ID, nome, ano, CPF, comorb, temp, sat, dias));//coloca os dados na fila de exame
                                    filaExame.VerificaSuspeita();//verifica se informaçoes salvas é covid ou nao. Se for, mantem salvo, senão, chuta pra fora 
                                    ID = 0;//zera o ID, só por segurança, pq necessidade não tem não.
                                }
                                else if (cadastro == "N")
                                {
                                    flag = true;
                                    Console.Clear();
                                    Console.WriteLine("Senha descartada. Pressione ENTER para voltar ao menu...");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("Opção incorreta. Digite S para cadastrar o paciente, ou N para descartar a senha e voltar ao menu.");
                                }
                            } while (flag == false);
                        }
                        else // se ja tiver chamado 2 senhas pref. ou se não tiver mais nenhuma pra chamar, vem pra cá.
                        {
                            if (comum.empty()) // se lista de senha comum tiver vazia, não chama ninguem (claro).
                            {
                                Console.WriteLine("Não existem senhas para chamar.\nPressione ENTER para voltar ao menu...");
                                Console.ReadKey();
                                Console.Clear();

                            }
                            else// se tiver gente na lista de senha comum, vem pra cá e faz a mesma coisa da senha preferencial.
                            {

                                Console.Clear();
                                int ID = comum.Head.Numero;
                                comum.pop();
                                cont = 0;
                                Console.WriteLine("\nDeseja cadastrar o paciente? (S ou N)");
                                bool flag = false;
                                do
                                {
                                    string cadastro = Console.ReadLine().ToUpper();
                                    if (cadastro == "S")
                                    {
                                        flag = true;
                                        Console.Clear();
                                        string nome, CPF, comorb;
                                        int ano, dias, temp, sat;
                                        Informacoes(out nome, out ano, out CPF, out dias, out comorb, out temp, out sat);
                                        filaExame.push(new Paciente(ID, nome, ano, CPF, comorb, temp, sat, dias));
                                        filaExame.VerificaSuspeita();
                                        ID = 0;
                                    }
                                    else if (cadastro == "N")
                                    {
                                        flag = true;
                                        Console.Clear();
                                        Console.WriteLine("Pressione ENTER para voltar ao menu...");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Opção incorreta. Digite S para cadastrar o paciente, ou N para descartar a senha e voltar ao menu.");
                                    }
                                } while (flag == false);
                            }
                        }
                        break;

                    case "3": //chamar da fila  de exames pra colocar o resultado do exame (positivo ou negativo)

                        if (filaExame.empty())
                        {
                            Console.WriteLine("Não existem pacientes aguardando exame.\nPressione ENTER para voltar ao menu...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine($"Senha {filaExame.Head.ID}\nPaciente {filaExame.Head.Nome}\n");
                            Console.WriteLine($"\nInforme o resultado do exame do(a) paciente {filaExame.Head.Nome}:");
                            Console.WriteLine("1 - Positivo\n2 - Negativo");
                            bool flag = true;
                            do //laço só pra controlar se o usuario vai digitar a opçao certa.
                            {
                                string resultado = Console.ReadLine();
                                if (resultado == "1")
                                {
                                    filaExame.Head.Exame = new Exames("Positivo");
                                    flag = false;
                                    Console.Clear();
                                }
                                else if (resultado == "2")
                                {
                                    filaExame.Head.Exame = new Exames("Negativo");
                                    flag = false;
                                    Console.Clear();
                                }
                                else
                                    Console.WriteLine("Opção invalida. Digite 1 se for positivo e 2 se for negativo");
                            } while (flag == true); //ja atribuiu ao paciente se o exame deu positivo ou negativo.

                            Paciente pessoa = filaExame.VerificarInternacao(); //chama a função de dentro da fila exames pra verificar a internação e atribui o retorno dela na variavel pessoa
                            filaInternacao.push(pessoa); // faz um push na fila de internação, atribuindo a variavel pessoa nesse push, que está com o valor do paciente.

                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;

                    case "4": // ver fila aguardando exame
                        filaExame.print();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "5": // ver fila de pessoas positivadas que precisam de internação.
                        filaInternacao.print();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "6": //ver a lista de internados
                        internacoes.print();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "7":
                        filaInternacao.VerificaVaga();
                        internacoes.Import();
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

        private static void MenuPrincipal(Internacoes internacoes)
        {
            Console.WriteLine($"No momento, temos {internacoes.Leitos} leitos disponíveis\n");
            Console.WriteLine("\t>>> Sistema Auxiliar de Atendimento <<<\n\nEscolha a opção desejada: \n");
            Console.WriteLine("1 - Retirar senha");
            Console.WriteLine("2 - Chamar senha para cadastro e triagem");
            Console.WriteLine("3 - Chamar para fazer exame");
            Console.WriteLine("4 - Ver fila Aguardando Exame");
            Console.WriteLine("5 - Ver fila de positivados aguardando internação");
            Console.WriteLine("6 - Ver lista de internados, por ordem de internação");
            Console.WriteLine("7 - Emergência - internação imediata");
            Console.WriteLine("8 - Ver lista de pacientes liberados");
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
