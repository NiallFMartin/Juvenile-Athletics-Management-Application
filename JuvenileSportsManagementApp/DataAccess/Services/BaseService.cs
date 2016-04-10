using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuvenileSportsManagementApp.DataAccess;
using JuvenileSportsManagementApp.Entities;

namespace JuvenileSportsManagementApp.DataAccess.Services
{
    public class BaseService : IDisposable
    {
        protected SportsAppContext _db;

        public BaseService(SportsAppContext context)
        {
            _db = context;
        }

        void IDisposable.Dispose()
        {
            _db.Dispose();
        }
    }
}
