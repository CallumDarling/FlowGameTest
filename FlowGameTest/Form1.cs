using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowGameTest
{
    public partial class Flo : Form
    {
        Random r = new Random();
        Button[,] btn = new Button[5, 5];       // Create 2D array of buttons
        //Button[] unkillable = new Button[25];
        List<Button> unkillable = new List<Button>();
        Boolean clickHeld = false;
        Color clickColor = Color.NavajoWhite;
        public Flo()
        {

            InitializeComponent();
            addButtons();
        }

        public void addButtons() {
            int gridOffSetX = 50;
            int gridOffSetY = 50;
            int buttonPosOffset = 46;
            int buttonSize = 45;
            for (int x = 0; x < btn.GetLength(0); x++)         // Loop for x
            {
                for (int y = 0; y < btn.GetLength(1); y++)     // Loop for y
                {
                    btn[x, y] = new Button();
                    btn[x, y].Font = new Font(btn[x, y].Font.FontFamily, 24);
                    btn[x, y].TextAlign = ContentAlignment.MiddleRight;
                    btn[x, y].Name = Convert.ToString((x + 1) + "," + (y + 1));
                    btn[x, y].SetBounds(gridOffSetX + buttonPosOffset * x + 1, gridOffSetY + buttonPosOffset * y + 1, buttonSize, buttonSize);
                    btn[x, y].BackColor = Color.PowderBlue;
                    //btn[x, y].Text = Convert.ToString((x + 1) + "," + (y + 1));
                    btn[x, y].Click += new EventHandler(this.btnEvent_Click);
                    btn[x, y].MouseEnter += new EventHandler(this.btnEvent_Enter);
                    btn[x, y].MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnEvent_Down);
                    btn[x, y].MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnEvent_Up);
                    Controls.Add(btn[x, y]);
                }
            }
        }
        void btnEvent_Click(object sender, EventArgs e)
        {
            Console.WriteLine(((Button)sender).Text);    // SAME handler as before
            if (!clickHeld) {
                clickHeld = true;
                clickColor = ((Button)sender).BackColor;
            }
            else
            {
                clickHeld = false;
            }

            //Color clickColor = ((Button)sender).BackColor;
        }

        void btnEvent_Down(object sender, EventArgs e)
        {
            //((Button)sender).BackColor = Color.Green;
            //clickHeld = true;
            //Color clickColor = ((Button)sender).BackColor;
        }
        void btnEvent_Up(object sender, EventArgs e)
        {
            //clickHeld = false;
            //Color clickColor = Color.NavajoWhite;
        }

        void btnEvent_Enter(object sender, EventArgs e)
        {
            if (clickHeld && !unkillable.Contains((Button)sender))
            {
                ((Button)sender).BackColor = clickColor;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void addFlowPath(int startX, int startY, int endX, int endY, Color col) {
            Button start = btn[startX, startY];
            Button end = btn[endX, endY];
            start.Text = "o";
            end.Text = "o";
            unkillable.Add(start);
            unkillable.Add(end);
            start.BackColor = col;
            end.BackColor = col;
        }

        private string convBoardToString()
        {
            string outP = "";
            for (int x = 0; x < btn.GetLength(0); x++)
            {
                for (int y = 0; y < btn.GetLength(1); y++)
                {
                    outP += btn[x, y].BackColor.GetHashCode()+";";
                }
                outP += ":";
            }
            textBox1.Text = outP;
            return outP;
        }
        private void startToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addFlowPath(0, 0, 2, 2, Color.Red);
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            convBoardToString();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void highSchoolToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
