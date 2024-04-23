using System.Diagnostics;

namespace Sorting;

public class QuickSort : ISort
{
    public static void Execute(int[] array, bool printArray)
    {
        var watch = Stopwatch.StartNew();
        var memoryBefore = GC.GetTotalMemory(false);
        var sorted = Sort(array, 0, array.Length-1);
        var memoryAfter = GC.GetTotalMemory(false);
        watch.Stop();
        Console.WriteLine($"{nameof(QuickSort)} took {memoryAfter - memoryBefore} bytes, {watch.ElapsedTicks} ticks, {watch.ElapsedMilliseconds}ms");
        if(printArray) Console.WriteLine($"SORTED : {string.Join(", ", sorted)}");
    }

    static int[] Sort(int[] array, int left, int right)
    {
        if (left < right)
        {
            var partitionIndex = Partition(array, left, right);
            Sort(array, left, partitionIndex - 1);
            Sort(array, partitionIndex + 1, right);
        }
        return array;
    }

    private static int Partition(int[] array, int left, int right)
    {
        var pivotIndex = right;
        var partitionIdx = left;
        for (var curr = left; curr < right; curr++)
        {
            if (array[curr] < array[pivotIndex])
            {
                (array[partitionIdx], array[curr]) = (array[curr], array[partitionIdx]);
                partitionIdx++;
            }
        }
        (array[partitionIdx], array[pivotIndex]) = (array[pivotIndex], array[partitionIdx]);
        return partitionIdx;
    }
}