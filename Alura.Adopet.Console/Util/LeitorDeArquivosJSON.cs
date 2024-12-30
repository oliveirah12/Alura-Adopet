using Alura.Adopet.Console.Modelos;
using System.Text.Json;

namespace Alura.Adopet.Console.Util
{
    public class LeitorDeArquivosJSON
    {
        private string caminhoArquivo;

        public LeitorDeArquivosJSON(string caminhoArquivo)
        {
            this.caminhoArquivo = caminhoArquivo;
        }

        public IEnumerable<Pet> RealizaLeitura()
        {
            if(!File.Exists(caminhoArquivo))
            {
                return null;
            }
            using var stream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read);
            return JsonSerializer.Deserialize<IEnumerable<Pet>>(stream);
        }
    }
}
