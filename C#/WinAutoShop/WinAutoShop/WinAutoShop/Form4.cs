using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinAutoShop
{
    public partial class Report : Form
    {
//        Auto dialog = new Auto();
        public Report()
        {
            InitializeComponent();
        }
        public void Show()
        {
            //MessageBox.Show("Hello!");
            //Auto dialog = new Auto();
            string body = "Report:";
            //if (DialogResult.Yes == dialog.ShowDialog())
            //{
            //}
            //body += "Model- " +dialog.ModelAuto.ToString();
            //MessageBox.Show(body);
            //this.textModelAuto.Text = "HHHH"; //dialog.ModelAuto;
            //MessageBox.Show(dia.ModelAuto.ToString());
            //if (DialogResult.Yes == dialog.ShowDialog())
            //{
            //    string body = "Report:";
            //    body += "Model- " + dialog.ModelAuto.ToString();
            //    this.textModelAuto.Text = dialog.ModelAuto;
            //    MessageBox.Show(dialog.ModelAuto.ToString());
            //}
        }

        public string ModelAuto
        {
            get
            {
                return textModelAuto.Text;
            }
            set
            {
                textModelAuto.Text = value;
            }
        }

        public string Color
        {
            get
            {
                return textColor.Text;
            }
            set
            {
                textColor.Text = value;
            }
        }

        public string Accessories
        {
            get
            {
                return textAccessories.Text;
            }
            set
            {
                textAccessories.Text = value;
            }
        }

        public string Name
        {
            get
            {
                return textf4Name.Text;
            }
            set
            {
                textf4Name.Text = value;
            }
        }

        public string Code
        {
            get
            {
                return textf4Code.Text;
            }
            set
            {
                textf4Code.Text = value;
            }
        }

        public string Passport
        {
            get
            {
                return textf4Passport.Text;
            }
            set
            {
                textf4Passport.Text = value;
            }
        }

        public string Address
        {
            get
            {
                return textf4Address.Text;
            }
            set
            {
                textf4Address.Text = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void textModelAuto_TextChanged(object sender, EventArgs e)
        {

        }

        private void textAccessories_TextChanged(object sender, EventArgs e)
        {

        }
    }
}