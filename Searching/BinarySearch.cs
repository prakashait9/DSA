using System.Diagnostics;

namespace Searching;

public class BinarySearch : ISearch
{
    public static int Execute(int[] array, int value)
    {
        var watch = Stopwatch.StartNew();
        var memoryBefore = GC.GetTotalMemory(false);
        var index = Search(array, value);
        var memoryAfter = GC.GetTotalMemory(false);
        watch.Stop();
        Console.WriteLine($"{nameof(BinarySearch)} took {memoryAfter - memoryBefore} bytes, {watch.ElapsedTicks} ticks, {watch.ElapsedMilliseconds}ms");
        return index;
    }

    static int Search(int[] array, int target)
    {
        int left = 0, right = array.Length - 1;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (array[mid] == target) return mid;
            if (array[mid] < target) left = mid + 1;
            else right = mid - 1;
        }

        return -1;
    }
}