using System;

namespace Heaps
{
    class Program
    {
        static void Main(string[] args)
        {
            var unsorted = new[]{3,2,1,7,8,4,10,16,12};
            
            var minHeap = new MinHeap(unsorted);
            Console.Write("Array in ascending order (MinHeap) : ");
            var minHeapLen = minHeap.Length();
            for (var i = 0; i < minHeapLen; i++)
                Console.Write(minHeap.ExtractMin() + " ");
            Console.WriteLine();
            
            var maxHeap = new MaxHeap(unsorted);
            Console.Write("Array in descending order (MaxHeap) : ");
            var maxHealLen = maxHeap.Length();
            for (var i = 0; i < maxHealLen; i++)
                Console.Write(maxHeap.ExtractMax() + " ");
            Console.WriteLine();
            
            // using iterative approach, and keeping function generic
            var pq = new PriorityQueue<int>((x, y) => x.CompareTo(y));
            foreach (var num in unsorted) pq.Enqueue(num);
            Console.Write("Array in ascending order (PriorityQueue) : ");
            var pqLen = pq.Count;
            for (var i = 0; i < pqLen; i++)
                Console.Write(pq.Dequeue() + " ");
            Console.WriteLine();
        }
    }
}