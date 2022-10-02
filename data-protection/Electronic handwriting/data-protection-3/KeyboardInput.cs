using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace data_protection_3
{
    public partial class KeyboardInput : Form
    {
        List<string> str = new List<string>();
        string currText = "";
        Random rand = new Random();
        List<int> timer = new List<int>();
        DateTime tempDate;
        string State;

        double accuracy = 10.0;

        double Value;
        double Delta;

        int counter = 0;

        public KeyboardInput(string state)
        {
            InitializeComponent();
            State = state;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.counter = 0;
            label2.Text = State == "l"? $"Добро пожаловать, {Program.CurrUser.Login}" : "Регистрация";
            str.Add("Зелёная зелень зеленит зелёную зелень");
            str.Add("Сегодняшний день был тяжёлым");
            currText = State == "l" ? Program.CurrUser.Key : str[rand.Next(0, str.Count)];
            label3.Text = $"Введите следующий текст:\n {currText}";
            this.timer = new List<int>();

        }

        void CalculateSpeedRegister()
        {
            this.Value = timer.Sum() / currText.Length;
            this.Delta = (timer.Sum() - Value) / currText.Length;
            Program.CurrUser.Value = Value;
            Program.CurrUser.Delta = Delta;
        }

        bool CalculateSpeed()
        {
            double locValue = timer.Sum() / currText.Length;
            double locDelta = (timer.Sum() - Value) / currText.Length;
            Console.WriteLine(locValue);
            if (Math.Abs(Program.CurrUser.Value - locValue) < accuracy && Math.Abs(Program.CurrUser.Delta - locDelta) < accuracy)
            {
                return true;
            }
            return false;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form LoginForm = new Login();
            LoginForm.Show();
        }

        private void AcceptBtn_Click(object sender, EventArgs e)
        {
            if (State == "l")
            {
                if (TextBox.Text == currText)
                {
                    if (CalculateSpeed()) MessageBox.Show("Доступ предоставлен", "Успех");
                    else MessageBox.Show("Кажется это не вы", "Ошибка");
                    
                }
                else MessageBox.Show("Ввод неверный, доступ отклонён", "Ошибка");
            } else if (State == "r")
            {
                if (TextBox.Text == currText && counter == 1)
                {
                    CalculateSpeedRegister();
                    Program.CurrUser.Key = currText;
                    Program.Users.Add(Program.CurrUser);
                    Console.WriteLine(Program.CurrUser.Value);
                    MessageBox.Show("Регистрация прошла успешно", "Успех");
                }
                else if (TextBox.Text == currText)
                {
                    TextBox.Text = "";
                    timer.Clear();
                    counter++;
                }
                else
                {
                    timer.Clear();
                    TextBox.Text = "";
                }
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            tempDate = DateTime.Now;
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            timer.Add((DateTime.Now - tempDate).Milliseconds);
        }
    }
}
