using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanNumeralConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;

            this.button1.Click += new EventHandler(this.button1_Click);
            this.button2.Click += new EventHandler(this.button2_Click);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }
        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
                button2.PerformClick();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (e != null)
            {
                this.KeyUp += new KeyEventHandler(this.Form1_KeyUp);
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (e != null)
            {
                this.KeyUp += new KeyEventHandler(this.Form2_KeyUp);
            }
        }
        
        //
        public static int ToArabic(string num)
        {
            int arabNum = 0;

            const char i = 'I';
            const char v = 'V';
            const char x = 'X';
            const char l = 'L';
            const char c = 'C';
            const char d = 'D';
            const char m = 'M';

            foreach (char item in num)
            {
                switch (item)
                {
                    case i:
                        arabNum++;
                        break;
                    case v:
                        arabNum += 5;
                        break;
                    case x:
                        arabNum += 10;
                        break;
                    case l:
                        arabNum += 50;
                        break;
                    case c:
                        arabNum += 100;
                        break;
                    case d:
                        arabNum += 500;
                        break;
                    case m:
                        arabNum += 1000;
                        break;
                    default:
                        break;
                }
            }

            for (int z = 0; z < num.Length - 1; z++)
            {
                if (num[z] == i && num[z + 1] != i && num[z + 1] != l && num[z + 1] != c && num[z + 1] != d && num[z + 1] != m)
                    arabNum -= 2;
                else if (num[z] == x && num[z + 1] != i && num[z + 1] != v && num[z + 1] != x)
                    arabNum -= 20;
                else if (num[z] == c && num[z + 1] == d && num[z + 1] == m)
                    arabNum -= 100;
            }

            return arabNum;
        }

        public static string mySwitch(int num)
        {
            switch (num)
            {
                case 0: return "";
                case 1: return "I";
                case 2: return "II";
                case 3: return "III";
                case 4: return "IV";
                case 5: return "V";
                case 6: return "VI";
                case 7: return "VII";
                case 8: return "VIII";
                case 9: return "IX";
                default: return "Ошибка";
            }
        }

        public static string ToRoman(string textNum)
        {
            int num = int.Parse(textNum);
            string romeNum = "";
            int x = num / 10 % 10;
            if (num < 10)
            {
                romeNum += mySwitch(num);
            }
            else if (num >= 10 && num < 50)
            {
                if (x == 4)
                {
                    romeNum += "XL";
                    romeNum += mySwitch(num % 10);
                }
                else
                {
                    for (int i = 0; i < num / 10; i++)
                        romeNum += "X";
                    romeNum += mySwitch(num % 10);
                }
            }
            else if (num >= 50 && num < 100)
            {
                if (x == 9)
                {
                    romeNum += "XC";
                    romeNum += mySwitch(num % 10);
                }
                else
                {
                    romeNum += "L";
                    for (int i = 0; i < (num - 50) / 10; i++)
                        romeNum += "X";
                    romeNum += mySwitch(num % 10);
                }

            }
            else if (num >= 100 && num < 500)
            {
                for (int i = 0; i < num / 100; i++)
                    romeNum += "C";
                if (x > 4)
                {
                    if (x == 9)
                    {
                        romeNum += "XC";
                    }
                    else
                    {
                        romeNum += "L";
                        for (int i = 0; i < x - 5; i++)
                            romeNum += "X";
                    }
                }
                else if (x == 4)
                    romeNum += "XL";
                else
                {
                    for (int i = 0; i < x; i++)
                        romeNum += "X";
                }
                if (num % 100 % 10 != 0)
                {
                    romeNum += mySwitch(num % 100 % 10);
                }
            }
            else if (num >= 500 && num < 1000)
            {
                if (num >= 900 && num < 1000)
                {
                    romeNum += "CM";
                }
                else
                {
                    romeNum += "D";
                    for (int i = 0; i < (num - 500) / 100; i++)
                        romeNum += "C";
                }
                if (x > 4)
                {
                    if (x == 9)
                    {
                        romeNum += "XC";
                    }
                    else
                    {
                        romeNum += "L";
                        for (int i = 0; i < x - 5; i++)
                            romeNum += "X";
                    }
                }
                else if (x == 4)
                    romeNum += "XL";
                else
                {
                    for (int i = 0; i < x; i++)
                        romeNum += "X";
                }
                if (num % 100 % 10 != 0)
                {
                    romeNum += mySwitch(num % 100 % 10);
                }
            }
            else if (num >= 1000 && num < 4000)
            {

                for (int i = 0; i < num / 1000; i++)
                    romeNum += "M";
                if (num % 1000 >= 900)
                {
                    romeNum += "CM";
                }
                else if (num % 1000 >= 500 && num % 1000 < 900)
                {
                    romeNum += "D";
                    for (int i = 0; i < (num-500) % 1000 / 100; i++)
                        romeNum += "C";
                }
                else if (num % 1000 < 500 && num % 1000 >= 100)
                {
                    if (num % 1000 / 100 == 4)
                    {
                        romeNum += "CD";
                    }
                    else
                        for (int i = 0; i < num % 1000 / 100; i++)
                            romeNum += "C";
                }
                if (num % 100 / 10 > 4)
                {
                    if (x == 9)
                    {
                        romeNum += "XC";
                    }
                    else
                    {
                        romeNum += "L";
                        for (int i = 0; i < x - 5; i++)
                            romeNum += "X";
                    }
                }
                else if (num % 100 / 10 == 4)
                    romeNum += "XL";
                else
                {
                    for (int i = 0; i < x; i++)
                        romeNum += "X";
                }
                if (num % 100 % 10 != 0)
                {
                    romeNum += mySwitch(num % 100 % 10);
                }
            }

            return romeNum;
        }
        //

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            textBox3.Text = ToArabic(text.ToUpper()).ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = textBox2.Text;
            textBox4.Text = ToRoman(text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
