using System;

class Program
{
    static void Main()
    {
        //-----------------------------
        // 1. Store student names
        //-----------------------------
        Console.WriteLine("Enter number of students: ");
        int numStudents = Convert.ToInt32(Console.ReadLine());

        string[] names = new string[numStudents];

        for (int i = 0; i < numStudents; i++)
        {
            Console.Write("Enter name of student " + (i + 1) + ": ");
            names[i] = Console.ReadLine();
        }

        Console.WriteLine("\n--- Student Names ---");
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }

        //-----------------------------
        // 2. Store student ages for many tracks
        //-----------------------------
        Console.WriteLine("\nEnter number of tracks: ");
        int numTracks = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter number of students per track: ");
        int studentsPerTrack = Convert.ToInt32(Console.ReadLine());

        int[,] ages = new int[numTracks, studentsPerTrack];

        for (int t = 0; t < numTracks; t++)
        {
            Console.WriteLine($"\nTrack {t + 1}: ");
            for (int s = 0; s < studentsPerTrack; s++)
            {
                Console.Write($"Enter age of student {s + 1}: ");
                ages[t, s] = Convert.ToInt32(Console.ReadLine());
            }
        }

        Console.WriteLine("\n--- Ages by Track ---");
        for (int t = 0; t < numTracks; t++)
        {
            Console.Write($"Track {t + 1}: ");
            int sum = 0;
            for (int s = 0; s < studentsPerTrack; s++)
            {
                Console.Write(ages[t, s] + " ");
                sum += ages[t, s];
            }
            double avg = (double)sum / studentsPerTrack;
            Console.WriteLine($" -> Average Age = {avg:F2}");
        }

        //-----------------------------
        // 3. Time Data Type
        //-----------------------------
        Console.WriteLine("\n--- Time Example ---");
        Time myTime = new Time(22, 33, 11);
        myTime.Print();
    }
}

//---------------------------------
// Custom datatype: Time
//---------------------------------
class Time
{
    public int Hours { get; set; }
    public int Minutes { get; set; }
    public int Seconds { get; set; }

    public Time(int h, int m, int s)
    {
        Hours = h;
        Minutes = m;
        Seconds = s;
    }

    public void Print()
    {
        Console.WriteLine($"{Hours}H:{Minutes}M:{Seconds}S");
    }
}
