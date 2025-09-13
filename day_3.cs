using System;

namespace LabDemo
{
    // ---------------- Calc Class ----------------
    class Calc
    {
        // Overloading sum
        public int Sum(int a, int b) => a + b;
        public double Sum(double a, double b) => a + b;

        // Overloading sub
        public int Sub(int a, int b) => a - b;
        public double Sub(double a, double b) => a - b;

        // Overloading mul
        public int Mul(int a, int b) => a * b;
        public double Mul(double a, double b) => a * b;

        // Overloading div
        public double Div(int a, int b) => (b != 0) ? (double)a / b : 0;
        public double Div(double a, double b) => (b != 0) ? a / b : 0;
    }

    // ---------------- Question Class ----------------
    class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }

        public Question() { }

        public Question(string header, string body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
        }

        public virtual void Show()
        {
            Console.WriteLine(Header);
            Console.WriteLine(Body);
            Console.WriteLine($"Mark: {Mark}");
        }
    }

    // ---------------- MCQ Class ----------------
    class MCQ : Question
    {
        public string[] Choices { get; set; }
        public int CorrectAnswer { get; set; }

        public MCQ(string header, string body, int mark, string[] choices, int correctAnswer)
            : base(header, body, mark)
        {
            Choices = choices;
            CorrectAnswer = correctAnswer;
        }

        public override void Show()
        {
            base.Show();
            for (int i = 0; i < Choices.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Choices[i]}");
            }
        }

        public bool CheckAnswer(int userAnswer)
        {
            return userAnswer == CorrectAnswer;
        }
    }

    // ---------------- Main Program ----------------
    class Program
    {
        static void Main(string[] args)
        {
            // Demo with one MCQ
            MCQ q1 = new MCQ(
                "Q1",
                "What is the capital of Egypt?",
                5,
                new string[] { "Cairo", "Alexandria", "Giza" },
                1
            );

            q1.Show();

            // Take answer from user
            Console.Write("Your Answer (1/2/3): ");
            int ans = int.Parse(Console.ReadLine());
            if (q1.CheckAnswer(ans))
                Console.WriteLine("Correct");
            else
                Console.WriteLine("Wrong");

            Console.WriteLine("\n-------------------\n");

            // Array of MCQs
            Console.Write("Enter number of questions: ");
            int n = int.Parse(Console.ReadLine());
            MCQ[] questions = new MCQ[n];
            int totalMark = 0, obtainedMark = 0;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nEnter data for Q{i + 1}:");
                Console.Write("Header: ");
                string header = Console.ReadLine();

                Console.Write("Body: ");
                string body = Console.ReadLine();

                Console.Write("Mark: ");
                int mark = int.Parse(Console.ReadLine());

                Console.Write("How many choices? ");
                int c = int.Parse(Console.ReadLine());
                string[] choices = new string[c];
                for (int j = 0; j < c; j++)
                {
                    Console.Write($"Choice {j + 1}: ");
                    choices[j] = Console.ReadLine();
                }

                Console.Write("Enter correct answer (1-based index): ");
                int correct = int.Parse(Console.ReadLine());

                questions[i] = new MCQ(header, body, mark, choices, correct);
            }

            Console.WriteLine("\n---- Exam Started ----\n");
            foreach (var q in questions)
            {
                q.Show();
                Console.Write("Your Answer: ");
                int userAns = int.Parse(Console.ReadLine());

                totalMark += q.Mark;
                if (q.CheckAnswer(userAns))
                {
                    obtainedMark += q.Mark;
                    Console.WriteLine("Correct\n");
                }
                else
                {
                    Console.WriteLine("Wrong\n");
                }
            }

            Console.WriteLine($"Your Result: {obtainedMark}/{totalMark}");
        }
    }
}
