using System;

namespace SampleHierarchies.Interfaces.Data.Mammals
{
    /// <summary>
    /// Interface depicting a gray wolf.
    /// </summary>
    public interface IGrayWolf : IMammal
    {
        #region Interface Members

        /// <summary>
        /// Gets or sets a value indicating whether the gray wolf is a pack hunter.
        /// </summary>
        bool PackHunter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the gray wolf has howling communication.
        /// </summary>
        bool HowlingCommunication { get; set; }

        /// <summary>
        /// Gets or sets the carnivorous diet of the gray wolf.
        /// </summary>
        string CarnivorousDiet { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the gray wolf has strong jaws.
        /// </summary>
        bool StrongJaws { get; set; }

        /// <summary>
        /// Gets or sets the level of good sense of smell of the gray wolf.
        /// </summary>
        string GoodSenseOfSmell { get; set; }

        #endregion // Interface Members
    }
}
