namespace SampleHierarchies.Interfaces.Data;

/// <summary>
/// Settings interface.
/// </summary>
public interface ISettings
{
    #region Interface Members

    /// <summary>
    /// Gets or sets the version of the settings.
    /// </summary>
    string Version { get; set; }

    /// <summary>
    /// Gets or sets the text color for the screen.
    /// </summary>
    string TextColor { get; set; }

    #endregion // Interface Members

    // Additional properties representing colors for different screens can be added below.
    // For simplicity, only a few examples are provided, but more can be added as needed.

    /// <summary>
    /// Gets or sets the main screen color.
    /// </summary>
    string MainScreenColor { get; set; }

    /// <summary>
    /// Gets or sets the animals screen color.
    /// </summary>
    string AnimalsScreenColor { get; set; }

    /// <summary>
    /// Gets or sets the mammals screen color.
    /// </summary>
    string MammalsScreenColor { get; set; }

    /// <summary>
    /// Gets or sets the dogs screen color.
    /// </summary>
    string DogsScreenColor { get; set; }

    // Other existing properties and methods can remain as they are.
}
