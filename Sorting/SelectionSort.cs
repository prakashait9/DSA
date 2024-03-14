using System.Diagnostics;

namespace Sorting;

public class SelectionSort : ISort
{
    public static void Execute(int[] array)
    {
        var watch = Stopwatch.StartNew();
        var sorted = Sort(array);
        watch.Stop();
        Console.WriteLine($"{nameof(SelectionSort)} took {watch.ElapsedTicks} ticks, {watch.ElapsedMilliseconds}ms");
        Console.WriteLine($"SORTED : {string.Join(", ", sorted)}");
    }

    static int[] Sort(int[] array)
    {
        var len = array.Length;
        for(var i=0; i<len; i++){
            int minIdx = i, temp = array[i];
            for(var j=i+1; j<len; j++){
                if(array[j] < array[minIdx])
                    minIdx = j;
            }
            array[i] = array[minIdx];
            array[minIdx] = temp;
        }
        return array;
    }
}