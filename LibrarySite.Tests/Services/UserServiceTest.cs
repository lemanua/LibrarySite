using LibrarySite.BusinessLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LibrarySite.Tests.Services
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UserNameIsNull()
        {
            // Arrange
            UserService service = new UserService();

            // Act
           service.GetOrCreate(null);
        }

        [TestMethod]
        public void CreateNewUser()
        {
            // Arrange
            UserService service = new UserService();
            const string userName = "John Doe";

            // Act
            var newUser = service.GetOrCreate(userName);

            //Assert
            Assert.AreEqual(newUser, service.GetOrCreate(userName));
        }

    }
}
