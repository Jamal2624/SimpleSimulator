using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleSimulatorAccess;
using SimulatorManager;
using SimulatorDataModel;

namespace WebSimulator.Controllers
{
    public class SimulatorController : Controller
    {
        private SimulatorHandler _handler = new SimulatorHandler(new SimulatorContext());

        [HttpGet]
        public ActionResult Simulate()
        {
            var current = _handler.GetCurrent();
            if (current != null)
            {
                var summary = _handler.Summarize(current).OrderBy(el => el.Placement).ToArray();
                ViewBag.Summary = summary;
            }


            return View("Simulate", current);
        }

        [HttpGet]
        public ActionResult Teams()
        {
            var teams = _handler.GetTeams();
            return View("Teams", teams);
        }

        [HttpPost]
        public ActionResult SaveTeams(List<FootballTeam> teams)

        {
            if (ModelState.IsValid)
            {
                foreach (FootballTeam team in teams)
                {
                    FootballTeam exTeam = _handler.Context.Find<FootballTeam>(team.Id);
                    exTeam.Name = team.Name;
                    exTeam.Code = team.Code;
                    exTeam.CollaboratingStrength = team.CollaboratingStrength;
                    exTeam.AttackStrength = team.AttackStrength;
                    exTeam.DefenceStrength = team.DefenceStrength;
                }
                _handler.Context.Save();
            }
            return View("Teams", teams);
        }

        [HttpPost]
        public ActionResult CreateCampionship()
        {
            //get last championship
            var last = _handler.Context.SimulatorData<Championship>().OrderByDescending(el => el.Year).FirstOrDefault();
            Championship champ;
            if (last == null || last.Completed)
            {
                var year = last == null ? DateTime.Now.Year : last.Year + 1;
                champ = _handler.CreateChampionship($"Championship {year}", year);
            }
            return RedirectToAction("Simulate", "Simulator");
        }

        [HttpGet]
        public ActionResult PlayMatch(int CompitionId)
        {
            //get game
            var cmp = _handler.Context.SimulatorData<Competition>().FirstOrDefault(el => el.Id == CompitionId);
            if (cmp != null && !cmp.FirstTeamScore.HasValue)
            {
                _handler.Play(cmp);
                var close = !cmp.Championship.Competitions.Any(el => !el.FirstTeamScore.HasValue);
                if (close)
                {
                    cmp.Championship.Completed = true;
                }
                _handler.Context.Save();
            }
            return RedirectToAction("Simulate", "Simulator");
        }


        [HttpGet]
        public ActionResult PlayAllMatch()
        {
            //get game
            var cmp = _handler.Context.SimulatorData<Championship>().OrderByDescending(el => el.Year).FirstOrDefault();
            if (cmp == null || !cmp.Completed)
            {
                _handler.FinalizeChampionship(cmp);
            }
            return RedirectToAction("Simulate", "Simulator");
        }
    }
}