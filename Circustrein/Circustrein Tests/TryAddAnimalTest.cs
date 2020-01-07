using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Circustrein;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Circustrein_Tests
{
    [TestClass]
    public class TestAnimal
    {
        Diet diet;
        AnimalSize size;
        Animal animal;

        [SetUp]
        public void Setup()
        {
            diet = Diet.Plants;
            size = AnimalSize.mediumsize;
            animal = new Animal("name", diet, size);
        }

        [Test]
        public void CorrectyInstantiate()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(animal.Diet, diet);
                Assert.AreEqual(animal.AnimalSize, size); ;
            });
        }
    }
}
