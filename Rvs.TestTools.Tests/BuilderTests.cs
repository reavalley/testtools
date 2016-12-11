using NUnit.Framework;
using System.Collections.Generic;

namespace Rvs.TestTools.Tests
{
    [TestFixture]
    public class BuilderTests
    {
        [Test]
        public void Given_Builder_With_Is_Used_When_Build_Output_Equals_Expected()
        {
            var toys = new List<string>()
                {
                    "Ball",
                    "Ring"
                };

            var expected = new Pet
            {
                Age = 5,
                Breed = "Border Jack",
                Name = "Beed",
                Toys = toys
            };

            var result = PetBuilder.Init()
                .With(x => x.Name, "Beed")
                .With(x => x.Age, 5)
                .With(x => x.Breed, "Border Jack")
                .With(x => x.Toys, toys)
                .Build();

            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.Age, result.Age);
            Assert.AreEqual(expected.Breed, result.Breed);
            Assert.AreEqual(expected.Toys, result.Toys);
        }

        [Test]
        public void Given_New_Method_Added_To_Builder_Output_Equals_Expected()
        {
            var toys = new List<string>()
                {
                    "Ball",
                    "Ring"
                };

            var expected = new Pet
            {
                Age = 5,
                Breed = "Border Jack",
                Name = "Beed",
                Toys = toys
            };

            var result = PetBuilder.Default().Build();

            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.Age, result.Age);
            Assert.AreEqual(expected.Breed, result.Breed);
            Assert.AreEqual(expected.Toys, result.Toys);
        }
        
        private class PetBuilder : Builder<Pet, PetBuilder>
        {
            public static PetBuilder Default()
            {
                return Init()
                    .With(x => x.Name, "Beed")
                    .With(x => x.Age, 5)
                    .With(x => x.Breed, "Border Jack")
                    .With(x => x.Toys, new List<string>()
                    {
                        "Ball",
                        "Ring"
                    });
            }
        }

        private class Pet
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Breed { get; set; }
            public List<string> Toys { get; set; }
        }
    }
}
