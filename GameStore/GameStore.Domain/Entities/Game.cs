using GameStore.Domain.Enums;
using System;

namespace GameStore.Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public EPlatformType Platform { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
