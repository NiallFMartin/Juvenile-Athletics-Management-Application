using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuvenileSportsManagementApp.DataAccess;
using JuvenileSportsManagementApp.DataAccess.Services.Interfaces;

namespace JuvenileSportsManagementApp.DataAccess.Services
{
    public static class DataAccessServiceController
    {
        private static IAthleteService _AthleteService;
        private static IGroupService _GroupService;
        private static IEventService _EventService;
        private static IResultService _ResultService;

        public static IAthleteService AthleteService
        {
            get { return _AthleteService ?? new AthleteService(new SportsAppContext()); }
            set { _AthleteService = value; }
        }

        public static IGroupService GroupService
        {
            get { return _GroupService ?? new GroupService(new SportsAppContext()); }
            set { _GroupService = value; }
        }

        public static IEventService EventService
        {
            get { return _EventService ?? new EventService(new SportsAppContext()); }
            set { _EventService = value; }
        }

        public static IResultService ResultService
        {
            get { return _ResultService ?? new ResultService(new SportsAppContext()); }
            set { _ResultService = value; }
        }
    }
}