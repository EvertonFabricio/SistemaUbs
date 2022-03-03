using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaUbs
{
    internal class AguardaInternacao
    {
        public Paciente Head;
        public Paciente Tail;

        public AguardaInternacao()
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

        public void Push(Paciente aux)
        {
            if (empty())
            {
                Head = aux;
                Tail = aux;
            }
            else
            {
                Head.Next = aux;
            }
        }

        public void print()
        {
            if (empty())
            {
                Console.WriteLine("Não há pacientes cadastrados.");
            }
            else
            {
                Paciente aux = Head;
                do
                {
                    Console.WriteLine(aux.ToString());
                    aux = aux.Next;
                    Console.WriteLine("\n\n");
                } while (aux != null);
            }
        }




    }
}
