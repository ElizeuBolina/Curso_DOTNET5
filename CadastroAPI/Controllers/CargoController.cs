using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CadastroAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CargoController : ControllerBase
    {
        public CargoController()
        {
        }

        [HttpPost]
        public Cargo Post(string nome)
        {
            APIContext context = new APIContext();
            
            Cargo cargo = new Cargo();
            cargo.Nome = nome;

            context.Cargos.Add(cargo);
            context.SaveChanges();

            return cargo;
        }

        [HttpGet]
        public List<Cargo> Get()
        {
            APIContext context = new APIContext();
            List<Cargo> lista = context.Cargos.ToList();
            return lista;
        }
    }
}
