namespace Calculator
{
    public partial class Form1 : Form
    {
        // Переменные для хранения состояния калькулятора
        private double resultValue = 0;
        private string operationPerformed = "";
        private bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        // 1. Обработка нажатия цифр (0-9) и десятичной точки
        private void Number_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Error")
            {
                button13.PerformClick();
            }
            if ((textBox1.Text == "0") || (isOperationPerformed))
                textBox1.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;

            // Проверка, чтобы не было нескольких точек
            if (button.Text == "." && textBox1.Text.Contains("."))
                return;

            textBox1.Text = textBox1.Text + button.Text;
        }

        // 2. Обработка арифметических операций (+, -, *, /, x^y)
        private void Operator_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Error")
            {
                button13.PerformClick();
            }
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                button12.PerformClick();
                operationPerformed = button.Text;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = Convert.ToDouble(textBox1.Text);
                isOperationPerformed = true;
            }
        }
        // 3. Обработка кнопки "Равно" (=)
        private void BtnEquals_Click(object sender, EventArgs e)
        {

            double secondOperand = Convert.ToDouble(textBox1.Text);

            if (textBox1.Text == "Error")
            {
                button13.PerformClick();
            }

            if (operationPerformed == "+")
            {
                textBox1.Text = (resultValue + secondOperand).ToString();
            }
            if (operationPerformed == "-")
            {
                textBox1.Text = (resultValue - secondOperand).ToString();
            }
            if (operationPerformed == "*")
            {
                textBox1.Text = (resultValue * secondOperand).ToString();
            }
            if (operationPerformed == "/")
            {
                if (secondOperand == 0)
                {
                    textBox1.Text = "Error"; // Защита от деления на ноль
                    MessageBox.Show("Деление на ноль невозможно!");
                    return;
                }
                textBox1.Text = (resultValue / secondOperand).ToString();
            }
            if (operationPerformed == "x^y")
            {
                textBox1.Text = Math.Pow(resultValue, secondOperand).ToString();
            }


            resultValue = Convert.ToDouble(textBox1.Text);
            operationPerformed = ""; // Сброс операции

        }

        // 4. Тригонометрия и функции одного аргумента (sin, cos, sqrt, etc.)
        private void AdvancedMath_Click(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            double inputValue = Double.Parse(textBox1.Text);
            double result = 0;

            if (textBox1.Text == "Error")
            {
                button13.PerformClick();
            }

            // Проверка режима: Градусы или Радианы
            bool isDegrees = rbDegrees.Checked;

            if (button.Text == "sin")
            {
                if (isDegrees)
                {
                    result = Math.Sin(DegreesToRadians(inputValue));
                }
                else
                {
                    result = Math.Sin(inputValue);
                }
            }
            if (button.Text == "cos")
            {
                if (isDegrees)
                {
                    result = Math.Cos(DegreesToRadians(inputValue));
                }
                else
                {
                    result = Math.Cos(inputValue);
                }
            }
            if (button.Text == "tg")
            {
                if (isDegrees)
                {
                    result = Math.Tan(DegreesToRadians(inputValue));
                }
                else
                {
                    result = Math.Tan(inputValue);
                }
            }
            if (button.Text == "ctg")
            {
                double tan;
                if (isDegrees)
                {
                    if (isDegrees)
                    {
                        tan = Math.Tan(DegreesToRadians(inputValue));
                    }
                    else
                    {
                        tan = Math.Tan(inputValue);
                    }
                    if (tan == 0)
                    {
                        textBox1.Text = "Error";
                        MessageBox.Show("Котангенс не определен.");
                        return;
                    }
                    result = 1.0 / tan;
                }
                else
                {
                    tan = Math.Tan(DegreesToRadians(inputValue));
                    if (tan == 0)
                    {
                        textBox1.Text = "Error";
                        MessageBox.Show("Котангенс не определен.");
                        return;
                    }
                    result = 1.0 / tan;
                }
            }
            if (button.Text == "√")
            {
                if (inputValue < 0)
                {
                    textBox1.Text = "Error";
                    MessageBox.Show("Нельзя извлечь корень из отрицательного числа!");
                    return;
                }
                result = Math.Sqrt(inputValue);
            }
            if (button.Text == "%")
            {
                result = inputValue / 100.0;
            }
            if (button.Text == "±")
            {
                result = -inputValue;
                textBox1.Text = result.ToString();
                return;
            }

            textBox1.Text = result.ToString();
            isOperationPerformed = true; // Чтобы следующее число начало новый ввод

        }

        // Вспомогательный метод перевода градусов в радианы
        private double DegreesToRadians(double degrees)
        {
            return (degrees * Math.PI) / 180.0;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            resultValue = 0;
            operationPerformed = "";
        }

        // 5. Константы (Pi, E)
        private void Constants_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "π")
                textBox1.Text = Math.PI.ToString();
            else if (button.Text == "e")
                textBox1.Text = Math.E.ToString();

            isOperationPerformed = true;
        }

        private void BtnBackspace_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }
            if (textBox1.Text == "")
            {
                textBox1.Text = "0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
