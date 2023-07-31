using SampleHierarchies.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data
{
    /// <summary>
    /// Settings class that implements the ISettings interface.
    /// </summary>
    public class Settings : ISettings
    {
        #region Properties

        /// <summary>
        /// Gets or sets the text color.
        /// </summary>
        public string TextColor { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the main screen color.
        /// </summary>
        public string MainScreenColor { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the animals screen color.
        /// </summary>
        public string AnimalsScreenColor { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the mammals screen color.
        /// </summary>
        public string MammalsScreenColor { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the dogs screen color.
        /// </summary>
        public string DogsScreenColor { get; set; } = string.Empty;

        // Other existing properties and methods can remain as they are.

        /// <summary>
        /// Gets or sets the version of the settings.
        /// </summary>
        public string Version { get; set; } = string.Empty;

        #endregion // Properties
    }
}
