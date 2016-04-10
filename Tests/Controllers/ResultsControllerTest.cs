using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JuvenileSportsManagementApp;
using JuvenileSportsManagementApp.Controllers;
using JuvenileSportsManagementApp.Models;

namespace Tests.Controllers
{
    [TestClass]
    public class ResultsControllerTest
    {
        [TestMethod]
        public void ResultsIndex()
        {
            // Arrange
            ResultsController controller = new ResultsController();

            // Act
            ViewResult result = controller.ResultsIndex() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ExistResults()
        {
            // Arrange
            ResultsController controller = new ResultsController();

            // Act
            ViewResult result = controller.ExistResults() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Results()
        {
            var results = new List<ResultVM>
            {
                new ResultVM { ResultID = 1, AthleteID = 1, AthleteName = "Niall Martin", EventID = 1, EventName = "100 metres", DateOfResult = DateTime.Now, Result = 11.3, IsDeleted = true },
                new ResultVM { ResultID = 2, AthleteID = 1, AthleteName = "Niall Martin",  EventID = 1, EventName = "100 metres", DateOfResult = DateTime.Now, Result = 10.7, IsDeleted = false },
                new ResultVM { ResultID = 3, AthleteID = 2, AthleteName = "Shane O'Rourke", EventID = 1, EventName = "100 metres", DateOfResult = DateTime.Now, Result = 21.3, IsDeleted = false }
            };

            // Arrange
            ResultsController controller = new ResultsController();

            // Act
            ViewResult result = controller.Results(results) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}

