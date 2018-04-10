using System.ComponentModel.DataAnnotations;

namespace SimulatorDataModel
{
    /// <summary>
    /// Common interface for all simulator data
    /// </summary>
    public interface ISimData
    {
        /// <summary>
        /// Unique Id of the football player
        /// </summary>
        [Key]
        int Id { get; set; }
    }
}
