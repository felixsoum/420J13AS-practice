/*
 * felixsoum 
 * 
 * 420-J13-AS
 * 
 * Practice random, quicksort and counting sort.
 */

using System;

namespace Practice03
{
    public class Program
    {
        static int[] A;

        static void Main(string[] args)
        {
            //A.
            Console.WriteLine(LootBox());

            //B.
            A = new int[] { 5, 8, 6, 2, 3, 7, 1, 4 };
            Partition(A, 0, A.Length - 1);

            ////C.
            //A = new int[] { 5, 8, 6, 2, 3, 7, 1, 4 };
            //Quicksort(A);

            ////D.
            //A = new int[] { 5, 8, 6, 2, 3, 7, 1, 4 };
            //QuicksortDescending(A);

            ////E.
            //A = new int[] { 5, 8, 6, 2, 3, 7, 1, 4 };
            //Console.WriteLine($"Pivot is at index: {RandomizedPartition(A, 0, A.Length - 1)}");

            ////F.
            //A = new int[] { 5, 8, 6, 2, 3, 7, 1, 4 };
            //RandomizedQuicksort(A);

            ////G.
            //A = new int[] { 5, 7, 8, 3, 6, 2, 7, 0, 3, 7, 1, 4, 9 };
            //int[] B = new int[A.Length];
            //CountingSort(A, B, new int[10]);
            //A = B;

            Console.WriteLine(String.Join(", ", A));
        }

        static string LootBox()
        {
            switch (new Random().Next(3))
            {
                default:
                case 0:
                    return "COMMON";
                case 1:
                    return "RARE";
                case 2:
                    return "EPIC";
                case 3:
                    return "LEGENDARY";
            }
        }

        public static void Swap(int[] A, int i, int j)
        {
            int temp = A[i];
            A[i] = A[j];
            A[j] = temp;
        }

        public static int Partition(int[] A, int p, int r)
        {
            //TODO
            return -1;
        }

        public static void Quicksort(int[] A, int p, int r)
        {
            //TODO
        }

        public static void Quicksort(int[] A)
        {
            Quicksort(A, 0, A.Length - 1);
        }

        public static int PartitionDescending(int[] A, int p, int r)
        {
            //TODO
            return -1;
        }

        public static void QuicksortDescending(int[] A, int p, int r)
        {
            //TODO
        }

        public static void QuicksortDescending(int[] A)
        {
            QuicksortDescending(A, 0, A.Length - 1);
        }

        public static int RandomizedPartition(int[] A, int p, int r)
        {
            //TODO
            return -1;
        }

        public static void RandomizedQuicksort(int[] A, int p, int r)
        {
            //TODO
        }

        public static void RandomizedQuicksort(int[] A)
        {
            RandomizedQuicksort(A, 0, A.Length - 1);
        }

        public static void CountingSort(int[] A, int[] B, int[] k)
        {
            //TODO
        }
    }
}
