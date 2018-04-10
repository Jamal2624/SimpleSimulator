using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimulatorDataModel
{
    /// <summary>
    /// Football team
    /// </summary>
    public class TeamResult : ISimData
    {
        /// <summary>
        /// Unique Id of the team
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
        public int? TeamId { get; set; }

        /// <summary>
        /// Reference to first team
        /// </summary>
        [ForeignKey("TeamId")]
        public virtual FootballTeam Team { get; set; }

        /// <summary>
        /// How strong the team is in attack
        /// from 1 to 10, as higher the strength is the higher chance to score by attack situation 
        /// </summary>
        public int Won { get; set; }

        /// <summary>
        /// How strong the team is in defence
        /// from 1 to 10, as higher the strength is the higher chance 
        /// to prevent scoring by attacking opponent team  
        /// </summary>
        public int Draw { get; set; }

        
        /// <summary>
        /// Total team's points    
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// How strong the players are in collaboration 
        /// from 1 to 10, as higher the strength is the higher chance 
        /// that payers organizing attack on opponent team  
        /// </summary>
        public int Lost { get; set; }

        /// <summary>
        /// How scored goals  
        /// </summary>
        public int Scored { get; set; }

        /// <summary>
        /// How scored goals  
        /// </summary>
        public int Conceded { get; set; }

        /// <summary>
        /// How scored goals  
        /// </summary>
        public int Placement { get; set; }

    }
}
