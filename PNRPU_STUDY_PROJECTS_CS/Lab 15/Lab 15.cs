namespace Lab15 {
    public class Lab {
        static readonly int MAX = 4;
        static readonly int MAX_THREAD = 4;
        static int[,] matA = new int[MAX, MAX];
        static int[,] matB = new int[MAX, MAX];
        static int[,] matC = new int[MAX, MAX];
        static int step_i = 0;

        class Worker {
            int i;

            public Worker(int i_) {
                i = i_;
            }

            public void Run() {
                for (int j = 0; j < MAX; j++) {
                    for (int k = 0; k < MAX; k++) {
                        matC[i, j] += matA[i, k] * matB[k, j];
                    }
                }
            }
        }

        private static void Initialization() {
            Random rand = new();

            for (int i = 0; i < MAX; i++) {
                for (int j = 0; j < MAX; j++) {
                    matA[i, j] = rand.Next(10);
                    matB[i, j] = rand.Next(10);
                }
            }
        }

        private static void PrintMatrix(int[,] mat, string text) {
            Console.WriteLine(text);
            for (int i = 0; i < MAX; i++) {
                for (int j = 0; j < MAX; j++) {
                    Console.Write($"{mat[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void ShowTaskMenu() {
            Initialization();

            PrintMatrix(matA, "Матрица A:");
            PrintMatrix(matB, "Матрица B:");

            MultithreadingSolve();

            PrintMatrix(matC, "Произведение матрицы A на B:");
        }

        private static void MultithreadingSolve() {
            Thread[] threads = new Thread[MAX_THREAD];

            for (int i = 0; i < MAX_THREAD; i++) {
                threads[i] = new Thread(new Worker(step_i++).Run);
                threads[i].Start();
            }

            for (int i = 0; i < MAX_THREAD; i++) {
                threads[i].Join();
            }
        }
    }
}