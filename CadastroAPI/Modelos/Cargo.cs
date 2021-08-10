using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CadastroAPI
{
    public class Cargo
    {
        [Key]
        public int Id {get;set;}
        public string Nome { get; set; }

        public List<Funcionario> Funcionarios { get; } = new List<Funcionario>();
    }
}
