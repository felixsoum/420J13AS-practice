using System;

namespace Practice02
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] A;

            A = new int[] { 2, 4, 8, 9, 11, 25, 34, 57, 3, 5, 7, 15, 26, 33, 44 };
            Merge(A, 0, 7, 14);

            //A = new int[] { 64, 14, 47, 32, 75, 34, 75, 34, 56, 25, 45, 34, 67, 45, 67 };
            //MergeSort(A);

            //A = new int[] { 27, 17, 3, 16, 13, 10, 1, 5, 7, 12, 4, 8, 9, 0 };
            //MaxHeapify(A, 3);

            //A = new int[] { 5, 3, 17, 10, 84, 19, 6, 22, 0 };
            //BuildMaxHeap(A);

            //A = new int[] { 64, 14, 47, 32, 75, 34, 75, 34, 56, 25, 45, 34, 67, 45, 67 };
            //HeapSort(A);

            Console.WriteLine(String.Join(", ", A));
        }

        public static void Merge(int[] A, int p, int q, int r)
        {
            //TODO
        }

        public static void MergeSort(int[] A, int p, int r)
        {
            //TODO
        }

        public static void MergeSort(int[] A)
        {
            MergeSort(A, 0, A.Length - 1);
        }

        public static int Left(int i)
        {
            return i * 2;
        }

        public static int Right(int i)
        {
            return i * 2 + 1;
        }

        public static void MaxHeapify(int[] A, int i, int heapSize)
        {
            //TODO
        }

        public static void MaxHeapify(int[] A, int index)
        {
            MaxHeapify(A, index, A.Length);
        }

        public static void BuildMaxHeap(int[] A)
        {
            //TODO
        }

        public static void HeapSort(int[] A)
        {
            //TODO
        }
    }
}
