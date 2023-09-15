namespace SampleHierarchies.Gui;

/// <summary>
/// Abstract base class for a screen.
/// </summary>
public class Screen
{
    // Pole do przechowywania nazwy pliku z definicją ekranu
    public string ScreenDefinitionJson { get; set; }

    public Screen(string screenDefinitionJson)
    {
        ScreenDefinitionJson = screenDefinitionJson;
    }

    // Metoda Show() i inne metody
    public virtual void Show()
    {
        Console.WriteLine("Showing screen");
    }
}

public class SubScreen : Screen
{
    public SubScreen(string screenDefinitionJson) : base(screenDefinitionJson)
    {
        // Nadpisujemy wartość pola w klasie potomnej
        ScreenDefinitionJson = "NowaWartosc.json";
    }

    // Nadpisane metody w klasie potomnej
    public override void Show()
    {
        Console.WriteLine($"Showing sub screen with JSON: {ScreenDefinitionJson}");
    }
}
