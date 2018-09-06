using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practika2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество рядов: ");
            int n = Convert.ToInt32(Console.ReadLine());
            double[,] c1 = new double[n, n], c2 = new double[n, n];
            Console.Clear();
            Matrix mx = new Matrix();
            Console.WriteLine("Введите данные первой матрицы: ");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Console.SetCursorPosition((j * 4) + 3, i + 1);
                    c1[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            Console.WriteLine("Введите данные второй матрицы: ");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Console.SetCursorPosition((j * 4) + 3, i + 2 + n);
                    c2[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            Console.WriteLine("Сумма двух матриц равна: ");
            mx.Print(mx.Sum(c1, c2));
            Console.WriteLine("Умножение двух матриц равно: ");
            mx.Print(mx.Multiplication(c1, c2));
            Console.WriteLine("Транспонирование матриц равно: ");
            mx.Print(mx.Transpose(c1));
            Console.WriteLine();
            mx.Print(mx.Transpose(c2));
            Console.WriteLine($"Определители матриц равны: {mx.Determinant(c1)}, {mx.Determinant(c2)}");
            Console.ReadKey();
        }
    }
    class Matrix
    {
        public double[,] Sum(double[,] a, double[,] b)
        {
            int n = a.GetLength(0);
            double[,] res = new double[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    res[i, j] = a[i, j] + b[i, j];
            return res;
        }
        public double[,] Multiplication(double[,] a, double[,] b)
        {
            int n = a.GetLength(0);
            double[,] res = new double[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    for (int k = 0; k < n; k++)
                        res[i, j] += a[i, k] * b[k, j];
            return res;
        }
        public double[,] Transpose(double[,] a)
        {
            int n = a.GetLength(0);
            double[,] res = new double[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    res[i, j] = a[j, i];
            return res;
        }
        public double Determinant(double[,] a)
        {
            int n = a.GetLength(0), m = n - 1;
            double res = 0;
            if (n == 1)
                res = a[0, 0];
            else if (n >= 2)
            {
                for (int i = 0; i < n; i++)
                {
                    double tmp = a[0, i];
                    double[,] b = new double[m, m];
                    for (int j = 0; j < m; j++)
                    {
                        for (int k = 0; k < m; k++)
                        {
                            if (i == 0 || k >= i)
                                b[j, k] = a[j + 1, k + 1];
                            else if (i == m || k < i)
                                b[j, k] = a[j + 1, k];
                        }
                    }
                    if (i % 2 == 0)
                        res += tmp * Determinant(b);
                    else
                        res -= tmp * Determinant(b);
                }
            }
            return res;
        }
        public void Print(double[,] a)
        {
            int n = a.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write($"{a[i, j],4}");
                Console.WriteLine();
            }
        }
    }
}
