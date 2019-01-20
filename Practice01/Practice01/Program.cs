﻿using System;

namespace Practice01
{
    public class Program
    {
        static void Main(string[] args)
        {
            //A.
            Console.WriteLine($"Answer to A is n = {SolveA()}\n");

            //B.
            Console.WriteLine($"Answer to B is n = {SolveB()}\n");

            //C.
            int[] insertionInput = new int[] { 4, 7, 5, 1, 8, 3, 9, 2, 6 };
            InsertionSort(insertionInput);
            Console.WriteLine(String.Join(", ", insertionInput) + "\n");

            //D.
            int[] insertionInput2 = new int[] { 4, 7, 5, 1, 8, 3, 9, 2, 6 };
            InsertionSortDescending(insertionInput2);
            Console.WriteLine(String.Join(", ", insertionInput2) + "\n");

            //E.
            bool[] binaryA = new bool[] { false, true, false, true };
            bool[] binaryB = new bool[] { true, true, true, true };
            bool[] binaryC = BinaryAdd(binaryA, binaryB);
            Console.WriteLine($"{BinaryToString(binaryA)} + {BinaryToString(binaryB)} = {BinaryToString(binaryC)}");
        }

        public static int SolveA()
        {
            for (int n = 1000; n > 0; n--)
            {
                if (n < 8 * Math.Log(n, 2))
                {
                    return n;
                }
            }
            throw new Exception("Answer not found.");
        }

        public static int SolveB()
        {
            for (int n = 1; n < 1000; n++)
            {
                if (100 * Math.Pow(n, 2) < Math.Pow(2, n))
                {
                    return n;
                }
            }
            throw new Exception("Answer not found.");
        }

        public static void InsertionSort(int[] A)
        {
            for (int j = 1; j <= A.Length - 1; j++)
            {
                int key = A[j];
                int i = j - 1;
                while (i > -1 && A[i] > key)
                {
                    A[i + 1] = A[i];
                    i--;
                }
                A[i + 1] = key;
            }
        }

        public static void InsertionSortDescending(int[] A)
        {
            for (int j = 1; j <= A.Length - 1; j++)
            {
                int key = A[j];
                int i = j - 1;
                while (i > -1 && A[i] < key)
                {
                    A[i + 1] = A[i];
                    i--;
                }
                A[i + 1] = key;
            }
        }

        public static bool[] BinaryAdd(bool[] A, bool[] B)
        {
            bool[] result = new bool[A.Length + 1];

            for (int i = A.Length - 1; i >= 0; i--)
            {
                if (A[i] && B[i])
                {
                    result[i] = true;
                }
                else if (A[i] != B[i])
                {
                    if (result[i + 1])
                    {
                        result[i] = true;
                    }
                    result[i + 1] = !result[i + 1];
                }
            }

            return result;
        }

        public static string BinaryToString(bool[] A)
        {
            string result = "";
            Array.ForEach(A, element => result += element ? "1" : "0");
            return result;
        }
    }
}
