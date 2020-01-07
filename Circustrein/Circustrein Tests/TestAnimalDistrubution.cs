using Circustrein;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein_Tests
{
    class TestAnimalDistrubution
    {
        public class TestWagon
        {
            Animal[][] animalMatrix =
            {
            new Animal[] //animalMatrix[0]
            {
                new Animal(Diet.Meat, AnimalSize.smallsize), //animal 0
                new Animal(Diet.Meat, AnimalSize.mediumsize), //animal 1
                new Animal(Diet.Meat, AnimalSize.largesize), //animal 2
                new Animal(Diet.Plants, AnimalSize.smallsize), //animal 3
                new Animal(Diet.Plants, AnimalSize.mediumsize),//animal 4
                new Animal(Diet.Plants, AnimalSize.largesize) //animal 5
            },
            new Animal[] //animalMatrix[1]: Crossreference array
            {
                new Animal(Diet.Meat, AnimalSize.smallsize),
                new Animal(Diet.Meat, AnimalSize.mediumsize),
                new Animal(Diet.Meat, AnimalSize.largesize),
                new Animal(Diet.Plants, AnimalSize.smallsize),
                new Animal(Diet.Plants, AnimalSize.mediumsize),
                new Animal(Diet.Plants, AnimalSize.largesize)
            }
        };

            bool[][] expectedBoolMatrix = //animal[x] vs Crossreference animals excpected results 
            {
            new bool[] //expectedBoolMatrix[0] animal 0 vs Crossreference 
            {
                false,  false, false, false, true, true
            },
            new bool[] //expectedBoolMatrix[1] animal 1 vs Crossreference 
            {
                false,  false, false, false, false, true
            },
            new bool[] //expectedBoolMatrix[2] animal 2 vs Crossreference 
            {
                false,  false, false, false, false, false
            },
            new bool[] //expectedBoolMatrix[3] animal 3 vs Crossreference 
            {
                false,  false, false, true, true, true
            },
            new bool[] //expectedBoolMatrix[4] animal 4 vs Crossreference 
            {
                true,  false, false, true, true, true
            },
            new bool[] //expectedBoolMatrix[5] animal 5 vs Crossreference 
            {
                true,  true, false, true, true, true
            },

        };


            [SetUp]
            public void Setup()
            {

            }

            [Test]
            public void CrossRefering()
            {
                Assert.Multiple(() =>
                {
                    for (int x = 0; x < animalMatrix[0].Length; x++)
                    {
                        Wagon wagon = new Wagon();
                        wagon.TryAddAnimal(animalMatrix[0][x]);

                        for (int y = 0; y < animalMatrix[1].Length; y++)
                        {
                            Assert.AreEqual(expectedBoolMatrix[x][y], wagon.TryAddAnimal(animalMatrix[1][y]));
                        }
                    }
                });
            }

            [Test]
            public void PlaceAnimals()
            {
                //Arrange
                Wagon wagon = new Wagon();
                List<Animal> animals = new List<Animal>()
            {
                new Animal(Diet.Plants, AnimalSize.smallsize),
                new Animal(Diet.Plants, AnimalSize.mediumsize),
                new Animal(Diet.Meat, AnimalSize.largesize),
                new Animal(Diet.Plants, AnimalSize.largesize), //this last one is expected to NOT be placed. 
            };

            }

            [Test]
            public void CalculateSeatedSize()
            {
                //Arrange
                List<Animal> animals = new List<Animal>()
            {
                new Animal(Diet.Meat, AnimalSize.smallsize),
                new Animal(Diet.Plants, AnimalSize.mediumsize),
                new Animal(Diet.Plants, AnimalSize.largesize)
            };

                int expectedResult = 0;
                Wagon wagon = new Wagon();
                
                //Act
                foreach (Animal animal in animals)
                {
                    expectedResult += (int)animal.AnimalSize; // In methode calculating the combined size of the placed animals. 
                    wagon.TryAddAnimal(animal);
                }

                //Assert
                Assert.AreEqual(expectedResult, wagon.CalculateSeatedSize());
            }
        }
    }
}

