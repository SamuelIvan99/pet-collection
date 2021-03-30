using System;

namespace PetCollection.Models
{
    public abstract class Pet
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public DateTime Birth { get; set; }

        public int FeededNo { get; set; }

        //public IEnumerable<Owner> Owners { get; set; }
    }
}
