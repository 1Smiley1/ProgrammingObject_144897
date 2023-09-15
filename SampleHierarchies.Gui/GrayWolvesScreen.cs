using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui
{
    /// <summary>
    /// Gray wolves main screen.
    /// </summary>
    public sealed class GrayWolvesScreen : Screen
    {
        #region Properties And Ctor

        /// <summary>
        /// Data service.
        /// </summary>
        private IDataService _dataService;

        /// <summary>
        /// Screen definition for the GrayWolvesScreen.
        /// </summary>
        public IScreenDefinition ScreenDefinition { get; }

        /// <summary>
        /// Constructor for the GrayWolvesScreen.
        /// </summary>
        /// <param name="dataService">Data service reference</param>
        /// <param name="screenDefinitionService">Screen definition service reference</param>
        public GrayWolvesScreen(IDataService dataService, IScreenDefinitionService screenDefinitionService)
    : base("gray-wolves-screen-definition.json")
        {
            _dataService = dataService;
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
                Console.WriteLine("1. List all gray wolves");
                Console.WriteLine("2. Create a new gray wolf");
                Console.WriteLine("3. Delete an existing gray wolf");
                Console.WriteLine("4. Modify an existing gray wolf");
                Console.Write("Please enter your choice: ");

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    GrayWolvesScreenChoices choice = (GrayWolvesScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case GrayWolvesScreenChoices.List:
                            ListGrayWolves();
                            break;

                        case GrayWolvesScreenChoices.Create:
                            AddGrayWolf();
                            break;

                        case GrayWolvesScreenChoices.Delete:
                            DeleteGrayWolf();
                            break;

                        case GrayWolvesScreenChoices.Modify:
                            EditGrayWolfMain();
                            break;

                        case GrayWolvesScreenChoices.Exit:
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

        #region Private Methods

        /// <summary>
        /// List all gray wolves.
        /// </summary>
        private void ListGrayWolves()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.GrayWolves is not null &&
                _dataService.Animals.Mammals.GrayWolves.Count > 0)
            {
                Console.WriteLine("Here's a list of gray wolves:");
                int i = 1;
                foreach (GrayWolf grayWolf in _dataService.Animals.Mammals.GrayWolves)
                {
                    Console.Write($"Gray wolf number {i}, ");
                    grayWolf.Display();
                    i++;
                }
            }
            else
            {
                Console.WriteLine("The list of gray wolves is empty.");
            }
        }

        /// <summary>
        /// Add a gray wolf.
        /// </summary>
        private void AddGrayWolf()
        {
            try
            {
                GrayWolf grayWolf = AddEditGrayWolf();
                _dataService?.Animals?.Mammals?.GrayWolves?.Add(grayWolf);
                Console.WriteLine("Gray wolf with name: {0} has been added to the list of gray wolves", grayWolf.Name);
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Deletes a gray wolf.
        /// </summary>
        private void DeleteGrayWolf()
        {
            try
            {
                Console.Write("What is the name of the gray wolf you want to delete? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                GrayWolf? grayWolf = (GrayWolf?)(_dataService?.Animals?.Mammals?.GrayWolves
                    ?.FirstOrDefault(gw => gw is not null && string.Equals(gw.Name, name)));
                if (grayWolf is not null)
                {
                    _dataService?.Animals?.Mammals?.GrayWolves?.Remove(grayWolf);
                    Console.WriteLine("Gray wolf with name: {0} has been deleted from the list of gray wolves", grayWolf.Name);
                }
                else
                {
                    Console.WriteLine("Gray wolf not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Edits an existing gray wolf after choice made.
        /// </summary>
        private void EditGrayWolfMain()
        {
            try
            {
                Console.Write("What is the name of the gray wolf you want to edit? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                GrayWolf? grayWolf = (GrayWolf?)(_dataService?.Animals?.Mammals?.GrayWolves
                    ?.FirstOrDefault(gw => gw is not null && string.Equals(gw.Name, name)));
                if (grayWolf is not null)
                {
                    GrayWolf grayWolfEdited = AddEditGrayWolf();
                    grayWolf.Copy(grayWolfEdited);
                    Console.Write("Gray wolf after edit:");
                    grayWolf.Display();
                }
                else
                {
                    Console.WriteLine("Gray wolf not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }

        /// <summary>
        /// Adds/edit a specific gray wolf.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private GrayWolf AddEditGrayWolf()
        {
            Console.Write("What is the name of the gray wolf? ");
            string? name = Console.ReadLine();
            Console.Write("What is the gray wolf's age? ");
            string? ageAsString = Console.ReadLine();
            Console.Write("Is the gray wolf a pack hunter? (true/false): ");
            string? packHunterAsString = Console.ReadLine();
            Console.Write("Does the gray wolf have howling communication? (true/false): ");
            string? howlingCommunicationAsString = Console.ReadLine();
            Console.Write("What is the gray wolf's carnivorous diet? ");
            string? carnivorousDiet = Console.ReadLine();
            Console.Write("Does the gray wolf have strong jaws? (true/false): ");
            string? strongJawsAsString = Console.ReadLine();
            Console.Write("What is the gray wolf's good sense of smell? ");
            string? goodSenseOfSmell = Console.ReadLine();

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null || packHunterAsString is null || howlingCommunicationAsString is null || strongJawsAsString is null)
            {
                throw new ArgumentNullException("One or more properties were not provided.");
            }

            int age = Int32.Parse(ageAsString);
            bool packHunter = bool.Parse(packHunterAsString);
            bool howlingCommunication = bool.Parse(howlingCommunicationAsString);
            bool strongJaws = bool.Parse(strongJawsAsString);

#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
            GrayWolf grayWolf = new GrayWolf(name, age, packHunter, howlingCommunication, carnivorousDiet, strongJaws, goodSenseOfSmell);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.

            return grayWolf;
        }

        #endregion // Private Methods
    }
}
