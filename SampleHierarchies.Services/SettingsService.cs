using Newtonsoft.Json;
using SampleHierarchies.Data;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Services;

/// <summary>
/// Settings service.
/// </summary>
public class SettingsService : ISettingsService
{
    /// <summary>
    /// Reads settings from a JSON file.
    /// </summary>
    /// <param name="jsonPath">The path to the JSON file containing settings.</param>
    /// <returns>The deserialized settings or null if an error occurs.</returns>
    public ISettings? Read(string jsonPath)
    {
        try
        {
            if (File.Exists(jsonPath))
            {
                string json = File.ReadAllText(jsonPath);
                return JsonConvert.DeserializeObject<Settings>(json);
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions if needed
            Console.WriteLine($"Error reading settings from {jsonPath}: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Writes settings to a JSON file.
    /// </summary>
    /// <param name="settings">The settings to write.</param>
    /// <param name="jsonPath">The path to the JSON file where settings will be saved.</param>
    public void Write(ISettings settings, string jsonPath)
    {
        try
        {
            string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(jsonPath, json);
        }
        catch (Exception ex)
        {
            // Handle exceptions if needed
            Console.WriteLine($"Error writing settings to {jsonPath}: {ex.Message}");
        }
    }
}

