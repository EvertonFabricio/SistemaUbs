using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaUbs
{
    internal class SenhaComum
    {
        public int Numero { get; set; }
        public SenhaComum Next { get; set; }

        public SenhaComum(int numero)
        {
            Numero = numero;
            Next = null;
        }
    }
    
    
    
    internal class Comum
    {
        public SenhaComum Head { get; set; }
        public SenhaComum Tail { get; set; }
        public Comum()
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

        public void push(SenhaComum aux)
        {
            if (Head == null && Tail == null)
            {
                Head = aux;
                Tail = aux;
                Console.WriteLine($"Sua senha é: C-{Tail.Numero}.");
            }
            else
            {
                Tail.Next = aux;
                Tail = aux;
                Console.WriteLine($"Sua senha é: C-{Tail.Numero}.");
            }
        }

        public void print()
        {
            if (empty())
            {
                Console.WriteLine("Não exixtem senhas COMUM para serem chamadas.");
            }
            else
            {
                SenhaComum aux = Head;
                do
                {
                    Console.WriteLine($"SENHA: C-{aux.Numero}");
                    aux = aux.Next;

                } while (aux != null);
            }
        }

        public void pop()
        {
            if (empty())
            {
                Console.WriteLine("Não existem mais senhas para serem chamadas");
            }
            else
            {
                Console.WriteLine($"Próxima senha: C-{Head.Numero}.");
                Head = Head.Next;
            }
            if (Head == null)
                Tail = null;
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadKey();
        }












    }







}
