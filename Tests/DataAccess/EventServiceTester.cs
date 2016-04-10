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
    /// Test for EventService
    /// </summary>
    [TestClass]
    public class EventServiceTester
    {

        [TestMethod]
        public void getEventsTest()
        {
            var mockEvents = new List<EventDA>
            {
                new EventDA { EventID = 1, EventName = "100 metres", EventType = "Time", IsDeleted = true, Results = new List<ResultDA>() },
                new EventDA { EventID = 2, EventName = "200 metres", EventType = "Time", IsDeleted = false, Results = new List<ResultDA>() },
                new EventDA { EventID = 3, EventName = "400 metres", EventType = "Time", IsDeleted = false, Results = new List<ResultDA>() },
            }.AsQueryable();

            var mockEventSet = new Mock<DbSet<EventDA>>();
            mockEventSet.As<IQueryable<EventDA>>().Setup(m => m.Provider).Returns(mockEvents.Provider);
            mockEventSet.As<IQueryable<EventDA>>().Setup(m => m.Expression).Returns(mockEvents.Expression);
            mockEventSet.As<IQueryable<EventDA>>().Setup(m => m.ElementType).Returns(mockEvents.ElementType);
            mockEventSet.As<IQueryable<EventDA>>().Setup(m => m.GetEnumerator()).Returns(mockEvents.GetEnumerator());

            var mockContext = new Mock<SportsAppContext>();
            mockContext.Setup(c => c.Events).Returns(mockEventSet.Object);

            var service = new EventService(mockContext.Object);
            var allAthletes = service.GetEvents(true);
            Assert.AreEqual(3, allAthletes.Count);

            var athletesActiveOnly = service.GetEvents(false);
            Assert.AreEqual(2, athletesActiveOnly.Count);
        }
    }
}