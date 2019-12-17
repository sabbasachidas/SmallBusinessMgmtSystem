using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectrum.Repository.Repository;
using Spectrum.Model.Model;

namespace Spectrum.Bll.Bll
{
    public class CategoryManager
    {
        CategoryRepository _categoryRepository = new CategoryRepository();
        public bool Add(Category category)
        {
            return _categoryRepository.Add(category);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category getById(int id)
        {
            return _categoryRepository.getById(id);
        }

        public bool Update(Category category)
        {
            return _categoryRepository.Update(category);
        }

        public bool Delete(int id)
        {
            return _categoryRepository.Delete(id);
        }
    }
}
