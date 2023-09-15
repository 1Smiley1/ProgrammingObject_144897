using System;
using SampleHierarchies.Data;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui
{
    /// <summary>
    /// Mammals main screen.
    /// </summary>
    public sealed class MammalsScreen : Screen
    {
        #region Properties And Ctor

        /// <summary>
        /// Dogs screen.
        /// </summary>
        private DogsScreen _dogsScreen;

        /// <summary>
        /// AfricanElephants screen.
        /// </summary>
        private AfricanElephantsScreen _africanElephantsScreen;

        /// <summary>
        /// Lions screen.
        /// </summary>
        private LionsScreen _lionsScreen;

        /// <summary>
        /// GrayWolves screen.
        /// </summary>
        private GrayWolvesScreen _grayWolvesScreen;


        /// <summary>
        /// Screen definition for the MammalsScreen.
        /// </summary>
        public IScreenDefinition ScreenDefinition { get; }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="dogsScreen">Dogs screen reference</param>
        /// <param name="africanElephantsScreen">AfricanElephants screen reference</param>
        /// <param name="lionsScreen">Lions screen reference</param>
        /// <param name="grayWolvesScreen">GrayWolves screen reference</param>
        /// <param name="screenDefinitionService">Screen definition service reference</param>
        public MammalsScreen(DogsScreen dogsScreen, AfricanElephantsScreen africanElephantsScreen, LionsScreen lionsScreen, GrayWolvesScreen grayWolvesScreen, IScreenDefinitionService screenDefinitionService)
    : base("mammals-screen-definition.json")
        {
            _dogsScreen = dogsScreen;
            _africanElephantsScreen = africanElephantsScreen;
            _lionsScreen = lionsScreen;
            _grayWolvesScreen = grayWolvesScreen;

            ScreenDefinition = screenDefinitionService.Load(ScreenDefinitionJson);
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
                Console.WriteLine("1. Dogs");
                Console.WriteLine("2. AfricanElephants");
                Console.WriteLine("3. Lions");
                Console.WriteLine("4. GrayWolves"); // Add option for GrayWolves
                Console.Write("Please enter your choice: ");

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    MammalsScreenChoices choice = (MammalsScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case MammalsScreenChoices.Dogs:
                            _dogsScreen.Show();
                            break;

                        case MammalsScreenChoices.AfricanElephants:
                            _africanElephantsScreen.Show();
                            break;

                        case MammalsScreenChoices.Lions:
                            _lionsScreen.Show();
                            break;

                        case MammalsScreenChoices.GrayWolves: // Case for GrayWolves
                            _grayWolvesScreen.Show();
                            break;

                        case MammalsScreenChoices.Exit:
                            Console.WriteLine("Going back to the parent menu.");
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
    }
}
