using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuvenileSportsManagementApp.Entities;

namespace JuvenileSportsManagementApp.DataAccess.Services.Interfaces
{
    public interface IEventService
    {
        List<EventDA> GetEvents(bool includeIsDeleted = false);

        EventDA GetEventByName(string eventName, bool includeIsDeleted = false);

        EventDA GetEventByID(int eventID, bool includeIsDeleted = false);

        bool SaveEvents(List<EventDA> events);
    }
}
