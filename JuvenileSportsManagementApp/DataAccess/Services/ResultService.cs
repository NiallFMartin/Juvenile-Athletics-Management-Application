using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using JuvenileSportsManagementApp.DataAccess;
using JuvenileSportsManagementApp.Entities;
using JuvenileSportsManagementApp.DataAccess.Services.Interfaces;

namespace JuvenileSportsManagementApp.DataAccess.Services
{
    public class ResultService : BaseService, IResultService
    {
        //constructor
        public ResultService(SportsAppContext context)
            : base(context)
        {

        }

        public List<ResultDA> GetAllResults(bool includeIsDeleted = false)
        {
            List<ResultDA> results = new List<ResultDA>();

            try
            {
                if (includeIsDeleted)
                {
                    results = _db.Results.ToList();
                }
                else
                {
                    results = _db.Results.Where(a => a.IsDeleted == false).ToList();
                }
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in ResultService.GetResults()"));
            }

            return results;
        }

        public List<ResultDA> GetResultsByGroup(int groupID, bool includeIsDeleted = false)
        {
            List<ResultDA> results = new List<ResultDA>();

            try
            {
                if (groupID == -1 && includeIsDeleted)
                {
                    results = _db.Results.ToList();
                }

                else if(groupID == -1)
                {
                    results = _db.Results.Where(g => g.IsDeleted == false).ToList();

                }

                else
                {
                    if (includeIsDeleted)
                    {
                        results = _db.Results.Where(g => g.Athlete.GroupID == groupID).ToList();
                    }
                    else
                    {
                        results = _db.Results.Where(g => g.Athlete.GroupID == groupID && g.IsDeleted == false).ToList();
                    }
                }
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in ResultService.GetResultsByGroup()"));
            }

            return results;
        }

        public List<ResultDA> GetResultsByAthlete(int athleteID, bool includeIsDeleted = false)
        {
            List<ResultDA> results = new List<ResultDA>();

            try
            {
                if (includeIsDeleted)
                {
                    results = _db.Results.Where(r => r.AthleteID == athleteID).ToList();
                }
                else
                {
                    results = _db.Results.Where(r => r.Athlete.AthleteID == athleteID && r.IsDeleted == false).ToList();
                }
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in ResultService.GetResultsByAthlete()"));
            }

            return results;
        }

        public List<ResultDA> GetResultsByEvent(int eventID, bool includeIsDeleted = false)
        {
            List<ResultDA> results = new List<ResultDA>();

            try
            {
                if (includeIsDeleted)
                {
                    results = _db.Results.Where(r => r.EventID == eventID).ToList();
                }
                else
                {
                    results = _db.Results.Where(r => r.EventID == eventID && r.IsDeleted == false).ToList();
                }
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in ResultService.GetResultsByEvent()"));
            }

            return results;
        }

        public ResultDA GetResultByID(int resultID)
        {
            List<ResultDA> resultSource = new List<ResultDA>();
            ResultDA result = new ResultDA();

            try
            {
                resultSource = _db.Results.Where(r => r.ResultID == resultID).ToList();
                result = resultSource.First();
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in AthleteService.GetResultByID(resultID)"));
            }

            return result;
        }

        public List<ResultDA> GetResultsForAnalysis(int athleteID, string eventName, string timeframe, bool includeIsDeleted = false)
        {
            List<ResultDA> results = new List<ResultDA>();

            try
            {
                if (timeframe == "week")
                {
                    if (includeIsDeleted)
                    {
                        results = _db.Results.Where(r => r.AthleteID == athleteID && r.Event.EventName == eventName && DbFunctions.DiffDays(r.DateOfResult, DateTime.Now) < 8).ToList();
                    }
                    else
                    {
                        results = _db.Results.Where(r => r.AthleteID == athleteID && r.Event.EventName == eventName && DbFunctions.DiffDays(r.DateOfResult, DateTime.Now) < 8 && r.IsDeleted == false).ToList();
                    }
                }
                else if (timeframe == "month")
                {
                    if (includeIsDeleted)
                    {
                        results = _db.Results.Where(r => r.AthleteID == athleteID && r.Event.EventName == eventName && DbFunctions.DiffDays(r.DateOfResult, DateTime.Now) < 31).ToList();
                    }
                    else
                    {
                        results = _db.Results.Where(r => r.AthleteID == athleteID && r.Event.EventName == eventName && DbFunctions.DiffDays(r.DateOfResult, DateTime.Now) < 31 && r.IsDeleted == false).ToList();
                    }
                }
                else if (timeframe == "year")
                {
                    if (includeIsDeleted)
                    {
                        results = _db.Results.Where(r => r.AthleteID == athleteID && r.Event.EventName == eventName && DbFunctions.DiffDays(r.DateOfResult, DateTime.Now) < 366).ToList();
                    }
                    else
                    {
                        results = _db.Results.Where(r => r.AthleteID == athleteID && r.Event.EventName == eventName && DbFunctions.DiffDays(r.DateOfResult, DateTime.Now) < 366 && r.IsDeleted == false).ToList();
                    }
                }
                else if (timeframe == "all")
                {
                    if (includeIsDeleted)
                    {
                        results = _db.Results.Where(r => r.AthleteID == athleteID && r.Event.EventName == eventName).ToList();
                    }
                    else
                    {
                        results = _db.Results.Where(r => r.AthleteID == athleteID && r.Event.EventName == eventName && r.IsDeleted == false).ToList();
                    }
                }
                return results;
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in AthleteService.GetResultsForAnalysis(int athleteID, string eventName, string timeframe, bool includeIsDeleted = false)"));
            }
        }

        public bool SaveResults(List<ResultDA> results)
        {
            bool success = false;

            try
            {
                foreach (ResultDA result in results)
                {
                    ResultDA existResult = new ResultDA();

                    //check if result is valid existing result
                    if (result.ResultID > 0)
                    {
                        result.Event = _db.Events.SingleOrDefault(e => e.EventName == result.EventName);
                        result.EventID = result.Event.EventID;
                        result.Athlete = _db.Athletes.SingleOrDefault(a => a.AthleteName == result.AthleteName);
                        result.AthleteID = result.Athlete.AthleteID;
                        //get existing result from database
                        existResult = _db.Results.SingleOrDefault(a => a.ResultID == result.ResultID);
                        //update existing result
                        _db.Entry(existResult).CurrentValues.SetValues(result);
                        //flag result as changed
                        _db.Entry(existResult).State = System.Data.Entity.EntityState.Modified;
                    }

                    else if (result.ResultID == 0)
                    {
                        //get athlete object associated with result
                        if (result.Athlete == null)
                        {
                            result.Athlete = _db.Athletes.SingleOrDefault(a => a.AthleteID == result.AthleteID);
                        }

                        //get event object associated with result
                        if(result.Event == null)
                        {
                            result.Event = _db.Events.SingleOrDefault(e => e.EventID == result.EventID);
                        }

                        _db.Results.Add(result);
                    }
                }
                //single call to database to save all changes
                _db.SaveChanges();
                success = true;
            }

            catch (Exception e)
            {
                throw (new Exception("Error occured in ResultService.SaveResults(results)"));
            }

            return success;
        }
    }
}