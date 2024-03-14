using System.Diagnostics;

namespace Sorting;

public class BubbleSort : ISort
{
    public static void Execute(int[] array)
    {
        var watch = Stopwatch.StartNew();
        var sorted = Sort(array);
        watch.Stop();
        Console.WriteLine($"{nameof(BubbleSort)} took {watch.ElapsedTicks} ticks, {watch.ElapsedMilliseconds}ms");
        Console.WriteLine($"SORTED : {string.Join(", ", sorted)}");
    }

    static int[] Sort(int[] array)
    {
        var len = array.Length;
        for(var i=0; i<len; i++){
            for(var j=0; j<len; j++){
                if(array[i] > array[j]){
                   (array[i], array[j]) = (array[j], array[i]);
                }
            }
        }
        return array;
    }
}