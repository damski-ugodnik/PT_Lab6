using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PT_Lab6
{
    public partial class AuthorForm : Form
    {
        public AuthorForm()
        {
            InitializeComponent();
        }

        private void AuthorForm_Load(object sender, EventArgs e)
        {

        }

        private void AuthorForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("Author: Ponomarenko Mykyta\n" +
                "Group: 525-I\n", Font, Brushes.Black, 50, 50);
        }
    }
}
