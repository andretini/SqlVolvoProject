using Microsoft.AspNetCore.Mvc;
using Projeto_SQL.Model;


namespace Projeto_SQL
{
    [Route("api/[controller]")]
    [ApiController]
    public class LavanderiaController : Controller
    {
        [HttpPost]
        public void Post([FromBody] ServicosLavanderium lavanderia )
        {
            using (var _context = new Hotel2Context())
            {
                _context.ServicosLavanderia.Add(lavanderia);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<ServicosLavanderium> Get()
        {
            using (var _context = new Hotel2Context())
            {
                return _context.ServicosLavanderia.ToList();
            }
        }

         [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.ServicosLavanderia.FirstOrDefault(t => t.IdLavagem == id);
                if (item == null){
                    return NotFound();
                }
                return Ok(item);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ServicosLavanderium lavanderia)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.ServicosLavanderia.FirstOrDefault(t => t.IdLavagem == id);
                if (item == null){
                    return;
                }
                _context.Entry(item).CurrentValues.SetValues(lavanderia);
                _context.SaveChanges();
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.ServicosLavanderia.FirstOrDefault(t => t.IdLavagem == id);
                if (item == null){
                    return;
                }
                _context.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}