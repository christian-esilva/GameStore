using GameStore.Domain.Entities;
using System.Collections.Generic;

namespace GameStore.Domain.Interfaces
{
    public interface IGameRepository : IRepository<Category>
    {
        List<Category> GetWithCategory(int skip = 0, int take = 30);
        Category GetWithCategory(int id);
    }
}
