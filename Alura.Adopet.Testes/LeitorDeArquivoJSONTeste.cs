using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Testes
{
    public class LeitorDeArquivoJSONTeste : IDisposable
    {
        private string caminhoArquivo;
        public LeitorDeArquivoJSONTeste()
        {
            //Setup
            string conteudo = @"
            [
              {
                ""Id"": ""68286fbf-f6f4-4924-adab-0637511813e0"",
                ""Nome"": ""Mancha"",
                ""Tipo"": 1
              },
              {
                ""Id"": ""68286fbf-f6f4-4924-adab-0637511672e0"",
                ""Nome"": ""Alvo"",
                ""Tipo"": 1
              },
              {
                ""Id"": ""68286fbf-f6f4-1234-adab-0637511672e0"",
                ""Nome"": ""Pinta"",
                ""Tipo"": 1
              }
            ]
            ";

            string nomeRandomico = $"{Guid.NewGuid()}.json";

            File.WriteAllText(nomeRandomico, conteudo);
            caminhoArquivo = Path.GetFullPath(nomeRandomico);
        }

        [Fact]
        public void QuandoArquivoExistenteDeveRetornarUmaListaDePets()
        {
            //Arrange            
            //Act
            var listaDePets = new LeitorDeArquivosJSON(caminhoArquivo).RealizaLeitura()!;
            //Assert
            Assert.NotNull(listaDePets);
            Assert.IsType<List<Pet>?>(listaDePets);
        }

        [Fact]
        public void QuandoArquivoNaoExistenteDeveRetornarNulo()
        {
            //Arrange            
            //Act
            var listaDePets = new LeitorDeArquivosJSON("").RealizaLeitura();
            //Assert
            Assert.Null(listaDePets);
        }

        [Fact]
        public void QuandoArquivoForNuloDeveRetornarNulo()
        {
            //Arrange            
            //Act
            var listaDePets = new LeitorDeArquivosJSON(null).RealizaLeitura();
            //Assert
            Assert.Null(listaDePets);
        }

        public void Dispose()
        {
            //ClearDown
            File.Delete(caminhoArquivo);
        }
    }
}
