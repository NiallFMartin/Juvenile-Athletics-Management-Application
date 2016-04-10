using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuvenileSportsManagementApp.DataAccess.Services;
using JuvenileSportsManagementApp.DataAccess.Services.Interfaces;

namespace Tests
{
    internal static class TestUtilities
    {
        public static MockRepository SetMocksonDataAccessServiceController()
        {
            MockRepository mr = new MockRepository(MockBehavior.Strict);

            DataAccessServiceController.AthleteService = mr.Create<IAthleteService>().Object;
            DataAccessServiceController.EventService = mr.Create<IEventService>().Object;
            DataAccessServiceController.GroupService = mr.Create<IGroupService>().Object;
            DataAccessServiceController.ResultService = mr.Create<IResultService>().Object;

            return mr;
        }
    }
}
