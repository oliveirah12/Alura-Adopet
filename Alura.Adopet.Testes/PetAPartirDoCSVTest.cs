using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes
{
    public class PetAPartirDoCsvTest
    {
        [Fact]
        public void QuandoStringForValidaDeveRetornarUmPet()
        {
            //Arrange
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";
            
            //Act
            Pet pet = linha.ConverteDoTexto();

            //Assert
            Assert.NotNull(pet);
        }

        [Fact]
        public void QuandoStringForNulaDeveLancarArgumentNullException()
        {
            //Arrange
            string linha = null;

            //Act + Assert
            Assert.Throws<ArgumentNullException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void QuandoStringForVaziaDeveRetornarUmaArgumentException()
        {
            //Arrange
            string linha = "";

            //Act + Assert
            Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void QuandoStringTiverCamposInsuficientesDeveRetornarUmaArgumentException()
        {
            //Assert
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;1";

            //Act + Assert
            Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void QuandoGUIDInvalidoDeveRetornarUmaArgumentException()
        {
            //Assert
            string linha = "456b24f4845d-4a80e8854a41;Lima Limão;1";

            //Act + Assert
            Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void QuandoTipoInvalidoDeveRetornarUmaArgumentException()
        {
            //Assert
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;5";

            //Act + Assert
            Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
        }
    }
}
