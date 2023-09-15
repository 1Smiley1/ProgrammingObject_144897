using SampleHierarchies.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data
{
    public class ScreenLineEntry : IScreenLineEntry
    {
        public string BackgroundColor { get; set; }
        public string ForegroundColor { get; set; }
        public string Text { get; set; }

        // Konstruktor domyślny
        public ScreenLineEntry()
        {
            BackgroundColor = string.Empty;
            ForegroundColor = string.Empty;
            Text = string.Empty;
        }

        // Konstruktor parametryczny
        public ScreenLineEntry(string backgroundColor, string foregroundColor, string text)
        {
            BackgroundColor = backgroundColor;
            ForegroundColor = foregroundColor;
            Text = text;
        }
    }
}
