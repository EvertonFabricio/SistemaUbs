using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaUbs
{
    internal class Internacoes
    {
        public int Leitos { get; set; }
        public Internacoes Next { get; set; }
        public Paciente Head;
        public Paciente Tail;

        public Internacoes(int leitos)
        {
            Leitos = leitos;
            Next = null;
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
                Leitos--;
            }
            else
            {
                Tail.Next = aux;
                Tail = aux;
            }
        }

        public void print()
        {
            if (empty())
            {
                Console.WriteLine("Não há pacientes internados.");
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
                Console.WriteLine("Não ha pacientes internados.");
            }
            else
            {
                Head = Head.Next;
                Leitos++;
            }
            if (Head == null)
            {
                Tail = null;
            }
            Console.WriteLine("Pressione ENTER para continuar...");

        }

        public int VerificaLeito()
        {
            return Leitos;
        }

        public void Import()
        {
            FilaInternacao filaInt = new FilaInternacao();
            Paciente pessoa = filaInt.VerificaVaga();
            push(pessoa);




        }


    }
}
