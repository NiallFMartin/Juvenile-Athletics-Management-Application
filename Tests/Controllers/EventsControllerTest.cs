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
    public class EventsControllerTest
    {
        [TestMethod]
        public void EventsIndex()
        {
            // Arrange
            EventsController controller = new EventsController();

            // Act
            ViewResult result = controller.EventsIndex() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Details()
        {
            // Arrange
            EventsController controller = new EventsController();

            // Act
            ViewResult result = controller.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            EventsController controller = new EventsController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
