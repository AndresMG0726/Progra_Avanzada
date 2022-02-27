using System;
using System.Collections.Generic;
using System.Text;
using data = BE.DAL.DO.Objetos;
using BE.DAL.EF;
using BE.DAL.Repository;
using BE.DAL.DO.Interfaces;
using System.Threading.Tasks;

namespace BE.DAL
{
    public class Products : ICRUD<data.Products>
    {
        private RepositoryProducts repo;
        public Products(NDbContext dbContext) 
        {
            repo = new RepositoryProducts(dbContext);
        }

        public void Delete(data.Products t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Products> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Products>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }


        public data.Products GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Products> GetOneByIdAsync(int id)
        {
            return repo.GetOneByIdAsinc(id);
        }

        public void Inset(data.Products t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Products t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
