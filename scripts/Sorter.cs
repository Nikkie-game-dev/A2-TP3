// 12/10/2025 - a2-tp3

using System;
using System.Collections.Generic;
using a2tp3.scripts.algorithms;
using Godot;

namespace a2tp3.scripts;


public partial class Sorter() : Control
{
    private delegate void SortingAction<T1>(ref T1[] array, bool isIncremental);

    [Export] private int _barsAmount;
    [Export] private int _maxValue;
    [Export] private int _minValue;
    [Export] private PackedScene _bar;

    private Bar[] _bars;
    private bool _isIncremental = true;
    
    private static readonly Dictionary<Algorithms, SortingAction<Bar>> Algorithms = new()
    {
        { scripts.Algorithms.Bitonic, Bitonic<Bar>.Sort },
        { scripts.Algorithms.Selection, Selection<Bar>.Sort },
        { scripts.Algorithms.Bubble, Bubble<Bar>.Sort },
        { scripts.Algorithms.Cocktail, Cocktail<Bar>.Sort },
        { scripts.Algorithms.Quick, Quick<Bar>.Sort },
        { scripts.Algorithms.Bogo, Bogo<Bar>.Sort },
        { scripts.Algorithms.Insertion, Insertion<Bar>.Sort },
        { scripts.Algorithms.Shell, Shell<Bar>.Sort },
        { scripts.Algorithms.Lsd, Lsd<Bar>.Sort },
        { scripts.Algorithms.Msd, Msd<Bar>.Sort },
        { scripts.Algorithms.Heap, Heap<Bar>.Sort },
        { scripts.Algorithms.Merge, Merge<Bar>.Sort },
        { scripts.Algorithms.Gnome, Gnome<Bar>.Sort },
        { scripts.Algorithms.Intro, Intro<Bar>.Sort }
    };

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
            bar.SetValue(GD.RandRange(_minValue, _maxValue));
            bar.Position = new Vector2(i * x + 10, bar.Position.Y);
            AddChild(bar);
            _bars[i] = bar;
        }
    }

    public void OnButtonPressed(Algorithms algorithm)
    {
        if (_bars == null) return;

        if (Algorithms.TryGetValue(algorithm, out var sort))
        {
            sort(ref _bars, _isIncremental);
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(algorithm), algorithm,
                $"This error means that an unexpected value was passed when a button was pressed." +
                $" Received value: {algorithm}. Expected value within {scripts.Algorithms.Bitonic} and {scripts.Algorithms.Last - 1} " +
                $"(inclusive)");
        }
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