namespace Lab1
{
    class Lab
    {
        public static void SolveFirstTask()
        { 
            Console.WriteLine("First task (1-3)");

            Console.Write("Enter the number value (n): ");
            double n = UserInputHandler.Number.Get();
            Console.Write("Enter the number value (m): ");
            double m = UserInputHandler.Number.Get();

            Console.WriteLine($"0) n = {n}; m = {m};");
            double firstResult = ++n * ++m;

            Console.WriteLine($"1) n = {n}; m = {m}; ++n * ++m = {firstResult:N3}");
            bool secondResult = m++ < n;

            Console.WriteLine($"2) n = {n}; m = {m};   m++ < n = {secondResult}");
            bool thirdResult = n++ > m;

            Console.WriteLine($"3) n = {n}; m = {m};   n++ > m = {thirdResult}\n");

            Console.WriteLine("First task (4)");

            Console.Write("Enter the argument (x) of the function (x + 1 / (x^3 - x) - 2): ");
            double[] numbersExcludedFromDomain = { -1.0, 0.0, 1.0 };
            double x = UserInputHandler.Number.GetExcluding(numbersExcludedFromDomain);

            double y = x + 1.0 / (Math.Pow(x, 3.0) - x) - 2.0;
            Console.WriteLine($"f({x}) = {y:3};\n");
        }

        public static void SolveSecondTask()
        {
            Console.WriteLine("Second task");

            Console.Write("Enter the number value (x): ");
            double x = UserInputHandler.Number.Get();
            Console.Write("Enter the number value (y): ");
            double y = UserInputHandler.Number.Get();

            Console.WriteLine($"Point({x}; {y})");

            bool isBelong = -7 <= x && x <= 0 &&
                            -2 <= y && y <= 0;
            Console.WriteLine($"Does a point belong to the shaded region? Answer: {isBelong}\n");
        }

        public static void SolveThirdTask()
        {
            /* ((a - b)^2 - (a^2 - 2ab)) / b^2 
             * (a^2 - 2ab + b^2 - a^2 + 2ab) / b^2
             * b^2 / b^2
             * 1
             */

            Console.WriteLine("Third task");

            float a1 = 1000f,
                  b1 = 0.0001f;

            float r11 = (a1 - b1),
                  r12 = r11 * r11, // (a - b)^2
                  r13 = a1 * a1 - 2.0f * a1 * b1,
                  r14 = r12 - r13,
                  r15 = r14 / (b1 * b1);

            Console.WriteLine("Data type: float");
            Console.WriteLine($"a = {a1}, b1 = {b1}");
            Console.WriteLine($"(a - b)                         = {r11}");
            Console.WriteLine($"(a - b)^2                       = {r12}");
            Console.WriteLine($"(a^2 - 2ab)                     = {r13}");
            Console.WriteLine($"(a - b)^2 - (a^2 - 2ab)         = {r14}");
            Console.WriteLine($"((a - b)^2 - (a^2 - 2ab)) / b^2 = {r15}\n");

            double a2 = 1000.0,
                   b2 = 0.0001;

            double r21 = (a2 - b2),
                   r22 = r21 * r21,
                   r23 = a2 * a2 - 2.0 * a2 * b2,
                   r24 = r22 - r23,
                   r25 = r24 / (b2 * b2);

            Console.WriteLine("Data type: double");
            Console.WriteLine($"a = {a2}, b1 = {b2}");
            Console.WriteLine($"(a - b)                         = {r21}");
            Console.WriteLine($"(a - b)^2                       = {r22}");
            Console.WriteLine($"(a^2 - 2ab)                     = {r23}");
            Console.WriteLine($"(a - b)^2 - (a^2 - 2ab)         = {r24}");
            Console.WriteLine($"((a - b)^2 - (a^2 - 2ab)) / b^2 = {r25}");
        }
    }
}