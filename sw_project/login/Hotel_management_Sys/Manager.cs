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
using Hotel_management_Sys;
namespace WindowsFormsApp1
{
    public partial class Manager : Form
    {
        /*this is con obj i will use to establish my connection on locol host so kindy if u want it to run on ur local host kindy change it*/
        /*you can change it by right click on your database connection then go to properties then copy your connection string*/
        SqlConnection con = new SqlConnection("Data Source=LOAY;Initial Catalog=hotelmanagement;Integrated Security=True;");
        public Manager()
        {
            /*lets firstly intialize all component we use in this frame*/
            InitializeComponent();

            /*initially i want all panels to be invisible*/
         
            /* Hide the add tasks panel */
            add_tasks_panel.Visible = false;

            /* Hide the room panel */
            room_panel.Visible = false;

            /* Hide the show details panel */
            showDetails_panel.Visible = false;

            /* Hide the show rate panel */
            showRate_panel.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                /* This button is a show details button that triggers an action opening the show details panel */

                /* Hide the add tasks panel */
                add_tasks_panel.Visible = false;

                /* Hide the room panel */
                room_panel.Visible = false;

                /* Show the show details panel */
                showDetails_panel.Visible = true;

                /* Hide the show rate panel */
                showRate_panel.Visible = false;

                /* Let's open the connection to the database server to select some attributes */
                con.Open();

                /* Generate a SqlCommand object to select specific attributes from the database, ensuring an inner join between the 'reservation' table and the 'customer' table */
                SqlCommand cmd = new SqlCommand("SELECT name, phone_number, gender, room_number, reservation_date, reservation_number FROM reservation AS r, customer AS c WHERE r.cust_id = c.cust_id", con);

                /* Create a new instance of SqlDataAdapter, providing the SqlCommand (cmd) as a parameter */
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                /* Create a new DataTable to store the data retrieved from the database */
                DataTable dt = new DataTable();

                /* Fill the DataTable with the data from the database using the SqlDataAdapter */
                da.Fill(dt);

                /* Set the DataSource property of dataGridView2 to the filled DataTable */
                dataGridView2.DataSource = dt;
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                /* Show the add tasks panel */
                add_tasks_panel.Visible = true;

                /* Hide the room panel */
                room_panel.Visible = false;

                /* Hide the show details panel */
                showDetails_panel.Visible = false;

                /* Hide the show rate panel */
                showRate_panel.Visible = false;

                /* Open the database connection */
                con.Open();

                /* Create a new SqlCommand to retrieve data from the 'employee' table based on the 'title' column */
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM employee WHERE title=@title", con);
                cmd2.Parameters.AddWithValue("@title", "HouseKeeper");

                /* Create a new SqlDataAdapter to fill a DataTable with the results of the SQL query */
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);

                /* Set the DataSource property of dataGridView4 to the filled DataTable */
                dataGridView4.DataSource = dt;
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

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                /* Hide the add tasks panel */
                add_tasks_panel.Visible = false;

                /* Hide the room panel */
                room_panel.Visible = false;

                /* Hide the show details panel */
                showDetails_panel.Visible = false;

                /* Show the show rate panel */
                showRate_panel.Visible = true;

                /* Open the database connection */
                con.Open();

                /* Create a new SqlCommand to retrieve data from the 'rates' table */
                SqlCommand cmd = new SqlCommand("SELECT * FROM rates", con);

                /* Create a new SqlDataAdapter to fill a DataTable with the results of the SQL query */
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                /* Set the DataSource property of dataGridView1 to the filled DataTable */
                dataGridView1.DataSource = dt;
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                /* Hide the add tasks panel */
                add_tasks_panel.Visible = false;

                /* Show the room panel */
                room_panel.Visible = true;

                /* Hide the show details panel */
                showDetails_panel.Visible = false;

                /* Hide the show rate panel */
                showRate_panel.Visible = false;

                /* Open the database connection */
                con.Open();

                /* Create a new SqlCommand to retrieve data from the 'room' table */
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM room", con);

                /* Create a new SqlDataAdapter to fill a DataTable with the results of the SQL query */
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);

                /* Set the DataSource property of dataGridView3 to the filled DataTable */
                dataGridView3.DataSource = dt;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void showDetails_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {
                /* Open the database connection */
                con.Open();

                /* Create a SqlCommand to retrieve the room_status based on the provided room_number */
                SqlCommand cmd1 = new SqlCommand("SELECT room_status FROM room WHERE room_number=@room_number", con);
                cmd1.Parameters.AddWithValue("@room_number", int.Parse(textBox2.Text));

                /* Execute the SELECT command to get the current room status */
                object result = cmd1.ExecuteScalar();
                string currentRoomStatus = result != null ? result.ToString() : null;

                /* Check the current room status */
                if (currentRoomStatus != null && currentRoomStatus.Equals("Opened", StringComparison.OrdinalIgnoreCase))
                {
                    /* The room is already open, notify the user */
                    MessageBox.Show("The Room is already opened");
                }
                else if (currentRoomStatus != null && currentRoomStatus.Equals("Closed", StringComparison.OrdinalIgnoreCase))
                {
                    /* The room is not open, update the status to 'open' */
                    SqlCommand cmd = new SqlCommand("UPDATE room SET room_status=@room_status WHERE room_number=@room_number", con);
                    cmd.Parameters.AddWithValue("@room_status", "Opened");
                    cmd.Parameters.AddWithValue("@room_number", int.Parse(textBox2.Text));

                    /* Execute the UPDATE command to change the room status */
                    cmd.ExecuteNonQuery();

                    /* Display a message indicating that the room is now opened */
                    MessageBox.Show("The Room is opened");
                }
                else
                {
                    /* The room number cannot be found, prompt the user to add it first */
                    MessageBox.Show("This room number cannot be found, please add it first");
                }

                /* Create a SqlCommand to retrieve all rows from the 'room' table */
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM room", con);

                /* Create a SqlDataAdapter to fill a DataTable with the results of the SQL query */
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);

