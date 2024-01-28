using Microsoft.AspNetCore.Mvc;
using Projeto_SQL.Model;


namespace Projeto_SQL
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuartoController : Controller
    {
        [HttpPost]
        public void Post([FromBody] Quarto quarto )
        {
            using (var _context = new Hotel2Context())
            {
                _context.Quartos.Add(quarto);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<Quarto> Get()
        {
            using (var _context = new Hotel2Context())
            {
                return _context.Quartos.ToList();
            }
        }

         [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.Quartos.FirstOrDefault(t => t.IdQuarto == id);
                if (item == null){
                    return NotFound();
                }
                return Ok(item);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Quarto quarto)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.Quartos.FirstOrDefault(t => t.IdQuarto == id);
                if (item == null){
                    return;
                }
                _context.Entry(item).CurrentValues.SetValues(quarto);
                _context.SaveChanges();
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.Quartos.FirstOrDefault(t => t.IdQuarto == id);
                if (item == null){
                    return;
                }
                _context.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}