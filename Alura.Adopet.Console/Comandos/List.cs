using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using FluentResults;
using System;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "list",
      documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.")]
    internal class List: IComando
    {
        private readonly HttpClientPet clientPet;

        public List(HttpClientPet clientPet)
        {
            this.clientPet = clientPet;
        }

        public Task<Result> ExecutarAsync(string[] args)
        {
            return this.ListaDadosPetsDaAPIAsync();            
        }

        private async Task<Result> ListaDadosPetsDaAPIAsync()
        {
            try
            {
                IEnumerable<Pet>? pets = await clientPet.ListPetsAsync();
                System.Console.WriteLine("----- Lista de Pets importados no sistema -----");
                foreach (var pet in pets)
                {
                    System.Console.WriteLine(pet);
                }
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(new Error(ex.Message).CausedBy(ex));
            }
        }

    }
}
