using SimulatorDataModel;
using System.Linq;
using System;
using System.Collections.Generic;

namespace SimulatorManager
{
    public class SimulatorHandler
    {
        private ISimulatorContext _context;
        private Random _randomizer = new Random(DateTime.Now.Millisecond);

        public ISimulatorContext Context { get { return _context; }  }

        public SimulatorHandler(ISimulatorContext context)
        {
            _context = context;
        }

        public Championship CreateChampionship(string caption, int year)
        {
            var champ = new Championship()
            {
                Caption = caption,
                Year = year
            };
            var teams = _context.SimulatorData<FootballTeam>().ToArray();
            for (int i = 0; i < teams.Count(); i++)
                for (int j = i + 1; j < teams.Count(); j++)
                {
                    var comp = new Competition()
                    {
                        FirstTeam = teams[i],
                        SecondTeam = teams[j]
                    };
                    champ.Competitions.Add(comp);
                }

            _context.Add(champ);
            _context.Save();
            return champ;
        }

        public List<FootballTeam> GetTeams()
        {
            return _context.SimulatorData<FootballTeam>().ToList();
        }

        public Championship GetCurrent()
        {
            var result = _context.SimulatorData<Championship>().OrderByDescending(cmp => cmp.Year).FirstOrDefault();
            return result; 
        }

        public void Play(Competition comp)
        {
            //each command has 45 possibilities to organaize attack on opponent
            comp.FirstTeamScore = comp.SecondTeamScore = 0;
            for (var i = 0; i < 45; i++)
            {
                comp.FirstTeamScore += AttackTrial(comp.FirstTeam, comp.SecondTeam);
                comp.SecondTeamScore += AttackTrial(comp.SecondTeam, comp.FirstTeam);
            }
        }

        private int AttackTrial(FootballTeam attacker, FootballTeam defender)
        {
            var result = 0;
            //Phase 1: organizing attack
            if (AttackOrganized(attacker.CollaboratingStrength))
            {
                result = Scored(attacker.AttackStrength, defender.DefenceStrength) ? 1 : 0;
            }

            return result;
        }

        private bool Scored(int attackStrength, int defenceStrength)
        {
            var result = false;
            var probability = 0.3 * ((0.5 + 0.04 * (attackStrength - defenceStrength)));
            var rnd = _randomizer.NextDouble();
            result = rnd < probability;
            return result;
        }

        private bool AttackOrganized(int collaboratingStrength)
        {
            var result = false;
            var probability = 0.3 * (1.0 * collaboratingStrength / 10);
            var rnd = _randomizer.NextDouble();
            result = rnd < probability;
            return result;
        }

        public TeamResult SummariseTeamResult(Championship cmp, FootballTeam team)
        {

            if (cmp == null || team == null ) return null;
            var result = new TeamResult()
            {
                Championship = cmp,
                Team = team
            };

            _context.SimulatorData<Competition>()
                .Where(el => el.FirstTeamId == team.Id && el.ChampionshipId== cmp.Id).ToList()
                .ForEach((el) =>
                {
                    if (el.FirstTeamScore.HasValue)
                    {
                        result.Scored += el.FirstTeamScore ?? 0;
                        result.Conceded += el.SecondTeamScore ?? 0;
                        result.Won += el.FirstTeamScore > el.SecondTeamScore ? 1 : 0;
                        result.Lost += el.FirstTeamScore < el.SecondTeamScore ? 1 : 0;
                        result.Draw += el.FirstTeamScore == el.SecondTeamScore ? 1 : 0;

                    }
                }
                );

            _context.SimulatorData<Competition>()
                .Where(el => el.SecondTeamId == team.Id && el.ChampionshipId == cmp.Id).ToList()
                .ForEach((el) =>
                {
                    if (el.FirstTeamScore.HasValue)
                    {
                        result.Scored += el.SecondTeamScore ?? 0;
                        result.Conceded += el.FirstTeamScore ?? 0;
                        result.Lost += el.FirstTeamScore > el.SecondTeamScore ? 1 : 0;
                        result.Won += el.FirstTeamScore < el.SecondTeamScore ? 1 : 0;
                        result.Draw += el.FirstTeamScore == el.SecondTeamScore ? 1 : 0;

                    }
                }
                );
            result.Points = 3 * result.Won + result.Draw;

            return result;
        }

        public void FinalizeChampionship(Championship champ)
        {
            foreach (var play in champ.Competitions)
            {
                if (!play.FirstTeamScore.HasValue)
                {
                    Play(play);
                }
            }
            champ.Completed = true;
            _context.Save();
        }

        public List<TeamResult> Summarize(Championship champ)
        {
            var list = new List<TeamResult>();
            if (champ.Competitions.All(el=>el.FirstTeamScore.HasValue))
            {
                champ.Completed = true;
                _context.Save();
            }
            var teams = _context.SimulatorData<FootballTeam>();
            teams.ToList()
                .ForEach((tm) => {
                    var item = SummariseTeamResult(champ, tm);
                    list.Add(item);
            });

            list=list.OrderByDescending(el => new ComparablePoint()
            {
                Points=el.Points,
                Difference=el.Scored-el.Conceded,
                Scored =el.Scored
            }).ToList();

            int pos = 1;
            list.ToList()
                .ForEach((rs) => {
                    rs.Placement = pos++;
                });


            return list;
        }
    }
}
