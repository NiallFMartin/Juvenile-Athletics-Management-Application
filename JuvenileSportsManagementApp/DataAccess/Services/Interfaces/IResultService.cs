using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuvenileSportsManagementApp.Entities;

namespace JuvenileSportsManagementApp.DataAccess.Services.Interfaces
{
    public interface IResultService
    {
        List<ResultDA> GetAllResults(bool includeIsDeleted = false);

        List<ResultDA> GetResultsByGroup(int groupID, bool includeIsDeleted = false);

        List<ResultDA> GetResultsByAthlete(int athleteID, bool includeIsDeleted = false);

        List<ResultDA> GetResultsByEvent(int eventID, bool includeIsDeleted = false);

        List<ResultDA> GetResultsForAnalysis(int athleteID, string eventName, string timeframe, bool includeIsDeleted = false);

        ResultDA GetResultByID(int resultID);

        bool SaveResults(List<ResultDA> results);
    }
}
