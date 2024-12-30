using Alura.Adopet.Console.Util;
using FluentResults;
using System;
using System.Reflection;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "help",
     documentacao: "adopet help comando que exibe informações da ajuda. \n" +
        "adopet help <NOME_COMANDO> para acessar a ajuda de um comando específico.")]
    internal class Help:IComando
    {
        private Dictionary<string, DocComando> docs;

        public Help()
        {
            docs = DocumentacaoDoSistema.ToDictionary(Assembly.GetExecutingAssembly()); 
        }

        public Task<Result> ExecutarAsync(string[] args)
        {
            try
            {
                this.ExibeDocumentacao(parametros: args);
                return Task.FromResult(Result.Ok());
            }
            catch (Exception ex)
            {
                return Task.FromResult(Result.Fail(new Error(ex.Message).CausedBy(ex)));
            } 

        }

        private void ExibeDocumentacao(string[] parametros)
        {
            // se não passou mais nenhum argumento mostra help de todos os comandos
            if (parametros.Length == 1)
            {
                System.Console.WriteLine($"Adopet (1.0) - Aplicativo de linha de comando (CLI).");
                System.Console.WriteLine($"Realiza a importação em lote de um arquivos de pets.");
                System.Console.WriteLine($"Comando possíveis: ");
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

            }
        }
    }
}
