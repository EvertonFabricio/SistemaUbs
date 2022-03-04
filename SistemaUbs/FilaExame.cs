using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaUbs
{
    internal class FilaExame
    {
        public Paciente Head;
        public Paciente Tail;

        public FilaExame()
        {
            Head = null;
            Tail = null;
        }

        public bool empty()
        {
            if (Head == null && Tail == null)
                return true;
            else
                return false;
        }

        public void push(Paciente aux)
        {
            if (aux == null)
                return;
            if (empty())
            {
                Head = aux;
                Tail = aux;
            }
            else
            {
                Tail.Next = aux;
                Tail = aux;
            }
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadKey();
        }

        public void print()
        {
            if (empty())
            {
                Console.WriteLine("Não há pacientes na fila para exames.");
            }
            else
            {
                Paciente aux = Head;
                do
                {
                    Console.WriteLine(aux.ToString());
                    aux = aux.Next;
                    Console.WriteLine("\n**********************************\n");
                } while (aux != null);
            }
        }

        public void pop()
        {
            if (empty())
            {
                Console.WriteLine("Não existem pessoas aguardando exame.");
            }
            else
            {
                Head = Head.Next;
            }
            if (Head == null)
            {
                Tail = null;
            }
            //Console.WriteLine("Pressione ENTER para continuar...");

        }

        public void VerificaSuspeita()
        {//verifica se pode liberar paciente direto na triagem

            Paciente aux = Head;
            if (aux.DiasSintoma < 3 && aux.Temp < 37 && aux.Saturacao > 90) //menos de 3 dias de sintoma, temperatura abaixo de 37 e saturação acima de 90, manda pra casa
            {
                Console.WriteLine("\nSintomas do paciente indicam que não é COVID. Liberar paciente.");
                pop();
                Console.ReadKey();
                Console.Clear();
            }
            else
            { //mais de 3 dias de sintomas, ou febre, ou saturação baixa, ou as 3 coisas junto, manda fazer exame.

                Console.WriteLine("\nPaciente deve fazer o exame PCR. Por favor aguarde.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public Paciente VerificarInternacao() //essa função não pode ser void. Precisa retornar um valor. Nesse caso, ela retorna a pessoa que está na Head.
        {//verifica se PCR deu positivo ou negativo. Negativo libera a pessoa. Positivo analisa pra ver se precisa internar.
            
            Paciente aux = Head;
            if (aux.Exame.PCR == "Negativo")
            {
                Console.WriteLine("Exame negativo. Liberar paciente.");
                Console.WriteLine("Pressione ENTER para voltar ao menu...");
                pop();
            }
            else if (aux.Saturacao < 90)
            {
                Console.WriteLine("Saturação extremamente baixa. Encaminhar paciente para internação\n");
                pop();
                return aux; //esse retorno fica armazenado na função verificainternação. Onde eu chamar ela, eu consigo ver o valor que ela tem.
            }
            return null;
        }
    }
}
