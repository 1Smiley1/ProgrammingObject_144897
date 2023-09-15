using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data
{
    /// <summary>
    /// Interfejs dla definicji ekranu.
    /// </summary>
    public interface IScreenDefinition
    {
        List<IScreenLineEntry> LineEntries { get; set; }
    }
}
