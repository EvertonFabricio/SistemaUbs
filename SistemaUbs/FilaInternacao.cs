using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaUbs
{
    internal class FilaInternacao
    {

        public Paciente Head;
        public Paciente Tail;
        public FilaInternacao()
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
        }

        public void print()
        {
            if (empty())
            {
                Console.WriteLine("Não há pacientes na fila para internações.");
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
        }

        public Paciente VerificaVaga()
        {
            Paciente aux = Head;
            Internacoes internacoes = new Internacoes();
            int leito = internacoes.Leitos;

            if (leito > 0)
            {
                Head = Head.Next;
                return aux;
            }
            return null;
        }





    }
}
