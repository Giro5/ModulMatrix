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
            Console.Write("Введите количество столбцов: ");
            int n = Convert.ToInt32(Console.ReadLine());
            double[,] c1 = new double[n, n], c2 = new double[n, n];
            Console.Clear();
            Matrix mx = new Matrix();
            Console.WriteLine("Введите данные первой матрицы: ");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Console.SetCursorPosition((j * 4) + 2, i + 1);
                    c1[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            Console.WriteLine("Введите данные второй матрицы: ");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Console.SetCursorPosition((j * 4) + 2, i + 2 + n);
                    c2[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            Console.SetCursorPosition(0, n + n + 2);
            Console.WriteLine("Сумма двух матриц равна: ");
            mx.Print(mx.Sum(c1, c2));
            Console.WriteLine("Умножение двух матриц равно: ");
            mx.Print(mx.Multiplication(c1, c2));
            Console.WriteLine("Транспонирование матрицы равно: ");
            mx.Print(mx.Transpose(c1));
            Console.WriteLine($"Определитель матрицы равен: {mx.Determinant(c1)}");
            Console.ReadKey();
        }
    }
    class Matrix
    {
        public double[,] Sum(double[,] a, double[,] b)
        {
            double[,] res = new double[a.GetLength(0), a.GetLength(0)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(0); j++)
                    res[i, j] = a[i, j] + b[i, j];
            return res;
        }
        public double[,] Multiplication(double[,] a, double[,] b)
        {
            double[,] res = new double[a.GetLength(0), a.GetLength(0)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(0); j++)
                    for (int k = 0; k < a.GetLength(0); k++)
                        res[i, j] += a[i, k] * b[k, j];
            return res;
        }
        public double[,] Transpose(double[,] a)
        {
            double[,] res = new double[a.GetLength(0), a.GetLength(0)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(0); j++)
                    res[i, j] = a[j, i];
            return res;
        }
        public double Determinant(double[,] a)
        {
            double res = 0, tmp1, tmp2;
            if (a.GetLength(0) == 1)
                res = a[0, 0];
            else if (a.GetLength(0) == 2)
                res = a[0, 0] * a[1, 1] - a[1, 0] * a[0, 1];
            else if (a.GetLength(0) == 3)
            {
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(0); j++)
                    {
                        for(int k = 0; k < a.GetLength(0); k++)
                        {

                        }
                    }
            }
            return res;
        }

        public void Print(double[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(0); j++)
                    Console.Write($"  {a[i, j]}");
                Console.WriteLine();
            }
        }
    }
}
