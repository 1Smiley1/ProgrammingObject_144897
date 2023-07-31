using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui
{
    /// <summary>
    /// Animals main screen.
    /// </summary>
    public sealed class AnimalsScreen : Screen
    {
        #region Properties And Ctor

        /// <summary>
        /// Data service.
        /// </summary>
        private IDataService _dataService;

        /// <summary>
        /// Mammals screen instance.
        /// </summary>
        private MammalsScreen _mammalsScreen;

        /// <summary>
        /// Constructor for the AnimalsScreen.
        /// </summary>
        /// <param name="dataService">Data service reference</param>
        /// <param name="mammalsScreen">Mammals screen instance</param>
        public AnimalsScreen(IDataService dataService, MammalsScreen mammalsScreen)
        {
            _dataService = dataService;
            _mammalsScreen = mammalsScreen;
        }

        #endregion Properties And Ctor

        #region Public Methods

        /// <inheritdoc/>
        public override void Show()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Your available choices are:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Mammals");
                Console.WriteLine("2. Save to file");
                Console.WriteLine("3. Read from file");
                Console.Write("Please enter your choice: ");

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    AnimalsScreenChoices choice = (AnimalsScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case AnimalsScreenChoices.Mammals:
                            _mammalsScreen.Show();
                            break;

                        case AnimalsScreenChoices.Read:
                            ReadFromFile();
                            break;

                        case AnimalsScreenChoices.Save:
                            SaveToFile();
                            break;

                        case AnimalsScreenChoices.Exit:
                            Console.WriteLine("Going back to parent menu.");
                            return;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }

        #endregion // Public Methods

        #region Private Methods

        /// <summary>
        /// Save data to a file.
        /// </summary>
        private void SaveToFile()
        {
            try
            {
                Console.Write("Save data to file: ");
                string? fileName = Console.ReadLine();
                if (fileName is null)
                {
                    throw new ArgumentNullException(nameof(fileName));
                }
                _dataService.Write(fileName);
                Console.WriteLine("Data saving to '{0}' was successful.", fileName);
            }
            catch
            {
                Console.WriteLine("Data saving was not successful.");
            }
        }

        /// <summary>
        /// Read data from a file.
        /// </summary>
        private void ReadFromFile()
        {
            try
            {
                Console.Write("Read data from file: ");
                string? fileName = Console.ReadLine();
                if (fileName is null)
                {
                    throw new ArgumentNullException(nameof(fileName));
                }
                _dataService.Read(fileName);
                Console.WriteLine("Data reading from '{0}' was successful.", fileName);
            }
            catch
            {
                Console.WriteLine("Data reading was not successful.");
            }
        }

        #endregion // Private Methods
    }
}
