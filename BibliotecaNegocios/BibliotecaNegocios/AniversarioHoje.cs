using System;
using System.Collections.Generic;

namespace BibliotecaNegocio
{
     public class AniversarioHoje
    {


        readonly List<Pessoa> FazemAniversarioHoje = new List<Pessoa>();
        readonly DateTime hoje = DateTime.Today;

        public AniversarioHoje(List<Pessoa> pessoas)
        {
            foreach (Pessoa p in pessoas)
            {
                if ((p.DataDeNascimento.Day == hoje.Day) && (p.DataDeNascimento.Month == hoje.Month))
                {
                    FazemAniversarioHoje.Add(p);

                }
            }

        }
        public List<Pessoa> QuemFazAniversarioHoje()
        {
            return FazemAniversarioHoje;
        }

    }


}
