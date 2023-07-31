using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui
{
    /// <summary>
    /// Application main screen.
    /// </summary>
    public sealed class MainScreen : Screen
    {
        private readonly IDataService _dataService;
        private readonly AnimalsScreen _animalsScreen;
        private readonly ISettingsService _settingsService; // Step 1: Inject the ISettingsService.

        /// <summary>
        /// Constructor for the MainScreen.
        /// </summary>
        /// <param name="dataService">Data service reference</param>
        /// <param name="animalsScreen">Animals screen reference</param>
        /// <param name="settingsService">Settings service reference</param>
        public MainScreen(
            IDataService dataService,
            AnimalsScreen animalsScreen,
            ISettingsService settingsService) // Step 1: Inject the ISettingsService.
        {
            _dataService = dataService;
            _animalsScreen = animalsScreen;
            _settingsService = settingsService; // Step 1: Assign the injected ISettingsService to the private field.
        }

        /// <inheritdoc/>
        public override void Show()
        {
            while (true)
            {
                // Step 2: Apply the colors obtained from the settings to different elements of the screen.
                ISettings? settings = _settingsService.Read("settings.json");
                if (settings == null)
                {
                    // If settings are not available or null, use default values.
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    // Convert and apply the colors from settings.
                    Console.BackgroundColor = ColorConverter.Convert(settings.MainScreenColor);
                    Console.ForegroundColor = ColorConverter.Convert(settings.TextColor);
                }

                Console.WriteLine();
                Console.WriteLine("Your available choices are:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Animals");
                Console.WriteLine("2. Create a new settings");
                Console.Write("Please enter your choice: ");

                string? choiceAsString = Console.ReadLine();

                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    MainScreenChoices choice = (MainScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case MainScreenChoices.Animals:
                            _animalsScreen.Show();
                            break;

                        case MainScreenChoices.Settings:
                            Console.WriteLine("Not yet implemented.");
                            // TODO: implement
                            break;

                        case MainScreenChoices.Exit:
                            Console.WriteLine("Goodbye.");
                            return;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }

                // Step 3: Reset colors to default after displaying the screen.
                Console.ResetColor();
            }
        }
    }

    /// <summary>
    /// Helper class for converting string color names to ConsoleColor.
    /// </summary>
    public static class ColorConverter
    {
        /// <summary>
        /// Converts a string color to its corresponding ConsoleColor.
        /// </summary>
        /// <param name="color">The string representation of the color.</param>
        /// <returns>The ConsoleColor value corresponding to the given color.</returns>
        public static ConsoleColor Convert(string color)
        {
            // Implement the conversion from string color to ConsoleColor.
            // For simplicity, let's assume that the color is a valid ConsoleColor name.
            if (Enum.TryParse(color, out ConsoleColor consoleColor))
            {
                return consoleColor;
            }
            else
            {
                // Default to White if the specified color is not a valid ConsoleColor.
                return ConsoleColor.White;
            }
        }
    }
}
