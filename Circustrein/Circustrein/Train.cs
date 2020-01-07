using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    class Train
    {
        private readonly List<Wagon> _wagons = new List<Wagon>();
        public IEnumerable<Wagon> Wagons => _wagons;
        //Adds animal to train
        public void AddAnimal(Animal a) 
        {

            foreach (Wagon wagon in _wagons)
            {
                if (wagon.TryAddAnimal(a))
                {
                    return;
                }
            }
            int id = (_wagons.Count > 0) ? _wagons.Count + 1 : 1;  
            _wagons.Add(new Wagon(id));
            AddAnimal(a); 
        }
    }
}

