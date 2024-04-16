using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ordering_Systems
{
    public partial class index : Form
    {
        UserControl2 w;
        checkout checkoutForm;

        public index()
        {
            InitializeComponent();
            checkoutForm = new checkout();
            this.Load += index_Load;
        }

        public void View()
        {

        }

        public void AddItem(string name, string des, double cost, string imgFileName)
        {
            string imagePath = Path.Combine(Application.StartupPath, "img", imgFileName);
            w = new UserControl2()
            {
                Title = name,
                Cost = cost,
                Description = des,
                Img = Image.FromFile(imagePath),
            };

            w.Onselect += UserControl_Onselect;

            flowLayoutPanel1.Controls.Add(w);
        }

        private void UserControl_Onselect(object sender, EventArgs e)
        {
            try
            {
                var selectedControl = (UserControl2)sender;

                // Check if selectedControl is not null
                if (selectedControl != null)
                {
                    DataGridView GridView = checkoutForm.GridView;

                    // tignan sa data if null
                    if (GridView != null)
                    {
                        bool itemFound = false;
                        foreach (DataGridViewRow row in GridView.Rows)
                        {
                            // Check if row and its cells are not null
                            if (row != null && row.Cells[0] != null && row.Cells[0].Value != null && row.Cells[1] != null && row.Cells[1].Value != null && row.Cells[2] != null && row.Cells[2].Value != null)
                            {
                                if (row.Cells[0].Value.ToString() == selectedControl.Title)
                                {
                                    row.Cells[1].Value = (int.Parse(row.Cells[1].Value.ToString()) + 1).ToString();
                                    row.Cells[2].Value = (double.Parse(row.Cells[1].Value.ToString()) * double.Parse(row.Cells[2].Value.ToString().Replace("$", ""))).ToString("C2");
                                    itemFound = true;
                                    break;
                                }
                            }
                        }

                        if (!itemFound)
                        {
                            int rowIndex = GridView.Rows.Add();
                            GridView.Rows[rowIndex].Cells[0].Value = selectedControl.Title;
                            GridView.Rows[rowIndex].Cells[1].Value = "1";
                            GridView.Rows[rowIndex].Cells[2].Value = selectedControl.Cost.ToString("C2");
                        }

                        Calculation();
                    }
                    else
                    {
                        MessageBox.Show("GridView is null.");
                    }
                }
                else
                {
                    MessageBox.Show("selectedControl is null.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        void Calculation()
        {
            try
            {
                if (checkoutForm != null && checkoutForm.GridView != null && checkoutForm.lbl != null)
                {
                    DataGridView GridView = checkoutForm.GridView;
                    double total = 0;
                    foreach (DataGridViewRow item in GridView.Rows)
                    {
                        if (item.Cells[2].Value != null)
                        {
                            total += double.Parse(item.Cells[2].Value.ToString().Replace("$", ""));
                        }
                    }
                    Label lbl = checkoutForm.lbl;
                    lbl.Text = "₱" + total.ToString();
                }
                else
                {
                    MessageBox.Show("checkoutForm, GridView, or lbl is null.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while calculating total: " + ex.Message);
            }
        }


       

        private void index_Load(object sender, EventArgs e)
        {
            
            AddItem("Tempura", "Delicious tempura wi'th dipping sauce.", 465.00, "Tempura.jpg");
            AddItem("Dynamite Roll", "Delicious Dynamite sushi.", 405.00, "Dynamite.jpg");
            AddItem("TENZARU SOBA", "Good Noodles", 395.00, "soba.jpg");
            AddItem("Tonkotso Ramen", "Lovely Ramen", 420.00, "Ramen.jpg");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkoutForm.Show();
        }
    }
}
