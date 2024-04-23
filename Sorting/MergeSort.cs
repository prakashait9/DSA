using System.Diagnostics;

namespace Sorting;

public class MergeSort : ISort
{
    public static void Execute(int[] array, bool printArray)
    {
        var watch = Stopwatch.StartNew();
        var memoryBefore = GC.GetTotalMemory(false);
        var sorted = Sort(array, new int[array.Length], 0, array.Length-1);
        var memoryAfter = GC.GetTotalMemory(false);
        watch.Stop();
        Console.WriteLine($"{nameof(MergeSort)} took {memoryAfter - memoryBefore} bytes, {watch.ElapsedTicks} ticks, {watch.ElapsedMilliseconds}ms");
        if(printArray) Console.WriteLine($"SORTED : {string.Join(", ", sorted)}");
    }

    static int[] Sort(int[] array, int[] temp, int left, int right)
    {
        if (left < right)
        {
            var mid = (left + right) / 2;
            Sort(array, temp, left, mid);
            Sort(array, temp, mid+1, right);
            Merge(array, temp, left, mid, right);
        }

        return array;
    }

    private static void Merge(int[] array, int[] temp, int left, int mid, int right)
    {
        int leftIdx = left, rightIdx = mid + 1, tempIdx = left;
        // copy data into temp array in ascending order
        while (leftIdx <= mid && rightIdx <= right)
            if (array[leftIdx] < array[rightIdx]) temp[tempIdx++] = array[leftIdx++];
            else temp[tempIdx++] = array[rightIdx++];

        // copy left over values
        while (leftIdx <= mid) temp[tempIdx++] = array[leftIdx++];
        while (rightIdx <= right) temp[tempIdx++] = array[rightIdx++];

        // copy data from temp to actual array
        for (var i = left; i <= right; i++)
            array[i] = temp[i];
    }
}