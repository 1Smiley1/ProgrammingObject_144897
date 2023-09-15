using Newtonsoft.Json;
using SampleHierarchies.Data;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Services
{
    /// <summary>
    /// Implementacja IScreenDefinitionService.
    /// </summary>
    public class ScreenDefinitionService : IScreenDefinitionService
    {
        public IScreenDefinition Load(string jsonFileName)
        {
            IScreenDefinition? screenDefinition = null;

            try
            {
                string json = File.ReadAllText(jsonFileName);
                screenDefinition = JsonConvert.DeserializeObject<ScreenDefinition>(json);
            }
            catch (FileNotFoundException)
            {
                // Obsługa braku pliku
            }
            catch (JsonException)
            {
                // Obsługa błędów w formacie JSON
            }

#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return screenDefinition;
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        }

        public bool Save(IScreenDefinition screenDefinition, string jsonFileName)
        {
            try
            {
                string json = JsonConvert.SerializeObject(screenDefinition);
                File.WriteAllText(jsonFileName, json);
                return true;
            }
            catch (Exception)
            {
                // Obsługa błędów zapisu
                return false;
            }
        }
    }
}
