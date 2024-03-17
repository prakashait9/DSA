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

// O(n^2)
BubbleSort.Execute((int[])unsorted.Clone(), printArray);
// O(n^2)
SelectionSort.Execute((int[])unsorted.Clone(), printArray);
// O(n^2)
InsertionSort.Execute((int[])unsorted.Clone(), printArray);
