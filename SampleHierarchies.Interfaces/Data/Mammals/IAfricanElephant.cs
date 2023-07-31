namespace SampleHierarchies.Interfaces.Data.Mammals
{
    /// <summary>
    /// Interface depicting an African elephant.
    /// </summary>
    public interface IAfricanElephant : IMammal
    {
        #region Interface Members

        /// <summary>
        /// Height of the African elephant (in meters).
        /// </summary>
        float Height { get; set; }

        /// <summary>
        /// Weight of the African elephant (in kilograms).
        /// </summary>
        float Weight { get; set; }

        /// <summary>
        /// Tusk length of the African elephant (in meters).
        /// </summary>
        float TuskLength { get; set; }

        /// <summary>
        /// Lifespan of the African elephant (in years).
        /// </summary>
        int Lifespan { get; set; }

        /// <summary>
        /// Social behavior of the African elephant.
        /// </summary>
        string SocialBehavior { get; set; }

        #endregion // Interface Members
    }
}
