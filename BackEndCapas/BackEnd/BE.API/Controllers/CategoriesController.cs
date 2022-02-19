using BE.DAL.DO.Objetos;
using BE.DAL.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.API.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly NDbContext _context;

        public CategoriesController(NDbContext context)
        {
            _context = context;
        }
        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categories>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
            // return new BE.BS.Categories(_context).GetAll();
        }
    }
}
