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
    public class AthletesControllerTest
    {
        [TestMethod]
        public void AthletesIndex()
        {
            // Arrange
            AthletesController controller = new AthletesController();

            // Act
            ViewResult result = controller.AthletesIndex() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }        

        [TestMethod]
        public void Create()
        {
            // Arrange
            AthletesController controller = new AthletesController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        

        [TestMethod]
        public void AnalyseIndex()
        {
            // Arrange
            AthletesController controller = new AthletesController();

            // Act
            ViewResult result = controller.AthletesIndex() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
