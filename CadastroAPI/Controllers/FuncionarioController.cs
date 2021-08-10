using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CadastroAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase
    {
        public FuncionarioController()
        {
        }

        [HttpPost]
        public Funcionario Post(Funcionario funcionario)
        {
            APIContext context = new APIContext();

            context.Funcionarios.Add(funcionario);
            context.SaveChanges();

            return funcionario;
        }

        [HttpPut]
        public Funcionario Put(Funcionario funcionario)
        {
            APIContext context = new APIContext();

            context.Funcionarios.Update(funcionario);
            context.SaveChanges();

            return funcionario;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            APIContext context = new APIContext();
            
            try
            {
                Funcionario funcionario = context.Funcionarios.FirstOrDefault(x => x.Id == id);
                context.Funcionarios.Remove(funcionario);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpGet]
        public List<Funcionario> GetTodos()
        {
            APIContext context = new APIContext();
            List<Funcionario> lista = context.Funcionarios.ToList();
            return lista;
        }
    }
}
