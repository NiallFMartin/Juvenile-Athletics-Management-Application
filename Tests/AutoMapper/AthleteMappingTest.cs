using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JuvenileSportsManagementApp.Entities;
using JuvenileSportsManagementApp.Models;
using AutoMapper;

namespace Tests.AutoMapper
{
    [TestClass]
    public sealed class AthleteMappingTest
    {
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            //register mappings for testing
            JuvenileSportsManagementApp.App_Start.AutoMapperConfig.RegisterMappings();
        }

        [TestMethod]
        public void TestAthleteDAtoVM()
        {
            AthleteDA source = new AthleteDA { AthleteID = 1, AthleteName = "Niall Martin", DateOfBirth = new DateTime(2006, 06, 10), GroupID = 1, GroupName = "Under 10s", AgeGroup = new GroupDA(), IsDeleted = false, Results = new List<ResultDA>() };
            AthleteVM dest = new AthleteVM();

            Assert.IsNull(dest.AthleteName);
            Mapper.Map(source, dest);
            Assert.AreEqual("Niall Martin", dest.AthleteName);
        }
    }
}
