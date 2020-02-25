using Microsoft.VisualStudio.TestTools.UnitTesting;
using Part_2;

namespace Part_2_Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void IsIPerson()
        {
            // Act && Assert
            Assert.IsTrue(new Person() is IPerson);
        }
    }
}
