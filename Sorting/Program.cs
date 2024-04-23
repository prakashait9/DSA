using Sorting;

// Change LEN to a higher value for clear difference in time complexity
const int LEN = 30;
bool printArray = LEN <= 30;

// generate some random int array. 
var random = new Random();
var unsorted = Enumerable.Range(0, LEN)
                .Select(i => random.Next(-500, 501))
                .ToArray();

if(printArray)
    Console.WriteLine($"UNSORTED : {string.Join(", ", unsorted)}");

// O(n^2) - keep comparing adjacent numbers and move smaller to left
BubbleSort.Execute((int[])unsorted.Clone(), printArray);
// O(n^2) - in every loop, find smallest in array, move it to first
SelectionSort.Execute((int[])unsorted.Clone(), printArray);
// O(n^2) - for every element, find it's suitable position on left side of that element
InsertionSort.Execute((int[])unsorted.Clone(), printArray);
// O(n log n) - divide and conquer
MergeSort.Execute((int[])unsorted.Clone(), printArray);
// O(n log n) - Take a pivot, put everything small on left of pivot, everything big on right, sort the left & right now
QuickSort.Execute((int[])unsorted.Clone(), printArray);
