using NUnit.Framework;

namespace Lab1._3.Tests
{
    [TestFixture]
    public class Tests
    {
        private Admin MainAdmin;

        [SetUp]
        public void Setup()
        {
            MainAdmin = new Admin("root", "password", "salt");
        }

        [TearDown]
        public void Cleanup() 
        {
            MainAdmin = null;
        }

        [Test]
        public void Admin_Password_Check_ReturnsTrue()
        {
            var result = MainAdmin.PassCheck("password");
            Assert.IsTrue(result);
        }

        [Test]
        public void Admin_Password_Check_ReturnsFalse()
        {
            var result = MainAdmin.PassCheck("123");
            Assert.IsFalse(result);
        }
    }
}