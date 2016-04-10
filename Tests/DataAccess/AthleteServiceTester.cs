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
    /// Test for AthleteService
    /// </summary>
    [TestClass]
    public class AthleteServiceTester
    {

        [TestMethod]
        public void getAthletesTest()
        {
            var mockAthletes = new List<AthleteDA>
            {
                new AthleteDA { AthleteID = 1, AthleteName = "Niall Martin", DateOfBirth = new DateTime(2006, 06, 10), GroupID = 1, GroupName = "Under 10s", AgeGroup = new GroupDA(), IsDeleted = true, Results = new List<ResultDA>() },
                new AthleteDA { AthleteID = 2, AthleteName = "Shane O'Rourke", DateOfBirth = new DateTime(2006, 10, 12), GroupID = 1, GroupName = "Under 10s", AgeGroup = new GroupDA(), IsDeleted = false, Results = new List<ResultDA>() },
                new AthleteDA { AthleteID = 3, AthleteName = "Sean Collum", DateOfBirth = new DateTime(2004, 08, 21), GroupID = 1, GroupName = "Under 10s", AgeGroup = new GroupDA(), IsDeleted = false, Results = new List<ResultDA>() }
            }.AsQueryable();

            var mockAthleteSet = new Mock<DbSet<AthleteDA>>();
            mockAthleteSet.As<IQueryable<AthleteDA>>().Setup(m => m.Provider).Returns(mockAthletes.Provider);
            mockAthleteSet.As<IQueryable<AthleteDA>>().Setup(m => m.Expression).Returns(mockAthletes.Expression);
            mockAthleteSet.As<IQueryable<AthleteDA>>().Setup(m => m.ElementType).Returns(mockAthletes.ElementType);
            mockAthleteSet.As<IQueryable<AthleteDA>>().Setup(m => m.GetEnumerator()).Returns(mockAthletes.GetEnumerator());

            var mockContext = new Mock<SportsAppContext>();
            mockContext.Setup(c => c.Athletes).Returns(mockAthleteSet.Object);

            var service = new AthleteService(mockContext.Object);
            var allAthletes = service.GetAthletes(1, true);
            Assert.AreEqual(3, allAthletes.Count);

            var athletesActiveOnly = service.GetAthletes(1, false);
            Assert.AreEqual(2, athletesActiveOnly.Count);
        }
    }
}