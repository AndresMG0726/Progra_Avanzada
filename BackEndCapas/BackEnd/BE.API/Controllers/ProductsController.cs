using AutoMapper;
using BE.DAL.DO.Objetos;
using BE.DAL.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objetos;
using models = BE.API.DataModels;

namespace BE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public ProductsController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Products>>> GetProducts()
        {
            var res  = new BE.BS.Products(_context).GetAll();
            List<models.Products> mapaAux = _mapper.Map<IEnumerable<data.Products>, IEnumerable<models.Products>>(res).ToList();
            return mapaAux;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Products>> GetProducts(int id)
        {
            var products = await new BE.BS.Products(_context).GetOneByIdAsync(id);

            if (products == null)
            {
                return NotFound();
            }
            models.Products mapaAux = _mapper.Map<data.Products, models.Products>(products);
            return mapaAux;
        }


        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, models.Products products)
        {
            if (id != products.ProductId)
            {
                return BadRequest();
            }

            try
            {
                data.Products mapaAux = _mapper.Map<models.Products, data.Products>(products);
                new BE.BS.Products(_context).Update(mapaAux);
            }
            catch (Exception ee)
            {
                if (!ProductsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Products>> PostProducts(models.Products products)
        {
            try
            {
                data.Products mapaAux = _mapper.Map<models.Products, data.Products>(products);
                new BE.BS.Products(_context).Inset(mapaAux);
            }
            catch (Exception ee)
            {
                BadRequest();
            }

            return CreatedAtAction("GetProducts", new { id = products.ProductId }, products);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Products>> DeleteProducts(int id)
        {
            var products = await new BE.BS.Products(_context).GetOneByIdAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.Products(_context).Delete(products);
            }
            catch (Exception)
            {
                BadRequest();
            }
            models.Products mapaAux = _mapper.Map<data.Products, models.Products>(products);

            return mapaAux;
        }

        private bool ProductsExists(int id)
        {
            return (new BE.BS.Products(_context).GetOneById(id) != null);
        }
    }
}
