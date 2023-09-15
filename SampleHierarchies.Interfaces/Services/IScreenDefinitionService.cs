using SampleHierarchies.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Services
{
    /// <summary>
    /// Interfejs dla usługi obsługującej definicje ekranów.
    /// </summary>
    public interface IScreenDefinitionService
    {
        IScreenDefinition Load(string jsonFileName);
        bool Save(IScreenDefinition screenDefinition, string jsonFileName);
    }
}
