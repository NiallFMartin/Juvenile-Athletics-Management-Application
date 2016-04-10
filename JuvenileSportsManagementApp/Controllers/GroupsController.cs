using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Web.UI;
using AutoMapper;
using JuvenileSportsManagementApp.Models;
using JuvenileSportsManagementApp.Entities;
using JuvenileSportsManagementApp.DataAccess;
using JuvenileSportsManagementApp.DataAccess.Services;

namespace JuvenileSportsManagementApp.Controllers
{
    public class GroupsController : Controller
    {
        // GET: Groups
        public ActionResult Groups()
        {
            List<GroupDA> groupsDA = DataAccessServiceController.GroupService.GetGroups();
            List<GroupVM> groups = new List<GroupVM>();
            Mapper.Map(groupsDA, groups);

            return View("Groups", groups);
        }
    }
}