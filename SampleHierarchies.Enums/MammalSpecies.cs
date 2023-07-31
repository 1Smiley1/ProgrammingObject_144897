using System.ComponentModel;

/// <summary>
/// Enumeration representing different mammal species.
/// </summary>
public enum MammalSpecies
{
    /// <summary>
    /// Dummy value for none.
    /// </summary>
    [Description("Simple description of a none")]
    None = 0,

    /// <summary>
    /// Dummy value for dog.
    /// </summary>
    [Description("Simple description of a dog")]
    Dog = 1,

    /// <summary>
    /// Dummy value for cat.
    /// </summary>
    [Description("Simple description of a cat")]
    Cat = 2,

    /// <summary>
    /// African Elephant species.
    /// </summary>
    AfricanElephant = 3,

    /// <summary>
    /// Lion species.
    /// </summary>
    Lion = 4,

    /// <summary>
    /// Gray Wolf species.
    /// </summary>
    GrayWolf = 5,
}
