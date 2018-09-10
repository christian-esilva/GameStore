using System.Collections.Generic;

namespace GameStore.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Games = new List<Game>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
