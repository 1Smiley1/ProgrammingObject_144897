using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data
{
    /// <summary>
    /// Behaviour actions.
    /// </summary>
    public interface IBehaviour
    {
        #region Interface Members

        /// <summary>
        /// Describes how the animal makes a sound.
        /// </summary>
        void MakeSound();

        /// <summary>
        /// Describes how the animal moves.
        /// </summary>
        void Move();

        /// <summary>
        /// Displays information about the animal.
        /// </summary>
        void Display();

        #endregion // Interface Members
    }
}
