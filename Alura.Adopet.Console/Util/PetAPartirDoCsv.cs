using Alura.Adopet.Console.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Util
{
    public static class PetAPartirDoCsv
    {
        public static Pet ConverteDoTexto(this string? linha)
        {     

            string[]? propriedades = linha?.Split(';') ?? throw new ArgumentNullException("Linha Nula");

            if (string.IsNullOrEmpty(linha)) throw new ArgumentException("Linha Vazia");

            if(propriedades.Length != 3) throw new ArgumentException("Campos Insuficientes");

            if(!Guid.TryParse(propriedades[0], out Guid petId)) throw new ArgumentException("GUID Inválido");

            bool sucesso = int.TryParse(propriedades[2], out int tipoPet);
            if(!sucesso) throw new ArgumentException("Tipo de Pet inválido");

            if (tipoPet != 0 && tipoPet != 1) throw new ArgumentException("Tipo de Pet inválido");

            return new Pet(petId, propriedades[1], tipoPet == 0 ? TipoPet.Gato : TipoPet.Cachorro
            );
        }
    }
}
