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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
    }
}
