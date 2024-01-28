using Microsoft.AspNetCore.Mvc;
using Projeto_SQL.Model;


namespace Projeto_SQL
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : Controller
    {
        [HttpPost]
        public void Post([FromBody] Funcionario funcionario )
        {
            using (var _context = new Hotel2Context())
            {
                _context.Funcionarios.Add(funcionario);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<Funcionario> Get()
        {
            using (var _context = new Hotel2Context())
            {
                return _context.Funcionarios.ToList();
            }
        }

         [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.Funcionarios.FirstOrDefault(t => t.IdFuncionario == id);
                if (item == null){
                    return NotFound();
                }
                return Ok(item);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Funcionario funcionario)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.Funcionarios.FirstOrDefault(t => t.IdFuncionario == id);
                if (item == null){
                    return;
                }
                _context.Entry(item).CurrentValues.SetValues(funcionario);
                _context.SaveChanges();
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.Funcionarios.FirstOrDefault(t => t.IdFuncionario == id);
                if (item == null){
                    return;
                }
                _context.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}