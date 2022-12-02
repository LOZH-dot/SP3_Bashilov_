using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a, b;
            double h;

            while (true)
            {
                try
                {
                    Console.Write("Введите начальное значение диапазона: ");
                    a = double.Parse(Console.ReadLine());

                    Console.Write("Введите конечное значение диапазона: ");
                    b = double.Parse(Console.ReadLine());

                    Console.Write("Введите шаг фунуции: ");
                    h = double.Parse(Console.ReadLine());

                    if (h == 0.0) throw new Exception("Введите шаг отличный от нуля!");
                    if (h < 0.0) throw new Exception("Введите положительный шаг!");
                    if (a > b) throw new Exception("Начальное значение диапазона должно быть меньше конечного!");
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введены некорректные значения!");
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    return;
                }
            }

            Console.WriteLine($"Результат вычисления функции на интервале [{a}, {b}] с шагом {h}:");
            Console.WriteLine("\t\tx\ty");
            for (double i = a; i <= b; i += h)
            {
                double y = 0.0;
                f(i, out y);
                Console.WriteLine($"\t\t{i}\t{y}");
            }
        }

        static double f(double x)
        {
            double result = 0.0;

            if (x < 0.0) result = 0;
            else if (x >= 0 && x != 1) result = x * x + 1;
            else if (x == 1) result = 1;

            return result;
        }

        static void f(double x, out double y)
        {
            double result = 0.0;

            if (x < 0.0) result = 0;
            else if (x >= 0 && x != 1) result = x * x + 1;
            else if (x == 1) result = 1;

            y = result;
        }
    }
}
