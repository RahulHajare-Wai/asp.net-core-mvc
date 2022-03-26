using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }
        //save is applicable at global lavel.
        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
