using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimulatorDataModel
{
    /// <summary>
    /// Football championship
    /// </summary>
    public class Championship: ISimData
    {
        /// <summary>
        /// Unique Id of the footbal championship
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Caption of the championship
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// In which year
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// True - all competition are played
        /// </summary>
        public bool Completed { get; set; }

        /// <summary>
        /// List of competitions
        /// </summary>
        public virtual IList<Competition> Competitions { get; set; } = new List<Competition>();

        /// <summary>
        /// List of teams
        /// </summary>
        public virtual IList<FootballTeam> Teams { get; set; } = new List<FootballTeam>();
    }
}
