using Microsoft.AspNetCore.Mvc;
using Projeto_SQL.Model;


namespace Projeto_SQL
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastoController : Controller
    {
        [HttpPost]
        public void Post([FromBody] Gasto gasto )
        {
            using (var _context = new Hotel2Context())
            {
                _context.Gastos.Add(gasto);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<Gasto> Get()
        {
            using (var _context = new Hotel2Context())
            {
                return _context.Gastos.ToList();
            }
        }

         [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.Gastos.FirstOrDefault(t => t.IdGasto == id);
                if (item == null){
                    return NotFound();
                }
                return Ok(item);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Gasto gasto)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.Gastos.FirstOrDefault(t => t.IdGasto == id);
                if (item == null){
                    return;
                }
                _context.Entry(item).CurrentValues.SetValues(gasto);
                _context.SaveChanges();
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.Gastos.FirstOrDefault(t => t.IdGasto == id);
                if (item == null){
                    return;
                }
                _context.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}