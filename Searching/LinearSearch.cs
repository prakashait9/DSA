using System.Diagnostics;

namespace Searching;

public class LinearSearch : ISearch
{
    public static int Execute(int[] array, int value)
    {
        var watch = Stopwatch.StartNew();
        var memoryBefore = GC.GetTotalMemory(false);
        var index = Search(array, value);
        var memoryAfter = GC.GetTotalMemory(false);
        watch.Stop();
        Console.WriteLine($"{nameof(LinearSearch)} took {memoryAfter - memoryBefore} bytes, {watch.ElapsedTicks} ticks, {watch.ElapsedMilliseconds}ms");
        return index;
    }

    static int Search(int[] array, int target)
    {
        for (var i = 0; i < array.Length; i++)
            if (array[i] == target) return i;

        return -1;
    }
}