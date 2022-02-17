using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int t = 1;
        int k = 4;
        int n = 7;
        private void bStart_Click(object sender, EventArgs e)
        {
            Polynom p1 = new Polynom(tbP1.Text);
            Polynom p2 = new Polynom(tbP2.Text);
            string s1 = p1;
            string s2 = p2;
            StringBuilder s3 = new StringBuilder(Polynom.MakeString(s2.Length));
            s3[0] = '1';
            p1 = p1 * new Polynom(s3.ToString());
            p1 += Polynom.Mod(p1, p2);
            tbCoded.Text = p1;
            if (tbP1.Text.Length != k)
            {
                MessageBox.Show("Длина сообщения должна быть " + k + " бит!");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbCoded.Text.Length != n)
            {
                MessageBox.Show("Кодовое слово должны быть длиной " + n + " бит!");
                return;
            }
            tbLog.Clear();
            Polynom p1 = new Polynom(tbCoded.Text);
            Polynom p2 = new Polynom(tbP2.Text);
            Polynom remainder = Polynom.Mod(p1, p2);
            if (remainder == "")
            {
                tbResult.ForeColor = Color.Black;
            }
            else
            {
                tbResult.ForeColor = Color.Red; 
            }
            string s1 = p1;
            tbResult.Text = s1.Substring(0, k);
        }

        int OnesCount(string s)
        {
            int sum = 0;
            foreach (char c in s)
            {
                if (c == '1') sum++;
            }
            return sum;
        }

        private void bCorrect_Click(object sender, EventArgs e)
        {
            if (tbCoded.Text.Length != n)
            {
                MessageBox.Show("Кодовое слово должны быть длиной " + n + " бит!");
                return;
            }
            tbLog.Clear();
            Polynom p1 = new Polynom(tbCoded.Text);
            int n1 = ((string)p1).Length;
            Polynom p2 = new Polynom(tbP2.Text);
            tbResult.ForeColor = Color.Black;
            {
                string remainder = Polynom.Mod(p1, p2);
                if (remainder == "") remainder = "0";
                tbLog.AppendText("Приняли: " + p1 + "\r\n");
                tbLog.AppendText("Остаток: " + remainder + "\r\n");
            }
            int shifts = 0;
            while (true)
            {
                Polynom polyRemainder = Polynom.Mod(p1, p2);;
                string remainder = polyRemainder;
                tbLog.AppendText("Кодовое слово: " + p1 + "\r\n");
                tbLog.AppendText("Остаток: " + remainder + "\r\n");
                if (OnesCount(remainder) > t)
                {
                    tbLog.AppendText("Слишком много единиц! Делаем сдвиг влево:\r\n");
                    string s = p1;
                    s = s.Substring(1) + s[0];
                    p1 = new Polynom(s);
                    shifts++;
                }
                else
                {
                    tbLog.AppendText("Получилось! Исправляем многочлен:\r\n");
                    p1 = p1 + polyRemainder;
                    tbLog.AppendText(p1 + "\r\n");
                    break;
                }
            }
            tbLog.AppendText("Теперь сдвигаем его вправо на "+shifts+":\r\n");
            for (int i = 0; i < shifts; i++)
            {
                string s = p1;
                if (s.Length < n1)
                {
                    while (s.Length < n1)
                    {
                        s = '0' + s;
                    }
                }
                s = s[s.Length-1] + s.Substring(0, s.Length-1);
                p1 = new Polynom(s);
            }
            tbLog.AppendText(p1 + "\r\n");
            tbCoded.Text = p1;
            tbResult.Text = ((string)p1).Substring(0, k);
            /*foreach (var elem in maps[mapIndex])
            {
                tbLog.AppendText(elem.Value + "  " + elem.Key + "\r\n");
            }
            Polynom result = (p1 + maps[mapIndex][remainder]) / p2;
            tbResult.Text = result;*/
        }

        private void bChoose1_Click(object sender, EventArgs e)
        {
            tbP2.Text = "1011";
            label1.Text = "Информационный код: (размер 4)";
            tbP1.Text = "1101";
            t = 1;
            k = 4;
            n = 7;
        }

        private void bChoose2_Click(object sender, EventArgs e)
        {
            tbP2.Text = "111010001";
            label1.Text = "Информационный код: (размер 7)";
            tbP1.Text = "1101010";
            t = 2;
            k = 7;
            n = 15;
        }

        private void bChoose3_Click(object sender, EventArgs e)
        {
            tbP2.Text = "10100110111";
            label1.Text = "Информационный код: (размер 5)";
            tbP1.Text = "11010";
            t = 3;
            k = 5;
            n = 15;
        }

        private void bAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("А нет");
        }

       
    }
}
