// 12/10/2025 - a2-tp3

using System;
using a2tp3.scripts.algorithms;
using Godot;

namespace a2tp3.scripts;

public partial class Sorter() : Control
{
    [Export] private int _barsAmount;
    [Export] private int _maxValue;
    [Export] private int _minValue;
    [Export] private PackedScene _bar;

    private Bar[] _bars;
    private bool _isIncremental = true;

    public override void _Ready()
    {
        GetViewport().SizeChanged += Reorder;
    }



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
            bar.Position = new Vector2(i * x + 10, bar.Position.Y);
            AddChild(bar);
            _bars[i] = bar;
        }
    }

    public void OnButtonPressed(Algorithms algorithm)
    {
        if (_bars == null) return;

        ISortable<Bar> sortingMethod = algorithm switch
        {
            Algorithms.Bitonic => new Bitonic<Bar>(ref _bars),
            Algorithms.Selection => new Selection<Bar>(),
            Algorithms.Bubble => new Bubble<Bar>(),
            Algorithms.Cocktail => new Cocktail<Bar>(),
            Algorithms.Quick => new Quick<Bar>(),
            Algorithms.Bogo => new Bogo<Bar>(),
            Algorithms.Insertion => new Insertion<Bar>(),
            Algorithms.Shell => new Shell<Bar>(),
            
            _ => throw new ArgumentOutOfRangeException(nameof(algorithm), algorithm,
                $"This error means that an unexpected value was passed when a button was pressed." +
                $" Received value: {algorithm}. Expected value within {Algorithms.Bitonic} and {Algorithms.Last - 1} " +
                $"(inclusive)")
        };

        sortingMethod.Sort(ref _bars, _isIncremental);

        Reorder();
    }

    private void OnIsIncrementalPressed()
    {
        _isIncremental = !_isIncremental;
    }
    
    private void Reorder()
    {
        if (_bars == null) return;
        
        var x = GetViewportRect().End.X / _barsAmount;

        for (var i = 0; i < _bars.Length; i++)
        {
            _bars[i].Position = new Vector2(i * x + 10, _bars[i].Position.Y);
        }
    }
}