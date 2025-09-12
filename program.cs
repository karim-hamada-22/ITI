    using System;

class Program
{
    static void Main()
    {
        // 1. Take a character from the user and display its ASCII code
        Console.WriteLine("Enter a character: ");
        char ch = Console.ReadKey().KeyChar;
        Console.WriteLine("\nASCII code of " + ch + " is " + (int)ch);

        // 2. Take ASCII code from user and display the character
        Console.WriteLine("\nEnter an ASCII code (0-127): ");
        int ascii = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Character is: " + (char)ascii);

        // 3. Take a number and display odd or even
        Console.WriteLine("\nEnter a number: ");
        int num = Convert.ToInt32(Console.ReadLine());
        if (num % 2 == 0)
            Console.WriteLine(num + " is Even.");
        else
            Console.WriteLine(num + " is Odd.");

        // 4. Take two numbers and print sum, subtraction, multiplication
        Console.WriteLine("\nEnter first number: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter second number: ");
        int b = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Sum = " + (a + b));
        Console.WriteLine("Subtraction = " + (a - b));
        Console.WriteLine("Multiplication = " + (a * b));

        // 5. Take student degree and calculate grade
        Console.WriteLine("\nEnter student degree (0-100): ");
        int degree = Convert.ToInt32(Console.ReadLine());
        if (degree >= 90)
            Console.WriteLine("Grade: A");
        else if (degree >= 80)
            Console.WriteLine("Grade: B");
        else if (degree >= 70)
            Console.WriteLine("Grade: C");
        else if (degree >= 60)
            Console.WriteLine("Grade: D");
        else
            Console.WriteLine("Grade: F");

        // 6. Multiplication table
        Console.WriteLine("\nEnter a number for multiplication table: ");
        int tableNum = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Multiplication Table of " + tableNum);
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(tableNum + " x " + i + " = " + (tableNum * i));
        }
    }
}
