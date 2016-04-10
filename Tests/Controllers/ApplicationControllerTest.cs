using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JuvenileSportsManagementApp;
using JuvenileSportsManagementApp.Controllers;

namespace Tests.Controllers
{
    [TestClass]
    public class ApplicationControllerTest
    {
        [TestMethod]
        public void Portal()
        {
            // Arrange
            ApplicationController controller = new ApplicationController();

            // Act
            ViewResult result = controller.Portal() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Success()
        {
            // Arrange
            ApplicationController controller = new ApplicationController();

            // Act
            ViewResult result = controller.Success() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Fail()
        {
            // Arrange
            ApplicationController controller = new ApplicationController();

            // Act
            ViewResult result = controller.Fail() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
