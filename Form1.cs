using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public long b = 1;
        public double a;
        public int c = 1;

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(comboBox1, "Выберите изначальную величину информации");
            toolTip2.SetToolTip(comboBox2, "Выберите величину, в которую хотите конвертировать");
            toolTip3.SetToolTip(button1, "Нажмите для конвертирования");
            toolTip4.SetToolTip(comboBox3, "Выберите вводимую систему счисления");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    a = Convert.ToDouble(textBox1.Text) * Convert.ToDouble(b);
                    textBox2.Text = Convert.ToString(a);
                    break;
                case 1:
                    a = Convert.ToDouble(textBox1.Text) * Convert.ToDouble(b) / 8.0;
                    textBox2.Text = Convert.ToString(a);
                    break;
                case 2:
                    a = Convert.ToDouble(textBox1.Text) * Convert.ToDouble(b) / 8192.0;
                    textBox2.Text = Convert.ToString(a);
                    break;
                case 3:
                    a = Convert.ToDouble(textBox1.Text) * Convert.ToDouble(b) / 8388608.0;
                    textBox2.Text = Convert.ToString(a);
                    break;
                case 4:
                    a = Convert.ToDouble(textBox1.Text) * Convert.ToDouble(b) / 8589934592.0;
                    textBox2.Text = Convert.ToString(a);
                    break;
                case 5:
                    a = Convert.ToDouble(textBox1.Text) * Convert.ToDouble(b) / 8796093022208.0;
                    textBox2.Text = Convert.ToString(a);
                    break;

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    b = 1; break;
                case 1:
                    b = 8; break;
                case 2:
                    b = 8192; break;
                case 3:
                    b = 8388608; break;
                case 4:
                    b = 8589934592; break;
                case 5:
                    b = 8796093022208; break;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    c = 2; break;
                case 1:
                    c = 8; break;
                case 2:
                    c = 10; break;
                case 3:
                    c = 16; break;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
            {
                e.Handled = true;
                MessageBox.Show("Вводите только числа!", "Ошибка");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    if ((e.KeyChar <= 47 || e.KeyChar >= 50) && e.KeyChar != 8)
                    {
                        e.Handled = true;
                        MessageBox.Show("Вводите только двоичные числа. Например : 0101101!", "Ошибка!");
                    }
                    break;
                case 1:
                    if ((e.KeyChar <= 47 || e.KeyChar >= 56) && e.KeyChar != 8)
                    {
                        e.Handled = true;
                        MessageBox.Show("Вводите только восьмеричные числа. От 0 до 7!", "Ошибка!");
                    }
                    break;
                case 2:
                    if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                    {
                        e.Handled = true;
                        MessageBox.Show("Вводите только десятичные числа. От 0 до 9!", "Ошибка!");
                    }
                    break;
                case 3:
                    if ((e.KeyChar <= 47 || e.KeyChar >= 58) && (e.KeyChar <= 64 || e.KeyChar >= 71) && (e.KeyChar <= 96 || e.KeyChar >= 103) && e.KeyChar != 8)
                    {
                        e.Handled = true;
                        MessageBox.Show("Вводите только шестнадцатиричное число. Например : 3D5!", "Ошибка");
                    }
                    break;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox4.Text = textBox4.Text.Insert(textBox4.GetFirstCharIndexFromLine(0), Convert.ToString(Convert.ToInt16(textBox3.Text,c), 2));
            }
            else textBox4.Text = textBox4.Text.Remove(textBox4.GetFirstCharIndexFromLine(0), textBox4.Lines[0].Length);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox4.Text = textBox4.Text.Insert(textBox4.GetFirstCharIndexFromLine(2), Convert.ToString(Convert.ToInt16(textBox3.Text,c), 8));
            }
            else textBox4.Text = textBox4.Text.Remove(textBox4.GetFirstCharIndexFromLine(2), textBox4.Lines[2].Length);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                textBox4.Text = textBox4.Text.Insert(textBox4.GetFirstCharIndexFromLine(4), Convert.ToString(Convert.ToInt16(textBox3.Text,c), 10));
            }
            else textBox4.Text = textBox4.Text.Remove(textBox4.GetFirstCharIndexFromLine(4), textBox4.Lines[4].Length);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                textBox4.Text = textBox4.Text.Insert(textBox4.GetFirstCharIndexFromLine(6), Convert.ToString(Convert.ToInt16(textBox3.Text,c), 16));
            }
            else textBox4.Text = textBox4.Text.Remove(textBox4.GetFirstCharIndexFromLine(6), textBox4.Lines[6].Length);
        }
    }
}
