using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace COMPSAD_GUI
{
    public partial class Main : Form
    {
        public SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\David Soliman\Documents\folder\Data.mdf;Integrated Security=True;Connect Timeout=30");
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\David Soliman\Documents\folder\Data.mdf;Integrated Security=True;Connect Timeout=30"; 
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\David Soliman\Documents\folder\Data.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Booking values(@BookingName,@BookingDate,@Unit,@Contact)", con);
            cmd.Parameters.AddWithValue("@BookingName", (tboxReservationName.Text));
            cmd.Parameters.AddWithValue("@BookingDate", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Unit", textBox2.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox1.Text);


            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Successfully Booked");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\David Soliman\Documents\folder\Data.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Booking set BookingDate=@BookingDate, Unit=@Unit, Contact=@Contact where BookingName=@BookingName ", con);
            cmd.Parameters.AddWithValue("@BookingName", (tboxReservationName.Text));
            cmd.Parameters.AddWithValue("@BookingDate", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Unit", textBox2.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox1.Text);

            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Successfully Updated Booking");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\David Soliman\Documents\folder\Data.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete Booking where BookingName=@BookingName",con);
            cmd.Parameters.AddWithValue("BookingName", (tboxReservationName.Text));
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Successfully Cancelled Booking");




        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Booking", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
