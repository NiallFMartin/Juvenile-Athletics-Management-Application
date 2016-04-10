using AutoMapper;
using JuvenileSportsManagementApp.Entities;
using JuvenileSportsManagementApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.AutoMapper
{
    [TestClass]
    public sealed class ResultMappingTest
    {
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            //register mappings for testing
            JuvenileSportsManagementApp.App_Start.AutoMapperConfig.RegisterMappings();
        }

        [TestMethod]
        public void TestResultDAtoVM()
        {
            ResultDA source = new ResultDA { ResultID = 1, AthleteID = 1, Athlete = new AthleteDA(), EventID = 1, Event = new EventDA(), DateOfResult = DateTime.Now, Result = 11.3, IsDeleted = false };

            ResultVM dest = new ResultVM();

            Assert.AreNotEqual(11.3, dest.Result);
            Mapper.Map(source, dest);
            Assert.AreEqual(11.3, dest.Result);
        }
    }
}
