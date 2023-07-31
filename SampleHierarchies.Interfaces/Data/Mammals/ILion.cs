using System;

namespace SampleHierarchies.Interfaces.Data.Mammals
{
    /// <summary>
    /// Interface depicting a lion.
    /// </summary>
    public interface ILion : IMammal
    {
        #region Interface Members

        /// <summary>
        /// Gets or sets a value indicating whether the lion is an apex predator.
        /// </summary>
        bool ApexPredator { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the lion is a pack hunter.
        /// </summary>
        bool PackHunter { get; set; }

        /// <summary>
        /// Gets or sets the type of mane the lion has.
        /// </summary>
        string Mane { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the lion has roaring communication.
        /// </summary>
        bool RoaringCommunication { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the lion has territory defense behavior.
        /// </summary>
        bool TerritoryDefense { get; set; }

        #endregion // Interface Members
    }
}
