using Searching;

// Change LEN to a higher value for clear difference in time complexity
const int LEN = 300;
var printArray = LEN <= 30;

// generate some random int array, without duplicates. 
var set = new HashSet<int>();
var random = new Random();
while (set.Count < LEN)
{
    var num = random.Next(-500000, 500000);
    set.Add(num);
}
var array = set.ToArray();
Array.Sort(array);

if(printArray)
    Console.WriteLine($"ARRAY : {string.Join(", ", array)}");
else
    Console.WriteLine($"Array of length {LEN} generated.");

var indexOfSearch = random.Next(0, LEN);
var invalidValue = -999999;

// O(n) - linear approach
var linearIndex = LinearSearch.Execute(array, array[indexOfSearch]);
Console.WriteLine($"Expected index of {array[indexOfSearch]} = {indexOfSearch}, actual = {linearIndex}");

linearIndex = LinearSearch.Execute(array, invalidValue);
Console.WriteLine($"Expected index of {invalidValue} = -1, actual = {linearIndex}");
Console.WriteLine("--------------------------------------------------");

// O(log n) - divide and conquer
var binaryIndex = BinarySearch.Execute(array, array[indexOfSearch]);
Console.WriteLine($"Expected index of {array[indexOfSearch]} = {indexOfSearch}, actual = {binaryIndex}");

binaryIndex = BinarySearch.Execute(array, invalidValue);
Console.WriteLine($"Expected index of {invalidValue} = -1, actual = {binaryIndex}");
Console.WriteLine("--------------------------------------------------");
