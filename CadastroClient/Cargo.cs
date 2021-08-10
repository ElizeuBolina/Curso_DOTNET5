using System.Collections.Generic;

namespace CadastroAPI
{
    public class Cargo
    {
        public int Id {get;set;}
        public string Nome { get; set; }

        public List<Funcionario> Funcionarios { get; } = new List<Funcionario>();
    }
}
