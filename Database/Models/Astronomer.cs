using Database.Models.Base;

namespace Database.Models
{
    public class Astronomer : Entity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public int Age { get; set; }
    }
}