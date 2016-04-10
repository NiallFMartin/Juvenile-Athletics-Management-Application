using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JuvenileSportsManagementApp.DataAccess;
using JuvenileSportsManagementApp.Entities;
using JuvenileSportsManagementApp.DataAccess.Services.Interfaces;

namespace JuvenileSportsManagementApp.DataAccess.Services
{
    public class GroupService : BaseService, IGroupService
    {
        //constructor
        public GroupService(SportsAppContext context)
            : base(context)
        {

        }

        public List<GroupDA> GetGroups(bool includeIsDeleted = false)
        {
            List<GroupDA> groups = new List<GroupDA>();

            try
            {
                if (includeIsDeleted)
                {
                    groups = _db.Groups.ToList();
                }
                else
                {
                    groups = _db.Groups.Where(a => a.IsDeleted == false).ToList();
                }
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in GroupService.GetGroups()"));
            }

            return groups;
        }

        public bool SaveGroups(List<GroupDA> groups)
        {
            bool success = false;

            try
            {
                foreach (GroupDA group in groups)
                {
                    GroupDA existGroup = new GroupDA();

                    //check if group is valid existing group
                    if (group.GroupID > 0)
                    {
                        //get existing group from database
                        existGroup = _db.Groups.SingleOrDefault(a => a.GroupID == group.GroupID);
                        //update existing group
                        _db.Entry(existGroup).CurrentValues.SetValues(group);
                        //flag group as changed
                        _db.Entry(existGroup).State = System.Data.Entity.EntityState.Modified;
                    }

                    else if (group.GroupID == 0)
                    {
                        _db.Groups.Add(group);
                    }
                }
                //single call to database to save all changes
                _db.SaveChanges();
                success = true;
            }

            catch (Exception e)
            {
                throw (new Exception("Error occured in GroupService.SaveGroups(groups)"));
            }

            return success;
        }
    }
}