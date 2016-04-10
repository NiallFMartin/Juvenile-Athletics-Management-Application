using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JuvenileSportsManagementApp.DataAccess;
using JuvenileSportsManagementApp.Entities;
using JuvenileSportsManagementApp.DataAccess.Services.Interfaces;

namespace JuvenileSportsManagementApp.DataAccess.Services
{
    public class EventService : BaseService, IEventService
    {
        //constructor
        public EventService(SportsAppContext context)
            : base(context)
        {

        }

        public List<EventDA> GetEvents(bool includeIsDeleted = false)
        {
            List<EventDA> events = new List<EventDA>();

            try
            {
                if (includeIsDeleted)
                {
                    events = _db.Events.ToList();
                }
                else
                {
                    events = _db.Events.Where(a => a.IsDeleted == false).ToList();
                }
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in EventService.GetEvents()"));
            }

            return events;
        }

        public EventDA GetEventByName(string eventName, bool includeIsDeleted)
        {
            EventDA evnt = new EventDA();
            List<EventDA> events = new List<EventDA>();

            try
            {
                events = _db.Events.Where(a => a.EventName == eventName).ToList();
                evnt = events.First();
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in EventService.GetEventByID()"));
            }
            

            return evnt;
        }

        public EventDA GetEventByID(int eventID, bool includeIsDeleted)
        {
            EventDA evnt = new EventDA();
            List<EventDA> events = new List<EventDA>();

            try
            {
                events = _db.Events.Where(a => a.EventID == eventID).ToList();
                evnt = events.First();
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in EventService.GetEventByID()"));
            }


            return evnt;
        }

        public bool SaveEvents(List<EventDA> events)
        {
            bool success = false;

            try
            {
                foreach (EventDA e in events)
                {
                    EventDA existEvent = new EventDA();

                    //check if event is valid existing event
                    if (e.EventID > 0)
                    {
                        //get existing event from database
                        existEvent = _db.Events.SingleOrDefault(a => a.EventID == e.EventID);
                        //update existing event
                        _db.Entry(existEvent).CurrentValues.SetValues(e);
                        //flag event as changed
                        _db.Entry(existEvent).State = System.Data.Entity.EntityState.Modified;
                    }

                    else if (e.EventID == 0)
                    {
                        _db.Events.Add(e);
                    }
                }
                //single call to database to save all changes
                _db.SaveChanges();
                success = true;
            }

            catch (Exception e)
            {
                throw (new Exception("Error occured in EventService.SaveEvents(events)"));
            }

            return success;
        }
    }
}