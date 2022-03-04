using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaUbs
{
    internal class Paciente
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int AnoNasc { get; set; }
        public string CPF { get; set; }
        public string Comorb { get; set; }
        public int Temp { get; set; }
        public int Saturacao { get; set; }
        public int DiasSintoma { get; set; }
        public Paciente Next { get; set; }
        public Exames Exame { get; set; }

        public Paciente(int iD, string nome, int anoNasc, string cPF, string comorb, int temp, int saturacao, int diasSintoma)
        {
            ID = iD;
            Nome = nome;
            AnoNasc = anoNasc;
            CPF = cPF;
            Comorb = comorb;
            Temp = temp;
            Saturacao = saturacao;
            DiasSintoma = diasSintoma;
            Next = null;
            //Exame = null;
        }
        public override string ToString()
        {
            return $"ID do paciente: {ID}\nNome do Paciente: {Nome}\nIdade: {2022 - AnoNasc}\nCPF: {CPF}.\nTem comorbidade?: {Comorb}" +
                $"\nTemperatura: {Temp}°C\nSaturação de Oxigenio no Sangue: {Saturacao}%\nEstá com sintomas à {DiasSintoma} dias";
        }
    }
}
