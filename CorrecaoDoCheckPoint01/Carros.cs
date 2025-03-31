using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrecaoDoCheckPoint01
{
    public class Carros
    {
        // se não tem nada no class, a classe é privada => para poder usar depois = public class XXX

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public int Ano { get; set; }

        public double Valor { get; set; }

        private double ValorCompra { get; set; }    

        public void ExibirDados()
        {
            //Console.WriteLine($"Marca: {Marca}");
            //Console.WriteLine($"Modelo: {Modelo}");
            //Console.WriteLine($"Ano: {Ano}");
            //Console.WriteLine($"Valor: {Valor:F2}");
        // Forma concatenada:
            Console.WriteLine($"Marca: {Marca} - Modelo: {Modelo} - Ano: {Ano} - Valor: R${Valor:F2}");
        }

        public string GerarLinhaArquivo()
        {
            return $"{Marca};{Modelo};{Ano};{Valor}";
        }
    }
}
