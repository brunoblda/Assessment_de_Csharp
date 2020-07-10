using System.Collections.Generic;
using BibliotecaNegocio;

namespace GerenciadorDeAniversariosV3
{
    public interface IManipulacaoDaLista
    {

        void Adicionar(Pessoa pessoa);

        List<Pessoa> Pesquisar(string nome);

        void Deletar(Pessoa pessoa);

        void Atualizar(Pessoa pessoa1, Pessoa pessoa2);
        

    }
}
