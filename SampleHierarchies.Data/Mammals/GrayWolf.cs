using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals
{
    /// <summary>
    /// Gray Wolf class that implements the IGrayWolf interface and extends the MammalBase class.
    /// </summary>
    public class GrayWolf : MammalBase, IGrayWolf
    {
        #region Properties

        /// <inheritdoc />
        public bool PackHunter { get; set; }

        /// <inheritdoc />
        public bool HowlingCommunication { get; set; }

        /// <inheritdoc />
        public string CarnivorousDiet { get; set; }

        /// <inheritdoc />
        public bool StrongJaws { get; set; }

        /// <inheritdoc />
        public string GoodSenseOfSmell { get; set; }

        #endregion // Properties

        #region Constructor

        /// <summary>
        /// Constructor for creating a new GrayWolf object.
        /// </summary>
        /// <param name="name">Name of the gray wolf</param>
        /// <param name="age">Age of the gray wolf</param>
        /// <param name="packHunter">Whether the gray wolf is a pack hunter</param>
        /// <param name="howlingCommunication">Whether the gray wolf exhibits howling communication</param>
        /// <param name="carnivorousDiet">Diet of the gray wolf</param>
        /// <param name="strongJaws">Whether the gray wolf has strong jaws</param>
        /// <param name="goodSenseOfSmell">The gray wolf's sense of smell</param>
        public GrayWolf(string name, int age, bool packHunter, bool howlingCommunication, string carnivorousDiet, bool strongJaws, string goodSenseOfSmell)
            : base(name, age, MammalSpecies.GrayWolf)
        {
            PackHunter = packHunter;
            HowlingCommunication = howlingCommunication;
            CarnivorousDiet = carnivorousDiet;
            StrongJaws = strongJaws;
            GoodSenseOfSmell = goodSenseOfSmell;
        }

        #endregion // Constructor
    }
}
