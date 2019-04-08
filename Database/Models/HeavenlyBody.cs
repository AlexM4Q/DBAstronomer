using Database.Models.Base;

namespace Database.Models
{
    public class HeavenlyBody : Entity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Distance { get; set; }
        public double Mass { get; set; }
        public double Radius { get; set; }
    }
}