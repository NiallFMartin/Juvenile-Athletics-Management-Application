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
    public class ResultsController : Controller
    {
        // GET: ResultsIndex
        public ViewResult ResultsIndex()
        {
            return View();
        }

        //GET: ExistResults
        public ViewResult ExistResults()
        {
            return View();
        }

        //GET: Results
        public ViewResult Results(List<ResultVM> results)
        {
            return View("Results", results);
        }

        //GET: Create
        public ViewResult Create()
        {
            try
            {
                ResultVM result = new ResultVM();

                List<string> eventNames = new List<string>();
                List<EventDA> events = DataAccessServiceController.EventService.GetEvents();
                foreach (var e in events)
                {
                    eventNames.Add(e.EventName);
                }

                List<string> athleteNames = new List<string>();
                List<AthleteDA> athletes = DataAccessServiceController.AthleteService.GetAthletes(-1);

                foreach (var a in athletes)
                {
                    athleteNames.Add(a.AthleteName);
                }

                athleteNames.Sort();

                ViewData["eventNames"] = eventNames;
                ViewData["athleteNames"] = athleteNames;

                return View("Create", result);
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in ResultsController.Create()"));
            }
        }

        //POST: Create
        [HttpPost]
        public ActionResult Create(ResultVM createdResult)
        {
            try
            {
                ResultDA resultDA = new ResultDA();
                List<ResultDA> resultList = new List<ResultDA>();


                List<EventDA> events = DataAccessServiceController.EventService.GetEvents();
                EventDA e = events.Find(x => x.EventName == createdResult.EventName);
                List<AthleteDA> athletes = DataAccessServiceController.AthleteService.GetAthletes(-1);
                AthleteDA a = athletes.Find(x => x.AthleteName == createdResult.AthleteName);

                //send event and athlete ids to created result viewmodel depending on names chosen
                createdResult.EventID = e.EventID;
                createdResult.AthleteID = a.AthleteID;

                Mapper.Map(createdResult, resultDA);

                resultList.Add(resultDA);
                bool success = DataAccessServiceController.ResultService.SaveResults(resultList);

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
                throw (new Exception("Error occured in ResultsController.Create(result)"));
            }
        }

        //GET: Delete
        public ViewResult Delete(int resultID)
        {
            ResultVM result = new ResultVM();
            ResultDA resultDA = new ResultDA();
            try
            {
                resultDA = DataAccessServiceController.ResultService.GetResultByID(resultID);

                Mapper.Map(resultDA, result);

                return View("Delete", result);
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in ResultController.Delete(resultID)"));
            }
        }

        //POST: Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int resultID)
        {
            try
            {

                List<ResultDA> resultList = new List<ResultDA>();

                ResultDA resultToDelete = DataAccessServiceController.ResultService.GetResultByID(resultID);
                resultToDelete.IsDeleted = true;

                resultList.Add(resultToDelete);

                bool success = DataAccessServiceController.ResultService.SaveResults(resultList);

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
                throw (new Exception("Error occured in ResultsController.DeletePost(resultID)"));
            }
        }

        //Get: Details
        public ViewResult Details(int resultID)
        {
            ResultVM result = new ResultVM();
            ResultDA resultDA = new ResultDA();

            try
            {
                resultDA = DataAccessServiceController.ResultService.GetResultByID(resultID);

                Mapper.Map(resultDA, result);
                return View("Details", result);
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in ResultsController.Details(resultID)"));
            }
        }

        //GET: Edit
        public ViewResult Edit(int resultID)
        {
            ResultVM result = new ResultVM();
            ResultDA resultDA = new ResultDA();

            try
            {
                resultDA = DataAccessServiceController.ResultService.GetResultByID(resultID);

                Mapper.Map(resultDA, result);

                List<string> eventNames = new List<string>();
                List<EventDA> events = DataAccessServiceController.EventService.GetEvents();
                foreach (var e in events)
                {
                    eventNames.Add(e.EventName);
                }

                List<string> athleteNames = new List<string>();
                List<AthleteDA> athletes = DataAccessServiceController.AthleteService.GetAthletes(-1);

                foreach (var a in athletes)
                {
                    athleteNames.Add(a.AthleteName);
                }

                athleteNames.Sort();

                ViewData["eventNames"] = eventNames;
                ViewData["athleteNames"] = athleteNames;
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in ResultsController.Edit(resultID)"));
            }
            return View("Edit", result);
        }

        //POST: Edit
        [HttpPost]
        public ActionResult Edit(ResultVM resultToEdit)
        {
            ResultDA resultDA = new ResultDA();
            List<ResultDA> resultList = new List<ResultDA>();

            Mapper.Map(resultToEdit, resultDA);
            resultList.Add(resultDA);

            bool success = DataAccessServiceController.ResultService.SaveResults(resultList);

            if (success == true)
            {
                return RedirectToAction("Success", "Application", new { area = "" });
            }
            else
            {
                return RedirectToAction("Fail", "Application", new { area = "" });
            }
        }

        //GET: ResultsByAthlete
        public ViewResult ResultsByAthlete()
        {
            List<AthleteVM> athletes = new List<AthleteVM>();
            List<AthleteDA> athletesDA = new List<AthleteDA>();

            //get list of all athletes
            athletesDA = DataAccessServiceController.AthleteService.GetAthletes(-1);

            Mapper.Map(athletesDA, athletes);

            athletes = athletes.OrderBy(a => a.AthleteName).ToList();

            return View("ResultsByAthlete", athletes);
        }

        //GET: AthleteResults
        public ViewResult AthleteResults(int ID)
        {
            List<ResultVM> resultList = new List<ResultVM>();
            List<ResultDA> resultDA = DataAccessServiceController.ResultService.GetResultsByAthlete(ID);

            Mapper.Map(resultDA, resultList);

            ViewResult vr = new ViewResult();
            vr = Results(resultList);
            return vr;
        }

        //GET: ResultsByEvent
        public ViewResult ResultsByEvent()
        {
            List<EventVM> events = new List<EventVM>();
            List<EventDA> eventsDA = new List<EventDA>();

            eventsDA = DataAccessServiceController.EventService.GetEvents();

            Mapper.Map(eventsDA, events);

            events = events.OrderBy(e => e.EventID).ToList();

            return View("ResultsByEvent", events);
        }

        //GET: AthleteResults
        public ViewResult EventResults(int ID)
        {
            List<ResultVM> resultList = new List<ResultVM>();
            List<ResultDA> resultDA = DataAccessServiceController.ResultService.GetResultsByEvent(ID);

            Mapper.Map(resultDA, resultList);

            ViewResult vr = new ViewResult();
            vr = Results(resultList);
            return vr;
        }

        //GET: ResultsByGroup
        public ViewResult ResultsByGroup()
        {
            List<GroupVM> groups = new List<GroupVM>();
            List<GroupDA> groupsDA = new List<GroupDA>();

            groupsDA = DataAccessServiceController.GroupService.GetGroups();

            Mapper.Map(groupsDA, groups);

            groups = groups.OrderBy(g => g.GroupID).ToList();

            return View("ResultsByGroup", groups);
        }

        //GET: GroupResults
        public ActionResult GroupResults(int ID)
        {
            List<ResultVM> resultList = new List<ResultVM>();
            List<ResultDA> resultDA = DataAccessServiceController.ResultService.GetResultsByGroup(ID);

            Mapper.Map(resultDA, resultList);

            ViewResult vr = new ViewResult();
            vr = Results(resultList);
            return vr;
        }

        //GET:AllResults
        public ActionResult AllResults()
        {
            List<ResultVM> resultList = new List<ResultVM>();
            List<ResultDA> resultDA = DataAccessServiceController.ResultService.GetResultsByGroup(-1);

            Mapper.Map(resultDA, resultList);

            ViewResult vr = new ViewResult();
            vr = Results(resultList);
            return vr;
        }

        //GET: ChooseAthletes
        public ViewResult ChooseAthletes()
        {
            List<string> eventNames = new List<string>();
            List<EventDA> events = DataAccessServiceController.EventService.GetEvents();
            foreach (var e in events)
            {
                eventNames.Add(e.EventName);
            }

            List<AthleteDA> athletesDA = DataAccessServiceController.AthleteService.GetAthletes(-1);
            List<AthleteVM> athletes = new List<AthleteVM>();
            athletes.OrderBy(m => m.AthleteName);
            Mapper.Map(athletesDA, athletes);

            ViewData["eventNames"] = eventNames;
            ViewData["athletes"] = athletes;
            return View("ChooseAthletes");
        }

        [HttpPost]
        public ActionResult ChooseAthletes(List<AnalyseVM> a)
        {
            AthleteDA a1 = DataAccessServiceController.AthleteService.GetAthleteByName(a.First().AthleteName);
            AthleteDA a2 = DataAccessServiceController.AthleteService.GetAthleteByName(a.Last().AthleteName);

            return RedirectToAction("Compare", new { aID1 = a1.AthleteID, aID2 = a2.AthleteID, eventName = a.First().EventName, timeframe = a.First().TimeFrame });
        }

        public ActionResult Compare(int aID1, int aID2, string eventName, string timeframe)
        {
            try
            {
                List<AnalyseVM> compareList = new List<AnalyseVM>();

                AthleteDA athlete1 = DataAccessServiceController.AthleteService.GetAthleteByID(aID1);
                EventDA evnt = DataAccessServiceController.EventService.GetEventByName(eventName);
                List<ResultDA> results1 = DataAccessServiceController.ResultService.GetResultsForAnalysis(aID1, eventName, timeframe);
                results1 = results1.OrderBy(r => r.DateOfResult).ToList();
                AnalyseVM analysis1 = new AnalyseVM();


                AthleteDA athlete2 = DataAccessServiceController.AthleteService.GetAthleteByID(aID2);
                EventDA evnt2 = DataAccessServiceController.EventService.GetEventByName(eventName);
                List<ResultDA> results2 = DataAccessServiceController.ResultService.GetResultsForAnalysis(aID2, eventName, timeframe);
                results2 = results2.OrderBy(r => r.DateOfResult).ToList();
                AnalyseVM analysis2 = new AnalyseVM();

                if (results1.Count > 0 && results2.Count > 0)
                {
                    analysis1.AthleteID = aID1;
                    analysis1.AthleteName = athlete1.AthleteName;
                    analysis1.EventName = evnt.EventName;
                    analysis1.EventType = evnt.EventType;
                    analysis1.TimeFrame = timeframe;
                    analysis1.TotalNumResults = results1.Count();


                    List<DateTime> dates1 = new List<DateTime>();
                    List<double> resultValues1 = new List<double>();
                    //List<string> resultDates = new List<string>();

                    foreach (ResultDA r in results1)
                    {
                        resultValues1.Add(r.Result);
                        dates1.Add(r.DateOfResult);
                    }

                    //AnalyseVM store results as arrays for use in graph
                    analysis1.Results = resultValues1.ToArray();
                    analysis1.ResultDates = dates1.ToArray();

                    if (analysis1.EventType == "Time")
                    {
                        analysis1.BestResult = analysis1.Results.Min();
                        analysis1.WorstResult = analysis1.Results.Max();
                        analysis1.TargetResult = analysis1.BestResult * 0.95;
                    }
                    else if (analysis1.EventType == "Distance")
                    {
                        analysis1.BestResult = analysis1.Results.Max();
                        analysis1.WorstResult = analysis1.Results.Min();
                        analysis1.TargetResult = analysis1.BestResult * 1.05;
                    }

                    analysis1.AverageResult = analysis1.Results.Average();

                    analysis2.AthleteID = aID2;
                    analysis2.AthleteName = athlete2.AthleteName;
                    analysis2.EventName = evnt2.EventName;
                    analysis2.EventType = evnt2.EventType;
                    analysis2.TimeFrame = timeframe;
                    analysis2.TotalNumResults = results2.Count();


                    List<DateTime> dates2 = new List<DateTime>();
                    List<double> resultValues2 = new List<double>();

                    foreach (ResultDA r in results2)
                    {
                        resultValues2.Add(r.Result);
                        dates2.Add(r.DateOfResult);
                    }

                    //AnalyseVM store results as arrays for use in graph
                    analysis2.Results = resultValues2.ToArray();
                    analysis2.ResultDates = dates2.ToArray();

                    if (analysis2.EventType == "Time")
                    {
                        analysis2.BestResult = analysis2.Results.Min();
                        analysis2.WorstResult = analysis2.Results.Max();
                        analysis2.TargetResult = analysis2.BestResult * 0.95;
                    }
                    else if (analysis1.EventType == "Distance")
                    {
                        analysis2.BestResult = analysis2.Results.Max();
                        analysis2.WorstResult = analysis2.Results.Min();
                        analysis2.TargetResult = analysis2.BestResult * 1.05;
                    }

                    analysis2.AverageResult = analysis2.Results.Average();
                    compareList.Add(analysis1);
                    compareList.Add(analysis2);

                    return View("Compare", compareList);
                }
                else
                {
                    return View("NoResults");
                }               
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in AthleteController.Compare(aID1, aID2, eventName, timeframe)"));
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
                throw (new Exception("Error occured in AthleteController.AnalyseChart(aID1, aID2, eventName, timeframe)"));
            }

        }

        [HttpPost]
        [ActionName("Compare")]
        public ActionResult ComparePost(int aID1, int aID2, string eventName, string timeframe)
        {
            return RedirectToAction("CompareChart", new { aID1, aID2, eventName, timeframe });
        }

        public ViewResult CompareChart(int aID1, int aID2, string eventName, string timeframe)
        {
            try
            {
                List<AnalyseVM> compareList = new List<AnalyseVM>();

                AthleteDA athlete1 = DataAccessServiceController.AthleteService.GetAthleteByID(aID1);
                EventDA evnt = DataAccessServiceController.EventService.GetEventByName(eventName);
                List<ResultDA> results1 = DataAccessServiceController.ResultService.GetResultsForAnalysis(aID1, eventName, timeframe);
                results1 = results1.OrderBy(r => r.DateOfResult).ToList();
                AnalyseVM analysis1 = new AnalyseVM();


                AthleteDA athlete2 = DataAccessServiceController.AthleteService.GetAthleteByID(aID2);
                EventDA evnt2 = DataAccessServiceController.EventService.GetEventByName(eventName);
                List<ResultDA> results2 = DataAccessServiceController.ResultService.GetResultsForAnalysis(aID2, eventName, timeframe);
                results2 = results2.OrderBy(r => r.DateOfResult).ToList();
                AnalyseVM analysis2 = new AnalyseVM();

                if (results1.Count > 0 && results2.Count > 0)
                {
                    analysis1.AthleteID = aID1;
                    analysis1.AthleteName = athlete1.AthleteName;
                    analysis1.EventName = evnt.EventName;
                    analysis1.EventType = evnt.EventType;
                    analysis1.TimeFrame = timeframe;
                    analysis1.TotalNumResults = results1.Count();


                    List<DateTime> dates1 = new List<DateTime>();
                    List<double> resultValues1 = new List<double>();
                    //List<string> resultDates = new List<string>();

                    foreach (ResultDA r in results1)
                    {
                        resultValues1.Add(r.Result);
                        dates1.Add(r.DateOfResult);
                    }

                    //AnalyseVM store results as arrays for use in graph
                    analysis1.Results = resultValues1.ToArray();
                    analysis1.ResultDates = dates1.ToArray();

                    if (analysis1.EventType == "Time")
                    {
                        analysis1.BestResult = analysis1.Results.Min();
                        analysis1.WorstResult = analysis1.Results.Max();
                        analysis1.TargetResult = analysis1.BestResult * 0.95;
                    }
                    else if (analysis1.EventType == "Distance")
                    {
                        analysis1.BestResult = analysis1.Results.Max();
                        analysis1.WorstResult = analysis1.Results.Min();
                        analysis1.TargetResult = analysis1.BestResult * 1.05;
                    }

                    analysis1.AverageResult = analysis1.Results.Average();

                    analysis2.AthleteID = aID2;
                    analysis2.AthleteName = athlete2.AthleteName;
                    analysis2.EventName = evnt2.EventName;
                    analysis2.EventType = evnt2.EventType;
                    analysis2.TimeFrame = timeframe;
                    analysis2.TotalNumResults = results2.Count();


                    List<DateTime> dates2 = new List<DateTime>();
                    List<double> resultValues2 = new List<double>();

                    foreach (ResultDA r in results2)
                    {
                        resultValues2.Add(r.Result);
                        dates2.Add(r.DateOfResult);
                    }

                    //AnalyseVM store results as arrays for use in graph
                    analysis2.Results = resultValues2.ToArray();
                    analysis2.ResultDates = dates2.ToArray();

                    if (analysis2.EventType == "Time")
                    {
                        analysis2.BestResult = analysis2.Results.Min();
                        analysis2.WorstResult = analysis2.Results.Max();
                        analysis2.TargetResult = analysis2.BestResult * 0.95;
                    }
                    else if (analysis1.EventType == "Distance")
                    {
                        analysis2.BestResult = analysis2.Results.Max();
                        analysis2.WorstResult = analysis2.Results.Min();
                        analysis2.TargetResult = analysis2.BestResult * 1.05;
                    }

                    analysis2.AverageResult = analysis2.Results.Average();
                    compareList.Add(analysis1);
                    compareList.Add(analysis2);

                    return View("CompareChart", compareList);
                }
                else
                {
                    return View("NoResults");
                }
            }
            catch (Exception e)
            {
                throw (new Exception("Error occured in AthleteController.Compare(aID1, aID2, eventName, timeframe)"));
            }
        }
    }
}