using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JuvenileSportsManagementApp.DataAccess;
using JuvenileSportsManagementApp.Entities;
using JuvenileSportsManagementApp.DataAccess.Services.Interfaces;

namespace JuvenileSportsManagementApp.DataAccess.Services
{
    public class AthleteService : BaseService, IAthleteService
    {
        //constructor
        public AthleteService(SportsAppContext context)
            : base(context)
        {

        }

        public List<AthleteDA> GetAthletes(int groupID, bool includeIsDeleted = false)
        {
            List<AthleteDA> athletes = new List<AthleteDA>();

            try
            {
                if(groupID < 0 && includeIsDeleted)
                {
                    athletes = _db.Athletes.ToList();
                }
                else if(groupID < 0)
                {
                    athletes = _db.Athletes.Where(a => a.IsDeleted == false).ToList();
                }
                else if(groupID > 0 && includeIsDeleted)
                {
                    athletes = _db.Athletes.Where(a => a.GroupID == groupID).ToList();
                }
                else
                {
                    athletes = _db.Athletes.Where(a => a.GroupID == groupID && a.IsDeleted == false).ToList();
                }
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in AthleteService.GetAthletes()"));
            }

            return athletes;
        }

        public AthleteDA GetAthleteByName(string athleteName)
        {
            List<AthleteDA> athleteSource = new List<AthleteDA>();
            AthleteDA athlete = new AthleteDA();

            try
            {
                athleteSource = _db.Athletes.Where(a => a.AthleteName == athleteName).ToList();
                athlete = athleteSource.First();
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in AthleteService.GetAthleteByName()"));
            }

            return athlete;
        }

        public AthleteDA GetAthleteByID(int athleteID)
        {
            List<AthleteDA> athleteSource = new List<AthleteDA>();
            AthleteDA athlete = new AthleteDA();

            try
            {
                athleteSource = _db.Athletes.Where(a => a.AthleteID == athleteID).ToList();
                athlete = athleteSource.First();
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in AthleteService.GetAthleteByID()"));
            }

            return athlete;
        }

        public bool SaveAthletes(List<AthleteDA> athletes)
        {
            bool success = false;

            try
            {
                foreach(AthleteDA athlete in athletes)
                {
                    AthleteDA existAthlete = new AthleteDA();

                    //check if athlete is valid existing athlete
                    if(athlete.AthleteID > 0)
                    {
                        //get age group object associated with athlete
                        if (athlete.AgeGroup == null)
                        {
                            athlete.AgeGroup = _db.Groups.SingleOrDefault(g => g.GroupID == athlete.GroupID); 
                        }
                        //get existing athlete from database
                        existAthlete = _db.Athletes.SingleOrDefault(a => a.AthleteID == athlete.AthleteID);
                        //update existing athlete
                        _db.Entry(existAthlete).CurrentValues.SetValues(athlete);
                        //flag athlete as changed
                        _db.Entry(existAthlete).State = System.Data.Entity.EntityState.Modified;
                    }

                    else if(athlete.AthleteID == 0)
                    {
                        //get age group object associated with athlete
                        if (athlete.AgeGroup == null)
                        {
                            athlete.AgeGroup = _db.Groups.SingleOrDefault(g => g.GroupID == athlete.GroupID);
                        }

                        _db.Athletes.Add(athlete);
                    }
                }
                //single call to database to save all changes
                _db.SaveChanges();
                success = true;
            }

            catch (Exception e)
            {
                throw (new Exception("Error occured in AthleteService.SaveAthletes(athletes) - " + e.Message));
            }

            return success;
        }
    }
}