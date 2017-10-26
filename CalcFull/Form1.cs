using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcFull
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int a;
        public char op;
        public void btn_plus_Click(object sender, EventArgs e) // для операций
        {
            a = Convert.ToInt32(txtResult.Text);
            op = (sender as Button).Text[0];
            txtResult.Clear();
        }
        public void btn_equal_Click(object sender, EventArgs e) // для результата
        {
                int b = Convert.ToInt32(txtResult.Text);
                int res = Calc(a, b, op);
                txtResult.Text = res.ToString();
        }
        public void btn_zero_Click(object sender, EventArgs e) // для цифр
        {
            txtResult.Text += (sender as Button).Text;
        }
        public int Calc(int a, int b, char op) //расчёт
        {
            int res = 0;
            switch (op)
            {
                case '+':
                    res = a + b;
                    break;
                case '-':
                    res = a - b;
                    break;
                case '*':
                    res = a * b;
                    break;
                case '/':
                    res = a / b;
                    break;
                default:
                    break;
            }
            return res;
        }
    }
}
