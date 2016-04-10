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
using System.Web.Helpers;

namespace JuvenileSportsManagementApp.Controllers
{
    public class AthletesController : Controller
    {

        //GET: AthletesIndex
        public ViewResult AthletesIndex()
        {
            return View();
        }

        //GET: ExistAthletes
        public ViewResult ExistAthletes()
        {
            List<GroupVM> groups = new List<GroupVM>();
            List<GroupDA> groupSource = new List<GroupDA>();

            try
            {
                groupSource = DataAccessServiceController.GroupService.GetGroups();
                //map data to VM object list
                Mapper.Map(groupSource, groups);

                groups = groups.OrderBy(a => a.GroupID).ToList();

                return View("ExistAthletes", groups);
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in AthleteController.ExistAthletes()"));
            }


        }

        // GET: Athlete
        public ViewResult Athletes(int groupID)
        {
            List<AthleteVM> athletes = new List<AthleteVM>();
            List<AthleteDA> athleteSource = new List<AthleteDA>();
            try
            {
                athleteSource = DataAccessServiceController.AthleteService.GetAthletes(groupID);
                //map data to VM object list
                Mapper.Map(athleteSource, athletes);

                athletes = athletes.OrderBy(a => a.GroupID).ToList();

                return View("Athletes", athletes);
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in AthleteController.Athletes()"));
            }
        }

        //GET: Create
        public ViewResult Create()
        {
            try
            {
                AthleteVM athlete = new AthleteVM();

                return View("Create", athlete);
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in AthleteController.Create()"));
            }
        }

        //POST: Create
        [HttpPost]
        public ActionResult Create(AthleteVM athlete)
        {
            try
            {
                AthleteDA athleteDA = new AthleteDA();
                List<AthleteDA> athleteList = new List<AthleteDA>();

                //set athlete's group depending on athlete's date of birth
                //condition is set by seeing if athlete is less than a certain amount of days old (eg. 4018 days is 11 years ie. 365.25 * 11)
                if ((DateTime.Now - athlete.DateOfBirth).Days < 4018)
                {
                    athlete.GroupID = 1;
                    athlete.GroupName = "Under 10s";
                }
                else if ((DateTime.Now - athlete.DateOfBirth).Days >= 4018 && (DateTime.Now - athlete.DateOfBirth).Days < 4748)
                {
                    athlete.GroupID = 2;
                    athlete.GroupName = "Under 12s";
                }
                else if ((DateTime.Now - athlete.DateOfBirth).Days >= 4748 && (DateTime.Now - athlete.DateOfBirth).Days < 5479)
                {
                    athlete.GroupID = 3;
                    athlete.GroupName = "Under 14s";
                }
                else if ((DateTime.Now - athlete.DateOfBirth).Days >= 5479 && (DateTime.Now - athlete.DateOfBirth).Days < 6209)
                {
                    athlete.GroupID = 4;
                    athlete.GroupName = "Under 16s";
                }
                else if ((DateTime.Now - athlete.DateOfBirth).Days >= 6209 && (DateTime.Now - athlete.DateOfBirth).Days < 6940)
                {
                    athlete.GroupID = 5;
                    athlete.GroupName = "Under 18s";
                }
                else if ((DateTime.Now - athlete.DateOfBirth).Days >= 6940 && (DateTime.Now - athlete.DateOfBirth).Days < 8036)
                {
                    athlete.GroupID = 6;
                    athlete.GroupName = "Under 21s";
                }
                else if ((DateTime.Now - athlete.DateOfBirth).Days >= 8036)
                {
                    athlete.GroupID = 7;
                    athlete.GroupName = "Senior";
                }

                Mapper.Map(athlete, athleteDA);

                athleteList.Add(athleteDA);
                bool success = DataAccessServiceController.AthleteService.SaveAthletes(athleteList);

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
                throw (new Exception("Error occured in AthleteController.Create(athlete)"));
            }
        }

        //GET: Details
        public ViewResult Details(int athleteID)
        {
            AthleteVM athlete = new AthleteVM();
            AthleteDA athleteSource = new AthleteDA();
            try
            {
                athleteSource = DataAccessServiceController.AthleteService.GetAthleteByID(athleteID);

                Mapper.Map(athleteSource, athlete);

                return View("Details", athlete);
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in AthleteController.Details(athleteID)"));
            }
        }

