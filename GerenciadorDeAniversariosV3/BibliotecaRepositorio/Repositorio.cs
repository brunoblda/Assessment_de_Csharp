using System.Collections.Generic;
using System.Linq;
using BibliotecaNegocio;


namespace GerenciadorDeAniversariosV3
{
    public class Repositorio : IManipulacaoDaLista
    {
        public static List<Pessoa> pessoas;

        public RepositorioExterno repositorioExterno;

        public bool ExisteRepositorioExterno()
        {

            bool exist;
            if (repositorioExterno.ImportarLista().Any())
            {
                exist = true;
            }
            else
            {
                exist = false;
            }

            return exist;

        }


        /* public void ImportarRepositorio()
         {

             foreach(Pessoa pessoa in repositorioExterno.ImportarLista())
             {
                 pessoas.Add(pessoa);
             }
         }*/


        public void ImportarRepositorio()
        {

            pessoas = repositorioExterno.ImportarLista();
            
                           
        }


        public void ExportarRepositorio()
        {
            repositorioExterno.ExportarLista(pessoas);
        }

        public Repositorio()
        {
            pessoas = new List<Pessoa>();
            repositorioExterno = new RepositorioExterno();

        }
        public void Adicionar(Pessoa pessoa)
        {
            pessoas.Add(pessoa);
        }
        public void Deletar(Pessoa pessoa)
        {
            pessoas.Remove(pessoa);
        }

        public void Atualizar(Pessoa pessoa1, Pessoa pessoa2)
        {
            foreach (Pessoa p in pessoas)
            {
                if ((pessoa1.Nome == p.Nome) & (pessoa1.Sobrenome == p.Sobrenome) & (pessoa1.DataDeNascimento == p.DataDeNascimento))
                {
                    p.Nome = pessoa2.Nome;
                    p.Sobrenome = pessoa2.Sobrenome;
                    p.DataDeNascimento = pessoa2.DataDeNascimento;
                }

            }
        }

        public List<Pessoa> ListaCompleta()
        {
            return pessoas;
        }

        public List<Pessoa> Pesquisar(string nome)
        {
            List<Pessoa> resposta = new List<Pessoa>();

            foreach (Pessoa pessoa in pessoas)
            {
                if (pessoa.Nome.Contains(nome) || pessoa.Sobrenome.Contains(nome))
                {
                    resposta.Add(pessoa);
                }
            }

            return resposta;
        }

        public bool VerificarDiretorio()
        {
            return pessoas.Any();
        }
    }
}
