using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Part_2;

namespace Part_2_Tests
{
    [TestClass]
    public class PersonRepositoryTests
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            const int expectedCount = 5;

            // Act
            IPerson[] actualResult = new PersonRepository(GetTestPersons()).Get();

            // Assert
            Assert.AreEqual(expectedCount, actualResult.Length);
        }

        [TestMethod]
        public void Get_By_Id()
        {
            // Arrange
            const int expectedId = 3;

            // Act
            IPerson actualResult = new PersonRepository(GetTestPersons()).Get(expectedId);

            // Assert
            Assert.AreEqual(expectedId, actualResult.Id);
        }

        [TestMethod]
        public void Get_ManCount()
        {
            // Arrange
            const int expectedCount = 3;

            // Act
            int actualResult = new PersonRepository(GetTestPersons()).ManCount;

            // Assert
            Assert.AreEqual(expectedCount, actualResult);
        }

        [TestMethod]
        public void Get_WomanCount()
        {
            // Arrange
            const int expectedCount = 2;

            // Act
            int actualResult = new PersonRepository(GetTestPersons()).WomanCount;

            // Assert
            Assert.AreEqual(expectedCount, actualResult);
        }

        [TestMethod]
        public void Get_Ordered()
        {
            // Arrange
            IPerson[] expected = GetTestPersons();
            IPerson[] ordered = expected.OrderBy(x => x).ToArray();

            // Act
            IPerson[] actualResult = new PersonRepository(expected).GetOrderedPersons();

            // Assert
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.IsTrue(ordered[i].Equals(actualResult[i]));
            }
        }

        [TestMethod]
        public void Get_DescendingOrdered()
        {
            // Arrange
            IPerson[] expected = GetTestPersons();
            IPerson[] ordered = expected.OrderByDescending(x => x).ToArray();

            // Act
            IPerson[] actualResult = new PersonRepository(expected).GetDescendingOrderedPersons();

            // Assert
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.IsTrue(ordered[i].Equals(actualResult[i]));
            }
        }

        [TestMethod]
        public void Get_UniqueEmails()
        {
            // Arrange
            IPerson[] expected = GetTestPersons();
            string[] expectedEmails = expected.Select(x => x.Email).Distinct().ToArray();

            // Act
            string[] actualResult = new PersonRepository(expected).GetUniquePersonEmails();

            // Assert
            for (int i = 0; i < expectedEmails.Length; i++)
            {
                Assert.IsTrue(expectedEmails[i].Equals(actualResult[i]));
            }
        }

        [TestMethod]
        public void Add()
        {
            // Arrange
            PersonRepository sut = new PersonRepository(GetTestPersons());

            // Act
            IPerson actualResult = sut.Add(new TestPerson
            {
                Id = 6,
                FirstName = "FName6",
                LastName = "LName6",
                Email = "email6@email.com",
                Gender = Gender.M
            });

            // Assert
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(6, actualResult.Id);
            Assert.AreEqual("FName6", actualResult.FirstName);
            Assert.AreEqual("LName6", actualResult.LastName);
            Assert.AreEqual("email6@email.com", actualResult.Email);
            Assert.AreEqual(Gender.M, actualResult.Gender);
        }

        [TestMethod]
        public void Edit()
        {
            // Arrange
            PersonRepository sut = new PersonRepository(GetTestPersons());

            // Act
            IPerson actualResult = sut.Edit(new TestPerson
            {
                Id = 3,
                FirstName = "FName6",
                LastName = "LName6",
                Email = "email6@email.com",
                Gender = Gender.M
            });

            // Assert
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(3, actualResult.Id);
            Assert.AreEqual("FName6", actualResult.FirstName);
            Assert.AreEqual("LName6", actualResult.LastName);
            Assert.AreEqual("email6@email.com", actualResult.Email);
            Assert.AreEqual(Gender.M, actualResult.Gender);
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            PersonRepository sut = new PersonRepository(GetTestPersons());

            // Act
            IPerson actualResult = sut.Delete(3);

            // Assert
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(3, actualResult.Id);
            Assert.AreEqual("FName3", actualResult.FirstName);
            Assert.AreEqual("LName3", actualResult.LastName);
            Assert.AreEqual("email3@email.com", actualResult.Email);
            Assert.AreEqual(Gender.M, actualResult.Gender);
        }

        private static IPerson[] GetTestPersons()
        {
            return new IPerson[]
            {
                new TestPerson
                {
                    Id = 2,
                    FirstName = "FName2",
                    LastName = "LName2",
                    Email = "email@email.com",
                    Gender = Gender.M
                }, 
                new TestPerson
                {
                    Id = 1,
                    FirstName = "FName1",
                    LastName = "LName1",
                    Email = "email@email.com",
                    Gender = Gender.W
                }, 
                new TestPerson
                {
                    Id = 3,
                    FirstName = "FName3",
                    LastName = "LName3",
                    Email = "email3@email.com",
                    Gender = Gender.M
                }, 
                new TestPerson
                {
                    Id = 4,
                    FirstName = "FName4",
                    LastName = "LName4",
                    Email = "email4@email.com",
                    Gender = Gender.W
                }, 
                new TestPerson
                {
                    Id = 5,
                    FirstName = "FName5",
                    LastName = "LName5",
                    Email = "email5@email.com",
                    Gender = Gender.M
                } 
            };
        }
    }
}