        //GET: Edit
        public ViewResult Edit(int athleteID)
        {
            AthleteVM athlete = new AthleteVM();
            AthleteDA athleteSource = new AthleteDA();
            try
            {
                athleteSource = DataAccessServiceController.AthleteService.GetAthleteByID(athleteID);

                Mapper.Map(athleteSource, athlete);

                return View("Edit", athlete);
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in AthleteController.Edit(athleteID)"));
            }
        }

        //POST: Edit
        [HttpPost]
        public ActionResult Edit(AthleteVM athlete)
        {
            AthleteDA athleteDA = DataAccessServiceController.AthleteService.GetAthleteByID(athlete.AthleteID);
            List<AthleteDA> athleteList = new List<AthleteDA>();
            try
            {
                //set athlete's group depending on athlete's date of birth
                //condition is set by seeing if athlete is less than a certain amount of days old (eg. 4018 days is 11 years ie. 365.25 * 11)
                if ((DateTime.Now - athlete.DateOfBirth).Days < 4018)
                {
                    athlete.GroupID = 1;
                    athlete.GroupName = "Under 10s";
                }
                else if ((DateTime.Now - athlete.DateOfBirth).Days >= 4018 && (DateTime.Now - athlete.DateOfBirth).Days < 4748)
                {
                    athlete.GroupID = 2;
                    athlete.GroupName = "Under 12s";
                }
                else if ((DateTime.Now - athlete.DateOfBirth).Days >= 4748 && (DateTime.Now - athlete.DateOfBirth).Days < 5479)
                {
                    athlete.GroupID = 3;
                    athlete.GroupName = "Under 14s";
                }
                else if ((DateTime.Now - athlete.DateOfBirth).Days >= 5479 && (DateTime.Now - athlete.DateOfBirth).Days < 6209)
                {
                    athlete.GroupID = 4;
                    athlete.GroupName = "Under 16s";
                }
                else if ((DateTime.Now - athlete.DateOfBirth).Days >= 6209 && (DateTime.Now - athlete.DateOfBirth).Days < 6940)
                {
                    athlete.GroupID = 5;
                    athlete.GroupName = "Under 18s";
                }
                else if ((DateTime.Now - athlete.DateOfBirth).Days >= 6940 && (DateTime.Now - athlete.DateOfBirth).Days < 8036)
                {
                    athlete.GroupID = 6;
                    athlete.GroupName = "Under 21s";
                }
                else if ((DateTime.Now - athlete.DateOfBirth).Days >= 8036)
                {
                    athlete.GroupID = 7;
                    athlete.GroupName = "Senior";
                }

                Mapper.Map(athlete, athleteDA);

                athleteList.Add(athleteDA);
                bool success = DataAccessServiceController.AthleteService.SaveAthletes(athleteList);
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
                throw (new Exception("Error occured in AthleteController.Edit(athlete)"));
            }
        }

        //GET: Delete
        public ViewResult Delete(int athleteID)
        {
            AthleteVM athlete = new AthleteVM();
            AthleteDA athleteSource = new AthleteDA();
            try
            {
                athleteSource = DataAccessServiceController.AthleteService.GetAthleteByID(athleteID);

                Mapper.Map(athleteSource, athlete);

                return View("Delete", athlete);
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in AthleteController.Delete(athleteID)"));
            }
        }

        //POST: Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int athleteID)
        {
            try
            {

                List<AthleteDA> athleteList = new List<AthleteDA>();

                AthleteDA athleteToDelete = DataAccessServiceController.AthleteService.GetAthleteByID(athleteID);
                athleteToDelete.IsDeleted = true;

                athleteList.Add(athleteToDelete);

                bool success = DataAccessServiceController.AthleteService.SaveAthletes(athleteList);

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
                throw (new Exception("Error occured in AthleteController.DeletePost(athleteID) - " + e.Message));
            }
        }

        //GET: AnalyseIndex
        public ViewResult AnalyseIndex(int athleteID)
        {
            List<string> eventNames = new List<string>();
            List<EventDA> events = DataAccessServiceController.EventService.GetEvents();
            foreach (var e in events)
            {
                eventNames.Add(e.EventName);
            }

            ViewData["eventNames"] = eventNames;
            ViewData["athleteID"] = athleteID;
            return View("AnalyseIndex");
        }

