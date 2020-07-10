using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaNegocio;


namespace GerenciadorDeAniversariosV3
{
    class Program
    {
        static void Main(string[] args)
        {

            Cabecalho();

            Repositorio repositorio = new Repositorio();

            if (repositorio.ExisteRepositorioExterno())
            {
                repositorio.ImportarRepositorio();

                Console.WriteLine("Dados Importados com sucesso!");
            }
            else
            {
                Console.WriteLine("Não existem dados a serem importados");
            }

            Console.WriteLine("");
            ListaAniversariosHoje(repositorio.ListaCompleta());

            int opcaoSelecionada = MenuPrincipal();


            while (opcaoSelecionada != 6)
            {

                switch (opcaoSelecionada)
                {
                    // Pesquisar Pessoas
                    case 1:

                        List<Pessoa> resultadosPesquisa;
                        Console.Clear();
                        Cabecalho();
                        Console.WriteLine("- Pesquisar pessoa");
                        Console.WriteLine();

                        if (!repositorio.VerificarDiretorio())
                        {

                            Console.WriteLine("Diretório vazio, adicione pessoas.");

                        }
                        else
                        {

                            Console.WriteLine("Digite o nome, ou parte do nome, da pessoa que deseja encontrar: ");
                            Console.WriteLine();
                            string nomeAPesquisar = Console.ReadLine();


                            resultadosPesquisa = repositorio.Pesquisar(nomeAPesquisar.ToUpper());

                            bool contemPessoa = resultadosPesquisa.Any();

                            if (contemPessoa)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Selecione uma das opções abaixo para visualizar os dados de uma das pessoas encontradas");
                                Console.WriteLine();

                                for (int i = 0; i < resultadosPesquisa.Count; i++)
                                {
                                    Console.WriteLine(i + " - " + resultadosPesquisa[i].Nome + " " + resultadosPesquisa[i].Sobrenome);
                                }

                                Console.WriteLine();
                                int pessoaSelecionada = int.Parse(Console.ReadLine());
                                Console.WriteLine();
                                Detalhar pessoaDetalhada = new Detalhar(resultadosPesquisa[pessoaSelecionada]);
                                Console.WriteLine(pessoaDetalhada.ToString());
                                Console.WriteLine();

                                Console.WriteLine("1 - Deletar");
                                Console.WriteLine("2 - Atualizar");
                                Console.WriteLine("3 - Continuar");
                                Console.WriteLine();
                                int escolha = int.Parse(Console.ReadLine());
                                switch (escolha)
                                {
                                    case 1:
                                        repositorio.Deletar(resultadosPesquisa[pessoaSelecionada]);
                                        Console.WriteLine("Pessoa deletada com sucesso!");

                                        List<Pessoa> ListaCompletaED = repositorio.ListaCompleta();
                                        if (ListaCompletaED.Any())
                                        {
                                            repositorio.ExportarRepositorio();
                                            Console.WriteLine("");
                                            Console.WriteLine("Dados Exportados com sucesso!");
                                            
                                        }
                                        else
                                        {
                                            Console.WriteLine("Lista Vazia, não existem dados a serem exportados");
                                        }

                                        break;
                                    case 2:
                                        Console.WriteLine("Digite o nome da pessoa: ");
                                        string novoNome = Console.ReadLine().ToUpper();

                                        Console.WriteLine("Digite o sobrenome da pessoa: ");
                                        string novoSobrenome = Console.ReadLine().ToUpper();

                                        Console.WriteLine("Digite a data de nascimento da pessoa no formato(dd/MM/yyyy): ");
                                        DateTime novaDataDeNascimento = DateTime.Parse(Console.ReadLine());

                                        Pessoa novaPessoa = new Pessoa(novoNome, novoSobrenome, novaDataDeNascimento);

                                        repositorio.Atualizar(resultadosPesquisa[pessoaSelecionada], novaPessoa);

                                        Console.WriteLine("Pessoa Atualizada com sucesso!");

                                        List<Pessoa> ListaCompletaEAt = repositorio.ListaCompleta();
                                        if (ListaCompletaEAt.Any())
                                        {
                                            repositorio.ExportarRepositorio();
                                            Console.WriteLine("");
                                            Console.WriteLine("Dados Exportados com sucesso!");

                                        }
                                        else
                                        {
                                            Console.WriteLine("Lista Vazia, não existem dados a serem exportados");
                                        }


                                        break;
                                    default:
                                        break;

                                }

                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Pessoa não encontrada!");
                            }
                        }
                        break;
                    // Adicionar Pessoas
                    case 2:

                        Console.Clear();
                        Cabecalho();
                        Pessoa pessoaAdicionada = AdicionarPessoa();
                        repositorio.Adicionar(pessoaAdicionada);

                        Console.WriteLine("Dados adicionados com sucesso!");
                        Console.WriteLine("");

                        List<Pessoa> ListaCompletaEA = repositorio.ListaCompleta();
                        if (ListaCompletaEA.Any())
                        {
                            repositorio.ExportarRepositorio();
                            Console.WriteLine("");
                            Console.WriteLine("Dados Exportados com sucesso!");

                        }
                        else
                        {
                            Console.WriteLine("Lista Vazia, não existem dados a serem exportados");
                        }



                        break;
                    // Importar Lista Externa
                    case 3:
                        Console.Clear();
                        Cabecalho();

                        if (repositorio.ExisteRepositorioExterno())
                        {
                            repositorio.ImportarRepositorio();

                            Console.WriteLine("Dados Importados com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Não existem dados a serem importados");
                        }

                        break;
                    // Exportar Lista Externa
                    case 4:
                        Console.Clear();
                        Cabecalho();

                        List<Pessoa> ListaCompletaE = repositorio.ListaCompleta();
                        if (ListaCompletaE.Any())
                        {
                            repositorio.ExportarRepositorio();
                            Console.WriteLine("Dados Exportados com sucesso!");                            

                        }
                        else
                        {
                            Console.WriteLine("Lista Vazia, não existem dados a serem exportados");
                        }

                                               

                        break;

                    case 5:
                        Console.Clear();
                        Cabecalho();
                        List<Pessoa> ListaCompletaI = repositorio.ListaCompleta();
                        if (ListaCompletaI.Any())
                        {
                            Console.WriteLine("Lista Completa de pessoas rodando no sistema no momento");
                            Console.WriteLine("");
                            foreach (Pessoa p in ListaCompletaI)
                            {
                                Console.WriteLine(p.Nome + " " + p.Sobrenome);
                            }
                           
                        }
                        else
                        {
                            Console.WriteLine("Lista Vazia, importe dados ou adicione pessoas");
                        }
                        break;
                    // Sair
                    default:
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal");
                Console.ReadKey();

                Console.Clear();
                Cabecalho();
                ListaAniversariosHoje(repositorio.ListaCompleta());
                opcaoSelecionada = MenuPrincipal();

            }
        }
        static void Cabecalho()
        {
            Console.WriteLine("Gerenciador de Aniversário");
            Console.WriteLine();
        }

