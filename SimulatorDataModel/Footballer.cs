using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimulatorDataModel
{
    /// <summary>
    /// Football player, member of a football team
    /// </summary>
    public class Footballer : ISimData
    {
        /// <summary>
        /// Unique Id of the football player
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// First name of the player
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Second name of the player
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Year of birth
        /// </summary>
        public int BirthYear { get; set; }

        /// <summary>
        /// Reference to the role
        /// </summary>
        [ForeignKey("Role")]
        public int Roleid { get; set; }

        /// <summary>
        /// Reference to role in the team
        /// </summary>
        public virtual FootballerRole Role { get; set; }

        /// <summary>
        /// Reference to football team
        /// </summary>
        [ForeignKey("Team")]
        public int Teamid { get; set; }

        /// <summary>
        /// Reference to football team
        /// </summary>
        public virtual FootballTeam Team { get; set; }

    }
}
