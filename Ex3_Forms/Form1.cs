using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex3_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            double a, b;
            double h;

            try
            {
                a = double.Parse(ATextBox.Text);
                b = double.Parse(BTextBox.Text);
                h = double.Parse(HTextBox.Text);

                if (h == 0.0) throw new Exception("Введите шаг отличный от нуля!");
                if (h < 0.0) throw new Exception("Введите положительный шаг!");
                if (a > b) throw new Exception("Начальное значение диапазона должно быть меньше конечного!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Введены некорректные значения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            ResultTextBox.Clear();
            ResultTextBox.Text += ($"Результат вычисления функции на интервале [{a}, {b}] с шагом {h}:\n");
            ResultTextBox.Text += ("\tx\ty\n");
            for (double i = a; i <= b; i += h)
            {
                double y = 0.0;
                f(i, out y);
                ResultTextBox.Text += ($"\t{i}\t{y}\n");
            }
        }

        private double f(double x)
        {
            double result = 0.0;

            if (x < 0.0) result = 0;
            else if (x >= 0 && x != 1) result = x * x + 1;
            else if (x == 1) result = 1;

            return result;
        }

        private void f(double x, out double y)
        {
            double result = 0.0;

            if (x < 0.0) result = 0;
            else if (x >= 0 && x != 1) result = x * x + 1;
            else if (x == 1) result = 1;

            y = result;
        }
    }
}
