using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinAutoShop
{
    public partial class Auto : Form
    {
        //Accessories Accessories;
        //PersonalDates PersonalDates;
        //Report Report;
        public Auto()
        {
            InitializeComponent();
            //Accessories = new Accessories();
            //Accessories.Owner = this;
            //Peport= new Report();
            //Report.Owner=this;
        }

        public string Name
        {
            get
            {
                return textName.Text;
            }
            set
            {
                textName.Text = value;
            }
        }

        public string Code
        {
            get
            {
                return textCode.Text;
            }
            set
            {
                textCode.Text = value;
            }
        }

        public string Passport
        {
            get
            {
                return textPassport.Text;
            }
            set
            {
                textPassport.Text = value;
            }
        }

        public string Address
        {
            get
            {
                return textAddress.Text;
            }
            set
            {
                textAddress.Text = value;
            }
        }

        public string ModelAuto
        {
            get
            {
                return comboBoxModelAuto.SelectedItem.ToString();
            }
            set
            {
                comboBoxModelAuto.Items.Add(value);
            }
        }

        public string Color
        {
            get
            {
                for (int i = 0; i < groupBox1.Controls.Count; i++)
                {
                    RadioButton rb = (RadioButton)groupBox1.Controls[i];
                    if (rb.Checked)
                        return rb.Text;
                }
                return "";
            }
            set
            {
                if (this.Color.ToString() == "red")
                {
                    //radioButton1.AutoCheck;
                }

            }
        }

        public string Accessories
        {
            //get 
            //{
            //    return listBox1.SelectedItems.ToString();
            //}
            get
            {
                string ss = " ";
                foreach (string s in listBox1.Items)
                {
                    ss = s;
                }
                return ss;
            }
            set
            {
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="Audi")
            {
                pictureBox1.Image = Image.FromFile("audi.jpg");
            }
            if(textBox1.Text=="audi")
            {
                pictureBox1.Image = Image.FromFile("audi.jpg");
            }
            if (textBox1.Text == "BMV")
            {
                pictureBox1.Image = Image.FromFile("bmv.jpg");
            }
            if (textBox1.Text == "bmv")
            {
                pictureBox1.Image = Image.FromFile("bmv.jpg");
            }
            comboBoxModelAuto.Items.AddRange(new object[] { textBox1.Text });
            textBox1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBoxModelAuto.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add(textBox2.Text);
            textBox2.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PersonalDates dialog = new PersonalDates();
            //PersonalDates.ShowDialog();                                  
            if (DialogResult.Yes == dialog.ShowDialog())
            {
                textName.Text = dialog.Name;
                textCode.Text = dialog.Code;
                textPassport.Text = dialog.Passport;
                textAddress.Text = dialog.Address;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Accessories dialog = new Accessories();
            //Accessories.ShowDialog();
            if (DialogResult.Yes == dialog.ShowDialog())
            {
                listBox1.Items.Add(dialog.ItemListBox);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Report dialog = new Report();
            //if (DialogResult.Yes == dialog.ShowDialog())
            //{
            dialog.ModelAuto = this.ModelAuto;
            dialog.Accessories = this.Accessories;
            dialog.Color = this.Color;
            dialog.Name = this.Name;
            dialog.Code = this.Code;
            dialog.Passport = this.Passport;
            dialog.Address = this.Address;

            //this.comboBoxModelAuto.Items.Clear();
            //this.listBox1.Items.Clear();

            dialog.ShowDialog();
            //MessageBox.Show(dialog.ModelAuto.ToString());
            //    dialog.Show();
            //}

        }

        private void PropertyForm_Apply(object sender, System.EventArgs e)
        {
            //PropertyForm dialog = (PropertyForm)sender;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //listBox1  .Items.Clear();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textRemove_Click(object sender, EventArgs e)
        {
            this.textName.Text = "";
            this.textCode.Text = "";
            this.textPassport.Text = "";
            this.textAddress.Text = "";
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            //Auto dialog = new Auto();
            //string modelauto = dialog.ModelAuto;
            XmlTextWriter xmlwriter = new XmlTextWriter("AutoShop.xml", null);
            //xmlwriter.WriteStartDocument();
            xmlwriter.WriteStartElement("AutoShop");

            xmlwriter.WriteStartElement("model");
            xmlwriter.WriteString(this.ModelAuto);
            xmlwriter.WriteEndElement();
            xmlwriter.WriteStartElement("color");
            xmlwriter.WriteString(this.Color);
            xmlwriter.WriteEndElement();
            xmlwriter.WriteStartElement("accessories");
            xmlwriter.WriteString(this.Accessories);
            xmlwriter.WriteEndElement();
            xmlwriter.WriteStartElement("name");
            xmlwriter.WriteString(this.Name);
            xmlwriter.WriteEndElement();
            xmlwriter.WriteStartElement("code");
            xmlwriter.WriteString(this.Code);
            xmlwriter.WriteEndElement();
            xmlwriter.WriteStartElement("passport");
            xmlwriter.WriteString(this.Passport);
            xmlwriter.WriteEndElement();
            xmlwriter.WriteStartElement("address");
            xmlwriter.WriteString(this.Address);
            xmlwriter.WriteEndElement();

            xmlwriter.WriteEndElement();
            //xmlwriter.WriteEndDocument();
            xmlwriter.Close();

            //System.Data.DataSet ds = new DataSet();
            //ds.WriteXml("result.xml");
        }

        private void LoadFile_Click(object sender, EventArgs e)
        {
            XmlTextReader reader = new XmlTextReader("AutoShop.xml");
            string[] order = new string[8];
            int i=0;
            while (reader.Read())
            {
                //enum order ("model","color","accessories","data","code","name","address");
                if (reader.NodeType == XmlNodeType.Element)
                {
                    reader.Read();
                    //MessageBox.Show(reader.NodeType.ToString());
                    //MessageBox.Show(reader.Value);
                    //if (reader.Value != "")
                    //{
                        order[i] = reader.Value;
                        MessageBox.Show(i.ToString(),order[i]);
                        i = i + 1;
                    //}
                }
                else
                {
                    //MessageBox.Show(reader.NodeType.ToString());
                    //MessageBox.Show(reader.Value);
                }
            }

            //for (int ii = 0; ii < 7; ii++)
            //    MessageBox.Show(order[ii].ToString());
            this.Color=order[1];
            this.Accessories = order[2];
            this.Name=order[3];
            this.Code = order[4];
            this.Passport=order[5];
            this.Address=order[6];
            }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}