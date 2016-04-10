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
    /// Test for GroupService
    /// </summary>
    [TestClass]
    public class GroupServiceTester
    {

        [TestMethod]
        public void getGroupsTest()
        {
            var mockGroups = new List<GroupDA>
            {
                new GroupDA { GroupID = 1, GroupName = "Under 10s", IsDeleted = true, Athletes = new List<AthleteDA>() },
                new GroupDA { GroupID = 2, GroupName = "Under 12s", IsDeleted = false, Athletes = new List<AthleteDA>() },
                new GroupDA { GroupID = 3, GroupName = "Under 14s", IsDeleted = false, Athletes = new List<AthleteDA>() }
            }.AsQueryable();

            var mockGroupSet = new Mock<DbSet<GroupDA>>();
            mockGroupSet.As<IQueryable<GroupDA>>().Setup(m => m.Provider).Returns(mockGroups.Provider);
            mockGroupSet.As<IQueryable<GroupDA>>().Setup(m => m.Expression).Returns(mockGroups.Expression);
            mockGroupSet.As<IQueryable<GroupDA>>().Setup(m => m.ElementType).Returns(mockGroups.ElementType);
            mockGroupSet.As<IQueryable<GroupDA>>().Setup(m => m.GetEnumerator()).Returns(mockGroups.GetEnumerator());

            var mockContext = new Mock<SportsAppContext>();
            mockContext.Setup(c => c.Groups).Returns(mockGroupSet.Object);

            var service = new GroupService(mockContext.Object);
            var allGroups = service.GetGroups(true);
            Assert.AreEqual(3, allGroups.Count);

            var groupsActiveOnly = service.GetGroups(false);
            Assert.AreEqual(2, groupsActiveOnly.Count);
        }
    }
}