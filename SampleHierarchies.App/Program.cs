using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PeanutButter.TinyEventAggregator;
using SampleHierarchies.Gui;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ImageTagger.FrontEnd.WinForms
{
    /// <summary>
    /// Main class for starting up the program.
    /// </summary>
    internal static class Program
    {
        #region Main Method

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">Arguments</param>
        [STAThread]
        static void Main(string[] args)
        {
            // Create the host and get the service provider
            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            // Show the main screen
            var mainScreen = ServiceProvider.GetRequiredService<MainScreen>();
            mainScreen.Show();

            // Save mammals to JSON before exiting
            SaveMammalsToJson();
        }

        #endregion // Main Method

        #region Properties And Methods

        /// <summary>
        /// Service provider.
        /// </summary>
        public static IServiceProvider? ServiceProvider { get; private set; } = null;

        /// <summary>
        /// Creates a host builder and configures services.
        /// </summary>
        /// <returns>Host builder</returns>
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Register the required services
                    services.AddSingleton<ISettingsService, SettingsService>();
                    services.AddSingleton<IEventAggregator, EventAggregator>();
                    services.AddSingleton<IDataService, DataService>();
                    services.AddSingleton<MainScreen, MainScreen>();
                    services.AddSingleton<DogsScreen, DogsScreen>();
                    services.AddSingleton<MammalsScreen, MammalsScreen>();
                    services.AddSingleton<AfricanElephantsScreen, AfricanElephantsScreen>();
                    services.AddSingleton<AnimalsScreen, AnimalsScreen>();
                    services.AddSingleton<LionsScreen, LionsScreen>(); // Add this line for LionsScreen.
                    services.AddSingleton<GrayWolvesScreen, GrayWolvesScreen>(); // Add this line for GrayWolvesScreen.
                });
        }

        /// <summary>
        /// Save mammals to separate JSON files.
        /// </summary>
        private static void SaveMammalsToJson()
        {
            var dataService = ServiceProvider.GetRequiredService<IDataService>();

            // Save each type of mammal to a separate JSON file
            SaveToJson(dataService.Animals.Mammals.Dogs, "dogs.json");
            SaveToJson(dataService.Animals.Mammals.AfricanElephants, "africanelephants.json");
            SaveToJson(dataService.Animals.Mammals.Lions, "lions.json");
            SaveToJson(dataService.Animals.Mammals.GrayWolves, "graywolves.json");
        }

        /// <summary>
        /// Save a list of mammals to a JSON file.
        /// </summary>
        /// <typeparam name="T">Type of mammal</typeparam>
        /// <param name="mammals">List of mammals</param>
        /// <param name="fileName">Name of the JSON file</param>
        private static void SaveToJson<T>(List<T> mammals, string fileName)
        {
            if (mammals is not null && mammals.Count > 0)
            {
                // Serialize the list to JSON
                var json = JsonConvert.SerializeObject(mammals, Formatting.Indented);
                File.WriteAllText(fileName, json);
                Console.WriteLine($"{typeof(T).Name}s data has been saved to {fileName}");
            }
            else
            {
                Console.WriteLine($"No {typeof(T).Name}s data to save.");
            }
        }

        #endregion // Properties And Methods
    }
}
