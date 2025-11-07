// 07/11/2025 - a2-tp3

using Godot;

namespace a2tp3.scripts;

public enum Algorithms
{
    Bitonic = 0,
    Selection,
    Bubble,
    Cocktail,
    Quick,
    Bogo,
    Insertion,
    Shell,
    Lsd,
    Msd,
    Last
}

public partial class Button : Godot.Button
{
    [Export] private Algorithms _selected;
    [Export] private Sorter _sorter;


    public void OnButtonPressed()
    {
        _sorter.OnButtonPressed(_selected);
    }
}