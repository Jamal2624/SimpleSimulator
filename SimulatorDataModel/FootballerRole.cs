using System.ComponentModel.DataAnnotations;

namespace SimulatorDataModel
{
    /// <summary>
    /// Role of the footballer in the team
    /// </summary>
    public class FootballerRole : ISimData
    {
        /// <summary>
        /// The role of the footballer in the team
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The caption of the role 
        /// </summary>
        public string Caption { get; set; }

    }
}
