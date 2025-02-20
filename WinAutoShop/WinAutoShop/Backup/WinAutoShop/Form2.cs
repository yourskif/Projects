using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinAutoShop
{
    public partial class PersonalDates : Form
    {
//        public event EventHandler ApplyHandler;
        public PersonalDates()
        {
            InitializeComponent();
        }

        public string Name
        {
            get
            {
                return textName.Text;
            }
            //set
            //{
            //    textName.Text = value;
            //}
        }

        public string Code
        {
            get
            {
                return textCode.Text;
            }
            //set
            //{
            //    textCode.Text = value;
            //}
        }

        public string Passport
        {
            get
            {
                return textPassport.Text;
            }
            //set
            //{
            //    textPassport.Text = value;
            //}
        }

        public string Address
        {
            get
            {
                return textAddress.Text;
            }
            //set
            //{
            //    textAddress.Text = value;
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        public void clearText()
        {
            textName.Text = "";
            textCode.Text = "";
            textPassport.Text = "";
            textAddress.Text = "";
        }
    }
}