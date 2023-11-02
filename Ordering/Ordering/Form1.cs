using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ordering
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private NpgsqlConnection conn;
        private DataTable dt;
        private NpgsqlCommand cmd;
        private string sql = null;

        private DataGridViewRow r ;
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=zeus ozcan;");
           // buttonSelect.PerformClick(); //load all orders when form opened
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            try
            {
                dgvData.DataSource = null;
                //load all orders from table tbl_orders
                if (conn != null && conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                
                sql = "select * from select_order()";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvData.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ex.Message,"FAIL!!!", MessageBoxButtons.OK,MessageBoxIcon.Error);
                conn.Close();
                
            }
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            //insert a new order into orders table
            try
            {
                if (conn != null && conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                sql = @"select * from insert_order(:_user_id,:_product_id,:_pieces)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_user_id", Int16.Parse(txtUserID.Text));
                cmd.Parameters.AddWithValue("_product_id", Int16.Parse(txtProductID.Text));
                cmd.Parameters.AddWithValue("_pieces", Int16.Parse(txtPiece.Text));
                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Inserted a new order successfully", "Well done :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    buttonSelect.PerformClick();//if inserted successfully then load all students again
                    //reset textbox components
                    txtUserID.Text = txtProductID.Text = txtPiece.Text = null;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "INSERT FAILED!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //delete an order
            if (r==null)
            {
                MessageBox.Show("Please choose an order to delete", ":O", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete this order?","Confirm Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    sql = @"select * from delete_order(:_order_id)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("_order_id",r.Cells["_order_id"].Value);
                    if ((int)cmd.ExecuteScalar() == 1)
                    {
                        conn.Close();
                        MessageBox.Show("Deleted successfully!!!", "Well done :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //load all orders again
                        buttonSelect.PerformClick();

                        //reset all textbox components
                        txtPiece.Text = txtProductID.Text = txtUserID.Text = null;

                        //reset record choosen
                        r = null;
                    }
                    
                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show("Error: " + ex.Message, "DELETE FAIL!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvData.Rows[e.RowIndex];
                txtUserID.Text = r.Cells["_user_id"].Value.ToString();
                txtUserID.Text = r.Cells["_product_id"].Value.ToString();
                txtUserID.Text = r.Cells["_pieces"].Value.ToString();
                
            }
        }

        private void btnSelectUsers_Click(object sender, EventArgs e)
        {
            try
            {
                dgvData.DataSource = null;
                //load all users from table tbl_user
                conn.Open();
                sql = "select * from select_users()";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvData.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Error: " + ex.Message, "FAIL!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);              
            }
        }

        private void btnSelectProducts_Click(object sender, EventArgs e)
        {
            try
            {
                dgvData.DataSource = null;
                //load all users from table tbl_products
                conn.Open();
                sql = "select * from select_products()";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvData.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Error: " + ex.Message, "FAIL!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
