using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrecaoDoCheckPoint01
{
    public class Clientes
    {

        public string NomeCli { get; set; }

        public string DataNascCli { get; set; }

        public void ExibirDadosCli()
        {
            Console.WriteLine($"Nome: {NomeCli} - Data de Nascimento (dd/mm/aaaa): {DataNascCli}");
        }

        public string GerarLinhaArquivoCli()
        {
            return $"{NomeCli};{DataNascCli}";
        }
    }
}


