using Microsoft.AspNetCore.Mvc;
using Projeto_SQL.Model;


namespace Projeto_SQL
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilialController : Controller
    {
        [HttpPost]
        public void Post([FromBody] Filial filial )
        {
            using (var _context = new Hotel2Context())
            {
                _context.Filials.Add(filial);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<Filial> Get()
        {
            using (var _context = new Hotel2Context())
            {
                return _context.Filials.ToList();
            }
        }

         [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.Filials.FirstOrDefault(t => t.IdFilial == id);
                if (item == null){
                    return NotFound();
                }
                return Ok(item);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Filial filial)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.Filials.FirstOrDefault(t => t.IdFilial == id);
                if (item == null){
                    return;
                }
                _context.Entry(item).CurrentValues.SetValues(filial);
                _context.SaveChanges();
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.Filials.FirstOrDefault(t => t.IdFilial == id);
                if (item == null){
                    return;
                }
                _context.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}