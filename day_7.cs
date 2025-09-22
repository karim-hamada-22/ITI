using System;

namespace Assignment
{
  
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Program
    {
       
        public static Product CreateProduct()
        {
            return new Product
            {
                Name = "Laptop",
                Price = 1200.50
            };
        }

        static void Main(string[] args)
        {
            // Test 1: Anonymous Product Object
            Product product = CreateProduct();
            Console.WriteLine($"Product Name: {product.Name}, Price: {product.Price}");

            // Test 2: String word count
            string text = "Hello, world!";
            Console.WriteLine($"Word count: {text.WordCount()}");

            // Test 3: Check even number
            int num = 10;
            Console.WriteLine($"{num} is even? {num.IsEven()}");

            // Test 4: Age from birthdate
            DateTime birthdate = new DateTime(2000, 5, 15);
            Console.WriteLine($"Age: {birthdate.CalculateAge()}");

            // Test 5: Reverse string
            string str = "hello";
            Console.WriteLine($"Reversed: {str.ReverseString()}");
        }
    }

    
    public static class Extensions
    {
        // 2. String word count
        public static int WordCount(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return 0;
            return str.Split(new char[] { ' ', '\t', '\n', ',', '.', '!', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }

        // 3. Int IsEven
        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }

        // 4. DateTime CalculateAge
        public static int CalculateAge(this DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }

        // 5. String Reverse
        public static string ReverseString(this string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
