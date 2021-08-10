using System;
using System.Collections.Generic;
using CadastroAPI;
using RestSharp;

namespace CadastroClient
{
    class Program
    {
        RestClient client = new RestClient("http://localhost:5000/");
        
        static void Main(string[] args)
        {
            string opcao = "";
            while(opcao != "0")
            {
                ImprimirMenu();

                opcao = Console.ReadLine();

                Console.Clear();
                
                if(opcao == "1")
                {
                    AdicionarCargo();
                }
                else if(opcao == "2")
                {
                    ListarCargos();
                }
                else if(opcao == "3")
                {
                    AdicionarFuncionario();
                }    
                else if(opcao == "4")
                {
                    AtualizarFuncionario();
                }      
                else if(opcao == "5")
                {
                    ExcluirFuncionario();
                }      
                else if(opcao == "6")
                {
                    ListarFuncionarios();
                }                           
            }
            
        }

        private static void ExcluirFuncionario()
        {
            Console.WriteLine("Opção 5 - Excluir Funcionario");
            Console.WriteLine("Digite o Id do Funcionario!");
            string id = Console.ReadLine();

            RestClient client = new RestClient("http://localhost:5000/");
            RestRequest request = new RestRequest("/Funcionario");    
            request.AddQueryParameter("id", id);
            var response = client.Delete(request);

            if(response.StatusCode == System.Net.HttpStatusCode.OK && response.Content == "true")
                Console.WriteLine("Funcionario excluido com sucesso!");
            else
                Console.WriteLine("Funcionario não encontrado!");

            Console.ReadKey();
        }

        private static void ListarFuncionarios()
        {
            Console.WriteLine("Opção 2 -Listar Funcionarios");

            
            RestClient client = new RestClient("http://localhost:5000/");
            RestRequest request = new RestRequest("/Funcionario");            
            var response = client.Get<List<Funcionario>>(request);

            List<Funcionario> lista = response.Data;


            Console.WriteLine("ID       Nome        Salario       CargoCode");
            foreach(Funcionario funcionario in lista)
            {
                Console.WriteLine(funcionario.Id + "    " + funcionario.Nome + "      " + funcionario.Salario + "       " + funcionario.CargoId);
            }
            Console.ReadKey();
        }

        private static void AdicionarFuncionario()
        {
            Console.WriteLine("Opção 3 - Adicionar Funcionario");
            Console.WriteLine("Digite o nome do funcionario!");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o salario!");
            decimal salario = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Digite o código do cargo!");
            int cargoId = int.Parse(Console.ReadLine());

            Funcionario funcionario = new Funcionario();
            funcionario.Nome = nome;
            funcionario.Salario = salario;
            funcionario.CargoId = cargoId;

            RestClient client = new RestClient("http://localhost:5000/");
            RestRequest request = new RestRequest("/Funcionario");    
            request.AddJsonBody(funcionario);
            var response = client.Post(request);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
                Console.WriteLine("Funcionario adicionado com sucesso!");
            else
                Console.WriteLine("Erro ao adicionar o funcionario!");

            Console.ReadKey();

        }

        private static void AtualizarFuncionario()
        {
            Console.WriteLine("Opção 4 - Atualizar Funcionario");
            Console.WriteLine("Digite o Id do funcionario!");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o nome do funcionario!");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o salario!");
            decimal salario = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Digite o código do cargo!");
            int cargoId = int.Parse(Console.ReadLine());

            Funcionario funcionario = new Funcionario();
            funcionario.Id = id;
            funcionario.Nome = nome;
            funcionario.Salario = salario;
            funcionario.CargoId = cargoId;

            RestClient client = new RestClient("http://localhost:5000/");
            RestRequest request = new RestRequest("/Funcionario");    
            request.AddJsonBody(funcionario);
            var response = client.Put(request);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
                Console.WriteLine("Funcionario atualizado com sucesso!");
            else
                Console.WriteLine("Erro ao atualizar o funcionario!");

            Console.ReadKey();

        }

        private static void ListarCargos()
        {
            Console.WriteLine("Opção 2 -Listar Cargos");

            
            RestClient client = new RestClient("http://localhost:5000/");
            RestRequest request = new RestRequest("/Cargo");            
            var response = client.Get<List<Cargo>>(request);

            List<Cargo> lista = response.Data;


            Console.WriteLine("ID   Nome");
            foreach(Cargo cargo in lista)
            {
                Console.WriteLine(cargo.Id + "  " + cargo.Nome);
            }
            Console.ReadKey();
        }

        static void AdicionarCargo()
        {
            Console.WriteLine("Opção 1 -Adicionar um Cargo");
            Console.WriteLine("Digite o nome do cargo!");
            string nome = Console.ReadLine();

            RestClient client = new RestClient("http://localhost:5000/");
            RestRequest request = new RestRequest("/Cargo");
            request.AddQueryParameter("nome", nome);
            
            client.Post(request);

            Console.WriteLine("Cargo adicionado com sucesso!!!");
            Console.ReadKey();
        }

        static void ImprimirMenu()
        {
            Console.Clear();
            Console.WriteLine("Programa - Cadastro de Funcionario!");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("--------------Menu-----------------");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("1-Adicionar um Cargo");
            Console.WriteLine("2-Listar Cargos");
            Console.WriteLine("3-Adicionar um Funcionario");
            Console.WriteLine("4-Atualizar um Funcionario");
            Console.WriteLine("5-Excluir um Funcionario");
            Console.WriteLine("6-Listar Todos Funcionarios");
            Console.WriteLine("-----------------------------------");
        }
    }
}
