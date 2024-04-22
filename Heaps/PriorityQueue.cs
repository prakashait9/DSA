using System;
using System.Collections.Generic;

namespace Heaps
{
    public class PriorityQueue<T>
    {
        private readonly List<T> _items;
        private readonly Comparison<T> _comparison;
        
        public int Count => _items.Count;

        public PriorityQueue(Comparison<T> comparison)
        {
            _items = new List<T>();
            _comparison = comparison;
        }

        public void Enqueue(T item)
        {
            _items.Add(item);
            
            // Bubble up
            int curr = Count - 1, parent = (curr - 1) / 2;
            while (curr > 0 && _comparison(_items[curr], _items[parent]) < 0)
            {   
                // swap
                (_items[curr], _items[parent]) = (_items[parent], _items[curr]);
                curr = parent;
                parent = (curr - 1) / 2;
            }
        }

        public T Dequeue()
        {
            if (Count == 0) return default;

            var returnVal = _items[0];
            _items[0] = _items[Count - 1];    // put biggest element on top for sink down later
            _items.RemoveAt(Count-1);
            
            // Sink down
            var curr = 0;
            while (curr * 2 + 1 < Count)
            {
                int leftChild = curr * 2 + 1, rightChild = curr * 2 + 2;
                var target = leftChild;

                // swap with parent should happen with smallest of the children
                if (rightChild < Count && _comparison(_items[rightChild], _items[leftChild]) < 0)
                    target = rightChild;

                // swap if parent is bigger than children
                if (_comparison(_items[target], _items[curr]) >= 0) break;     // no need to swap
                (_items[curr], _items[target]) = (_items[target], _items[curr]);
                curr = target;
            }

            return returnVal;
        }
    }
}