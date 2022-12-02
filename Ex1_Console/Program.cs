using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            Console.WriteLine("Введите числа, которые будут проверятся (напишите stop для продолжения работы программы): ");
            while (true)
            {
                int number = 0;
                try
                {

                    Console.Write("Введите целое число: ");
                    string cmd = Console.ReadLine();

                    if (cmd == "stop") break;
                    number = int.Parse(cmd);

                    numbers.Add(number);
                    
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

            numbers = f(numbers);

            Console.Write("Во всех трехзначных числах поменяны местами первая и последняя цифры: ");

            foreach (int num in numbers)
                Console.Write(num + " ");

            Console.WriteLine();

        }

        static List<int> f(List<int> num_arr)
        {
            List<int> result_arr = new List<int>();

            foreach (int num in num_arr)
            {
                int abs_number = Math.Abs(num);

                if (abs_number.ToString().Length != 3) result_arr.Add(num);
                else
                {
                    int first = abs_number / 100;
                    int second = abs_number % 100 / 10;
                    int third = abs_number % 100 % 10;

                    if (num < 0) result_arr.Add(int.Parse($"-{third}{second}{first}"));
                    else result_arr.Add(int.Parse($"{third}{second}{first}"));
                }
            }

            return result_arr;
        }
    }
}
