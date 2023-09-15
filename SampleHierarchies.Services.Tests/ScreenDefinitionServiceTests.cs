using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services; // Zaimportowanie klasy, którą testujemy


namespace SampleHierarchies.Services.Tests
{
    [TestClass]
    public class ScreenDefinitionService
    {
        [TestMethod]
        public void Load_ValidJsonFile_ReturnsScreenDefinition()
        {
            // Arrange
            IScreenDefinitionService screenDefinitionService = new ScreenDefinitionService();
            string jsonFileName = "valid-screen-definition.json"; // Plik JSON z prawidłową definicją ekranu

            // Act
            var screenDefinition = screenDefinitionService.Load(jsonFileName);

            // Assert
            Assert.IsNotNull(screenDefinition); // Upewnij się, że wynik nie jest null
            // Dodaj więcej asercji, aby sprawdzić oczekiwane zachowanie
        }

        [TestMethod]
        public void Load_InvalidJsonFile_ReturnsNull()
        {
            // Arrange
            IScreenDefinitionService screenDefinitionService = new ScreenDefinitionService();
            string jsonFileName = "invalid-screen-definition.json"; // Plik JSON z nieprawidłową definicją ekranu

            // Act
            var screenDefinition = screenDefinitionService.Load(jsonFileName);

            // Assert
            Assert.IsNull(screenDefinition); // Upewnij się, że wynik jest null, jeśli plik JSON jest nieprawidłowy
            // Dodaj więcej asercji, aby sprawdzić oczekiwane zachowanie
        }
    }
}
