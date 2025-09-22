using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    public static void OptimizedBubbleSort(int[] arr)
    {
        int n = arr.Length;
        bool swapped;
        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = true;
                }
            }
            if (!swapped) break; 
        }
    }

    public class Range<T> where T : IComparable<T>
    {
        private T min;
        private T max;

        public Range(T min, T max)
        {
            if (min.CompareTo(max) > 0)
                throw new ArgumentException("Minimum value cannot be greater than maximum value.");

            this.min = min;
            this.max = max;
        }

        public bool IsInRange(T value)
        {
            return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
        }

        public dynamic Length()
        {
            return (dynamic)max - (dynamic)min;
        }
    }


    public static void ReverseArrayList(ArrayList list)
    {
        int left = 0, right = list.Count - 1;
        while (left < right)
        {
            object temp = list[left];
            list[left] = list[right];
            list[right] = temp;
            left++;
            right--;
        }
    }


    public static List<int> GetEvenNumbers(List<int> numbers)
    {
        List<int> evens = new List<int>();
        foreach (var num in numbers)
        {
            if (num % 2 == 0)
                evens.Add(num);
        }
        return evens;
    }

  
    public class FixedSizeList<T>
    {
        private T[] items;
        private int count = 0;

        public FixedSizeList(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Capacity must be greater than zero.");
            items = new T[capacity];
        }

        public void Add(T item)
        {
            if (count >= items.Length)
                throw new InvalidOperationException("List is full. Cannot add more elements.");
            items[count++] = item;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException("Invalid index.");
            return items[index];
        }
    }

   
    public static int FirstNonRepeatedCharIndex(string str)
    {
        Dictionary<char, int> freq = new Dictionary<char, int>();

        foreach (char c in str)
        {
            if (freq.ContainsKey(c))
                freq[c]++;
            else
                freq[c] = 1;
        }

        for (int i = 0; i < str.Length; i++)
        {
            if (freq[str[i]] == 1)
                return i;
        }
        return -1;
    }

    
    static void Main(string[] args)
    {
        // 1. Bubble Sort
        int[] arr = { 5, 3, 8, 4, 2 };
        OptimizedBubbleSort(arr);
        Console.WriteLine("Sorted: " + string.Join(", ", arr));

        // 2. Range<T>
        Range<int> range = new Range<int>(10, 20);
        Console.WriteLine("Is 15 in range? " + range.IsInRange(15));
        Console.WriteLine("Length: " + range.Length());

        // 3. Reverse ArrayList
        ArrayList list = new ArrayList() { 1, 2, 3, 4, 5 };
        ReverseArrayList(list);
        Console.WriteLine("Reversed ArrayList: " + string.Join(", ", list.ToArray()));

        // 4. Even Numbers
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6 };
        List<int> evens = GetEvenNumbers(numbers);
        Console.WriteLine("Even Numbers: " + string.Join(", ", evens));

        // 5. FixedSizeList<T>
        FixedSizeList<string> fixedList = new FixedSizeList<string>(2);
        fixedList.Add("A");
        fixedList.Add("B");
        Console.WriteLine("Element at index 1: " + fixedList.Get(1));

        // 6. First Non-Repeated Character
        string str = "swiss";
        Console.WriteLine("First non-repeated char index: " + FirstNonRepeatedCharIndex(str));
    }
}
