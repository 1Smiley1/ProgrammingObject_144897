using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;
using System.Collections.Generic;

namespace SampleHierarchies.Data.Mammals
{
    /// <summary>
    /// Mammals collection class that implements the IMammals interface.
    /// </summary>
    public class Mammals : IMammals
    {
        #region IMammals Implementation

        /// <inheritdoc/>
        public List<IDog> Dogs { get; set; }

        /// <inheritdoc/>
        public List<IAfricanElephant> AfricanElephants { get; set; }

        /// <inheritdoc/>
        public List<ILion> Lions { get; set; }

        /// <inheritdoc/>
        public List<IGrayWolf> GrayWolves { get; set; }

        #endregion // IMammals Implementation

        #region Constructors

        /// <summary>
        /// Default constructor for the Mammals class.
        /// Initializes lists of different mammal types.
        /// </summary>
        public Mammals()
        {
            Dogs = new List<IDog>();
            AfricanElephants = new List<IAfricanElephant>();
            Lions = new List<ILion>();
            GrayWolves = new List<IGrayWolf>(); // Initialize the GrayWolves list
        }

        #endregion // Constructors
    }
}
