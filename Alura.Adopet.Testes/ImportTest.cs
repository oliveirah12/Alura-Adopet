using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;
using Alura.Adopet.Testes.Builder;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes
{
    public class ImportTest
    {
        [Fact]
        public async void QuandoListaVaziaNaoDeveChamarCreatePetAsync()
        {
            //Arrange
            List<Pet> listaDePet = new();
            var leitorDeArquivo = LeitorDeArquivosMockBuilder.CriaMock(listaDePet);

            var httpClientPet = new Mock<HttpClientPet>(MockBehavior.Default, 
                It.IsAny<HttpClient>());

            var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);
            string[] args = { "import", "lista.csv" };

            //Act
            await import.ExecutarAsync(args);

            //Assert
            httpClientPet.Verify(_=>_.CreatePetAsync(It.IsAny<Pet>()), Times.Never);
        }

        [Fact]
        public async Task QuandoArquivoNaoExistenteDeveGerarFalha()
        {
            //Arrange
            List<Pet> listaDePet = new();
            var leitor = LeitorDeArquivosMockBuilder.CriaMock(listaDePet);
            leitor.Setup(_ => _.RealizaLeitura()).Throws<FileNotFoundException>();

            var httpClientPet = HttpClientPetMockBuilder.CriaMock() ;

            string[] args = { "import", "lista.csv" };

            var import = new Import(httpClientPet.Object, leitor.Object);

            //Act
            var resultado = await import.ExecutarAsync(args);

            //Assert
            Assert.True(resultado.IsFailed);

        }

        [Fact]
        public async Task QuandoPetEstiverNoArquivoDeveSerImportado()
        {
            //Arrange
            var listaDePets = new List<Pet>();
            var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"),
                "Lima", TipoPet.Cachorro);

            listaDePets.Add(pet);

            var leitor = LeitorDeArquivosMockBuilder.CriaMock(listaDePets);
            var httpClientpet = HttpClientPetMockBuilder.CriaMock();

            var import = new Import(httpClientpet.Object, leitor.Object);
            string[] args = { "import", "lista.csv" };

            //Act
            var resultado = await import.ExecutarAsync(args);

            //Assert
            Assert.True(resultado.IsSuccess);
            var sucesso = (SuccessWithPets)resultado.Successes[0];
            Assert.Equal("Lima", sucesso.Data.First().Nome);
        }
    }
}
