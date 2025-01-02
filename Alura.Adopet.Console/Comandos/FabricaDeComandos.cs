using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Console.Servicos.Http;

namespace Alura.Adopet.Console.Comandos
{
    internal static class FabricaDeComandos
    {
        public static IComando? CriarComando(string[] argumentos)
        {
            var comando = argumentos[0];
            

            switch (comando)
            {
                case "import":
                    var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
                    var leitorDeArquivos = LeitorDeArquivosFactory.CreatePetFromArchiveType(argumentos[1]);
                    if (leitorDeArquivos is null)
                    {
                        return null;
                    }
                    return new Import(httpClientPet, leitorDeArquivos);     
                    
                case "list":
                    var httpClientPetList = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
                    return new List(httpClientPetList);  
                    
                case "show":
                    var leitorDeArquivosShow = LeitorDeArquivosFactory.CreatePetFromArchiveType(argumentos[1]);
                    if (leitorDeArquivosShow is null)
                    {
                        return null;
                    }
                    return new Show(leitorDeArquivosShow);

                case "help":
                    var comandoASerExibido = argumentos.Length==2? argumentos[1] : null;
                    return new Help(comandoASerExibido);

                default: return null;
            }           
        }
    }
}
