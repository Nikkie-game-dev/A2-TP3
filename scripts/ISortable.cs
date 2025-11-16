using System;

namespace a2tp3.scripts;

public interface ISortable<T> where T : IComparable
{
    public static abstract void Sort(ref T[] array, bool isIncremental);

    public static void Swap(T[] array, int i, int j) => (array[i], array[j]) = (array[j], array[i]);

    /// <summary>
    /// Checks if "b" follows "a" when is incremental or if "a" follows "b" when is decremental
    /// </summary>
    /// <param name="a"> T element</param>
    /// <param name="b"> T element</param>
    /// <param name="isIncremental"> Whether "a" should follow "b"</param>
    /// <returns>True if summary applies</returns>
    public static bool IsOrdered(T a, T b, bool isIncremental) =>
        (isIncremental && a.CompareTo(b) >= 0) || (!isIncremental && a.CompareTo(b) < 0);
}