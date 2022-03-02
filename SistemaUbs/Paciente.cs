using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaUbs
{
    internal class Paciente
    {
        public string Nome { get; set; }
        public int AnoNasc { get; set; }
        public string CPF { get; set; }
        public string Comorb { get; set; }
        public string PerdaPaladar { get; set; }
        public int Temp { get; set; }
        public int Saturacao { get; set; }
        public int DiasSintoma { get; set; }
        public Paciente Next { get; set; }

        public Paciente(string nome, int anoNasc, string cPF, string comorb, string perdaPaladar, int temp, int saturacao, int diasSintoma)
        {
            Nome = nome;
            AnoNasc = anoNasc;
            CPF = cPF;
            Comorb = comorb;
            PerdaPaladar = perdaPaladar;
            Temp = temp;
            Saturacao = saturacao;
            DiasSintoma = diasSintoma;
            Next = null;
        }


        public override string ToString()
        {
            return $"Nome do Paciente: {Nome}\nIdade: {2022 - AnoNasc}\nCPF: {CPF}.\nTem comorbidade?: {Comorb}" +
                $"\nPerdeu o Paladar?: {PerdaPaladar}\nTemperatura: {Temp}°C\nSaturação de Oxigenio no Sangue: {Saturacao}%\nEstá com sintomas à {DiasSintoma} dias";
        }


    }

    internal class DadosPaciente
    {
        public Paciente Head;
        public Paciente Tail;
        public DadosPaciente()
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

        public void push(Paciente aux)
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
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadKey();
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
                } while (aux != null);
            }
        }


    }
}
