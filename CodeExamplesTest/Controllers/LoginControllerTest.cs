using System;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVMExample.Controllers;
using MVVMExample.Models;
using MVVMExample.ViewModels;

namespace CodeExamplesTest.Tests.Controllers
{
    [TestClass]
    public class LoginControllerTest
    {

        [TestMethod]
        public void Login()
        {
            // Arrange
            LoginController loginController = new LoginController();
            var returnUrl = "";

            // Act
            var actionResult = loginController.Login(returnUrl) as ViewResult;

            // Assert
            Assert.IsInstanceOfType(actionResult.Model, typeof(LoginModel));
        }

        [TestMethod]
        public void Login_UsernamePasswordEntered()
        {
            // Arrange
            LoginController loginController = new LoginController();
            LoginModel model = new LoginModel();
            var returnUrl = "";
            model.Username = "staylor";
            model.ProtectedID = "123";
            model.Password = "123";

            // Act
            var actionResult = loginController.Login(model, returnUrl) as ViewResult;

            // Assert
            Assert.IsInstanceOfType(actionResult.Model, typeof(LoginModel));
        }
    }
}
