namespace SimpleSimulatorAccess.Migrations
{
    using SimulatorDataModel;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleSimulatorAccess.SimulatorContext>
    {
        Random _rndGenerator = new Random();
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SimpleSimulatorAccess.SimulatorContext context)
        {
            var roles = SeedFootballerRoles(context);
            var teams = SeedFootballTeams(context);
            SeedFootballers(context, roles, teams);

            //save seedings
        }

        private void SeedFootballers(SimulatorContext context, FootballerRole[] roles, FootballTeam[] teams)
        {
            var dictRoles = roles.ToDictionary(el => el.Caption);
            var dictTeams = teams.ToDictionary(el => el.Code);

            var list = new Footballer[]
{
                        new Footballer()
                        {
                            FirstName="Hirving",
                            SecondName="Lozano",
                            BirthYear=1995,
                            Roleid=dictRoles["Forward"].Id,
                            Teamid=dictTeams["PSV"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Luuk",
                            SecondName="de Jong",
                            BirthYear=1990,
                            Roleid=dictRoles["Forward"].Id,
                            Teamid=dictTeams["PSV"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Maximiliano",
                            SecondName="Romero",
                            BirthYear=1999,
                            Roleid=dictRoles["Forward"].Id,
                            Teamid=dictTeams["PSV"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Marco",
                            SecondName="van Ginkel",
                            BirthYear=1992,
                            Roleid=dictRoles["Midfielder"].Id,
                            Teamid=dictTeams["PSV"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Santiago",
                            SecondName="Arias",
                            BirthYear=1992,
                            Roleid=dictRoles["Defender"].Id,
                            Teamid=dictTeams["PSV"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Jeroen",
                            SecondName="Zoet",
                            BirthYear=1991,
                            Roleid=dictRoles["Goalkeeper"].Id,
                            Teamid=dictTeams["PSV"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Gastón",
                            SecondName="Pereiro",
                            BirthYear=1995,
                            Roleid=dictRoles["Forward"].Id,
                            Teamid=dictTeams["PSV"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Steven",
                            SecondName="Bergwijn",
                            BirthYear=1997,
                            Roleid=dictRoles["Forward"].Id,
                            Teamid=dictTeams["PSV"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Mauro",
                            SecondName="Júnior",
                            BirthYear=1999,
                            Roleid=dictRoles["Midfielder"].Id,
                            Teamid=dictTeams["PSV"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Jorrit",
                            SecondName="Hendrix",
                            BirthYear=1995,
                            Roleid=dictRoles["Midfielder"].Id,
                            Teamid=dictTeams["PSV"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Bart",
                            SecondName="Ramselaar",
                            BirthYear=1995,
                            Roleid=dictRoles["Midfielder"].Id,
                            Teamid=dictTeams["PSV"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Abdelhak",
                            SecondName="Nouri",
                            BirthYear=1997,
                            Roleid=dictRoles["Midfielder"].Id,
                            Teamid=dictTeams["Ajax"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Matthijs",
                            SecondName="de Ligt",
                            BirthYear=1999,
                            Roleid=dictRoles["Defender"].Id,
                            Teamid=dictTeams["Ajax"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Justin",
                            SecondName="Kluivert",
                            BirthYear=1999,
                            Roleid=dictRoles["Forward"].Id,
                            Teamid=dictTeams["Ajax"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Amin",
                            SecondName="Younes",
                            BirthYear=1993,
                            Roleid=dictRoles["Forward"].Id,
                            Teamid=dictTeams["Ajax"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Kasper",
                            SecondName="Dolberg",
                            BirthYear=1997,
                            Roleid=dictRoles["Forward"].Id,
                            Teamid=dictTeams["Ajax"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Hakim",
                            SecondName="Ziyech",
                            BirthYear=1993,
                            Roleid=dictRoles["Midfielder"].Id,
                            Teamid=dictTeams["Ajax"].Id
                        },
                        new Footballer()
                        {
                            FirstName="David",
                            SecondName="Neres",
                            BirthYear=1997,
                            Roleid=dictRoles["Forward"].Id,
                            Teamid=dictTeams["Ajax"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Klaas-Jan",
                            SecondName="Huntelaar",
                            BirthYear=1983,
                            Roleid=dictRoles["Forward"].Id,
                            Teamid=dictTeams["Ajax"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Nicolás",
                            SecondName="Tagliafico",
                            BirthYear=1992,
                            Roleid=dictRoles["Defender"].Id,
                            Teamid=dictTeams["Ajax"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Lasse",
                            SecondName="Schöne",
                            BirthYear=1986,
                            Roleid=dictRoles["Midfielder"].Id,
                            Teamid=dictTeams["Ajax"].Id
                        },
                        new Footballer()
                        {
                            FirstName="André",
                            SecondName="Onana",
                            BirthYear=1996,
                            Roleid=dictRoles["Goalkeeper"].Id,
                            Teamid=dictTeams["Ajax"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Alireza",
                            SecondName="Jahanbakhsh",
                            BirthYear=1993,
                            Roleid=dictRoles["Midfielder"].Id,
                            Teamid=dictTeams["AZ"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Wout",
                            SecondName="Weghorst",
                            BirthYear=1992 ,
                            Roleid=dictRoles["Forward"].Id,
                            Teamid=dictTeams["AZ"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Idrissi",
                            SecondName="Oussama",
                            BirthYear=1996,
                            Roleid=dictRoles["Forward"].Id,
                            Teamid=dictTeams["AZ"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Ron",
                            SecondName="Vlaar",
                            BirthYear=1985,
                            Roleid=dictRoles["Defender"].Id,
                            Teamid=dictTeams["AZ"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Guus",
                            SecondName="Til",
                            BirthYear=1997,
                            Roleid=dictRoles["Midfielder"].Id,
                            Teamid=dictTeams["AZ"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Jonas",
                            SecondName="Svensson",
                            BirthYear=1993,
                            Roleid=dictRoles["Defender"].Id,
                            Teamid=dictTeams["AZ"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Thomas",
                            SecondName="Ouwejan",
                            BirthYear=1996,
                            Roleid=dictRoles["Defender"].Id,
                            Teamid=dictTeams["AZ"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Marco",
                            SecondName="Bizot",
                            BirthYear=1991,
                            Roleid=dictRoles["Goalkeeper"].Id,
                            Teamid=dictTeams["AZ"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Rens",
                            SecondName="van Eijden",
                            BirthYear=1988,
                            Roleid=dictRoles["Defender"].Id,
                            Teamid=dictTeams["AZ"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Calvin",
                            SecondName="Stengs",
                            BirthYear=1998,
                            Roleid=dictRoles["Forward"].Id,
                            Teamid=dictTeams["AZ"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Mats",
                            SecondName="Seuntjens",
                            BirthYear=1992,
                            Roleid=dictRoles["Midfielder"].Id,
                            Teamid=dictTeams["AZ"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Robin",
                            SecondName="van Persie",
                            BirthYear=1983,
                            Roleid=dictRoles["Forward"].Id,
                            Teamid=dictTeams["Feyenoord"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Nicolai",
                            SecondName="Jørgensen",
                            BirthYear=1991,
                            Roleid=dictRoles["Forward"].Id,
                            Teamid=dictTeams["Feyenoord"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Tonny",
                            SecondName="Vilhena",
                            BirthYear=1995,
                            Roleid=dictRoles["Midfielder"].Id,
                            Teamid=dictTeams["Feyenoord"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Steven ",
                            SecondName="Berghuis",
                            BirthYear=1991,
                            Roleid=dictRoles["Forward"].Id,
                            Teamid=dictTeams["Feyenoord"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Karim",
                            SecondName="El Ahmadi",
                            BirthYear=2004,
                            Roleid=dictRoles["Midfielder"].Id,
                            Teamid=dictTeams["Feyenoord"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Jens",
                            SecondName="Toornstra",
                            BirthYear=1989,
                            Roleid=dictRoles["Midfielder"].Id,
                            Teamid=dictTeams["Feyenoord"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Brad ",
                            SecondName="Jones",
                            BirthYear=1982,
                            Roleid=dictRoles["Goalkeeper"].Id,
                            Teamid=dictTeams["Feyenoord"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Sven",
                            SecondName="van Beek",
                            BirthYear=1994,
                            Roleid=dictRoles["Defender"].Id,
                            Teamid=dictTeams["Feyenoord"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Renato",
                            SecondName="Tapia",
                            BirthYear=1995,
                            Roleid=dictRoles["Midfielder"].Id,
                            Teamid=dictTeams["Feyenoord"].Id
                        },
                        new Footballer()
                        {
                            FirstName="Eric Fernando",
                            SecondName="Botteghin",
                            BirthYear=1987,
                            Roleid=dictRoles["Defender"].Id,
                            Teamid=dictTeams["Feyenoord"].Id
                        },
                                                new Footballer()
                        {
                            FirstName="Jan-Arie",
                            SecondName="van der Heijden",
                            BirthYear=1988 ,
                            Roleid=dictRoles["Defender"].Id,
                            Teamid=dictTeams["Feyenoord"].Id
                        }

};

            context.Footballers.AddOrUpdate(el => new { el.FirstName, el.SecondName }, list);
            context.SaveChanges();
        }

        private FootballTeam[] SeedFootballTeams(SimulatorContext context)
        {
            var list = new FootballTeam[]
            {
                new FootballTeam(){
                    Name = " Philips Sport Vereniging",
                    Code="PSV",
                    AttackStrength=_rndGenerator.Next(1,10),
                    DefenceStrength=_rndGenerator.Next(1,10),
                    CollaboratingStrength=_rndGenerator.Next(1,10)
                },
                new FootballTeam(){
                    Name = "AFC Ajax",
                    Code="Ajax",
                    AttackStrength=_rndGenerator.Next(1,10),
                    DefenceStrength=_rndGenerator.Next(1,10),
                    CollaboratingStrength=_rndGenerator.Next(1,10)
                },
                new FootballTeam(){
                    Name = "Alkmaar Zaanstreek",
                    Code="AZ",
                    AttackStrength=_rndGenerator.Next(1,10),
                    DefenceStrength=_rndGenerator.Next(1,10),
                    CollaboratingStrength=_rndGenerator.Next(1,10)
                },
                new FootballTeam(){
                    Name = "Feyenoord Rotterdam",
                    Code="Feyenoord",
                    AttackStrength=_rndGenerator.Next(1,10),
                    DefenceStrength=_rndGenerator.Next(1,10),
                    CollaboratingStrength=_rndGenerator.Next(1,10)
                }
            };

            context.FootballTeams.AddOrUpdate(el => el.Name, list);
            context.SaveChanges();

            return list;
        }

        private FootballerRole[] SeedFootballerRoles(SimulatorContext context)
        {
            var list = new FootballerRole[]
            {
                new FootballerRole(){ Caption="Goalkeeper"},
                new FootballerRole(){ Caption="Defender"},
                new FootballerRole(){ Caption="Midfielder"},
                new FootballerRole(){ Caption="Forward"}
            };

            context.FootballerRoles.AddOrUpdate(el => el.Caption, list);
            context.SaveChanges();
            return list;
        }
    }
}
