using System.Collections.Generic;
using System.Linq;

namespace Practice05
{
    /// <summary>
    /// Dictionary of student ID numbers to their grades.
    /// </summary>
    public class GradeBook
    {
        /// <summary>
        /// Class to use as data nodes in the linked lists.
        /// </summary>
        class GradeBookData
        {
            public int id;
            public double grade;

            public GradeBookData(int id, double grade)
            {
                this.id = id;
                this.grade = grade;
            }
        }

        const int m = 101;
        LinkedList<GradeBookData>[] table = new LinkedList<GradeBookData>[m];

        /// <summary>
        /// Use indexers to allow using [].
        /// </summary>
        /// <param name="k">Key which is student ID number.</param>
        /// <returns>The grade of the student.</returns>
        public double this[int k]
        {
            get
            {
                return Search(k);
            }
            set
            {
                Insert(k, value);
            }
        }

        /// <summary>
        /// Returns the number of grades recorded.
        /// </summary>
        public int Count
        {
            get
            {
                int count = 0;
                foreach (var list in table)
                {
                    if (list != null)
                    {
                        count += list.Count;
                    }
                }
                return count;
            }
        }

        /// <summary>
        /// Inserts a grade for a student.
        /// </summary>
        /// <param name="id">Student ID number.</param>
        /// <param name="grade">Grade between 0 and 100.</param>
        public void Insert(int id, double grade)
        {
            int hashValue = Hash(id);

            if (table[hashValue] == null)
            {
                table[hashValue] = new LinkedList<GradeBookData>();
            }
            table[hashValue].AddFirst(new GradeBookData(id, grade));
        }

        /// <summary>
        /// Search for grade by student ID number.
        /// </summary>
        /// <param name="id">Student ID number.</param>
        /// <returns>Student grade.</returns>
        public double Search(int id)
        {
            int hashValue = Hash(id);
            if (table[hashValue] != null)
            {
                return table[hashValue].Where(d => d.id == id).First().grade;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        /// <summary>
        /// Delete student grade by ID.
        /// </summary>
        /// <param name="id">Student ID number.</param>
        public void Delete(int id)
        {
            int hashValue = Hash(id);
            if (table[hashValue] != null)
            {
                GradeBookData data = table[hashValue].Where(d => d.id == id).First();
                table[hashValue].Remove(data);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        /// <summary>
        /// Hash key using division method.
        /// </summary>
        /// <param name="k">Key to hash.</param>
        /// <returns>Hash value.</returns>
        public static int Hash(int k)
        {
            return k % m;
        }
    }
}
