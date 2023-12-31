using FirstTime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using WindowsFormsApp1;

namespace Hotel_management_Sys
{
    public partial class Admin : Form
    {
        /*this is con obj i will use to establish my connection on locol host so kindy if u want it to run on ur local host kindy change it*/
        /*you can change it by right click on your database connection then go to properties then copy your connection string*/
        SqlConnection con = new SqlConnection("Data Source=LOAY;Initial Catalog=hotelmanagement;Integrated Security=True;");

        public Admin()
        {
            InitializeComponent();
            Dashboard_panel.Visible = false;
            addAcc_panel.Visible = true;
            addOffer_panel.Visible = false;
        }

        private void Dashboard_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void male_radiobtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Dashboard_Click(object sender, EventArgs e)
        {
            Dashboard_panel.Visible = true;
            addAcc_panel.Visible = false;
            addOffer_panel.Visible = false;
            try
            {

                /*Open new connection*/
                con.Open();

                /* Create a SqlCommand to check password of name */
                SqlCommand cmd1 = new SqlCommand("select count(*) from room", con);

                /* Execute the SELECT command to get the current title */
                object result_tot_rooms = cmd1.ExecuteScalar();
                string tot_room = result_tot_rooms != null ? result_tot_rooms.ToString() : null;
                All_rooms.Text = tot_room;

                /* Create a SqlCommand to check password of name */
                SqlCommand cmd2 = new SqlCommand("select count(*) from room where room_status=@room_status", con);
                cmd2.Parameters.AddWithValue("@room_status", "Closed");
                /* Execute the SELECT command to get the current title */
                object result_tot_reserved = cmd2.ExecuteScalar();
                string tot_reserved = result_tot_reserved != null ? result_tot_reserved.ToString() : null;
                Reserved.Text = tot_reserved;

                Free.Text = (int.Parse(tot_room) - int.Parse(tot_reserved)).ToString();

                SqlCommand cmd3 = new SqlCommand("select count(*) from employee", con);

                /* Execute the SELECT command to get the current title */
                object result_tot_emp = cmd3.ExecuteScalar();
                string tot_emp = result_tot_emp != null ? result_tot_emp.ToString() : null;
                Total_emp.Text = tot_emp;

                SqlCommand cmd4 = new SqlCommand("select count(*) from reservation", con);

                /* Execute the SELECT command to get the current title */
                object result_tot_guests = cmd4.ExecuteScalar();
                string tot_guest = result_tot_guests != null ? result_tot_guests.ToString() : null;
                tot_guests.Text = tot_guest;

            }
            catch (Exception ex)
            {
                /* Handle any exceptions that may occur during database operations */
                MessageBox.Show($"An error occurred while connecting to the database: {ex.Message}");
            }
            finally
            {
                /* Close the database connection in the finally block to ensure it's closed even if an exception occurs */
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void Add_Account_Click(object sender, EventArgs e)
        {
            Dashboard_panel.Visible = false;
            addAcc_panel.Visible = true;
            addOffer_panel.Visible = false;
        }

        private void Add_Offer_Click(object sender, EventArgs e)
        {
            Dashboard_panel.Visible = false;
            addAcc_panel.Visible = false;
            addOffer_panel.Visible = true;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void confirm_btn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO employee (password, name, age, salary,title,phone_no,nationality,gender) " +
                                     "VALUES (@password, @name, @age, @salary,@title,@phone_no,@nationality,@gender)", con))
                {
                    if (male_radiobtn.Checked)
                    {
                        command.Parameters.AddWithValue("@gender", "Male");
                    }
                    else if (female_radiobtn.Checked)
                    {
                        command.Parameters.AddWithValue("@gender", "Female");
                    }

                    // Set parameter values from your text fields
                    command.Parameters.AddWithValue("@name", textBox1.Text);
                    command.Parameters.AddWithValue("@password", textBox2.Text);
                    command.Parameters.AddWithValue("@age", textBox3.Text);
                    command.Parameters.AddWithValue("@nationality", textBox4.Text);
                    command.Parameters.AddWithValue("@phone_no", textBox5.Text);
                    command.Parameters.AddWithValue("@title", textBox6.Text);
                    command.Parameters.AddWithValue("@salary", textBox7.Text);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected < 0)
                    {
                        MessageBox.Show("No rows were affected. Data might not have been inserted.");
                    }
                    else
                    {
                        MessageBox.Show("Add sucessfully");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();
                        male_radiobtn.Checked = false;
                        female_radiobtn.Checked = false;
                    }

                }
            }
            catch (Exception ex)
            {
                /* Handle any exceptions that may occur during database operations */
                MessageBox.Show($"An error occurred while connecting to the database: {ex.Message}");
            }
            finally
            {
                /* Close the database connection in the finally block to ensure it's closed even if an exception occurs */
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }




        private void button1_Click_1(object sender, EventArgs e)
        {
            Login l = new Login();
            this.Hide();
            l.ShowDialog();
        }

        private void submit_offer_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO offer (todayOffer) " +
                                     "VALUES (@todayOffer)", con))
                {

                    // Set parameter values from your text fields
                    command.Parameters.AddWithValue("@todayOffer", offerDetails.Text);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected < 0)
                    {
                        MessageBox.Show("No rows were affected. Data might not have been inserted.");
                    }
                    else
                    {
                        MessageBox.Show("Add sucessfully");
                        offerDetails.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                /* Handle any exceptions that may occur during database operations */
                MessageBox.Show($"An error occurred while connecting to the database: {ex.Message}");
            }
            finally
            {
                /* Close the database connection in the finally block to ensure it's closed even if an exception occurs */
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}
