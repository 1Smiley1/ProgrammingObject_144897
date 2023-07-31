using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals
{
    /// <summary>
    /// Mammal base class that implements the IMammal interface and extends the AnimalBase class.
    /// </summary>
    public class MammalBase : AnimalBase, IMammal
    {
        #region IMammal Implementation

        /// <inheritdoc/>
        public MammalSpecies Species { get; set; }

        #endregion // IMammal Implementation

        #region Constructors

        /// <summary>
        /// Mammal base class constructor with parameters.
        /// </summary>
        /// <param name="name">Name of the mammal</param>
        /// <param name="age">Age of the mammal</param>
        /// <param name="species">Species of the mammal</param>
        public MammalBase(
            string name,
            int age,
            MammalSpecies species) : base(name, age)
        {
            Species = species;
        }

        /// <summary>
        /// Parameterless constructor for the mammal base class.
        /// </summary>
        public MammalBase() : base()
        {
            Species = MammalSpecies.None;
        }

        #endregion // Constructors

        #region Public Methods

        /// <inheritdoc/>
        public override void MakeSound()
        {
            base.MakeSound();
            Console.WriteLine("My name is: {0} and I am making a mammal sound", Name);
        }

        /// <inheritdoc/>
        public override void Move()
        {
            base.Move();
            Console.WriteLine("My name is: {0} and I am moving like a mammal", Name);
        }

        /// <inheritdoc/>
        public override void Copy(IAnimal animal)
        {
            if (animal is IMammal am)
            {
                base.Copy(animal);
                Species = am.Species;
            }
        }

        #endregion // Public Methods
    }
}
