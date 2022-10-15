namespace Lab3
{
    class Lab
    {
        public static void SolveTask()
        {
            const int n = 40;
            const double k = 10.0,
                         eps = 0.0001,
                         lowerBoundary = Math.PI / 5.0,
                         upperBoundary = 9.0 * Math.PI / 5.0,
                         step = (upperBoundary - lowerBoundary) / k;

            for (double X = lowerBoundary; X <= upperBoundary; X += step)
            {
                // y = -ln|2sin(x/2)|
                double Y = -Math.Log(Math.Abs(2.0 * Math.Sin(X / 2.0)));

                // для заданного n
                double SN = 0.0;
                for (int i = 1; i <= n; ++i)
                    SN += Math.Cos(i * X) / i;

                // для заданной точности eps
                int currentN = 1;
                double SE = 0.0,
                       nextN = Math.Cos(currentN * X) / currentN;
                do
                {
                    SE += nextN;
                    currentN++;
                    nextN = Math.Cos(currentN * X) / currentN;
                } while (eps <= Math.Abs(nextN));

                Console.WriteLine($"X = {X:N5}\tSN = {SN:N5}\tSE = {SE:N5}\tY = {Y:N5}");
            }
        }
    }
}