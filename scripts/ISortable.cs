// 12/10/2025 - a2-tp3

namespace a2tp3.scripts;

public interface ISortable <in T>
{
    public static abstract bool IsOrdered(T[] array, Order order);
}