using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui
{
    /// <summary>
    /// African Elephants main screen.
    /// </summary>
    public sealed class AfricanElephantsScreen : Screen
    {
        #region Properties And Ctor

        /// <summary>
        /// Data service.
        /// </summary>
        private IDataService _dataService;

        /// <summary>
        /// Screen definition for the AfricanElephantsScreen.
        /// </summary>
        public IScreenDefinition ScreenDefinition { get; }

        /// <summary>
        /// Constructor for the AfricanElephantsScreen.
        /// </summary>
        /// <param name="dataService">Data service reference</param>
        /// <param name="screenDefinitionService">Screen definition service reference</param>


        public AfricanElephantsScreen(IDataService dataService, IScreenDefinitionService screenDefinitionService)
    : base("african-elephants-screen-definition.json")
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
                Console.WriteLine("1. List all African Elephants");
                Console.WriteLine("2. Create a new African Elephant");
                Console.WriteLine("3. Delete existing African Elephant");
                Console.WriteLine("4. Modify existing African Elephant");
                Console.Write("Please enter your choice: ");

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    AfricanElephantsScreenChoices choice = (AfricanElephantsScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case AfricanElephantsScreenChoices.List:
                            ListAfricanElephants();
                            break;

                        case AfricanElephantsScreenChoices.Create:
                            AddAfricanElephant();
                            break;

                        case AfricanElephantsScreenChoices.Delete:
                            DeleteAfricanElephant();
                            break;

                        case AfricanElephantsScreenChoices.Modify:
                            EditAfricanElephantMain();
                            break;

                        case AfricanElephantsScreenChoices.Exit:
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
        /// List all African Elephants.
        /// </summary>
        private void ListAfricanElephants()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.AfricanElephants is not null &&
                _dataService.Animals.Mammals.AfricanElephants.Count > 0)
            {
                Console.WriteLine("Here's a list of African Elephants:");
                int i = 1;
                foreach (AfricanElephant elephant in _dataService.Animals.Mammals.AfricanElephants)
                {
                    Console.Write($"African Elephant number {i}, ");
                    elephant.Display();
                    i++;
                }
            }
            else
            {
                Console.WriteLine("The list of African Elephants is empty.");
            }
        }

        /// <summary>
        /// Add a new African Elephant.
        /// </summary>
        private void AddAfricanElephant()
        {
            try
            {
                AfricanElephant elephant = AddEditAfricanElephant();
                _dataService?.Animals?.Mammals?.AfricanElephants?.Add(elephant);
                Console.WriteLine("African Elephant with name: {0} has been added to the list of African Elephants", elephant.Name);
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Deletes an African Elephant.
        /// </summary>
        private void DeleteAfricanElephant()
        {
            try
            {
                Console.Write("What is the name of the African Elephant you want to delete? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                AfricanElephant? elephant = (AfricanElephant?)(_dataService?.Animals?.Mammals?.AfricanElephants
                    ?.FirstOrDefault(e => e is not null && string.Equals(e.Name, name)));
                if (elephant is not null)
                {
                    _dataService?.Animals?.Mammals?.AfricanElephants?.Remove(elephant);
                    Console.WriteLine("African Elephant with name: {0} has been deleted from the list of African Elephants", elephant.Name);
                }
                else
                {
                    Console.WriteLine("African Elephant not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Edits an existing African Elephant after choice made.
        /// </summary>
        private void EditAfricanElephantMain()
        {
            try
            {
                Console.Write("What is the name of the African Elephant you want to edit? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                AfricanElephant? elephant = (AfricanElephant?)(_dataService?.Animals?.Mammals?.AfricanElephants
                    ?.FirstOrDefault(e => e is not null && string.Equals(e.Name, name)));
                if (elephant is not null)
                {
                    AfricanElephant elephantEdited = AddEditAfricanElephant();
                    elephant.Copy(elephantEdited);
                    Console.Write("African Elephant after edit:");
                    elephant.Display();
                }
                else
                {
                    Console.WriteLine("African Elephant not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }

        /// <summary>
        /// Adds/edit specific African Elephant.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private AfricanElephant AddEditAfricanElephant()
        {
            Console.Write("What name of the African Elephant? ");
            string? name = Console.ReadLine();
            Console.Write("What is the African Elephant's age? ");
            string? ageAsString = Console.ReadLine();
            Console.Write("What is the African Elephant's height? ");
            string? heightAsString = Console.ReadLine();
            Console.Write("What is the African Elephant's weight? ");
            string? weightAsString = Console.ReadLine();
            Console.Write("What is the African Elephant's tusk length? ");
            string? tuskLengthAsString = Console.ReadLine();
            Console.Write("What is the African Elephant's lifespan? ");
            string? lifespanAsString = Console.ReadLine();
            Console.Write("What is the African Elephant's social behavior? ");
            string? socialBehavior = Console.ReadLine();

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (heightAsString is null)
            {
                throw new ArgumentNullException(nameof(heightAsString));
            }
            if (weightAsString is null)
            {
                throw new ArgumentNullException(nameof(weightAsString));
            }
            if (tuskLengthAsString is null)
            {
                throw new ArgumentNullException(nameof(tuskLengthAsString));
            }
            if (lifespanAsString is null)
            {
                throw new ArgumentNullException(nameof(lifespanAsString));
            }
            if (socialBehavior is null)
            {
                throw new ArgumentNullException(nameof(socialBehavior));
            }

            int age = Int32.Parse(ageAsString);
            float height = float.Parse(heightAsString);
            float weight = float.Parse(weightAsString);
            float tuskLength = float.Parse(tuskLengthAsString);
            int lifespan = Int32.Parse(lifespanAsString);

            AfricanElephant elephant = new AfricanElephant(name, age, height, weight, tuskLength, lifespan, socialBehavior);

            return elephant;
        }

        #endregion // Private Methods
    }
}
