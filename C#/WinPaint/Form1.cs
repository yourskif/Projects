using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WinPaint
{
    public enum EnumDraw
    {
        DrawAfrerMouse = 0,
        DrawCommonLine,
        DrawEmptyRectangle,
        DrawFillRectangle,
        DrawEmptyEllipse,
        DrawFillEllipse
    };
    public partial class Form1 : Form
    {
        ArrayList PointArray = new ArrayList();
        //FormSize fSizeImage;
        const int Empty_BitmapWidth = 800;
        const int Empty_BitmapHeigth = 600;
        Bitmap curBitmap;
        Graphics gr;
        bool mustSaveBitmap;
        EnumDraw drawObject = EnumDraw.DrawAfrerMouse;
        Color currentColor = Color.Black;
        int currentWidth = 2;
        Pen currentPen = new Pen(Color.Black, 2);
        bool mustDraw = false;
        Point ptLast;
        Point ptBegin;
        Rectangle rectForFigures = new Rectangle();

        public Form1()
        {
            InitializeComponent();
            CreateEmptyBitmap();
            Invalidate();
        }

        protected void CreateEmptyBitmap()
        {
            if (this.pictureBox1.Image != null)
            {
                DialogResult result = MessageBox.Show(
                      "Save in file \"" + this.Text + "\"?",
                      "MyPaint", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Cancel:
                        return;
                    case DialogResult.No:
                        mustSaveBitmap = false;
                        break;
                    case DialogResult.Yes:
                        SaveFileAs();
                        break;
                }
                curBitmap.Dispose();
                gr.Dispose();
            }
            curBitmap = new Bitmap(Empty_BitmapWidth, Empty_BitmapHeigth);
            this.panel1.AutoScrollMinSize = new Size(Empty_BitmapWidth, Empty_BitmapHeigth);
            gr = Graphics.FromImage(curBitmap);
            gr.Clear(Color.White);
            this.Text = "new";
            mustSaveBitmap = true;
            this.pictureBox1.Image = curBitmap;
        }

        protected void SaveFileAs()
        {
            this.saveFileDialog1.Filter = 
                "BMP | *.bmp |GIF | *.gif |JPEG | *.jpeg |PNG | *.png";
            this.saveFileDialog1.FilterIndex = 1;
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    curBitmap = (Bitmap)this.pictureBox1.Image;
                    switch (this.saveFileDialog1.FilterIndex)
                    {
                        case 1:
                            curBitmap.Save(this.saveFileDialog1.FileName,
                                ImageFormat.Bmp);
                            break;
                        case 2:
                            curBitmap.Save(this.saveFileDialog1.FileName,
                                ImageFormat.Gif);
                            break;
                        case 3:
                            curBitmap.Save(this.saveFileDialog1.FileName,
                                ImageFormat.Jpeg);
                            break;
                        case 4:
                            curBitmap.Save(this.saveFileDialog1.FileName,
                                ImageFormat.Png);
                            break;
                    }
                    this.Text = this.saveFileDialog1.FileName;
                    mustSaveBitmap = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "MyPaint", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
            }



        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //CommandPointer();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            drawObject = EnumDraw.DrawEmptyRectangle;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            drawObject = EnumDraw.DrawEmptyEllipse;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            drawObject = EnumDraw.DrawCommonLine;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            drawObject = EnumDraw.DrawAfrerMouse;
            currentWidth = 2;
            currentPen = new Pen(currentColor, currentWidth);
        }

        private void ÒÓÁ‰‡Ú¸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEmptyBitmap();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            switch (drawObject)
            {
                case EnumDraw.DrawCommonLine:
                    e.Graphics.DrawLine(currentPen, ptLast, ptBegin);
                    break;
                case EnumDraw.DrawEmptyRectangle:
                    e.Graphics.DrawRectangle(currentPen, rectForFigures);
                    break;
                case EnumDraw.DrawEmptyEllipse:
                    e.Graphics.DrawEllipse(currentPen, rectForFigures);
                    break;
                case EnumDraw.DrawFillRectangle:
                    e.Graphics.FillRectangle(new SolidBrush(currentColor), rectForFigures);
                    break;
                case EnumDraw.DrawFillEllipse:
                    e.Graphics.FillEllipse(new SolidBrush(currentColor), rectForFigures);
                    break;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            ptLast = new Point(e.X, e.Y);
            mustDraw = true;

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            if (drawObject == EnumDraw.DrawCommonLine)
                gr.DrawLine(currentPen, ptLast, ptBegin);
            else if (drawObject == EnumDraw.DrawEmptyRectangle)
                gr.DrawRectangle(currentPen, rectForFigures);
            else if (drawObject == EnumDraw.DrawEmptyEllipse)
                gr.DrawEllipse(currentPen, rectForFigures);
            else if (drawObject == EnumDraw.DrawFillRectangle)
                gr.FillRectangle(new SolidBrush(currentColor), rectForFigures);
            else if (drawObject == EnumDraw.DrawFillEllipse)
                gr.FillEllipse(new SolidBrush(currentColor), rectForFigures);
            mustDraw = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button != MouseButtons.Left)
                return;
            if (!mustDraw)
                return;
            Graphics grf = this.pictureBox1.CreateGraphics();
            switch (drawObject)
            {
                case EnumDraw.DrawAfrerMouse:
                    Point ptNew = new Point(e.X, e.Y);
                    grf.DrawLine(currentPen, ptLast, ptNew);
                    gr.DrawLine(currentPen, ptLast, ptNew);
                    ptLast = ptNew;
                    break;
                case EnumDraw.DrawCommonLine:
                    ptBegin = new Point(e.X, e.Y);
                    this.pictureBox1.Invalidate();
                    break;

                case EnumDraw.DrawEmptyRectangle:
                case EnumDraw.DrawFillRectangle:
                case EnumDraw.DrawEmptyEllipse:
                case EnumDraw.DrawFillEllipse:
                    rectForFigures.Size = new Size(Math.Abs(e.X - ptLast.X),
                    Math.Abs(e.Y - ptLast.Y));
                    if (e.X > ptLast.X && e.Y < ptLast.Y)
                    {
                        rectForFigures.X = ptLast.X;
                        rectForFigures.Y = ptLast.Y - rectForFigures.Height;
                    }
                    if (e.X < ptLast.X && e.Y < ptLast.Y)
                    {
                        rectForFigures.X = e.X;
                        rectForFigures.Y = e.Y;
                    }
                    if (e.X < ptLast.X && e.Y > ptLast.Y)
                    {
                        rectForFigures.X = e.X;
                        rectForFigures.Y = e.Y - rectForFigures.Height;
                    }
                    if (e.X > ptLast.X && e.Y > ptLast.Y)
                    {
                        rectForFigures.X = ptLast.X;
                        rectForFigures.Y = ptLast.Y;
                    }
                    this.pictureBox1.Invalidate();
                    break;
            }
            grf.Dispose();
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            this.pictureBox1.Invalidate();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            drawObject = EnumDraw.DrawFillRectangle;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            drawObject = EnumDraw.DrawFillEllipse;
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            drawObject = EnumDraw.DrawAfrerMouse;
            currentWidth = 10;
            currentPen = new Pen(currentColor, currentWidth);
        }

        private void ‚˚ıÓ‰ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (pictureBox1.Image != null && mustSaveBitmap == true)
            {
                DialogResult result = MessageBox.Show(
                                      "Save in file \"" + this.Text + "\"?",
                                      "MyPaint", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Cancel:
                        return;
                    case DialogResult.No:
                        mustSaveBitmap = false;
                        break;
                    case DialogResult.Yes:
                        SaveFileAs();
                        break;
                }
            }
            this.openFileDialog1.Filter =
                "BMP | *.bmp |GIF | *.gif |JPEG | *.jpeg |PNG | *.png |All files | *.*";
            this.openFileDialog1.FilterIndex = 5;
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    curBitmap.Dispose();
                    gr.Dispose();
                    curBitmap = (Bitmap)Image.FromFile(this.openFileDialog1.FileName);
                    gr = Graphics.FromImage(curBitmap);
                    this.panel1.AutoScrollMinSize = new Size((int)(curBitmap.Width * 1.5),
                        (int)(curBitmap.Height * 1.5));
                    mustSaveBitmap = true;
                    this.Text = this.openFileDialog1.FileName;
                    this.pictureBox1.Image = curBitmap;
                    this.statusStrip1.Invalidate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "MyPaint", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void ÒÓı‡ÌËÚ¸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Text == "New")
                SaveFileAs();
            else
            {
                try
                {
                    curBitmap.Save(this.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "MyPaint", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void ÒÓı‡ÌËÚ¸ ‡ÍToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            drawObject = EnumDraw.DrawAfrerMouse;
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new Rectangle(this.pictureBox1.Location,
                this.pictureBox1.Image.Size));
            SolidBrush brush = new SolidBrush(currentColor);
            gr.FillPath(brush, path);
            pictureBox1.Image = curBitmap;
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                currentColor = colorDialog1.Color;
                currentPen = new Pen(currentColor, currentWidth);
            }
        }
    }
}