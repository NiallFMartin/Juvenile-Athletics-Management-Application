using JuvenileSportsManagementApp;
using JuvenileSportsManagementApp.DataAccess;
using JuvenileSportsManagementApp.DataAccess.Services;
using JuvenileSportsManagementApp.DataAccess.Services.Interfaces;
using JuvenileSportsManagementApp.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace Tests.DataAccess
{
    /// <summary>
    /// Test for ResultService
    /// </summary>
    [TestClass]
    public class ResultServiceTester
    {

        [TestMethod]
        public void getResultsTest()
        {
            var mockResults = new List<ResultDA>
            {
                new ResultDA { ResultID = 1, AthleteID = 1, Athlete = new AthleteDA(), EventID = 1, Event = new EventDA(), DateOfResult = DateTime.Now, Result = 11.3, IsDeleted = true },
                new ResultDA { ResultID = 2, AthleteID = 1, Athlete = new AthleteDA(), EventID = 2, Event = new EventDA(), DateOfResult = DateTime.Now, Result = 10.7, IsDeleted = false },
                new ResultDA { ResultID = 3, AthleteID = 2, Athlete = new AthleteDA(), EventID = 3, Event = new EventDA(), DateOfResult = DateTime.Now, Result = 21.3, IsDeleted = false }
            }.AsQueryable();

            var mockAthleteSet = new Mock<DbSet<ResultDA>>();
            mockAthleteSet.As<IQueryable<ResultDA>>().Setup(m => m.Provider).Returns(mockResults.Provider);
            mockAthleteSet.As<IQueryable<ResultDA>>().Setup(m => m.Expression).Returns(mockResults.Expression);
            mockAthleteSet.As<IQueryable<ResultDA>>().Setup(m => m.ElementType).Returns(mockResults.ElementType);
            mockAthleteSet.As<IQueryable<ResultDA>>().Setup(m => m.GetEnumerator()).Returns(mockResults.GetEnumerator());

            var mockContext = new Mock<SportsAppContext>();
            mockContext.Setup(c => c.Results).Returns(mockAthleteSet.Object);

            var service = new ResultService(mockContext.Object);
            var allResults = service.GetAllResults(true);
            Assert.AreEqual(3, allResults.Count);

            var resultsActiveOnly = service.GetAllResults(false);
            Assert.AreEqual(2, resultsActiveOnly.Count);
        }
    }
}