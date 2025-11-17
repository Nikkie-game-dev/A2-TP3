// 07/11/2025 - a2-tp3

using System;
using Godot;

namespace a2tp3.scripts.algorithms;

public class Radix<T> where T : IComparable, INumericValue<int>, new()
{
    protected static void GetDigits(T[] array, int biggestPos, out int digits)
    {
        digits = 0;
        if (array[biggestPos] is Bar bar)
        {
            var value = bar.GetValue() / (int)Mathf.Pow(10, digits);
        
            while (value > 9)
            {
                value = bar.GetValue() / (int)Mathf.Pow(10, digits);
                digits++;
            }
        }
    }

    protected static void GetBiggest(T[] array, out int biggestPos)
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

    protected static void Bubble(ref T[] array, bool isIncremental, int digits)
    {
        bool hasChanged;
        
        if (isIncremental)
        {
            do
            {
                hasChanged = false;

                for (var j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] is not Bar barA || array[j + 1] is not Bar barB) continue;
                    
                    var significantDigitA = GetSignificantDigit(barA, in digits);
                    var significantDigitB = GetSignificantDigit(barB, in digits);

                    if (significantDigitA <= significantDigitB) continue;
                        
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
                    
                    
                    var significantDigitA = GetSignificantDigit(barA, in digits);
                    var significantDigitB = GetSignificantDigit(barB, in digits);
                    
                    if (significantDigitA >= significantDigitB) continue;
                        
                    ISortable<T>.Swap(array, j, j + 1);
                    hasChanged = true;
                }
            } while (hasChanged);
        }
    }

    protected static int GetSignificantDigit(in Bar barA, in int digits)
    {
        var divisor = (int)MathF.Pow(10, digits);
        return (barA.GetValue() / divisor) % (divisor > 1 ? divisor : 10);
    }
}
//O(d * (n + b)), where d is the number of digits, n is the number of elements, and b is the base of the number system being used
public class Lsd<T> : Radix<T>, ISortable<T> where T : IComparable, INumericValue<int>, new()
{
    public static void Sort(ref T[] array, bool isIncremental)
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
}

public class Msd<T> : Radix<T>, ISortable<T> where T : IComparable, INumericValue<int>, new()
{
    public static void Sort(ref T[] array, bool isIncremental)
    {
        var copy = array;
        
        GetBiggest(array, out var biggestPos);
        GetDigits(array, biggestPos, out var biggestDigit);

        // add padding of 0 in the right
        for (var i = 0; i < array.Length; i++)
        {
            GetDigits(array, i, out var digits);
            if (digits < biggestDigit)
            {
               copy[i].SetValue(copy[i].GetValue() * (int)Mathf.Pow(10, biggestDigit - digits)); 
            }
        }
        
        MsdSort(ref copy, isIncremental, 0, copy.Length);
        
        
    }

    private static void MsdSort(ref T[] array, bool isIncremental, int start, int end)
    {
    }

    private static void GetBucket(ref T[] array, in int numberToCheck, in int digit, out int start, out int end)
    {
        start = -1;
        end = 0;
        for (var i = 0; i < array.Length; i++)
        {
            if (start == -1 && numberToCheck == GetSignificantDigit(array[i] as Bar,digit))
            {
                start = i;
            }
            else if (start != -1 && numberToCheck != GetSignificantDigit(array[i] as Bar, digit))
            {
                end = i;
                break;
            }
        }
    }
    
}


