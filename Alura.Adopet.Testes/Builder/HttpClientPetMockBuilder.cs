using Alura.Adopet.Console.Servicos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes.Builder
{
    public static class HttpClientPetMockBuilder
    {
        public static Mock<HttpClientPet> CriaMock()
        {
            var httpClientPet = new Mock<HttpClientPet>(MockBehavior.Default, It.IsAny<HttpClient>());

            return httpClientPet;

        }

    }
}
