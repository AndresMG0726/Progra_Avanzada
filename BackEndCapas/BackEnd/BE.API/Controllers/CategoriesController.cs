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

    public class CategoriesController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;
        public CategoriesController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Categories>>> GetCategories()
        {
           // return null;
           //return new BE.BS.Categories(_context).GetAll().ToList();
           var res = new BE.BS.Categories(_context).GetAll();
           List<models.Categories> mapaAux = _mapper.Map<IEnumerable<data.Categories>, IEnumerable<models.Categories>>(res).ToList();
           return mapaAux;
        }
        
        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Categories>> GetCategories(int id)
        {
            var categories = new BE.BS.Categories(_context).GetOneById(id);

            if (categories == null)
            {
                return NotFound();
            }

            models.Categories mapaAux = _mapper.Map<data.Categories, models.Categories>(categories);
            
            return mapaAux;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategories(int id, models.Categories categories)
        {
            if (id != categories.CategoryId)
            {
                return BadRequest();
            }

            try
            {
               data.Categories mapaAux = _mapper.Map<models.Categories, data.Categories>(categories);
               new BE.BS.Categories(_context).Update(mapaAux);
            }
            catch (Exception ee)
            {
                if (!CategoriesExists(id))
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


        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Categories>> PostCategories(models.Categories categories)
        {
            try
            {
                data.Categories mapaAux = _mapper.Map<models.Categories, data.Categories>(categories);
                new BE.BS.Categories(_context).Inset(mapaAux);
            }
            catch (Exception)
            {
                BadRequest();
            }
            return CreatedAtAction("GetCategories", new { id = categories.CategoryId }, categories);
        }


        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Categories>> DeleteCategories(int id)
        {
            var categories = new BE.BS.Categories(_context).GetOneById(id);
            if (categories == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.Categories(_context).Delete(categories);
            }
            catch (Exception)
            {
                BadRequest();
            }
            models.Categories mapaAux = _mapper.Map<data.Categories, models.Categories>(categories);

            return mapaAux;
        }

        private bool CategoriesExists(int id)
        {
            return (new BE.BS.Categories(_context).GetOneById(id) != null);
        }

    }
}