        static int MenuPrincipal()
        {
            Console.WriteLine("Selecione uma das opções abaixo: ");
            Console.WriteLine("1 - Pesquisar pessoas");
            Console.WriteLine("2 - Adicionar pessoas");
            Console.WriteLine("3 - Importar dados");
            Console.WriteLine("4 - Exportar dados");
            Console.WriteLine("5 - Lista Completa");
            Console.WriteLine("6 - Sair");
            Console.WriteLine();


            int selecao = int.Parse(Console.ReadLine());

            return selecao;
        }
        static Pessoa AdicionarPessoa()
        {
            int selecaoDeDadosCorretos;
            string addNome;
            string addSobrenome;
            DateTime addDataDeNascimento;

            do
            {
                Console.WriteLine("- Adicionar pessoa ");
                Console.WriteLine();
                Console.WriteLine("Digite o nome da pessoa: ");
                addNome = Console.ReadLine().ToUpper();

                Console.WriteLine("Digite o sobrenome da pessoa: ");
                addSobrenome = Console.ReadLine().ToUpper();

                Console.WriteLine("Digite a data de nascimento da pessoa no formato(dd/MM/yyyy): ");
                addDataDeNascimento = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("---------------------------------------------------");

                Console.WriteLine("Os dados abaixo estão corretos ?");
                Console.WriteLine();
                Console.WriteLine("Nome: {0} {1}", addNome, addSobrenome);
                Console.WriteLine("Data do aniversário: {0}", addDataDeNascimento.ToShortDateString());
                Console.WriteLine();
                Console.WriteLine("1 - Sim");
                Console.WriteLine("2 - Não");
                Console.WriteLine();

                selecaoDeDadosCorretos = int.Parse(Console.ReadLine());
                Console.WriteLine();

            } while (selecaoDeDadosCorretos != 1);

            Pessoa pessoaAdd = new Pessoa(addNome, addSobrenome, addDataDeNascimento);

            return pessoaAdd;
        }

        static void ListaAniversariosHoje(List<Pessoa> p)
        {

            AniversarioHoje An = new AniversarioHoje(p);
            List<Pessoa> lista = An.QuemFazAniversarioHoje();

            Console.WriteLine("Número de pessoas que fazem aniversario hoje " + lista.Count);
            Console.WriteLine("");

            if (lista.Any())
            {
                Console.WriteLine("Aniversarios hoje: ");
                Console.WriteLine("");
                foreach (Pessoa pe in lista)
                {
                    Console.WriteLine("Nome Completo: " + pe.Nome + " " + pe.Sobrenome);
                }
            }
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("");
        }

    }
}
