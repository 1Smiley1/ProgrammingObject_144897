using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data
{
    /// <summary>
    /// Interfejs dla definicji linii ekranu.
    /// </summary>
    public interface IScreenLineEntry
    {
        string BackgroundColor { get; set; }
        string ForegroundColor { get; set; }
        string Text { get; set; }
    }
}
