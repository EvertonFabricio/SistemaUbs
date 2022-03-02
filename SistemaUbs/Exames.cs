using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaUbs
{
    internal class Exames
    {
        public string PCR { get; set; }
        public Exames Next { get; set; }

        public Exames(string pCR)
        {
            PCR = pCR;
            Next = null;
        }
    }

    internal class Exame
    {
        public Exames Head { get; set; }
        public Exames Tail { get; set; }
        public Exame()
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

        public void push(Exames aux)
        {
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

    }


}
