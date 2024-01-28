using Microsoft.AspNetCore.Mvc;
using Projeto_SQL.Model;


namespace Projeto_SQL
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        [HttpPost]
        public void Post([FromBody] Produto produto )
        {
            using (var _context = new Hotel2Context())
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<Produto> Get()
        {
            using (var _context = new Hotel2Context())
            {
                return _context.Produtos.ToList();
            }
        }

         [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.Produtos.FirstOrDefault(t => t.IdProduto == id);
                if (item == null){
                    return NotFound();
                }
                return Ok(item);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Produto produto)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.Produtos.FirstOrDefault(t => t.IdProduto == id);
                if (item == null){
                    return;
                }
                _context.Entry(item).CurrentValues.SetValues(produto);
                _context.SaveChanges();
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new Hotel2Context())
            {
                var item = _context.Produtos.FirstOrDefault(t => t.IdProduto == id);
                if (item == null){
                    return;
                }
                _context.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}