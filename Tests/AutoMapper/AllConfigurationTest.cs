using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;

namespace Tests.AutoMapper
{
    [TestClass]
    public sealed class AllConfigurationTest
    {
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            //register mappings for testing
            JuvenileSportsManagementApp.App_Start.AutoMapperConfig.RegisterMappings();
        }

        [TestMethod]
        public void AutoMapperConfigurationIsValid()
        {
            // Tests and validates all mapping.
            // Used commonly to check for any properties which are not mapped (excluded by automapper but not explicitly excluded using the ignore())
            // Does not necessarliy indicate that there is a bug or issue.
            Mapper.AssertConfigurationIsValid();
        }
    }
}
