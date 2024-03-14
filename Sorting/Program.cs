using Sorting;

// generate some random int array
var random = new Random();
var unsorted = Enumerable.Range(0, 30)
                .Select(i => random.Next(-500, 501))
                .ToArray();

Console.WriteLine($"UNSORTED : {string.Join(", ", unsorted)}");

// O(n^2)
BubbleSort.Execute(unsorted);
