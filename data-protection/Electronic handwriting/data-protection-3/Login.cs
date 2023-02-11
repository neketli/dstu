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
    public partial class Login : Form
    {   
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            foreach (var user in Program.Users)
            {
                if (user.Login == LoginForm.Text && user.Password == PassForm.Text)
                {
                    MessageBox.Show("Такой пользователь уже есть!", "Error");
                    return;
                }
            };
            Program.CurrUser.Login = LoginForm.Text;
            Program.CurrUser.Password = PassForm.Text;
            this.Hide();
            Form form = new KeyboardInput("r");
            form.Show();
        }

        private void AcceptBtn_Click(object sender, EventArgs e)
        {
            foreach (var user in Program.Users)
            {
                if (user.Login == LoginForm.Text && user.Password == PassForm.Text)
                {
                    Program.CurrUser = user;
                    this.Hide();
                    Form KeyboardForm = new KeyboardInput("l");
                    KeyboardForm.Show();
                    return;
                }
            };
            MessageBox.Show("Нет такого пользователя!", "Error");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
