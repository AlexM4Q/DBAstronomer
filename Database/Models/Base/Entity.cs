using System;

namespace Database.Models.Base
{
    public class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime? Deleted { get; set; }
    }
}