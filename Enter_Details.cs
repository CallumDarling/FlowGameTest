using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowFreeNew
{
    public partial class Enter_Details : Form
    {
        string name = " ";
        string score = "0";
        string namescore = " ";


        public Enter_Details()
        {
            InitializeComponent();
        }

        private void namelabel_Click(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nameLabelEnter(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            namelabel.Text = name;
            scoretextbox.Text = score;
            namescore = name + ": " + score;

        }

      }
}
