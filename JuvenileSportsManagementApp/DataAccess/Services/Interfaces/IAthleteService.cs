using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuvenileSportsManagementApp.Entities;

namespace JuvenileSportsManagementApp.DataAccess.Services.Interfaces
{
    public interface IAthleteService
    {
        List<AthleteDA> GetAthletes(int groupID, bool includeIsDeleted = false);

        AthleteDA GetAthleteByID(int athleteID);

        AthleteDA GetAthleteByName(string athleteName);

        bool SaveAthletes(List<AthleteDA> athletes);

    }
}
