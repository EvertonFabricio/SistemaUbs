using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaUbs
{
    internal class Internacao
    {
        public Paciente Paciente { get; set; }
        public Internacao Next { get; set; }

        public Internacao(Paciente paciente)
        {
            Paciente = paciente;
            Next = null;
        }
    }


    internal class Internacoes
    {
        public Internacao Head { get; set; }
        public Internacao Tail { get; set; }
        public Internacoes()
        {
            Head = null;
            Tail = null;
        }

        public bool empty()
        {
            if (Head == null)
                return true;
            else
                return false;
        }
        public void push(Internacao novo)
        {
            if (empty())
            {
                Head = novo;
                Tail = novo;
                Console.WriteLine("Paciente colocado na fila para internação.");
            }
            else
            {
                Tail.Next = novo;
                Tail = novo;
                Console.WriteLine("Paciente colocado na fila para internação.");
            }
        }
        public void pop()
        {
            if (empty())
            {
                Console.WriteLine("Fila para internação está vazia");
            }
            else
            {
                Head = Head.Next;
                Console.WriteLine("Paciente foi internado.");
            }
        }

    }
}
