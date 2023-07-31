using SampleHierarchies.Interfaces.Data.Mammals;
using System.Collections.Generic;

namespace SampleHierarchies.Interfaces.Data
{
    /// <summary>
    /// Mammals collection.
    /// </summary>
    public interface IMammals
    {
        #region Interface Members

        /// <summary>
        /// Dogs collection.
        /// </summary>
        List<IDog> Dogs { get; set; }

        /// <summary>
        /// AfricanElephants collection.
        /// </summary>
        List<IAfricanElephant> AfricanElephants { get; set; }

        /// <summary>
        /// Lions collection.
        /// </summary>
        List<ILion> Lions { get; set; }

        /// <summary>
        /// GrayWolves collection.
        /// </summary>
        List<IGrayWolf> GrayWolves { get; set; }

        #endregion // Interface Members
    }
}
