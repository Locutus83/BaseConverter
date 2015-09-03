using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseConverter
{
    public partial class Form1 : Form
    {
        const string CONVERSION_STRING = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public Form1()
        {
            InitializeComponent();
        }

        private enum ComboBoxValues : int
        {
            _02 = 0,
            _03 = 1,
            _04 = 2,
            _05 = 3,
            _06 = 4,
            _07 = 5,
            _08 = 6,
            _09 = 7,
            _10 = 8,
            _11 = 9,
            _12 = 10,
            _13 = 11,
            _14 = 12,
            _15 = 13,
            _16 = 14,
            _17 = 15,
            _18 = 16,
            _19 = 17,
            _20 = 18,
            _21 = 19,
            _22 = 20,
            _23 = 21,
            _24 = 22,
            _25 = 23,
            _26 = 24,
            _27 = 25,
            _28 = 26,
            _29 = 27,
            _30 = 28,
            _31 = 29,
            _32 = 30,
            _33 = 31,
            _34 = 32,
            _35 = 33,
            _36 = 34
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbFrom.SelectedIndex = (int)ComboBoxValues._10;
            cmbTo.SelectedIndex = (int)ComboBoxValues._36;
        }

        private int ConvertToBase10(string str)
        {
            int workingValue = 0;

            for (int j = str.Length - 1; j >= 0; j-- )
            {
                for (int i = 0; i < CONVERSION_STRING.Length; i++)
                {
                    if (str[j] == CONVERSION_STRING[i])
                    {
                        workingValue += i * (int)Math.Pow(10, j);
                        break;
                    }
                }
            }

            return workingValue;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            int convertedArray = ConvertToBase10(txtFrom.Text);

            txtTo.Text = ConvertToBase(int.Parse(txtFrom.Text), 36);
        }

        public String ConvertToBase(int num, int nbase)
        {
            String chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            // check if we can convert to another base
            if (nbase < 2 || nbase > chars.Length)
                return "";

            int r;
            String newNumber = "";

            // in r we have the offset of the char that was converted to the new base
            while (num >= nbase)
            {
                r = num % nbase;
                newNumber = chars[r] + newNumber;
                num = num / nbase;
            }
            // the last number to convert
            newNumber = chars[num] + newNumber;

            return newNumber;
        }
    }
}
