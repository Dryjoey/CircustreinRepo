using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    public class Wagon
    {
        public int Id { get; private set; }
        public int Room { get; private set; }
         

        private readonly List<Animal> _animals = new List<Animal>();

        public IEnumerable<Animal> Animals => _animals;

        public Wagon(int Id)
        {
            this.Id = Id;
        }

        public Wagon()
        {
        }
        //Distribute the animals safely into their wagons
        public bool TryAddAnimal(Animal newAnimal)
        {

            if ( CheckRoom(newAnimal)== true && CheckForCarnivore() == true&& CheckNewAnimal(newAnimal)== true)

            {
                return AddAnimal(newAnimal);
            }
            return false;
            
         }
        // Check if the new animal thats about to be added is safe to place
        public bool CheckNewAnimal(Animal newAnimal)
        {
            if (_animals.Any(animal => newAnimal.AnimalSize >= animal.AnimalSize && newAnimal.Diet == Diet.Meat))
            {
                return false;
            }
            return true;

        }
        //Checks if there is a Carnivore in current wagon
        public bool CheckForCarnivore()
        {
            if (_animals.Any(animal=> animal.Diet== Diet.Meat))
            {
                return false;
            }
            return true;
        }
        //Checks if there is room in the wagon
        //If not it creates a new wagon
        public bool CheckRoom(Animal newAnimal)
        {
            if ((Room + (int)newAnimal.AnimalSize) <= 10)
            {
                return true;
            }

            return false;
        }
         

        //Puts the animals in their wagon
        private bool AddAnimal(Animal newAnimal)
        {
            Room += (int)newAnimal.AnimalSize;
            _animals.Add(newAnimal);
            return true;
        }

        public int CalculateSeatedSize()
        {
            return _animals.Sum(a => (int)a.AnimalSize);
        }


    }
}
