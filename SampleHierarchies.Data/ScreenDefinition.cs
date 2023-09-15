using SampleHierarchies.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data
{
    /// <summary>
    /// Implementacja IScreenDefinition reprezentująca definicję ekranu.
    /// </summary>
    public class ScreenDefinition : IScreenDefinition
    {
        public List<IScreenLineEntry> LineEntries { get; set; } = new List<IScreenLineEntry>();
        public List<ScreenLineEntry> ListEntriesPl { get; set; } = new List<ScreenLineEntry>(); // Lista polskojęzycznych wpisów
    }


}
