using System.ComponentModel.DataAnnotations;

namespace PetCollection.Models
{
    public class Dog : Pet
    {
        [Range(1, 10)]
        public int TrainingDegree { get; set; }

        public int Height { get; set; }
    }
}
