using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex1_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            string[] strs = NumbersTextBox.Text.Split(' ');

            List<int> numbers = new List<int>();

            foreach (string str in strs)
            {
                int number = 0;
                try
                {
                    number = int.Parse(str);
                    numbers.Add(number);
                }
                catch
                {
                    continue;
                }
            }

            numbers = f(numbers);
            string result = string.Empty;

            foreach (int num in numbers)
                result += num + " ";
            ResultTextBox.Text = $"Во всех трехзначных числах поменяны местами первая и последняя цифры: {result}";
        }

        List<int> f(List<int> num_arr)
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
