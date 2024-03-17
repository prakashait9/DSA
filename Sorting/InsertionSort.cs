using System.Diagnostics;

namespace Sorting;

public class InsertionSort : ISort
{
    public static void Execute(int[] array, bool printArray)
    {
        var watch = Stopwatch.StartNew();
        var sorted = Sort(array);
        watch.Stop();
        Console.WriteLine($"{nameof(InsertionSort)} took {watch.ElapsedTicks} ticks, {watch.ElapsedMilliseconds}ms");
        if(printArray)
            Console.WriteLine($"SORTED : {string.Join(", ", sorted)}");
    }

    static int[] Sort(int[] array)
    {
        var len = array.Length;
        for(var i=0; i<len; i++){
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