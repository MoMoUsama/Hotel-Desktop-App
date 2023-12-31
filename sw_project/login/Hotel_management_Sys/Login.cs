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
using WindowsFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hotel_management_Sys
{
    public partial class Login : Form
    {
        /*this is con obj i will use to establish my connection on locol host so kindy if u want it to run on ur local host kindy change it*/
        /*you can change it by right click on your database connection then go to properties then copy your connection string*/
        SqlConnection con = new SqlConnection("Data Source=LOAY;Initial Catalog=hotelmanagement;Integrated Security=True;");
        public Login()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            try
            {

                /*Open new connection*/
                con.Open();

                /* Create a SqlCommand to check password of name */
                SqlCommand cmd1 = new SqlCommand("select password from employee where name = @name", con);
                cmd1.Parameters.AddWithValue("@name", username.Text);


                /* Execute the SELECT command to get the current title */
                object result_pass = cmd1.ExecuteScalar();
                string pass = result_pass != null ? result_pass.ToString() : null;

                if (pass != null && pass.Equals(textBox1.Text, StringComparison.OrdinalIgnoreCase))
                {
                    /* Create a SqlCommand to retrieve the room_status based on the provided room_number */
                    SqlCommand cmd2 = new SqlCommand("select title from employee where name = @name", con);
                    cmd2.Parameters.AddWithValue("@name", username.Text);

                    /* Execute the SELECT command to get the current title */
                    object result = cmd2.ExecuteScalar();
                    string title = result != null ? result.ToString() : null;
                    /* Check the current room status */
                    if (title != null && title.Equals("Manager", StringComparison.OrdinalIgnoreCase))
                    {
                        Manager a = new Manager();
                        this.Hide();
                        a.ShowDialog();
                    }
                    else if (title!= null && title.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                    {
                        Admin a = new Admin();                 
                        this.Hide();
                        a.ShowDialog();
                    }
                    else if (title != null && title.Equals("Receiption", StringComparison.OrdinalIgnoreCase))
                    {
                        Reception a = new Reception();
                        this.Hide();
                        a.ShowDialog();
                    }
                    else
                    {
                        /*show err message that their is no employee with this name*/
                        MessageBox.Show("Invalid data");
                    }
                    this.Close();
                }
                else
                {
                    /*show err message that their is no employee with this name*/
                    MessageBox.Show("Invalid data");
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
