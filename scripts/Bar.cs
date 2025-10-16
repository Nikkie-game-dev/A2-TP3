using System;
using Godot;

namespace a2tp3.scripts;

public partial class Bar : Control, IComparable
{

    
    [Export] private int _val ;
    public int Val
    {
        get => _val;
        set
        {
            _val = value;
            Size = new Vector2(Size.X, _val);
        }
    }

    public Bar()
    {
        
    }

    public int CompareTo(object obj)
    {
        if (obj == null) return 1;
        
        var other = (Bar)obj;
        
        if (other == null) throw new ArgumentException();

        return other.Val - _val;
    }
    
}