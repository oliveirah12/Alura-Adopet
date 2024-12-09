﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console
{
    [DocComando(instrucao: "help", documentacao: "adopet help comando que exibe informações da ajuda.\n " +
        "adopet help <NOME_COMANDO> para acessar a ajuda de um comando específico.")]
    internal class Help
    {
        private Dictionary<string, DocComando> docs;

        public Help()
        {
            docs = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetCustomAttributes<DocComando>().Any())
                .Select(t => t.GetCustomAttribute<DocComando>()!)
                .ToDictionary(d => d.Instrucao);    
        }

        public void ExibeDocumentacao(string[] parametros)
        {
            if (parametros.Length == 1)
            {
                System.Console.WriteLine($"Adopet (1.0) - Aplicativo de linha de comando (CLI).");
                System.Console.WriteLine($"Realiza a importação em lote de um arquivos de pets.");
                System.Console.WriteLine($"Comando possíveis: ");
                //System.Console.WriteLine($" adopet help comando que exibe informações da ajuda.");
                //System.Console.WriteLine($" adopet help <NOME_COMANDO> para acessar a ajuda de um comando específico.");
                //System.Console.WriteLine($" adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.");
                //System.Console.WriteLine($" adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.");
                //System.Console.WriteLine($" adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet." + "\n");
                foreach (var doc in docs.Values)
                {
                    System.Console.WriteLine(doc.Documentacao);
                }
            
            }
            // exibe o help daquele comando específico
            else if (parametros.Length == 2)
            {
                string comandoASerExibido = parametros[1];

                if (docs.ContainsKey(comandoASerExibido))
                {

                    var comando = docs[comandoASerExibido];
                    System.Console.WriteLine(comando.Documentacao);

                }
                //if (comandoASerExibido.Equals("import"))
                //{
                //    System.Console.WriteLine($"adopet import <arquivo> " +
                //        "comando que realiza a importação do arquivo de pets.");
                //}
                //if (comandoASerExibido.Equals("show"))
                //{
                //    System.Console.WriteLine($"adopet show <arquivo>  comando que " +
                //        "exibe no terminal o conteúdo do arquivo importado.");
                //}
                //if (comandoASerExibido.Equals("list"))
                //{
                //    System.Console.WriteLine($"adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.");
                //}
            }
        }
    }
}
