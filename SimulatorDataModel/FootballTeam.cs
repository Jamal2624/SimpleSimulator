using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace SimulatorDataModel
{
    /// <summary>
    /// Football team
    /// </summary>
    public class FootballTeam : ISimData
    {
        /// <summary>
        /// Unique Id of the team
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of the team
        /// </summary>
        [Required(ErrorMessage = "Please enter  Name")]
        public string Name { get; set; }

        /// <summary>
        /// Code of the team
        /// </summary>
        [Required(ErrorMessage = "Please enter team Code")]
        public string Code { get; set; }

        /// <summary>
        /// How strong the team is in attack
        /// from 1 to 10, as higher the strength is the higher chance to score by attack situation 
        /// </summary>
        [Required(ErrorMessage = "Please enter  Attack Strength")]
        [Range(1, 10, ErrorMessage = "Attack range should be in the range 1 to 10")]
        public int AttackStrength { get; set; }

        /// <summary>
        /// How strong the team is in defence
        /// from 1 to 10, as higher the strength is the higher chance 
        /// to prevent scoring by attacking opponent team  
        /// </summary>
        [Required(ErrorMessage = "Please enter  Defence Strength")]
        [Range(1, 10, ErrorMessage = "Defence range should be in the range 1 to 10")]
        public int DefenceStrength { get; set; }

        /// <summary>
        /// How strong the players are in collaboration 
        /// from 1 to 10, as higher the strength is the higher chance 
        /// that payers organizing attack on opponent team  
        /// </summary>
        [Required(ErrorMessage = "Please enter  Collaborating Strength")]
        [Range(1, 10, ErrorMessage = "Collaborating range should be in the range 1 to 10")]
        public int CollaboratingStrength { get; set; }

        /// <summary>
        /// List of footballers in the team
        /// </summary>
        public virtual IList<Footballer> Players { get; set; } = new List<Footballer>();
    }
}
