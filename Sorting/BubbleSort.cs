using System.Diagnostics;

namespace Sorting;

public class BubbleSort : ISort
{
    public static void Execute(int[] array, bool printArray)
    {
        var watch = Stopwatch.StartNew();
        var memoryBefore = GC.GetTotalMemory(false);
        var sorted = Sort(array);
        var memoryAfter = GC.GetTotalMemory(false);
        watch.Stop();
        Console.WriteLine($"{nameof(BubbleSort)} took {memoryAfter - memoryBefore} bytes, {watch.ElapsedTicks} ticks, {watch.ElapsedMilliseconds}ms");
        if(printArray) Console.WriteLine($"SORTED : {string.Join(", ", sorted)}");
    }

    static int[] Sort(int[] array)
    {
        var len = array.Length;
        for(var i=len-1; i>0; i--){
            for(var j=0; j<i; j++){
                if(array[j+1] < array[j]){
                   (array[j+1], array[j]) = (array[j], array[j+1]);
                }
            }
        }
        return array;
    }
}