using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JuvenileSportsManagementApp.Entities;
using JuvenileSportsManagementApp.Models;
using AutoMapper;

namespace Tests.AutoMapper
{
    [TestClass]
    public sealed class EventMappingTest
    {
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            //register mappings for testing
            JuvenileSportsManagementApp.App_Start.AutoMapperConfig.RegisterMappings();
        }

        [TestMethod]
        public void TestEventDAtoVM()
        {
            EventDA source = new EventDA { EventID = 1, EventName = "100 metres", EventType = "Time", IsDeleted = false, Results = new List<ResultDA>() };
            EventVM dest = new EventVM();

            Assert.IsNull(dest.EventName);
            Mapper.Map(source, dest);
            Assert.AreEqual("100 metres", dest.EventName);
        }
    }
}