                /* Set the DataSource property of dataGridView3 to the filled DataTable */
                dataGridView3.DataSource = dt;
            }
            catch (Exception ex)
            {
                /* Handle any exceptions that may occur during database operations */
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                /* Close the database connection in the finally block to ensure it's closed even if an exception occurs */
                con.Close();
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                /* Open the database connection */
                con.Open();

                /* Create a SqlCommand to retrieve the room_status based on the provided room_number */
                SqlCommand cmd1 = new SqlCommand("SELECT room_status FROM room WHERE room_number=@room_number", con);
                cmd1.Parameters.AddWithValue("@room_number", int.Parse(textBox2.Text));

                /* Execute the SELECT command to get the current room status */
                object result = cmd1.ExecuteScalar();
                string currentRoomStatus = result != null ? result.ToString() : null;

                /* Check the current room status */
                if (currentRoomStatus != null && currentRoomStatus.Equals("Closed", StringComparison.OrdinalIgnoreCase))
                {
                    /* The room is already closed, notify the user */
                    MessageBox.Show("The Room is already closed");
                }
                else if (currentRoomStatus != null && currentRoomStatus.Equals("Opened", StringComparison.OrdinalIgnoreCase))
                {
                    /* The room is not open, update the status to 'close' */
                    SqlCommand cmd = new SqlCommand("UPDATE room SET room_status=@room_status WHERE room_number=@room_number", con);
                    cmd.Parameters.AddWithValue("@room_status", "Closed");
                    cmd.Parameters.AddWithValue("@room_number", int.Parse(textBox2.Text));

                    /* Execute the UPDATE command to change the room status */
                    cmd.ExecuteNonQuery();

                    /* Display a message indicating that the room is now closed */
                    MessageBox.Show("The Room is closed");
                }
                else
                {
                    /* The room number cannot be found, prompt the user to add it first */
                    MessageBox.Show("This room number cannot be found, please add it first");
                }

                /* Create a SqlCommand to retrieve all rows from the 'room' table */
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM room", con);

                /* Create a SqlDataAdapter to fill a DataTable with the results of the SQL query */
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);

                /* Set the DataSource property of dataGridView3 to the filled DataTable */
                dataGridView3.DataSource = dt;
            }
            catch (Exception ex)
            {
                /* Handle any exceptions that may occur during database operations */
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                /* Close the database connection in the finally block to ensure it's closed even if an exception occurs */
                con.Close();
            }

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                /* Open the database connection */
                 con.Open();

                /* Create a SqlCommand to retrieve the title of the employee based on the provided emp_id */
                SqlCommand cmd1 = new SqlCommand("SELECT title FROM employee WHERE emp_id=@emp_id", con);
                cmd1.Parameters.AddWithValue("@emp_id", int.Parse(textBox4.Text));

                /* Execute the SELECT command to get the current title */
                object result = cmd1.ExecuteScalar();
                string currentTitle = result != null ? result.ToString() : null;

                /* Check if the current title is 'HouseKeeper' */
                if (currentTitle != null && currentTitle.Equals("HouseKeeper", StringComparison.OrdinalIgnoreCase))
                {
                    /* Check if the task text box is not empty */
                    if (!string.IsNullOrWhiteSpace(textBox1.Text))
                    {
                        /* The employee is a HouseKeeper, update their task */
                        SqlCommand cmd = new SqlCommand("UPDATE employee SET task=@task WHERE emp_id=@emp_id", con);
                        cmd.Parameters.AddWithValue("@task", textBox1.Text);
                        cmd.Parameters.AddWithValue("@emp_id", int.Parse(textBox4.Text));

                        /* Execute the UPDATE command to assign the task */
                        cmd.ExecuteNonQuery();

                        /* Display a message indicating that the task assignment is done */
                        MessageBox.Show("Done");
                    }
                    else
                    {
                        /* Display an error message if the task text box is empty */
                        MessageBox.Show("Error\nPlease enter a task before assigning.");
                    }
                }
                else
                {
                    /* The employee is not a HouseKeeper, display an error message */
                    MessageBox.Show("Error\nYou can assign tasks to House Keepers only");
                }

                /* Create a SqlCommand to retrieve all HouseKeepers from the 'employee' table */
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM employee WHERE title=@title", con);
                cmd2.Parameters.AddWithValue("@title", "HouseKeeper");

                /* Create a SqlDataAdapter to fill a DataTable with the results of the SQL query */
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);

                /* Set the DataSource property of dataGridView4 to the filled DataTable */
                dataGridView4.DataSource = dt;
            }
           catch (Exception ex)
            {
                /* Handle any exceptions that may occur during database operations */
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
           finally
            {
                /* Close the database connection in the finally block to ensure it's closed even if an exception occurs */
                con.Close();
            }

        }

        private void room_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            this.Hide();
            l.ShowDialog();
        }
    }
}
