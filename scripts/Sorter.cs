// 12/10/2025 - a2-tp3

using Godot;

namespace a2tp3.scripts;

public partial class Sorter() : Control
{
    [Export] private int _barsAmount;
    [Export] private int _maxValue;
    [Export] private int _minValue;
    [Export] private PackedScene _bar;
    [Export] private Order _order;
    
    private Bar[] _bars;
    private readonly SortingAlgorithms<Bar> _algorithms = new();


    private void OnGeneratePressed()
    {
        _bars ??= new Bar[_barsAmount];

        foreach (var bar in _bars)
        {
            bar?.Free();
        }

        var x = GetViewportRect().End.X / _barsAmount;
        for (var i = 0; i < _barsAmount; i++)
        {
            var bar = (Bar)_bar.Instantiate();
            bar.Val = GD.RandRange(_minValue, _maxValue);
            bar.Position = new Vector2(i * x, bar.Position.Y);
            AddChild(bar);
            _bars[i] = bar;
        }
        
        
    }

    private void OnBitonicPressed()
    {
        if (_algorithms == null || _bars == null) return;
        
        _algorithms.DoBitonic(ref _bars, _order);

        Reorder();
    }

    private void Reorder()
    {
        var x = GetViewportRect().End.X / _barsAmount;

        for (var i = 0; i < _bars.Length; i++)
        {
            _bars[i].Position = new Vector2(i * x, _bars[i].Position.Y);
        }
    }
}