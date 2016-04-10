using AutoMapper;
using JuvenileSportsManagementApp.Entities;
using JuvenileSportsManagementApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace Tests.AutoMapper
{
    [TestClass]
    public sealed class GroupMappingTest
    {
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            //register mappings for testing
            JuvenileSportsManagementApp.App_Start.AutoMapperConfig.RegisterMappings();
        }

        [TestMethod]
        public void TestGroupDAtoVM()
        {
            GroupDA source = new GroupDA { GroupID = 1, GroupName = "Under 10s", IsDeleted = false, Athletes = new List<AthleteDA>() };

            GroupVM dest = new GroupVM();

            Assert.IsNull(dest.GroupName);
            Mapper.Map(source, dest);
            Assert.AreEqual("Under 10s", dest.GroupName);
        }
    }
}
