using GameStore.Domain.Entities;
using System.Collections.Generic;

namespace GameStore.Domain.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        List<Game> GetWithCategory(int skip = 0, int take = 30);
        Game GetWithCategory(int id);
    }
}
