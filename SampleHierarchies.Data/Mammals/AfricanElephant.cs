using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals
{
    /// <summary>
    /// African Elephant class that implements the IMammal interface.
    /// </summary>
    public class AfricanElephant : MammalBase, IAfricanElephant
    {
        #region Properties

        /// <inheritdoc />
        public float Height { get; set; }

        /// <inheritdoc />
        public float Weight { get; set; }

        /// <inheritdoc />
        public float TuskLength { get; set; }

        /// <inheritdoc />
        public int Lifespan { get; set; }

        /// <inheritdoc />
        public string SocialBehavior { get; set; }

        #endregion // Properties

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// Initializes properties with default values.
        /// </summary>
        public AfricanElephant()
        {
            // Default values
            Height = 0f;
            Weight = 0f;
            TuskLength = 0f;
            Lifespan = 0;
            SocialBehavior = string.Empty;
        }

        /// <summary>
        /// Parameterized constructor.
        /// Initializes properties with specified values.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="age">Age</param>
        /// <param name="height">Height</param>
        /// <param name="weight">Weight</param>
        /// <param name="tuskLength">Tusk length</param>
        /// <param name="lifespan">Lifespan</param>
        /// <param name="socialBehavior">Social behavior</param>
        public AfricanElephant(string name, int age, float height, float weight, float tuskLength, int lifespan, string socialBehavior)
            : base(name, age, MammalSpecies.AfricanElephant)
        {
            Height = height;
            Weight = weight;
            TuskLength = tuskLength;
            Lifespan = lifespan;
            SocialBehavior = socialBehavior;
        }

        #endregion // Constructors

        #region Public Methods

        /// <inheritdoc />
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Height: {Height} meters");
            Console.WriteLine($"Weight: {Weight} kilograms");
            Console.WriteLine($"Tusk length: {TuskLength} meters");
            Console.WriteLine($"Lifespan: {Lifespan} years");
            Console.WriteLine($"Social behavior: {SocialBehavior}");
        }

        #endregion // Public Methods
    }
}
