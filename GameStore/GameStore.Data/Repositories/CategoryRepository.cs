using GameStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Domain.Entities;
using GameStore.Data.DataContext;
using System.Data.Entity;

namespace GameStore.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private Context _db;

        public CategoryRepository()
        {
            _db = new Context();
        }

        public void Create(Category entity)
        {
            _db.Categories.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Categories.Remove(_db.Categories.Find(id));
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public Category Get(int id)
        {
            return _db.Categories.Find(id);
        }

        public List<Category> Get(int skip = 0, int take = 25)
        {
            return _db.Categories.OrderBy(x => x.Title).Skip(skip).Take(take).ToList();
        }

        public void Update(Category entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
