// 07/11/2025 - a2-tp3

using System;
using Godot;

namespace a2tp3.scripts.algorithms;

public class Radix<T>(bool isLsd) : ISortable<T>
    where T : IComparable, INumericValue<int>, new()
{
    private bool _isLsd = isLsd;

    public void Sort(ref T[] array, bool isIncremental)
    {
        if (_isLsd)
        {
            Lsd(ref array, isIncremental);
        }
        else
        {
            Msd(ref array, isIncremental);
        }
    }

    private void Lsd(ref T[] array, bool isIncremental)
    {
        GetBiggest(array, out var biggestPos);

        GetDigits(array, biggestPos, out var digits);

        var currentDigit = 0;

        while (digits > currentDigit)
        {
            Bubble(ref array, isIncremental, currentDigit);
            currentDigit++;
        }
    }

    private void Msd(ref T[] array, bool isIncremental)
    {
        GetBiggest(array, out var biggestPos);

        GetDigits(array, biggestPos, out var digits);

        while (digits > 0)
        {
            digits--;
            Bubble(ref array, isIncremental, digits);
        }
    }

    private static void GetDigits(T[] array, int biggestPos, out int digits)
    {
        digits = 0;
        var bar = array[biggestPos] as Bar;
        if (bar != null)
        {
            var value = bar.GetValue() / (int)Mathf.Pow(10, digits);
        
            while (value > 9)
            {
                value = bar.GetValue() / (int)Mathf.Pow(10, digits);
                digits++;
            }
        }

        ;
    }

    private static void GetBiggest(T[] array, out int biggestPos)
    {
        biggestPos = 0;
        for (var i = 0; i < array.Length; i++)
        {
            if (array[i].CompareTo(array[biggestPos]) < 0)
            {
                biggestPos = i;
            }
        }
    }

    private void Bubble(ref T[] array, bool isIncremental, int digits)
    {
        bool hasChanged;

        var divisor = (int)MathF.Pow(10, digits);

        if (isIncremental)
        {
            do
            {
                hasChanged = false;

                for (var j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] is not Bar barA || array[j + 1] is not Bar barB) continue;
                    
                    var significantDigitA = (barA.GetValue() / divisor) % (divisor > 1 ? divisor : 10);
                    var significantDigitB = (barB.GetValue() / divisor) % (divisor > 1 ? divisor : 10);

                    if (significantDigitA <= significantDigitB) continue;

                    if (!_isLsd)
                    {
                        var priorDiv = divisor * 10;
                        
                        var priorSignificantDigitA = (barA.GetValue() / priorDiv) % (priorDiv > 1 ? priorDiv : 10);
                        var priorSignificantDigitB = (barB.GetValue() / priorDiv) % (priorDiv > 1 ? priorDiv : 10);

                        if (priorSignificantDigitA != priorSignificantDigitB) continue;
                    }
                    
                        
                    ISortable<T>.Swap(array, j, j + 1);
                    hasChanged = true;
                }
            } while (hasChanged);
        }
        else
        {
            do
            {
                hasChanged = false;

                for (var j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] is not Bar barA || array[j + 1] is not Bar barB) continue;
                    
                    
                    var significantDigitA = (barA.GetValue() / divisor) % (divisor > 1 ? divisor : 10);
                    var significantDigitB = (barB.GetValue() / divisor) % (divisor > 1 ? divisor : 10);
                    
                    if (significantDigitA >= significantDigitB) continue;
                        
                    ISortable<T>.Swap(array, j, j + 1);
                    hasChanged = true;
                }
            } while (hasChanged);
        }
    }
}