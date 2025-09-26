using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQAssignments
{
    public class Subject
    {
        public int Code { get; set; }
        public string Name { get; set; }
    }

    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Subject[] subjects { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //---------------------- Part 1 ----------------------//
            List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };

            // Query1: Display numbers without repetition, sorted
            var q1 = numbers.Distinct().OrderBy(n => n);
            Console.WriteLine("Query1: Distinct & Sorted Numbers");
            foreach (var num in q1)
                Console.WriteLine(num);

            // Query2: Using Query1 result and show number & multiplication
            Console.WriteLine("\nQuery2: Number and Multiplication");
            foreach (var num in q1)
                Console.WriteLine($"{num} * {num} = {num * num}");

            //---------------------- Part 2 ----------------------//
            string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" };

            // Query1: Select names with length = 3
            var nq1 = from n in names
                      where n.Length == 3
                      select n;
            Console.WriteLine("\nNames with length 3:");
            foreach (var n in nq1) Console.WriteLine(n);

            // Method expression
            var nq1m = names.Where(n => n.Length == 3);
            Console.WriteLine("Method Expression:");
            foreach (var n in nq1m) Console.WriteLine(n);

            // Query2: Names that contain "a" (case-insensitive), sorted by length
            var nq2 = names
                        .Where(n => n.ToLower().Contains("a"))
                        .OrderBy(n => n.Length);
            Console.WriteLine("\nNames containing 'a' sorted by length:");
            foreach (var n in nq2) Console.WriteLine(n);

            // Query3: Display first 2 names
            var nq3 = names.Take(2);
            Console.WriteLine("\nFirst 2 names:");
            foreach (var n in nq3) Console.WriteLine(n);

            //---------------------- Part 3 ----------------------//
            List<Student> students = new List<Student>()
            {
                new Student(){ ID=1, FirstName="Ali", LastName="Mohammed",
                    subjects=new Subject[]{ new Subject(){ Code=22,Name="EF"},
                                            new Subject(){ Code=33,Name="UML"}}},

                new Student(){ ID=2, FirstName="Mona", LastName="Gala",
                    subjects=new Subject []{ new Subject(){ Code=22,Name="EF"},
                                             new Subject(){ Code=34,Name="XML"},
                                             new Subject(){ Code=25,Name="JS"}}},

                new Student(){ ID=3, FirstName="Yara", LastName="Yousf",
                    subjects=new Subject []{ new Subject (){ Code=22,Name="EF"},
                                             new Subject(){ Code=25,Name="JS"}}},

                new Student(){ ID=1, FirstName="Ali", LastName="Ali",
                    subjects=new Subject []{  new Subject (){ Code=33,Name="UML"}}}
            };

            // Query1: Full name and number of subjects
            Console.WriteLine("\nStudents and number of subjects:");
            students.ForEach(s =>
                Console.WriteLine($"{s.FirstName} {s.LastName} - Subjects: {s.subjects.Length}")
            );

            // Query2: Order by FirstName Desc, LastName Asc
            var q2Students = students
                                .OrderByDescending(s => s.FirstName)
                                .ThenBy(s => s.LastName)
                                .Select(s => new { s.FirstName, s.LastName });
            Console.WriteLine("\nStudents ordered by FirstName desc & LastName asc:");
            foreach (var s in q2Students)
                Console.WriteLine($"{s.FirstName} {s.LastName}");

            // Query3: Each student with their subjects (SelectMany)
            Console.WriteLine("\nStudents with subjects:");
            var q3Students = students.SelectMany(s => s.subjects,
                                (st, subj) => new { Student = st.FirstName, Subject = subj.Name });
            foreach (var item in q3Students)
                Console.WriteLine($"{item.Student} - {item.Subject}");

            Console.WriteLine("\nGroupBy Subjects:");
            var grouped = students.SelectMany(s => s.subjects,
                                (st, subj) => new { st.FirstName, subj.Name })
                                .GroupBy(x => x.Name);
            foreach (var group in grouped)
            {
                Console.WriteLine($"Subject: {group.Key}");
                foreach (var student in group)
                    Console.WriteLine($"  - {student.FirstName}");
            }

            Console.ReadKey();
        }
    }
}
