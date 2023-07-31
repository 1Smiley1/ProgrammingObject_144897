using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals
{
    /// <summary>
    /// Lion class that implements the ILion interface and extends the MammalBase class.
    /// </summary>
    public class Lion : MammalBase, ILion
    {
        #region Properties

        /// <inheritdoc />
        public bool ApexPredator { get; set; }

        /// <inheritdoc />
        public bool PackHunter { get; set; }

        /// <inheritdoc />
        public string Mane { get; set; }

        /// <inheritdoc />
        public bool RoaringCommunication { get; set; }

        /// <inheritdoc />
        public bool TerritoryDefense { get; set; }

        #endregion // Properties

        #region Constructor

        /// <summary>
        /// Constructor for creating a new Lion object.
        /// </summary>
        /// <param name="name">Name of the lion</param>
        /// <param name="age">Age of the lion</param>
        /// <param name="apexPredator">Whether the lion is an apex predator</param>
        /// <param name="packHunter">Whether the lion is a pack hunter</param>
        /// <param name="mane">Type of mane the lion has</param>
        /// <param name="roaringCommunication">Whether the lion exhibits roaring communication</param>
        /// <param name="territoryDefense">Whether the lion engages in territory defense</param>
        public Lion(string name, int age, bool apexPredator, bool packHunter, string mane, bool roaringCommunication, bool territoryDefense)
            : base(name, age, MammalSpecies.Lion)
        {
            ApexPredator = apexPredator;
            PackHunter = packHunter;
            Mane = mane;
            RoaringCommunication = roaringCommunication;
            TerritoryDefense = territoryDefense;
        }

        #endregion // Constructor
    }
}
