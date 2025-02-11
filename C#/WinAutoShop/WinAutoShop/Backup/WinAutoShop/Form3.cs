using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinAutoShop
{
    public partial class Accessories : Form
    {
        public Accessories()
        {
            InitializeComponent();
        }

        public string ItemListBox
        {
            get
            {
                return listBoxAccessories.SelectedItem.ToString();
            }
            set
            {
                listBoxAccessories.Items.Add(value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBoxAccessories.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBoxAccessories.Items.Add(textAccessories.Text);
            textAccessories.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void listBoxAccessories_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}