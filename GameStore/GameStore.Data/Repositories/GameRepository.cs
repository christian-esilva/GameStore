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
    public class GameRepository : IGameRepository
    {
        private Context _db;

        public GameRepository()
        {
            _db = new Context();
        }

        public void Create(Game entity)
        {
            _db.Games.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Games.Remove(_db.Games.Find(id));
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public Game Get(int id)
        {
            return _db.Games.Find(id);
        }

        public List<Game> Get(int skip = 0, int take = 25)
        {
            return _db.Games.OrderBy(x => x.Title).Skip(skip).Take(take).ToList();
        }

        public Game GetWithCategory(int id)
        {
            return _db.Games.Include("Category").Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Game> GetWithCategory(int skip = 0, int take = 30)
        {
            return _db.Games.Include("Category").OrderBy(x => x.Title).Skip(skip).Take(take).ToList();
        }

        public void Update(Game entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
