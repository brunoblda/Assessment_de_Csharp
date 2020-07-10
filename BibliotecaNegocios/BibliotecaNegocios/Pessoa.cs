using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaNegocio
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public Pessoa()
        {
        }
        public Pessoa(string nome, string sobrenome, DateTime dataDeNascimento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            DataDeNascimento = dataDeNascimento;
        }

        public override string ToString()
        {
            return Nome + "." + Sobrenome + "." + DataDeNascimento.ToShortDateString() + "\n";

        }

    }
}
