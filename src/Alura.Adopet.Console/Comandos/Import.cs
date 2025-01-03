using Alura.Adopet.Console.Atributos;
using FluentResults;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Servicos.Abstracoes;

namespace Alura.Adopet.Console.Comandos
{
    [DocComandoAttribute(instrucao: "import",
        documentacao: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
    public class Import:IComando
    {
        private readonly IApiService clientPet;

        private readonly ILeitorDeArquivos leitor;

        public Import(IApiService clientPet, ILeitorDeArquivos leitor)
        {
            this.clientPet = clientPet;
            this.leitor = leitor;
        }

        public async Task<Result> ExecutarAsync()
        {
            return await this.ImportacaoArquivoPetAsync();
        }

        private async Task<Result> ImportacaoArquivoPetAsync()
        {
            try
            {
                var listaDePet = leitor.RealizaLeitura();
                foreach (var pet in listaDePet)
                {                       
                   await clientPet.CreateAsync(pet);               
                }
                return Result.Ok().WithSuccess(new SuccessWithPets(listaDePet,"Importação Realizada com Sucesso!"));
            }
            catch (Exception exception)
            {

                return Result.Fail(new Error("Importação falhou!").CausedBy(exception));
            }
            
            
            
            
        }
    }
}
