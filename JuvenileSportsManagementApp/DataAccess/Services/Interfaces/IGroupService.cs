using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuvenileSportsManagementApp.Entities;

namespace JuvenileSportsManagementApp.DataAccess.Services.Interfaces
{
    public interface IGroupService
    {
        List<GroupDA> GetGroups(bool includeIsDeleted = false);

        bool SaveGroups(List<GroupDA> groups);
    }
}
