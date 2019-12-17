using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectrum.Model.Model;
using Spectrum.DatabaseContext.DatabaseContext;

namespace Spectrum.Repository.Repository
{
   public class CategoryRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();
        public bool Add(Category category)
        {
            _dbContext.Category.Add(category);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            Category acategory = _dbContext.Category.FirstOrDefault((c => c.Id == id));
            _dbContext.Category.Remove(acategory);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Update(Category category)
        {
            Category acategory = _dbContext.Category.FirstOrDefault(c => c.Id == category.Id);
            if (acategory != null)
            {
                acategory.Code = category.Code;
                acategory.Name = category.Name;

            }

            return _dbContext.SaveChanges() > 0;
        }

        public List<Category> GetAll()
        {
            return _dbContext.Category.ToList();
        }
        public Category getById(int id)
        {

            return _dbContext.Category.FirstOrDefault((c => c.Id == id));
        }
    }
}
