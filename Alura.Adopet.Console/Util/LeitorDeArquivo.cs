using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Util
{
    public class LeitorDeArquivo
    {
        private string _caminhoArquivo;

        public LeitorDeArquivo(string caminhoArquivo)
        {
            _caminhoArquivo = caminhoArquivo;
        }

        public virtual List<Pet> RealizaLeitura()
        {
            if(_caminhoArquivo == null) return null;
            if(!File.Exists(_caminhoArquivo)) return null;

            List<Pet> listaDePet = new List<Pet>();
            using (StreamReader sr = new StreamReader(_caminhoArquivo))
            {
                System.Console.WriteLine("----- Dados a serem importados -----");
                while (!sr.EndOfStream)
                {
                    // separa linha usando ponto e vírgula
                    string[]? propriedades = sr.ReadLine().Split(';');
                    // cria objeto Pet a partir da separação
                    Pet pet = new Pet(Guid.Parse(propriedades[0]),
                    propriedades[1],
                    int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro
                    );
                    listaDePet.Add(pet);

                }
            }

            return listaDePet;
        }
    }
}
