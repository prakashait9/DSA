using System.Diagnostics;

namespace Sorting;

public class InsertionSort : ISort
{
    public static void Execute(int[] array, bool printArray)
    {
        var watch = Stopwatch.StartNew();
        var memoryBefore = GC.GetTotalMemory(false);
        var sorted = Sort(array);
        var memoryAfter = GC.GetTotalMemory(false);
        watch.Stop();
        Console.WriteLine($"{nameof(InsertionSort)} took {memoryAfter - memoryBefore} bytes, {watch.ElapsedTicks} ticks, {watch.ElapsedMilliseconds}ms");
        if(printArray) Console.WriteLine($"SORTED : {string.Join(", ", sorted)}");
    }

    static int[] Sort(int[] array)
    {
        for(var i=0; i<array.Length; i++){
            var key = array[i];
            var j = i-1;
            while(j >= 0 && array[j] > key){
                array[j+1] = array[j];
                j--;
            }
            array[j+1] = key;
        }
        return array;
    }
}