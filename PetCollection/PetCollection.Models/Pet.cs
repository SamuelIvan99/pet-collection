using System;

namespace PetCollection.Models
{
    public abstract class Pet
    {
        protected string Id { get; set; }

        protected string Name { get; set; }

        protected string Breed { get; set; }

        protected DateTime Birth { get; set; }

        protected int FeededNo { get; set; }
    }
}
