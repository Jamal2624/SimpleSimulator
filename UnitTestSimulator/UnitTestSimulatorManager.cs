using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Xunit;
using SimpleSimulatorAccess;
using SimulatorDataModel;
using System.Linq;
using SimulatorManager;
using System.Data.Entity;

namespace UnitTestSimulator
{
    [TestClass]
    public class UnitTestSimulatorManager
    {
        private ISimulatorContext GetContext()
        {
            return new SimulatorContext();
        }

        //[Fact]
        [TestMethod]
        public void Check_get_context()
        {
            var context = new SimulatorContext();
            var list = context.Set<FootballerRole>().ToList();
            Assert.IsTrue(context.IsOpen);
        }

        //[Fact]
        [TestMethod]
        public void Create_New_Chanpionship()
        {
            var context = GetContext();

            var champship = new Championship()
            {
                Caption = "Test",
                Year = 9999
            };

            context.Add(champship);
            context.Save();

            champship = context.SimulatorData<Championship>()
                .FirstOrDefault(el => el.Caption== "Test");
            Assert.IsNotNull(champship);

            context.Delete(champship);
            context.Save();
        }

        [TestMethod]
        public void Create_New_Chanpionship_with_competitions()
        {
            var context = GetContext();

            var simulator = new SimulatorHandler(context);
            simulator.CreateChampionship("Test", 9999);

            var comps = context.SimulatorData<Competition>().Where(cmp => cmp.Championship.Year == 9999);
            var count= comps.Count();
            Assert.IsNotNull(count == 6);

            context.Delete<Competition>(comps.ToList());

            var champship = context.SimulatorData<Championship>()
                .FirstOrDefault(el => el.Caption == "Test");
            context.Delete(champship);
            context.Save();

        }

        [TestMethod]
        public void Testing_of_Single_Play_strong_weak()
        {

            var simulator = new SimulatorHandler(null);
            var first = new FootballTeam()
            {
                AttackStrength = 1,
                CollaboratingStrength = 1,
                DefenceStrength = 1
            };

            var second = new FootballTeam()
            {
                AttackStrength = 10,
                CollaboratingStrength = 10,
                DefenceStrength = 10
            };

  
            var comp = new Competition()
            {
                FirstTeam= first,
                SecondTeam= second
            };

            simulator.Play(comp);
        }

        [TestMethod]
        public void Testing_of_Single_Play_middle_middle()
        {

            var simulator = new SimulatorHandler(null);
            var first = new FootballTeam()
            {
                AttackStrength = 5,
                CollaboratingStrength = 5,
                DefenceStrength = 5
            };

            var second = new FootballTeam()
            {
                AttackStrength = 7,
                CollaboratingStrength = 7,
                DefenceStrength = 7
            };


            var comp = new Competition()
            {
                FirstTeam = first,
                SecondTeam = second
            };

            simulator.Play(comp);
        }

        [TestMethod]
        public void Testing_of_Play_Championship()
        {
            var context = GetContext();

            var simulator = new SimulatorHandler(context);
            //get last championship
            var last = context.SimulatorData<Championship>().OrderByDescending(el => el.Year).FirstOrDefault();
            Championship champ;
            if (last == null || last.Completed)
            {
                var year = last == null ? DateTime.Now.Year : last.Year + 1;
                champ = simulator.CreateChampionship($"Championship {year}", year);
            } else
            {
                champ = last;
            }
            simulator.FinalizeChampionship(champ);

        }

        [TestMethod]
        public void Testing_first_team_results()
        {
            var context = GetContext();

            var simulator = new SimulatorHandler(context);
            //get last championship
            var champ = context.SimulatorData<Championship>()
                .Include(el => el.Competitions)
                .OrderByDescending(el => el.Year).FirstOrDefault();
            if (champ != null )
            {
                var team = champ.Competitions.FirstOrDefault()? .FirstTeam;
                if (team != null)
                {
                    var result = simulator.SummariseTeamResult(champ, team);
                }
            }
        }

        [TestMethod]
        public void Testing_Summarize_Championship()
        {
            var context = GetContext();

            var simulator = new SimulatorHandler(context);
            //get last championship
            var champ = context.SimulatorData<Championship>()
                .Include(el => el.Competitions)
                .OrderByDescending(el => el.Year).FirstOrDefault();
            if (champ != null)
            {
                var allResults = simulator.Summarize(champ);
            }
        }

        [TestMethod]
        public void Testing_of_Calculate_Championship_results()
        {
            var context = GetContext();

            var simulator = new SimulatorHandler(context);
            //get last championship
            var last = context.SimulatorData<Championship>().OrderByDescending(el => el.Year).FirstOrDefault();
            Championship champ;
            if (last == null || last.Completed)
            {
                var year = last == null ? DateTime.Now.Year : last.Year + 1;
                champ = simulator.CreateChampionship($"Championship {year}", year);
            }
            else
            {
                champ = last;
            }
            simulator.FinalizeChampionship(champ);
        }
    }
}
