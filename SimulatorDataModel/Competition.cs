using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimulatorDataModel
{
    /// <summary>
    /// Competition meeting bitween two football teams
    /// </summary>
    public class Competition: ISimData
    {
        /// <summary>
        /// Unique Id of the competition
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Reference to Championship
        /// </summary>
        [ForeignKey("Championship")]
        public int ChampionshipId { get; set; }

        /// <summary>
        /// Reference to Championship
        /// </summary>
        public virtual Championship Championship { get; set; }


        /// <summary>
        /// Reference to Id of the first team
        /// </summary>
        public int? FirstTeamId { get; set; }

        /// <summary>
        /// Reference to first team
        /// </summary>
        [ForeignKey("FirstTeamId")]
        public virtual FootballTeam FirstTeam { get; set; }

        /// <summary>
        /// Score of the first team
        /// </summary>
        public int? FirstTeamScore { get; set; }

        /// <summary>
        /// Reference to Id of the second team
        /// </summary>
        public int? SecondTeamId { get; set; }

        /// <summary>
        /// Reference to second team
        /// </summary>
        [ForeignKey("SecondTeamId")]
        public virtual FootballTeam SecondTeam { get; set; }

        /// <summary>
        /// Score of the second team
        /// </summary>
        public int? SecondTeamScore { get; set; }

        public Tuple<int, int> CalculateResult()
        {
            Tuple<int, int> result;

            if (!(FirstTeamScore.HasValue && SecondTeamScore.HasValue))
                return null;
            if (FirstTeamScore == SecondTeamScore)
            {
                result = new Tuple<int, int>(1, 1);
            }
            else if (FirstTeamScore == SecondTeamScore)
            {
                result = new Tuple<int, int>(3, 0);
            }
            else
            {
                result = new Tuple<int, int>(0, 3);
            }

            return result;
        }
    }
}
