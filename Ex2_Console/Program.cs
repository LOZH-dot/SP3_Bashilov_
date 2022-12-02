using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b;
            double h;

            while (true)
            {
                try
                {
                    Console.Write("Введите начальное значение интервала: ");
                    a = double.Parse(Console.ReadLine());

                    Console.Write("Введите конечное значение интервала: ");
                    b = double.Parse(Console.ReadLine());

                    Console.Write("Введите шаг функции: ");
                    h = double.Parse(Console.ReadLine());

                    if (h == 0.0) throw new Exception("Введите шаг отличный от нуля!");
                    if (h < 0.0) throw new Exception("Введите положительный шаг!");
                    if (a > b) throw new Exception("Начальное значение диапазона должно быть меньше конечного!");
                    break;

                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Ошибка: ");
                    Console.ResetColor();
                    Console.WriteLine("Ожидается ввод числа!");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Ошибка: ");
                    Console.ResetColor();
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine($"Результат вычисления функции на интервале [{a}, {b}] с шагом {h}:");
            Console.WriteLine("\t\tx\ty");
            for (double i = a; i <= b; i += h)
            {
                Console.WriteLine($"\t\t{Math.Round(i, 2)}\t{Math.Round(f(i), 2)}");
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
    }
}
