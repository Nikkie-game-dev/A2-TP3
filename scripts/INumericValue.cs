// 07/11/2025 - a2-tp3

using System.Numerics;

namespace a2tp3.scripts;

public interface INumericValue <T> where T : INumber<T>
{
    public T GetValue();
    public void SetValue(T value);
}