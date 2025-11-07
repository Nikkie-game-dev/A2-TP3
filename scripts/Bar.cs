using System;
using Godot;

namespace a2tp3.scripts;

public partial class Bar() : Control, IComparable, INumericValue<int>
{
    [Export] private int _val ;
    
    public int CompareTo(object obj)
    {
        if (obj == null) return 1;
        
        var other = (Bar)obj;
        
        if (other == null) throw new ArgumentException();

        return other.GetValue() - _val;
    }

    public int GetValue() => _val;
    public void SetValue(int value)
    {
        _val = value;
        Size = new Vector2(Size.X, _val);
    }
}