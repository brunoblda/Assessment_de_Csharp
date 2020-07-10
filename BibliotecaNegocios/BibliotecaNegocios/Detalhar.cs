using System;


namespace BibliotecaNegocio
{
    public class Detalhar
    {

        public Pessoa pessoa { get; set; }

        public Detalhar(Pessoa pessoa)
        {
            this.pessoa = pessoa;
        }

        public string DiasParaAniversario()
        {
            DateTime agora = DateTime.Now;
            string dataDeNascimentoShort = pessoa.DataDeNascimento.ToShortDateString();
            string diaMes = dataDeNascimentoShort.Remove(6);
            string diaMesAno = diaMes + agora.Year;
            DateTime aniversario = DateTime.Parse(diaMesAno);

            string tempoQueFalta;

            TimeSpan umDia = new TimeSpan(1, 0, 0, 0);

            if (agora > aniversario)
            {
                int ano = agora.Year + 1;
                diaMesAno = diaMes + ano;
                aniversario = DateTime.Parse(diaMesAno);
                TimeSpan tempo = aniversario.Subtract(agora) + umDia;
                if (int.Parse(tempo.Days.ToString()) == 365)
                {
                    tempoQueFalta = "0";
                }
                else
                {
                    tempoQueFalta = tempo.Days.ToString();
                }
            }
            else
            {
                TimeSpan tempo = aniversario.Subtract(agora) + umDia;

                if (int.Parse(tempo.Days.ToString()) == 365)
                {
                    tempoQueFalta = "0";
                }
                else
                {
                    tempoQueFalta = tempo.Days.ToString();
                }
            }

            return tempoQueFalta;
        }

        public override string ToString()
        {
            return "Dados da pessoa: \n"
                 + "Nome Completo: " + pessoa.Nome + " " + pessoa.Sobrenome + "\n"
                 + "Data de nascimento " + pessoa.DataDeNascimento.ToShortDateString() + "\n"
                 + "Faltam " + DiasParaAniversario() + " dias para esse aniversario ";
        }


    }
}
