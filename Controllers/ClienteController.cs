using Microsoft.AspNetCore.Mvc;
using Projeto_SQL.Model;


namespace Projeto_SQL
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        [HttpPost]
        public void Post([FromBody] Cliente cliente )
        {
            using (var _context = new Hotel2Context())
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<Cliente> Get()
        {
            using (var _context = new Hotel2Context())
            {
                return _context.Clientes.ToList();
            }
        }

         [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.Clientes.FirstOrDefault(t => t.IdCliente == id);
                if (item == null){
                    return NotFound();
                }
                return Ok(item);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cliente cliente)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.Clientes.FirstOrDefault(t => t.IdCliente == id);
                if (item == null){
                    return;
                }
                _context.Entry(item).CurrentValues.SetValues(cliente);
                _context.SaveChanges();
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.Clientes.FirstOrDefault(t => t.IdCliente == id);
                if (item == null){
                    return;
                }
                _context.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}