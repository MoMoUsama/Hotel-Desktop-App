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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace FirstTime
{
    public partial class Reception : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=LOAY;Initial Catalog=hotelmanagement;Integrated Security=True;");
        private int checkoutPrice = 0;
        public Reception()
        {
            InitializeComponent();
            // Disable the button initially
            submit.Enabled = false;
            panel1.Visible = false;
            CheckOutPanel.Visible = false;
            CashPanel.Visible = false;
            CreditCardPanel.Visible = false;
            panel2.Visible = true;
            richTextBox1.Text = "Front Desk:\r\n\r\nGreet and assist guests during check-in and check-out.\r\nProvide information on hotel services and local attractions.\r\nManage reservations efficiently.\r\nHousekeeping:\r\n\r\nClean and prepare guest rooms to high standards.\r\nReplace linens, towels, and toiletries.\r\nReport maintenance issues promptly.\r\nFollow cleaning schedules.\r\nRestaurant/Room Service:\r\n\r\nTake orders and serve meals promptly.\r\nProvide menu recommendations.\r\nEnsure clean and set tables.\r\nProcess guest payments.\r\nMaintenance:\r\n\r\nPerform routine inspections and repairs.\r\nRespond to guest requests for room repairs.\r\nMonitor HVAC systems.\r\nKeep maintenance records.\r\nSecurity:\r\n\r\nControl access and monitor hotel premises.\r\nRespond to security incidents.\r\nConduct regular property patrols.\r\nEnsure guest and employee safety.\r\nManagement:\r\n\r\nProvide leadership and enforce SOPs.\r\nConduct staff meetings and training.\r\nMonitor employee performance.\r\nManage inventory and budgets.\r\nGeneral:\r\n\r\nUphold brand standards.\r\nDress professionally.\r\nAttend training sessions.\r\nFoster a positive work environment.\r\nAdhere to hotel policies.\r\nStrive for continuous improvement..";
            CashRadioButton.Checked = false;
            CreditCardRadioButton.Checked = false;
            Male.Checked = false;
            Female.Checked = false;
            // Attach event handlers
            CustomerNumber.TextChanged += CheckData;
            Female.CheckedChanged += CheckData;
            Male.CheckedChanged += CheckData;
            // Add similar lines for other textboxes if needed
            RoomType.Items.Add("Single");
            RoomType.Items.Add("Double");
            RoomType.Items.Add("Triple");
            // Set the default selected item
            RoomType.SelectedIndex = 0; // Set to 0 for "Single", 1 for "Double", and 2 for "Triple"

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckOutPanel.Visible = false;
            CashPanel.Visible = false;
            CreditCardPanel.Visible = false;
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create a SqlConnection using the connection string
            using (SqlConnection connection = new SqlConnection("Data Source=LOAY;Initial Catalog=hotelmanagement;Integrated Security=True;"))
            {
                try
                {
                    // Open the database connection
                    connection.Open();

                    // SQL query to select text from the "offer" table
                    string query = "SELECT top 1 * FROM offer order by offerID desc ";

                    // Create a SqlCommand with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Execute the command and get the result
                        object result = command.ExecuteScalar();

                        // Check if the result is not null
                        if (result != null)
                        {
                            // Display the result in a DialogResult
                            DialogResult dialogResult = MessageBox.Show(result.ToString(), "Today Offer", MessageBoxButtons.OK);

                            // You can add additional logic based on the dialog result if needed
                            if (dialogResult == DialogResult.OK)
                            {
                                // Do something when the user clicks OK
                            }
                        }
                        else
                        {
                            // Handle the case where no data is found
                            MessageBox.Show("No Offers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            try
            {
                connection.Open();
                // Your SQL INSERT query with parameters
                using (SqlCommand command = new SqlCommand("INSERT INTO customer (name, phone_number, gender) " +
                                     "VALUES (@name, @phone_number, @gender)", connection))
                {
                    // Set parameter values from your text fields
                    command.Parameters.AddWithValue("@name", CustomerName.Text);
                    command.Parameters.AddWithValue("@phone_number", CustomerNumber.Text);
                    
                    if (Male.Checked)
                    {
                        command.Parameters.AddWithValue("@gender", "Male");
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@gender", "Female");
                    }

                    // Execute the INSERT query
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected < 0)
                    {
                        MessageBox.Show("No rows were affected. Data might not have been inserted.");
                    }
                    else
                    {

                    }

                }
                // Your SQL INSERT query with parameters
                string insertQuery = "INSERT INTO reservation (reservation_date,cust_id,room_number) " +
                                     "VALUES (@reservation_date,@cust_id,@room_number)";
                SqlCommand  command10 = new SqlCommand("select top 1 cust_id from customer order by cust_id DESC;", connection);
                object result_custID = command10.ExecuteScalar();
                string custID = result_custID != null ? result_custID.ToString() : null;
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    // Set reservation_date from DateTimePicker
                    command.Parameters.AddWithValue("@reservation_date", dateTimePicker1.Value);
                    command.Parameters.AddWithValue("@cust_id", custID);
                    command.Parameters.AddWithValue("@room_number", RoomNumberCust.Text);

                    // Execute the INSERT query
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data inserted successfully!");

                    }
                    else
                    {
                        MessageBox.Show("No rows were affected. Data might not have been inserted.");
                    }
                }

                /* Create a SqlCommand to retrieve the room_status based on the provided room_number */
                SqlCommand cmd1 = new SqlCommand("SELECT room_status FROM room WHERE room_number=@room_number", connection);
                cmd1.Parameters.AddWithValue("@room_number", int.Parse(RoomNumberCust.Text));

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
                    SqlCommand cmd = new SqlCommand("UPDATE room SET room_status=@room_status WHERE room_number=@room_number", connection);
                    cmd.Parameters.AddWithValue("@room_status", "Closed");
                    cmd.Parameters.AddWithValue("@room_number", int.Parse(RoomNumberCust.Text));

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
                string selectedRoomType = RoomType.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedRoomType))
                {
                    // SQL query to retrieve rooms of the selected type from your database
                    string query = "SELECT * FROM room WHERE room_type = @SelectedRoomType";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add a parameter to the SqlCommand
                        command.Parameters.AddWithValue("@SelectedRoomType", selectedRoomType);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Bind the DataTable to the DataGridView
                            dataGridView3.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                // Close the SQL connection in the finally block
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        private void CheckData(object sender, EventArgs e)
        {
            // Check if all required data is filled
            if (IsDataFilled())
            {
                // Enable the button
                submit.Enabled = true;
            }
            else
            {
                // Disable the button
                submit.Enabled = false;
            }
        }
        private bool IsDataFilled()
        {
            bool isRadioButton1Checked = Female.Checked;
            bool isRadioButton2Checked = Male.Checked;
            // Add conditions to check if all required data is filled
            if
        (
                (!string.IsNullOrEmpty(CustomerNumber.Text.Trim())) && (!string.IsNullOrEmpty(CustomerName.Text.Trim()))
                && (!string.IsNullOrEmpty(RoomType.Text.Trim())
                && (Female.Checked || Male.Checked))
        )
            { return true; }
            return false;

            // Add similar conditions for other textboxes if needed
        }

        private void button2_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void ReceiptMoney_Click(object sender, EventArgs e)
        {

        }

        private void CashPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Cash_CheckedChanged(object sender, EventArgs e)
        {
            CreditCardPanel.Visible = false;
            CashPanel.Visible = true;
        }

        private void checkout_Click(object sender, EventArgs e)
        {
            CashPanel.Visible = false;
            CreditCardPanel.Visible = false;
            panel2.Visible = false;
            panel1.Visible = false;
            CheckOutPanel.Visible = true;


        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            CashPanel.Visible = false;
            CreditCardPanel.Visible = true;


        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void CardPass_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void label11_Click_1(object sender, EventArgs e)
        {

        }

        private void ConfirmTranscation_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                // Step 1: SELECT cust_id FROM reservation WHERE room_number = @room_number
                using (SqlCommand selectCommand = new SqlCommand("SELECT cust_id FROM reservation WHERE room_number = @room_number", connection))
                {
                    selectCommand.Parameters.AddWithValue("@room_number", RoomNumber.Text);

                    // Execute the SELECT query and retrieve the cust_id
                    object result = selectCommand.ExecuteScalar();

                    if (result != null)
                    {
                        int cust_id = Convert.ToInt32(result);

                        // Step 2: UPDATE reservation SET cust_id = NULL WHERE room_number = @room_number
                        using (SqlCommand updateCommand = new SqlCommand("UPDATE reservation SET cust_id = NULL WHERE room_number = @room_number", connection))
                        {
                            updateCommand.Parameters.AddWithValue("@room_number", RoomNumber.Text);

                            // Execute the UPDATE query
                            int rowsAffected = updateCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Step 3: DELETE FROM customer WHERE cust_id = @cust_id
                                string deleteQuery = "DELETE FROM customer WHERE cust_id = @cust_id";

                                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                                {
                                    deleteCommand.Parameters.AddWithValue("@cust_id", cust_id);

                                    // Execute the DELETE query
                                    int deleteRowsAffected = deleteCommand.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                // Handle the case where no rows were updated
                                MessageBox.Show("No reservation updated");
                            }
                        }
                    }
                    else
                    {
                        // Handle the case where no cust_id was found
                        MessageBox.Show("No cust_id found");
                    }
                }

                MessageBox.Show("Successfully Deleted");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during database operations
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Ensure that the connection is closed even if an exception occurs
                connection.Close();
            }

        }

        private void ConfirmRoom_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                // Step 1: SELECT cust_id FROM reservation WHERE room_number = @room_number
                string selectQuery = "SELECT cust_id FROM reservation WHERE room_number = @room_number";

                using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@room_number", RoomNumber.Text);

                    // Execute the SELECT query and retrieve the cust_id
                    object result = selectCommand.ExecuteScalar();

                    if (result != null)
                    {
                        int cust_id = Convert.ToInt32(result);

                        // Step 2: UPDATE reservation SET cust_id = NULL WHERE room_number = @room_number
                        string updateQuery = "UPDATE reservation SET cust_id = NULL WHERE room_number = @room_number";

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@room_number", RoomNumber.Text);

                            // Execute the UPDATE query
                            int rowsAffected = updateCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Step 3: DELETE FROM customer WHERE cust_id = @cust_id
                                string deleteQuery = "DELETE FROM customer WHERE cust_id = @cust_id";

                                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                                {
                                    deleteCommand.Parameters.AddWithValue("@cust_id", cust_id);

                                    // Execute the DELETE query
                                    int deleteRowsAffected = deleteCommand.ExecuteNonQuery();
                                }

                                // Display success message only if all operations succeed
                                MessageBox.Show("Successfully Deleted");
                                /* Create a new SqlCommand to retrieve data from the 'employee' table based on the 'title' column */
                                SqlCommand cmd10 = new SqlCommand("UPDATE room set room_status=@room_status where room_number=@room_number", connection);
                                cmd10.Parameters.AddWithValue("@room_status", "Opened");
                                cmd10.Parameters.AddWithValue("@room_number", int.Parse(RoomNumber.Text));
                                cmd10.ExecuteNonQuery();
                                MessageBox.Show("Successfully Opened");
                               
                                // Get the room number from the TextBox
                                if (int.TryParse(RoomNumber.Text, out int roomNumber))
                                {
                                    // Calculate the total cost
                                    decimal totalCost = CalculateTotalCost(roomNumber);

                                    // Parse the value from the "gestpaid" textbox
                                    if (decimal.TryParse(GuestPay.Text, out decimal gestPaidValue))
                                    {
                                        // Subtract the value from the total cost
                                        decimal restPaidValue = gestPaidValue - totalCost;
                                        // Display the result in the "restpaid" textbox
                                        GuestRest.Text = restPaidValue.ToString();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Invalid input. Please enter a valid number in the 'gestpaid' textbox.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please enter a valid room number.");
                                }
                            }
                            else
                            {
                                // Handle the case where no rows were updated
                                MessageBox.Show("No reservation updated");
                            }
                        }
                    }
                    else
                    {
                        // Handle the case where no cust_id was found
                        MessageBox.Show("No cust_id found");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during database operations
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Ensure that the connection is closed even if an exception occurs
                connection.Close();
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Update_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                // Get the selected room type from the combo box
                string selectedRoomType = RoomType.SelectedItem?.ToString();

                if (!string.IsNullOrEmpty(selectedRoomType))
                {
                    // SQL query to retrieve rooms of the selected type from your database
                    string query = "SELECT * FROM room WHERE room_type = @SelectedRoomType";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add a parameter to the SqlCommand
                        command.Parameters.AddWithValue("@SelectedRoomType", selectedRoomType);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Bind the DataTable to the DataGridView
                            dataGridView3.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                // Close the SQL connection in the finally block
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }
        private decimal CalculateTotalCost(int roomNumber)
        {
            try
            {
                // Retrieve reservation date associated with the room number
                string reservationQuery = "SELECT reservation_date FROM reservation WHERE room_number = @RoomNumber";

                using (SqlCommand reservationCommand = new SqlCommand(reservationQuery, connection))
                {
                    reservationCommand.Parameters.AddWithValue("@RoomNumber", roomNumber);

                    object reservationDateObject = reservationCommand.ExecuteScalar();

                    if (reservationDateObject == null || reservationDateObject == DBNull.Value)
                    {
                        MessageBox.Show("No reservation found for the specified room number.");
                        return 0; // or handle appropriately
                    }

                    DateTime reservationDate = Convert.ToDateTime(reservationDateObject);

                    // Calculate the number of days between the reservation date and today
                    int numberOfDays = ((int)(DateTime.Today - reservationDate).TotalDays) + 1;


                    // Retrieve room price associated with the room number
                    string roomQuery = "SELECT price_per_night FROM room WHERE room_number = @RoomNumber";

                    using (SqlCommand roomCommand = new SqlCommand(roomQuery, connection))
                    {
                        roomCommand.Parameters.AddWithValue("@RoomNumber", roomNumber);

                        object roomPriceObject = roomCommand.ExecuteScalar();

                        if (roomPriceObject == null || roomPriceObject == DBNull.Value)
                        {
                            MessageBox.Show("No room found for the specified room number.");
                            return 0; // or handle appropriately
                        }

                        decimal roomPrice = Convert.ToDecimal(roomPriceObject);

                        // Calculate the total cost
                        decimal totalCost = numberOfDays * roomPrice;
                        StayedDaysTextBox.Text = $"{numberOfDays}";
                        if (connection.State != System.Data.ConnectionState.Closed)
                        {
                            connection.Close();
                        }
                        return totalCost;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return 0; // or handle appropriately
        }
        private void RetrieveCost_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                // Get the room number from the TextBox
                if (!int.TryParse(RoomNumber.Text, out int roomNumber))
                {
                    MessageBox.Show("Please enter a valid room number.");
                    return;
                }

                // Calculate the total cost
                decimal totalCost = CalculateTotalCost(roomNumber);

                // Display the result in the Receipt TextBox
                Receipt.Text = $"{totalCost}";
                checkoutPrice = (int)totalCost;

                /* Generate a SqlCommand object to select specific attributes from the database, ensuring an inner join between the 'reservation' table and the 'customer' table */
                SqlCommand cmd = new SqlCommand("SELECT c.name, c.phone_number, c.gender, r.room_number, r.reservation_date, r.reservation_number FROM reservation AS r INNER JOIN customer AS c ON r.cust_id = c.cust_id WHERE r.room_number = @room_number;\r\n", connection);
                cmd.Parameters.AddWithValue("@room_number", int.Parse(RoomNumber.Text));


                /* Create a new instance of SqlDataAdapter, providing the SqlCommand (cmd) as a parameter */
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                /* Create a new DataTable to store the data retrieved from the database */
                DataTable dt = new DataTable();

                /* Fill the DataTable with the data from the database using the SqlDataAdapter */
                da.Fill(dt);

                /* Set the DataSource property of dataGridView2 to the filled DataTable */
                dataGridView1.DataSource = dt;
                dataGridView2.DataSource = dt;
                }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Wrong " + ex.Message);
            }
            finally
            {
                // Close the SQL connection in the finally block
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        private void label11_Click_2(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Male_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void CustomerNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            this.Hide();
            l.ShowDialog();
        }
    }
}

