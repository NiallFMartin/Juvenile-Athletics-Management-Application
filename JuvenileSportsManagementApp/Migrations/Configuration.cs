namespace JuvenileSportsManagementApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using JuvenileSportsManagementApp.Models;
    using JuvenileSportsManagementApp.Entities;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Text;
    using JuvenileSportsManagementApp.DataAccess;

    internal sealed class Configuration : DbMigrationsConfiguration<JuvenileSportsManagementApp.DataAccess.SportsAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(JuvenileSportsManagementApp.DataAccess.SportsAppContext context)
        {
            var Groups = new List<GroupDA>
            {
                new GroupDA { GroupID = 1, GroupName = "Under 10s", IsDeleted = false, Athletes = new List<AthleteDA>() },
                new GroupDA { GroupID = 2, GroupName = "Under 12s", IsDeleted = false, Athletes = new List<AthleteDA>() },
                new GroupDA { GroupID = 3, GroupName = "Under 14s", IsDeleted = false, Athletes = new List<AthleteDA>() },
                new GroupDA { GroupID = 4, GroupName = "Under 16s", IsDeleted = false, Athletes = new List<AthleteDA>() },
                new GroupDA { GroupID = 5, GroupName = "Under 18s", IsDeleted = false, Athletes = new List<AthleteDA>() },
                new GroupDA { GroupID = 6, GroupName = "Under 21s", IsDeleted = false, Athletes = new List<AthleteDA>() },
                new GroupDA { GroupID = 7, GroupName = "Senior", IsDeleted = false, Athletes = new List<AthleteDA>() }
            };

            Groups.ForEach(g => context.Groups.AddOrUpdate(g));
            SaveChanges(context);

            var Events = new List<EventDA>
            {
                new EventDA { EventID = 1, EventName = "100 metres", EventType = "Time", IsDeleted = false, Results = new List<ResultDA>() },
                new EventDA { EventID = 2, EventName = "200 metres", EventType = "Time", IsDeleted = false, Results = new List<ResultDA>() },
                new EventDA { EventID = 3, EventName = "400 metres", EventType = "Time", IsDeleted = false, Results = new List<ResultDA>() },
                new EventDA { EventID = 4, EventName = "800 metres", EventType = "Time", IsDeleted = false, Results = new List<ResultDA>() },
                new EventDA { EventID = 5, EventName = "1500 metres", EventType = "Time", IsDeleted = false, Results = new List<ResultDA>() },
                new EventDA { EventID = 6, EventName = "3000 metres", EventType = "Time", IsDeleted = false, Results = new List<ResultDA>() },
                new EventDA { EventID = 7, EventName = "5000 metres", EventType = "Time", IsDeleted = false, Results = new List<ResultDA>() },
                new EventDA { EventID = 8, EventName = "10000 metres", EventType = "Time", IsDeleted = false, Results = new List<ResultDA>() },
                new EventDA { EventID = 9, EventName = "Shot Putt", EventType = "Distance", IsDeleted = false, Results = new List<ResultDA>() },
                new EventDA { EventID = 10, EventName = "Discus", EventType = "Distance", IsDeleted = false, Results = new List<ResultDA>() },
                new EventDA { EventID = 11, EventName = "Javelin", EventType = "Distance", IsDeleted = false, Results = new List<ResultDA>() },
                new EventDA { EventID = 12, EventName = "High Jump", EventType = "Distance", IsDeleted = false, Results = new List<ResultDA>() },
                new EventDA { EventID = 13, EventName = "Long Jump", EventType = "Distance", IsDeleted = false, Results = new List<ResultDA>() },
                new EventDA { EventID = 14, EventName = "Pole Vault", EventType = "Distance", IsDeleted = false, Results = new List<ResultDA>() },
                new EventDA { EventID = 15, EventName = "110 metres hurdles", EventType = "Time", IsDeleted = false, Results = new List<ResultDA>() }
            };

            Events.ForEach(e => context.Events.AddOrUpdate(e));
            SaveChanges(context);

            var Athletes = new List<AthleteDA>
            {
                new AthleteDA { AthleteID = 1, AthleteName = "Niall Martin", DateOfBirth = new DateTime(2006, 06, 10), GroupID = 1, GroupName = "Under 10s", AgeGroup = Groups.SingleOrDefault(g => g.GroupID == 1), IsDeleted = false, Results = new List<ResultDA>() },
                new AthleteDA { AthleteID = 2, AthleteName = "Shane O'Rourke", DateOfBirth = new DateTime(2006, 10, 12), GroupID = 1, GroupName = "Under 10s", AgeGroup = Groups.SingleOrDefault(g => g.GroupID == 1), IsDeleted = false, Results = new List<ResultDA>() },
                new AthleteDA { AthleteID = 3, AthleteName = "Sean Collum", DateOfBirth = new DateTime(2004, 08, 21), GroupID = 2, GroupName = "Under 12s", AgeGroup = Groups.SingleOrDefault(g => g.GroupID == 2), IsDeleted = false, Results = new List<ResultDA>() },
                new AthleteDA { AthleteID = 4, AthleteName = "Patrick McBride", DateOfBirth = new DateTime(2004, 09, 08), GroupID = 2, GroupName = "Under 12s", AgeGroup = Groups.SingleOrDefault(g => g.GroupID == 2), IsDeleted = false, Results = new List<ResultDA>() },
                new AthleteDA { AthleteID = 5, AthleteName = "Breandan O'Conghaile", DateOfBirth = new DateTime(2002, 10, 11), GroupID = 3, GroupName = "Under 14s", AgeGroup = Groups.SingleOrDefault(g => g.GroupID == 3), IsDeleted = false, Results = new List<ResultDA>() },
                new AthleteDA { AthleteID = 6, AthleteName = "Ian Hynes", DateOfBirth = new DateTime(2002, 09, 01), GroupID = 3, GroupName = "Under 14s", AgeGroup = Groups.SingleOrDefault(g => g.GroupID == 3), IsDeleted = false, Results = new List<ResultDA>() },
                new AthleteDA { AthleteID = 7, AthleteName = "Bob Groome", DateOfBirth = new DateTime(2000, 07, 18), GroupID = 4, GroupName = "Under 16s", AgeGroup = Groups.SingleOrDefault(g => g.GroupID == 4), IsDeleted = false, Results = new List<ResultDA>() },
                new AthleteDA { AthleteID = 8, AthleteName = "Shane Curtin", DateOfBirth = new DateTime(2000, 11, 07), GroupID = 4, GroupName = "Under 16s", AgeGroup = Groups.SingleOrDefault(g => g.GroupID == 4), IsDeleted = false, Results = new List<ResultDA>() },
                new AthleteDA { AthleteID = 9, AthleteName = "Adrian Cooney", DateOfBirth = new DateTime(1998, 09, 10), GroupID = 5, GroupName = "Under 18s", AgeGroup = Groups.SingleOrDefault(g => g.GroupID == 5), IsDeleted = false, Results = new List<ResultDA>() },
                new AthleteDA { AthleteID = 10, AthleteName = "Shane Martin", DateOfBirth = new DateTime(1998, 11, 04), GroupID = 5, GroupName = "Under 18s", AgeGroup = Groups.SingleOrDefault(g => g.GroupID == 5), IsDeleted = false, Results = new List<ResultDA>() },
                new AthleteDA { AthleteID = 11, AthleteName = "David Martin", DateOfBirth = new DateTime(1996, 06, 22), GroupID = 6, GroupName = "Under 21s", AgeGroup = Groups.SingleOrDefault(g => g.GroupID == 6), IsDeleted = false, Results = new List<ResultDA>() },
                new AthleteDA { AthleteID = 12, AthleteName = "Niamh Martin", DateOfBirth = new DateTime(1996, 12, 15), GroupID = 6, GroupName = "Under 21s", AgeGroup = Groups.SingleOrDefault(g => g.GroupID == 6), IsDeleted = false, Results = new List<ResultDA>() },
                new AthleteDA { AthleteID = 13, AthleteName = "Thomas Martin", DateOfBirth = new DateTime(1993, 04, 09), GroupID = 7, GroupName = "Senior", AgeGroup = Groups.SingleOrDefault(g => g.GroupID == 7), IsDeleted = false, Results = new List<ResultDA>() },
                new AthleteDA { AthleteID = 14, AthleteName = "Geraldine Martin", DateOfBirth = new DateTime(1993, 11, 22), GroupID = 7, GroupName = "Senior", AgeGroup = Groups.SingleOrDefault(g => g.GroupID == 7), IsDeleted = false, Results = new List<ResultDA>() }
            };

            Athletes.ForEach(g => context.Athletes.AddOrUpdate(g));
            SaveChanges(context);

            var Results = new List<ResultDA>
            {
                new ResultDA { ResultID = 1, AthleteID = 1, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 1), AthleteName = "Niall Martin", EventID = 1, EventName = "100 metres", Event = Events.SingleOrDefault(e => e.EventID == 1), DateOfResult = DateTime.Now, Result = 11.3, IsDeleted = false },
                new ResultDA { ResultID = 2, AthleteID = 1, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 1), AthleteName = "Niall Martin", EventID = 2, EventName = "200 metres", Event = Events.SingleOrDefault(e => e.EventID == 2), DateOfResult = DateTime.Now, Result = 10.7, IsDeleted = false },
                new ResultDA { ResultID = 3, AthleteID = 2, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 2), AthleteName = "Shane O'Rourke",  EventID = 3, EventName = "400 metres", Event = Events.SingleOrDefault(e => e.EventID == 3), DateOfResult = DateTime.Now, Result = 21.3, IsDeleted = false },
                new ResultDA { ResultID = 4, AthleteID = 2, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 2), AthleteName = "Shane O'Rourke", EventID = 4, EventName = "800 metres", Event = Events.SingleOrDefault(e => e.EventID == 4), DateOfResult = DateTime.Now, Result = 22.3, IsDeleted = false },
                new ResultDA { ResultID = 5, AthleteID = 3, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 3), AthleteName = "Sean Collum", EventID = 5, EventName = "1500 metres", Event = Events.SingleOrDefault(e => e.EventID == 5), DateOfResult = DateTime.Now, Result = 114.3, IsDeleted = false },
                new ResultDA { ResultID = 6, AthleteID = 3, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 3), AthleteName = "Sean COllum", EventID = 6, EventName = "3000 metres", Event = Events.SingleOrDefault(e => e.EventID == 6), DateOfResult = DateTime.Now, Result = 113.3, IsDeleted = false },
                new ResultDA { ResultID = 7, AthleteID = 4, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 4), AthleteName = "Patrick McBride", EventID = 7, EventName = "5000 metres", Event = Events.SingleOrDefault(e => e.EventID == 7), DateOfResult = DateTime.Now, Result = 115.3, IsDeleted = false },
                new ResultDA { ResultID = 8, AthleteID = 4, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 4), AthleteName = "Patrick McBride", EventID = 8, EventName = "10000 metres", Event = Events.SingleOrDefault(e => e.EventID == 8), DateOfResult = DateTime.Now, Result = 11.63, IsDeleted = false },
                new ResultDA { ResultID = 9, AthleteID = 5, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 5), AthleteName = "Breandan O'Conghaile", EventID = 9, EventName = "Shot Putt", Event = Events.SingleOrDefault(e => e.EventID == 9), DateOfResult = DateTime.Now, Result = 11.37, IsDeleted = false },
                new ResultDA { ResultID = 10, AthleteID = 5, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 5), AthleteName = "Breandan O'Conghaile", EventID = 10, EventName = "Discus", Event = Events.SingleOrDefault(e => e.EventID == 10), DateOfResult = DateTime.Now, Result = 141.3, IsDeleted = false },
                new ResultDA { ResultID = 11, AthleteID = 6, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 6), AthleteName = "Ian Hynes", EventID = 11, EventName = "Javelin", Event = Events.SingleOrDefault(e => e.EventID == 11), DateOfResult = DateTime.Now, Result = 116.3, IsDeleted = false },
                new ResultDA { ResultID = 12, AthleteID = 6, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 6), AthleteName = "Ian Hynes", EventID = 12, EventName = "High Jump", Event = Events.SingleOrDefault(e => e.EventID == 12), DateOfResult = DateTime.Now, Result = 11.43, IsDeleted = false },
                new ResultDA { ResultID = 13, AthleteID = 7, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 7), AthleteName = "Bob Groome", EventID = 13, EventName = "Long Jump", Event = Events.SingleOrDefault(e => e.EventID == 13), DateOfResult = DateTime.Now, Result = 11.33, IsDeleted = false },
                new ResultDA { ResultID = 14, AthleteID = 7, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 7), AthleteName = "Bob Groome", EventID = 14, EventName = "Pole Vault", Event = Events.SingleOrDefault(e => e.EventID == 14), DateOfResult = DateTime.Now, Result = 11.38, IsDeleted = false },
                new ResultDA { ResultID = 15, AthleteID = 8, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 8), AthleteName = "Shane Curtin", EventID = 15, EventName = "110 metres hurdles", Event = Events.SingleOrDefault(e => e.EventID == 15), DateOfResult = DateTime.Now, Result = 11.36, IsDeleted = false },
                new ResultDA { ResultID = 16, AthleteID = 8, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 8), AthleteName = "Shane Curtin", EventID = 1, EventName = "100 metres", Event = Events.SingleOrDefault(e => e.EventID == 1), DateOfResult = DateTime.Now, Result = 11.23, IsDeleted = false },
                new ResultDA { ResultID = 17, AthleteID = 9, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 9), AthleteName = "Adrian Cooney", EventID = 2, EventName = "200 metres", Event = Events.SingleOrDefault(e => e.EventID == 2), DateOfResult = DateTime.Now, Result = 110.3, IsDeleted = false },
                new ResultDA { ResultID = 18, AthleteID = 9, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 9), AthleteName = "Adrian Cooney", EventID = 3, EventName = "400 metres", Event = Events.SingleOrDefault(e => e.EventID == 3), DateOfResult = DateTime.Now, Result = 115.3, IsDeleted = false },
                new ResultDA { ResultID = 19, AthleteID = 10, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 10), AthleteName = "Shane Martin", EventID = 4, EventName = "800 metres", Event = Events.SingleOrDefault(e => e.EventID == 4), DateOfResult = DateTime.Now, Result = 151.3, IsDeleted = false },
                new ResultDA { ResultID = 20, AthleteID = 10, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 10), AthleteName = "Shane Martin", EventID = 5, EventName = "1500 metres", Event = Events.SingleOrDefault(e => e.EventID == 5), DateOfResult = DateTime.Now, Result = 117.3, IsDeleted = false },
                new ResultDA { ResultID = 21, AthleteID = 11, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 11), AthleteName = "David Martin", EventID = 6, EventName = "3000 metres", Event = Events.SingleOrDefault(e => e.EventID == 6), DateOfResult = DateTime.Now, Result = 115.3, IsDeleted = false },
                new ResultDA { ResultID = 22, AthleteID = 11, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 11), AthleteName = "David Martin", EventID = 7, EventName = "5000 metres", Event = Events.SingleOrDefault(e => e.EventID == 7), DateOfResult = DateTime.Now, Result = 113.3, IsDeleted = false },
                new ResultDA { ResultID = 23, AthleteID = 12, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 12), AthleteName = "Niamh Martin", EventID = 8, EventName = "10000 metres", Event = Events.SingleOrDefault(e => e.EventID == 8), DateOfResult = DateTime.Now, Result = 111.3, IsDeleted = false },
                new ResultDA { ResultID = 24, AthleteID = 12, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 12), AthleteName = "Niamh Martin", EventID = 9, EventName = "Shot Putt", Event = Events.SingleOrDefault(e => e.EventID == 9), DateOfResult = DateTime.Now, Result = 119.3, IsDeleted = false },
                new ResultDA { ResultID = 25, AthleteID = 13, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 13), AthleteName = "Thomas Martin", EventID = 10, EventName = "Discus", Event = Events.SingleOrDefault(e => e.EventID == 10), DateOfResult = DateTime.Now, Result = 121.3, IsDeleted = false },
                new ResultDA { ResultID = 26, AthleteID = 13, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 13), AthleteName = "Thomas Martin", EventID = 11, EventName = "Javelin", Event = Events.SingleOrDefault(e => e.EventID == 11), DateOfResult = DateTime.Now, Result = 131.3, IsDeleted = false },
                new ResultDA { ResultID = 27, AthleteID = 14, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 14), AthleteName = "Geraldine Martin", EventID = 12, EventName = "High Jump", Event = Events.SingleOrDefault(e => e.EventID == 12), DateOfResult = DateTime.Now, Result = 411.3, IsDeleted = false },
                new ResultDA { ResultID = 28, AthleteID = 14, Athlete = Athletes.SingleOrDefault(a => a.AthleteID == 14), AthleteName = "Geraldine Martin", EventID = 13, EventName = "Long Jump", Event = Events.SingleOrDefault(e => e.EventID == 13), DateOfResult = DateTime.Now, Result = 611.3, IsDeleted = false },
            };

            Results.ForEach(r => context.Results.AddOrUpdate(r));
            SaveChanges(context);

        }

        private void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }
    }
}
