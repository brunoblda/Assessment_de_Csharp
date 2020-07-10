using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BibliotecaNegocio;

namespace GerenciadorDeAniversariosV3
{
    public class RepositorioExterno
    {

        //public string pasta = @"C:\DataBase\";
        public string pasta = @".\";
        public string nomeArquivo = "GerenciadorDeAniversarios.txt";

        public List<Pessoa> ImportarLista()
        {
            List<Pessoa> pessoas = new List<Pessoa>();

            string caminhoArquivo = Path.Combine(pasta, nomeArquivo);
            if (File.Exists(caminhoArquivo))
            {

                List<string> linhas = File.ReadAllLines(caminhoArquivo).ToList();

                List<string> linhasFiltradas = new List<string>();

                //Eliminar linhas vazias
                foreach (string linha in linhas)
                {
                    if (!(string.IsNullOrEmpty(linha)))
                    {
                        linhasFiltradas.Add(linha);
                    }
                }

                if (linhasFiltradas.Any())
                {                       
                    foreach (string linha in linhasFiltradas)
                    {                                    
                        List<string> subs = linha.Split('.').ToList();

                        Pessoa p = new Pessoa(subs[0], subs[1], DateTime.Parse(subs[2]));
                                    
                        pessoas.Add(p);
                    }
                }
            }
            return pessoas;
        }

        public void ExportarLista(List<Pessoa> pessoas)
        {
            Directory.CreateDirectory(pasta);

            string caminhoArquivo = Path.Combine(pasta, nomeArquivo);

            using StreamWriter escrever = new StreamWriter(caminhoArquivo, false);
            foreach (Pessoa pessoa in pessoas)
            {
                escrever.Write(pessoa.ToString());
            }

        }
    }
}
