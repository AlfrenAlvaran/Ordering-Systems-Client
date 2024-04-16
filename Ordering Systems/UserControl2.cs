using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ordering_Systems
{
    public partial class UserControl2 : UserControl
    {
        private double _cost;

        public event EventHandler Onselect = null;


        public UserControl2()
        {
            InitializeComponent();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Onselect?.Invoke(this, e);
        }

        public string Title { get => lbl_title.Text; set => lbl_title.Text = value; }
        public string Description { get => lbl_des.Text; set => lbl_des.Text = value; }
        public double Cost { get => _cost; set { _cost = value; lbl_price.Text = value.ToString("C2"); } }
        public Image  Img { get => pictureBox1.Image; set => pictureBox1.Image = value; }

        private void UserControl2_Load(object sender, EventArgs e)
        {

        }
    }
}
