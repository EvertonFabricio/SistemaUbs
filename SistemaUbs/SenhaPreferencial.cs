using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaUbs
{
    internal class SenhaPreferencial
    {
        public int Numero { get; set; }
        public SenhaPreferencial Next { get; set; }

        public SenhaPreferencial(int numero)
        {
            Numero = numero;
            Next = null;
        }
    }
    internal class Preferencial
    {
        public SenhaPreferencial Head { get; set; }
        public SenhaPreferencial Tail { get; set; }
        public Preferencial()
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

        public void push(SenhaPreferencial aux)
        {
            if (Head == null && Tail == null)
            {
                Head = aux;
                Tail = aux;
                Console.WriteLine($"\nSua senha é: P-{Tail.Numero}.");
            }
            else
            {
                Tail.Next = aux;
                Tail = aux;
                Console.WriteLine($"\nSua senha é: P-{Tail.Numero}.");
            }
        }

        public void print()
        {
            if (empty())
            {
                Console.WriteLine("Não exixte senha PREFERENCIAL para sere chamada.");
            }
            else
            {
                SenhaPreferencial aux = Head;
                do
                {
                    Console.WriteLine($"SENHA: P-{aux.Numero}");
                    aux = aux.Next;

                } while (aux != null);
            }
        }

        public void pop()
        {
            if (empty())
            {
                Console.WriteLine("Não exixte senha PREFERENCIAL para sere chamada.");
            }
            else
            {
                Console.WriteLine($"Próxima senha: P-{Head.Numero}.");
                Head = Head.Next;
            }
            if (Head == null)
                Tail = null;
            //Console.WriteLine("Pressione ENTER para continuar...");
            //Console.ReadKey();
        }












    }
}
