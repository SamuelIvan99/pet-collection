using System.Collections.Generic;

namespace PetCollection.Models
{
    public class Owner
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public IEnumerable<Pet> Pets { get; set; }
    }
}
