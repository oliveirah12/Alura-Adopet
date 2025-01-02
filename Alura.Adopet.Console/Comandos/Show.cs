using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.Util;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComandoAttribute(instrucao: "show",
       documentacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
    internal class Show:IComando
    {
        private readonly ILeitorDeArquivos leitor;

        public Show(ILeitorDeArquivos leitor)
        {
            this.leitor = leitor;
        }

        public Task<Result> ExecutarAsync()
        {
            try
            {
               return this.ExibeConteudoArquivo(); 
            }
            catch (Exception exception)
            {
               return Task.FromResult(Result.Fail(new Error("Importação falhou!\n" + exception.Message).CausedBy(exception)));
            }
        }

        private Task<Result> ExibeConteudoArquivo()
        {           
            var listaDepets = leitor.RealizaLeitura();       
            return Task.FromResult(Result.Ok().WithSuccess(new SuccessWithPets(listaDepets, "Exibição do arquivo realizada com sucesso!")));

        }
    }
}
