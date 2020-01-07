using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    public class Animal
    {
        private object carnivore;
        private object small;

        public string Name { get; private set; }
        public Diet Diet { get; private set; }
        public AnimalSize AnimalSize { get; private set; }

        public Animal(string name, Diet diet, AnimalSize size)
        {
            Name = name;
            Diet = diet;
            AnimalSize = size;
        }

        public Animal(object carnivore, object small)
        {
            this.carnivore = carnivore;
            this.small = small;
        }
    }
    }