        //POST: AnalyseIndex
        [HttpPost]
        public ActionResult AnalyseIndex(int athleteID, AnalyseVM a)
        {

            return RedirectToAction("Analyse", new { aID = athleteID, eventName = a.EventName, timeframe = a.TimeFrame });
        }

        
        public ActionResult Analyse(int aID, string eventName, string timeframe)
        {
            try
            {
                AthleteDA athlete = DataAccessServiceController.AthleteService.GetAthleteByID(aID);
                EventDA evnt = DataAccessServiceController.EventService.GetEventByName(eventName);
                List<ResultDA> results = DataAccessServiceController.ResultService.GetResultsForAnalysis(aID, eventName, timeframe);
                results = results.OrderBy(r => r.DateOfResult).ToList();
                AnalyseVM analysis = new AnalyseVM();              

                if (results.Count > 0)
                {
                    analysis.AthleteID = aID;
                    analysis.AthleteName = athlete.AthleteName;
                    analysis.EventName = evnt.EventName;
                    analysis.EventType = evnt.EventType;
                    analysis.TimeFrame = timeframe;
                    analysis.TotalNumResults = results.Count();


                    List<DateTime> dates = new List<DateTime>();
                    List<double> resultValues = new List<double>();
                    //List<string> resultDates = new List<string>();

                    foreach (ResultDA r in results)
                    {
                        resultValues.Add(r.Result);
                        dates.Add(r.DateOfResult);
                    }

                    //AnalyseVM store results as arrays for use in graph
                    analysis.Results = resultValues.ToArray();
                    analysis.ResultDates = dates.ToArray();

                    if (analysis.EventType == "Time")
                    {
                        analysis.BestResult = analysis.Results.Min();
                        analysis.WorstResult = analysis.Results.Max();
                        analysis.TargetResult = analysis.BestResult * 0.95;
                    }
                    else if (analysis.EventType == "Distance")
                    {
                        analysis.BestResult = analysis.Results.Max();
                        analysis.WorstResult = analysis.Results.Min();
                        analysis.TargetResult = analysis.BestResult * 1.05;
                    }

                    analysis.AverageResult = analysis.Results.Average();

                    return View("Analyse", analysis);
                }
                else
                {
                    return View("NoResults");
                }

            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in AthleteController.Analyse(aID, eventName, timeframe)"));
            }
        }
        
        [HttpPost]
        [ActionName("Analyse")]
        public ActionResult AnalysePost(int aID, string eventName, string timeframe)
        {
            return RedirectToAction("AnalysisChart", new { aID, eventName, timeframe });
        }

        public ViewResult AnalysisChart(int aID, string eventName, string timeframe)
        {
            try
            {
                AthleteDA athlete = DataAccessServiceController.AthleteService.GetAthleteByID(aID);
                EventDA evnt = DataAccessServiceController.EventService.GetEventByName(eventName);
                List<ResultDA> results = DataAccessServiceController.ResultService.GetResultsForAnalysis(aID, eventName, timeframe);
                results = results.OrderBy(r => r.DateOfResult).ToList();
                AnalyseVM analysis = new AnalyseVM();

                if (results.Count > 0)
                {
                    analysis.AthleteID = aID;
                    analysis.AthleteName = athlete.AthleteName;
                    analysis.EventName = evnt.EventName;
                    analysis.EventType = evnt.EventType;
                    analysis.TimeFrame = timeframe;
                    analysis.TotalNumResults = results.Count();


                    List<DateTime> dates = new List<DateTime>();
                    List<double> resultValues = new List<double>();
                    //List<string> resultDates = new List<string>();

                    foreach (ResultDA r in results)
                    {
                        resultValues.Add(r.Result);
                        dates.Add(r.DateOfResult);
                    }

                    //AnalyseVM store results as arrays for use in graph
                    analysis.Results = resultValues.ToArray();
                    analysis.ResultDates = dates.ToArray();

                    if (analysis.EventType == "Time")
                    {
                        analysis.BestResult = analysis.Results.Min();
                        analysis.WorstResult = analysis.Results.Max();
                        analysis.TargetResult = analysis.BestResult * 0.95;
                    }
                    else if (analysis.EventType == "Distance")
                    {
                        analysis.BestResult = analysis.Results.Max();
                        analysis.WorstResult = analysis.Results.Min();
                        analysis.TargetResult = analysis.BestResult * 1.05;
                    }

                    analysis.AverageResult = analysis.Results.Average();

                    return View("AnalysisChart", analysis);
                }
                else
                {
                    return View("NoResults");
                }

            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in AthleteController.AnalyseChart(aID, eventName, timeframe)"));
            }
            
        }
    }
}