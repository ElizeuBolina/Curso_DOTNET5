using System.ComponentModel.DataAnnotations;

namespace CadastroAPI
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Salario { get; set; }

        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }
    }
}
