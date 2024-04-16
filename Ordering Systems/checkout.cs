using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ordering_Systems
{
    public partial class checkout : Form
    {
        public DataGridView GridView
        {
            get { return dataGridView1; }
        }

        public Label lbl
        {
            get { return txt_total; } 
        }
        public checkout()
        {
            InitializeComponent();
            comboBox1.Items.Add("Gcash");
            comboBox1.Items.Add("Paymaya");
            comboBox1.Items.Add("PayPal");
            comboBox1.Items.Add("Bank Transfer");
        }

        private void checkout_Load(object sender, EventArgs e)
        {
           
        }

        private void btn_pay_Click(object sender, EventArgs e)
        {
            string selectedPayment = comboBox1.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedPayment))
            {

                MessageBox.Show($"You have selected {selectedPayment} as your payment method.", "Payment Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form1 frm = new Form1();
                index i = new index();
                frm.Show();
                i.Hide  ();
               
                this.Hide();
            }
            else
            {

                MessageBox.Show("Please select a payment method.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
