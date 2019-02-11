/*
 * felixsoum 
 * 
 * 420-J13-AS
 * 
 * Practice hash tables and hash functions.
 */
using System;

namespace Practice05
{
    class Program
    {
        static void Main(string[] args)
        {
            var gradeBook = new GradeBook();
            gradeBook[1000] = 60;
            gradeBook[1101] = 75;
            gradeBook[1202] = 90;

            Console.WriteLine($"Grade of student 1000 is {gradeBook[1000]}.");
            Console.WriteLine($"Grade of student 1101 is {gradeBook[1101]}.");
            Console.WriteLine($"Grade of student 1202 is {gradeBook[1202]}.");

            gradeBook.Delete(1101);
            gradeBook[1101] = 100;
            Console.WriteLine($"Grade of student 1101 changed to {gradeBook[1101]}.");
            Console.WriteLine($"First, there are {gradeBook.Count} entries in the GradeBook.");
            gradeBook.Delete(1000);
            gradeBook.Delete(1101);
            gradeBook.Delete(1202);
            Console.WriteLine($"Now, there are {gradeBook.Count} entries in the GradeBook.");
        }
    }
}
