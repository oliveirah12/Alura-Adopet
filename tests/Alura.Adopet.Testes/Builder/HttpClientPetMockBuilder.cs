using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Http;
using Moq;

namespace Alura.Adopet.Testes.Builder;

internal static class HttpClientPetMockBuilder
{
    public static Mock<PetService> GetMock()
    {
        var httpClientPet = new Mock<PetService>(MockBehavior.Default,
            It.IsAny<HttpClient>());
        return httpClientPet;
    }

    public static Mock<PetService> GetMockList(List<Pet> lista)
    {
        var httpClientPet = new Mock<PetService>(MockBehavior.Default,
            It.IsAny<HttpClient>());
        httpClientPet.Setup(_ => _.ListAsync())
            .ReturnsAsync(lista);
        return httpClientPet;
    }

}
