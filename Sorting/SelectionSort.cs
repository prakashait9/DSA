using System.Diagnostics;

namespace Sorting;

public class SelectionSort : ISort
{
    public static void Execute(int[] array, bool printArray)
    {
        var watch = Stopwatch.StartNew();
        var memoryBefore = GC.GetTotalMemory(false);
        var sorted = Sort(array);
        var memoryAfter = GC.GetTotalMemory(false);
        watch.Stop();
        Console.WriteLine($"{nameof(SelectionSort)} took {memoryAfter - memoryBefore} bytes, {watch.ElapsedTicks} ticks, {watch.ElapsedMilliseconds}ms");
        if(printArray) Console.WriteLine($"SORTED : {string.Join(", ", sorted)}");
    }

    static int[] Sort(int[] array)
    {
        var len = array.Length;
        for(var i=0; i<len; i++)
        {
            var minIdx = i;
            for(var j=i+1; j<len; j++){
                if(array[j] < array[minIdx])
                    minIdx = j;
            }
            // swap
            (array[i], array[minIdx]) = (array[minIdx], array[i]);
        }
        return array;
    }
}