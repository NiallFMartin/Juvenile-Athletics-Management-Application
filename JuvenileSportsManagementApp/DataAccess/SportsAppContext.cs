using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuvenileSportsManagementApp.Entities;

namespace JuvenileSportsManagementApp.DataAccess
{
    public class SportsAppContext : DbContext
    {       
        // constructor sets connection string
        public SportsAppContext() : base("DefaultConnection")
        {
        }

        //Add tables to database
        public virtual DbSet<AthleteDA> Athletes { get; set; }

        public virtual DbSet<GroupDA> Groups { get; set; }

        public virtual DbSet<ResultDA> Results { get; set; }

        public virtual DbSet<EventDA> Events { get; set; }

    }
}