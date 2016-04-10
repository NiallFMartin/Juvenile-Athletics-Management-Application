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
    public class EventsController : Controller
    {
        // GET: Events
        public ViewResult Events()
        {
            List<EventDA> eventDAList = DataAccessServiceController.EventService.GetEvents();
            List<EventVM> eventList = new List<EventVM>();

            Mapper.Map(eventDAList, eventList);
            return View("Events", eventList);
        }

        //GET: EventsIndex
        public ViewResult EventsIndex()
        {
            return View();
        }

        //GET: Details
        public ViewResult Details(int eventID)
        {
            EventDA eventDA = DataAccessServiceController.EventService.GetEventByID(eventID);
            EventVM evnt = new EventVM();

            Mapper.Map(eventDA, evnt);
            return View("Details", evnt);
        }

        //GET: Create
        public ViewResult Create()
        {
            EventVM e = new EventVM();
            
            //manually adding event types to list for use in creating events
            List<string> eventTypes = new List<string>();
            eventTypes.Add("Time");
            eventTypes.Add("Distance");

            ViewData["eventTypes"] = eventTypes; 

            return View("Create", e);
        }

        //POST: Create
        [HttpPost]
        public ActionResult Create(EventVM createdEvent)
        {
            try
            {
                EventDA eventDA = new EventDA();
                List<EventDA> eventList = new List<EventDA>();

                Mapper.Map(createdEvent, eventDA);

                eventList.Add(eventDA);
                bool success = DataAccessServiceController.EventService.SaveEvents(eventList);

                if (success == true)
                {
                    return RedirectToAction("Success", "Application", new { area = "" });
                }
                else
                {
                    return RedirectToAction("Fail", "Application", new { area = "" });
                }
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in EventsController.Create(result)"));
            }
        }
    }
}