using SampleHierarchies.Data;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

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
        private readonly IScreenDefinitionService _screenDefinitionService;
        private readonly List<string> history = new List<string>();


        /// <summary>
        /// Constructor for the MainScreen.
        /// </summary>
        /// <param name="dataService">Data service reference</param>
        /// <param name="animalsScreen">Animals screen reference</param>
        /// <param name="settingsService">Settings service reference</param>
        /// <param name="screenDefinitionService">Settings service reference</param>



        public MainScreen(
            IDataService dataService,
            AnimalsScreen animalsScreen,
            ISettingsService settingsService,
            IScreenDefinitionService screenDefinitionService)
            : base("main-screen-definition.json") // Ustaw nazwę pliku JSON dla tego ekranu
        {
            _dataService = dataService;
            _animalsScreen = animalsScreen;
            _settingsService = settingsService;
            _screenDefinitionService = screenDefinitionService;
        }

        /// <inheritdoc/>
        public override void Show()
        {
            while (true)
            {
                // Wczytaj ustawienia kolorów z pliku JSON
                ISettings? settings = _settingsService.Read("settings.json");

                // Ustaw kolory na podstawie wczytanych ustawień
                if (settings != null)
                {
                    Console.BackgroundColor = ColorConverter.Convert(settings.MainScreenColor);
                    Console.ForegroundColor = ColorConverter.Convert(settings.TextColor);
                }
                else
                {
                    // Ustaw domyślne kolory, jeśli nie udało się wczytać ustawień
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.Clear(); // Wyczyść ekran przed wyświetleniem nowej zawartości

                // Wyświetl historię wyborów
                Console.WriteLine("History:");
                foreach (var entry in history)
                {
                    Console.WriteLine(entry);
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
                        
                        case  MainScreenChoices.Animals:
                            history.Add("Main Screen -> Animals");
                            _animalsScreen.Show();
                            break;

                        case MainScreenChoices.Settings:
                            history.Add("Main Screen -> Create Settings");
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
