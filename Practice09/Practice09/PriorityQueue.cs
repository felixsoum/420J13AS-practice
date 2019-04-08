using System.Collections.Generic;

namespace Practice09
{
    class PriorityQueue<T> : List<T>
    {
        public T ExtractMin()
        {
            Sort();
            T result = this[0];
            RemoveAt(0);
            return result;
        }
    }
}
