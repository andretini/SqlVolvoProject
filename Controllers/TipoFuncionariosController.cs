using Microsoft.AspNetCore.Mvc;
using Projeto_SQL.Model;


namespace Projeto_SQL
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoFuncionariosController : Controller
    {
        [HttpPost]
        public void Post([FromBody] TipoFuncionario tipoFuncionario )
        {
            using (var _context = new Hotel2Context())
            {
                _context.TipoFuncionarios.Add(tipoFuncionario);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<TipoFuncionario> Get()
        {
            using (var _context = new Hotel2Context())
            {
                return _context.TipoFuncionarios.ToList();
            }
        }

         [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.TipoFuncionarios.FirstOrDefault(t => t.IdProficao == id);
                if (item == null){
                    return NotFound();
                }
                return Ok(item);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TipoFuncionario tipoFuncionario)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.TipoFuncionarios.FirstOrDefault(t => t.IdProficao == id);
                if (item == null){
                    return;
                }
                _context.Entry(item).CurrentValues.SetValues(tipoFuncionario);
                _context.SaveChanges();
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.TipoFuncionarios.FirstOrDefault(t => t.IdProficao == id);
                if (item == null){
                    return;
                }
                _context.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}