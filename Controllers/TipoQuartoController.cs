using Microsoft.AspNetCore.Mvc;
using Projeto_SQL.Model;


namespace Projeto_SQL
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoQuartoController : Controller
    {
        [HttpPost]
        public void Post([FromBody] TipoQuarto tipoQuarto )
        {
            using (var _context = new Hotel2Context())
            {
                _context.TipoQuartos.Add(tipoQuarto);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<TipoQuarto> Get()
        {
            using (var _context = new Hotel2Context())
            {
                return _context.TipoQuartos.ToList();
            }
        }

         [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.TipoQuartos.FirstOrDefault(t => t.IdPlanta == id);
                if (item == null){
                    return NotFound();
                }
                return Ok(item);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TipoQuarto tipoQuarto)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.TipoQuartos.FirstOrDefault(t => t.IdPlanta == id);
                if (item == null){
                    return;
                }
                _context.Entry(item).CurrentValues.SetValues(tipoQuarto);
                _context.SaveChanges();
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.TipoQuartos.FirstOrDefault(t => t.IdPlanta == id);
                if (item == null){
                    return;
                }
                _context.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}