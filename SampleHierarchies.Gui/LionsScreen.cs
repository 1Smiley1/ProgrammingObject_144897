using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui
{
    /// <summary>
    /// Lions main screen.
    /// </summary>
    public sealed class LionsScreen : Screen
    {
        #region Properties And Ctor

        /// <summary>
        /// Data service.
        /// </summary>
        private IDataService _dataService;

        /// <summary>
        /// Constructor for the LionsScreen.
        /// </summary>
        /// <param name="dataService">Data service reference</param>
        public LionsScreen(IDataService dataService)
        {
            _dataService = dataService;
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
                Console.WriteLine("1. List all lions");
                Console.WriteLine("2. Create a new lion");
                Console.WriteLine("3. Delete an existing lion");
                Console.WriteLine("4. Modify an existing lion");
                Console.Write("Please enter your choice: ");

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    LionsScreenChoices choice = (LionsScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case LionsScreenChoices.List:
                            ListLions();
                            break;

                        case LionsScreenChoices.Create:
                            AddLion();
                            break;

                        case LionsScreenChoices.Delete:
                            DeleteLion();
                            break;

                        case LionsScreenChoices.Modify:
                            EditLionMain();
                            break;

                        case LionsScreenChoices.Exit:
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
        /// List all lions.
        /// </summary>
        private void ListLions()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Lions is not null &&
                _dataService.Animals.Mammals.Lions.Count > 0)
            {
                Console.WriteLine("Here's a list of lions:");
                int i = 1;
                foreach (Lion lion in _dataService.Animals.Mammals.Lions)
                {
                    Console.Write($"Lion number {i}, ");
                    lion.Display();
                    i++;
                }
            }
            else
            {
                Console.WriteLine("The list of lions is empty.");
            }
        }

        /// <summary>
        /// Add a lion.
        /// </summary>
        private void AddLion()
        {
            try
            {
                Lion lion = AddEditLion();
                _dataService?.Animals?.Mammals?.Lions?.Add(lion);
                Console.WriteLine("Lion with name: {0} has been added to the list of lions", lion.Name);
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Deletes a lion.
        /// </summary>
        private void DeleteLion()
        {
            try
            {
                Console.Write("What is the name of the lion you want to delete? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Lion? lion = (Lion?)(_dataService?.Animals?.Mammals?.Lions
                    ?.FirstOrDefault(l => l is not null && string.Equals(l.Name, name)));
                if (lion is not null)
                {
                    _dataService?.Animals?.Mammals?.Lions?.Remove(lion);
                    Console.WriteLine("Lion with name: {0} has been deleted from the list of lions", lion.Name);
                }
                else
                {
                    Console.WriteLine("Lion not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Edits an existing lion after choice made.
        /// </summary>
        private void EditLionMain()
        {
            try
            {
                Console.Write("What is the name of the lion you want to edit? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Lion? lion = (Lion?)(_dataService?.Animals?.Mammals?.Lions
                    ?.FirstOrDefault(l => l is not null && string.Equals(l.Name, name)));
                if (lion is not null)
                {
                    Lion lionEdited = AddEditLion();
                    lion.Copy(lionEdited);
                    Console.Write("Lion after edit:");
                    lion.Display();
                }
                else
                {
                    Console.WriteLine("Lion not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }

        /// <summary>
        /// Adds/edit a specific lion.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Lion AddEditLion()
        {
            Console.Write("What is the name of the lion? ");
            string? name = Console.ReadLine();
            Console.Write("What is the lion's age? ");
            string? ageAsString = Console.ReadLine();
            Console.Write("Is the lion an apex predator? (true/false): ");
            string? apexPredatorAsString = Console.ReadLine();
            Console.Write("Is the lion a pack hunter? (true/false): ");
            string? packHunterAsString = Console.ReadLine();
            Console.Write("What type of mane does the lion have? ");
            string? mane = Console.ReadLine();
            Console.Write("Does the lion have roaring communication? (true/false): ");
            string? roaringCommunicationAsString = Console.ReadLine();
            Console.Write("Does the lion have territory defense? (true/false): ");
            string? territoryDefenseAsString = Console.ReadLine();

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (apexPredatorAsString is null || packHunterAsString is null || roaringCommunicationAsString is null || territoryDefenseAsString is null)
            {
                throw new ArgumentNullException("One or more properties were not provided.");
            }

            int age = Int32.Parse(ageAsString);
            bool apexPredator = bool.Parse(apexPredatorAsString);
            bool packHunter = bool.Parse(packHunterAsString);
            bool roaringCommunication = bool.Parse(roaringCommunicationAsString);
            bool territoryDefense = bool.Parse(territoryDefenseAsString);

            Lion lion = new Lion(name, age, apexPredator, packHunter, mane, roaringCommunication, territoryDefense);

            return lion;
        }

        #endregion // Private Methods
    }
}
