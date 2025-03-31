using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Correção do CheckPoint 01
// 1° definir as prioridades

namespace CorrecaoDoCheckPoint01
{
    class Program
    {
        static List<Carros> listaCarros = new List<Carros>();
        static List<Clientes> listaClientes = new List<Clientes>();
        static void Main(string[] args)
        {
            if (Login())
            { 
                Menu();
                CadastrarCliente();
                CadastrarVeiculo();
                ListarVeiculos();
                ListarClientes();
            }
        }

        static bool Login()
        {
            int tentativas = 0;
            string usuarioCorreto = "camargo";
            string senhaCorreta = "97956";

            while (tentativas < 3)
            {
                Console.Write("Usuário: ");
                string usuario = Console.ReadLine().ToLower();

                Console.Write("Senha (RM): ");
                string senha = Console.ReadLine();

                if (usuario == usuarioCorreto && senha == senhaCorreta)
                {
                    Console.Write("Login realizado com sucesso!");
                    return true;
                }
                tentativas++;
                Console.WriteLine($"Usuário ou senha inválidos! Restam: {3 - tentativas} tentativas.");

            }
            Console.WriteLine("Número de máximo de tentativas excedido!");
            return false;
        }

        
        static void CadastrarCliente()
        {
            Clientes cliente = new Clientes();

            Console.Write("Nome completo: ");
            cliente.NomeCli = Console.ReadLine();

            DateTime dataNascimento;
            bool idadeValida = false;

            do
            {
                Console.Write("Digite sua data de nascimento (dd/mm/aaaa): ");
                string entrada = Console.ReadLine();

                if (!DateTime.TryParseExact(entrada, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataNascimento))
                {
                    Console.WriteLine("Formato inválido! Use dd/mm/aaaa.");
                    continue;
                }

                // Calcula a idade
                int idade = CalcularIdade(dataNascimento);

                if (idade < 18)
                {
                    Console.WriteLine("Cadastro permitido apenas para maiores de 18 anos.");
                }
                else
                {
                    idadeValida = true;
                }

            } while (!idadeValida);

            Console.WriteLine("Cadastro realizado com sucesso!");
        }

        static int CalcularIdade(DateTime dataNascimento)
        {
            DateTime hoje = DateTime.Today;
            int idade = hoje.Year - dataNascimento.Year;

            // Ajusta a idade se ainda não fez aniversário este ano
            if (dataNascimento.Date > hoje.AddYears(-idade))
            {
                idade--;
            }

            return idade;
        }
        static void ListarClientes()
        {
            if (listaClientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado!");
                return;
            }
            Console.WriteLine("\nLista de clientes: ");
            foreach (Clientes cliente in listaClientes)
            {
                // método criado na classe Clientes
                cliente.ExibirDadosCli();
            }
        }

        static void CadastrarVeiculo()
        {
            Carros carro = new Carros();

            Console.Write("Marca:");
            carro.Marca = Console.ReadLine().ToUpper();

            Console.WriteLine("Modelo:");
            carro.Modelo = Console.ReadLine().ToUpper();

            Console.WriteLine("Ano:");
            carro.Ano = Convert.ToInt32(Console.ReadLine());
            //do
            //{
                Console.WriteLine("Valor (mínimo R$ 60.000,00):");
                carro.Valor = Convert.ToDouble(Console.ReadLine());

                if (carro.Valor < 60000)
                {
                    Console.WriteLine("Valor inválido! O valor mínimo é R$ 60.000,00");
                }

            //} while (carro.Valor >= 60000);

            listaCarros.Add(carro);

        }

        static void ExportarTxt()
        {
            string caminho = "veiculos.txt";
            using (StreamWriter writer = new StreamWriter(caminho))
            {
                foreach (Carros carro in listaCarros)
                {
                    writer.WriteLine(carro.GerarLinhaArquivo());
                }

            }
            Console.WriteLine($"Veículos salvos com sucesso em '{caminho}'");
        }

        static void ListarVeiculos()
        {
            if(listaCarros.Count == 0)
            {
                Console.WriteLine("Nenhum veículo cadastrado!");
                return;
            }
            Console.WriteLine("\nLista de veículos: ");
            foreach (Carros carro in listaCarros)
            {
                // método criado na classe Carros
                carro.ExibirDados();
            }
        }

        static void ExportarTxtCli()
        {
            string caminhoCli = "clientes.txt";
            using (StreamWriter writer = new StreamWriter(caminhoCli))
            {
                foreach (Clientes cliente in listaClientes)
                {
                    writer.WriteLine(cliente.GerarLinhaArquivoCli());
                }

            }
            Console.WriteLine($"Veículos salvos com sucesso em '{caminhoCli}'");
        }

        static void Menu() 
        {
            int opcao;
            do
            {
                Console.WriteLine("\nMenu de opções");
                Console.WriteLine("1 - Cadastrar cliente");
                Console.WriteLine("2 - Listar clientes");
                Console.WriteLine("3 - Cadastrar veículo");
                Console.WriteLine("4 - Listar veículos");
                Console.WriteLine("5 - Exportar veículos cadastrados");
                Console.WriteLine("6 - Exportar clientes cadastrados");
                Console.WriteLine("7 - Sair");
                Console.Write("Digite a opção desejada: ");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarCliente();
                        break;
                    case 2:
                        ListarClientes();
                        break;
                    case 3:
                        CadastrarVeiculo();
                        break;
                    case 4:
                        ListarVeiculos();
                        break;
                    case 5:
                        ExportarTxt();
                        break;
                    case 6:
                        ExportarTxtCli();
                        break;
                    case 7:
                        Console.WriteLine("Saindo do sistema...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (opcao != 5);
        }
    }
}

