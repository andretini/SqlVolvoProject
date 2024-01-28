using Microsoft.AspNetCore.Mvc;
using Projeto_SQL.Model;


namespace Projeto_SQL
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : Controller
    {
        [HttpPost]
        public void Post([FromBody] Reserva reserva )
        {
            using (var _context = new Hotel2Context())
            {
                _context.Reservas.Add(reserva);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<Reserva> Get()
        {
            using (var _context = new Hotel2Context())
            {
                return _context.Reservas.ToList();
            }
        }

         [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.Reservas.FirstOrDefault(t => t.IdReserva == id);
                if (item == null){
                    return NotFound();
                }
                return Ok(item);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Reserva reserva)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.Reservas.FirstOrDefault(t => t.IdReserva == id);
                if (item == null){
                    return;
                }
                _context.Entry(item).CurrentValues.SetValues(reserva);
                _context.SaveChanges();
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.Reservas.FirstOrDefault(t => t.IdReserva == id);
                if (item == null){
                    return;
                }
                _context.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}