// 12/10/2025 - a2-tp3

using System;

namespace a2tp3.scripts;

public class Rco<T> : ISortable<Rco<T>> where T : IComparable
{
    public T X;
    public T Y;
    private T _preceding;
    private T _succeeding;

    public void Sort(Order order)
    {
        var comparison = X?.CompareTo(Y); // is x after y? if so comparison > 0

        switch (order)
        {
            case Order.Decreasing when comparison < 0:
                _preceding = X;
                _succeeding = Y;
                break;
            case Order.Decreasing:
            case Order.Increasing when comparison < 0:
                _preceding = Y;
                _succeeding = X;
                break;
            case Order.Increasing:
                _preceding = X;
                _succeeding = Y;
                break;
        }
    }

    public static bool IsOrdered(Rco<T>[] array, Order order)
    {
        switch (order)
        {
            case Order.Decreasing:
                for (var i = 0; i < array.Length; ++i)
                {
                    var comparison = array[i].X.CompareTo(array[i].Y);
                    if (comparison > 0) return false;
                    comparison = array[i].Y.CompareTo(array[i + 1].X);
                    if (comparison > 0) return false;
                }

                break;

            case Order.Increasing:
                for (var i = 0; i < array.Length; ++i)
                {
                    var comparison = array[i].X.CompareTo(array[i].Y);
                    if (comparison < 0) return false;
                    comparison = array[i].Y.CompareTo(array[i + 1].X);
                    if (comparison < 0) return false;
                }

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(order), order, null);
        }

        return true;
    }

    public static void Join(Rco<T>[] rcos)
    {
        for (var i = 0; i < rcos.Length; i += 2)
        {
            rcos[i].X = rcos[i]._succeeding;
            rcos[i].Y = rcos[i + 1]._succeeding;

            rcos[i + 1].X = rcos[i]._preceding;
            rcos[i + 1].Y = rcos[i]._preceding;
        }
    }

    public static void Extract(in Rco<T>[] rcos, T[] array)
    {
        for (int i = 0, j = 0; i < rcos.Length; i++)
        {
            array[j] = rcos[i].X;
            array[j + 1] = rcos[i].Y;
            j += 2;
        }
    }
}