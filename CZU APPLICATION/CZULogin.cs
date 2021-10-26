using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CZU_APPLICATION
{
    
    public partial class CZULogin : Form
    {
        int count = 0;
        string path = @"Data Source=DESKTOP-3GAOIRP;Initial Catalog=czu_users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public CZULogin()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            // Opening SQL connection
            SqlConnection connection = new SqlConnection(path);
            SqlCommand query;
            SqlDataReader dataReader;
            connection.Open();
            string cmd = "select id, name, password, pin from users";
            query = new SqlCommand(cmd, connection);
            dataReader = query.ExecuteReader();
            bool loggedIn = false;
            while (dataReader.Read())
            {
                if (inUsername.Text == (string)dataReader.GetValue(1) && inPassword.Text == (string)dataReader.GetValue(2) && inPinCode.Text == (string)dataReader.GetValue(3))
                {
                    CZUMain form2 = new CZUMain();
                    CZURegister form3 = new CZURegister();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand nonquery;
                    string command = $"update users set connected = 'on' where id = {dataReader.GetValue(0)}";
                    form2.connectedUser = $"{dataReader.GetValue(1)}";
                    dataReader.Close();
                    nonquery = new SqlCommand(command, connection);
                    adapter.InsertCommand = nonquery;
                    adapter.InsertCommand.ExecuteNonQuery();
                    nonquery.Dispose();
                    dataReader.Close();
                    loggedIn = true;
                    MessageBox.Show("Succesfully logged in");
                    this.Hide();
                    form2.Show();
                    connection.Close();
                    // Closing SQL connection
                    break;
                }
            }
            if (!loggedIn)
            {
                count++;
                if (count != 3)
                {
                    MessageBox.Show("Incorrect credentials");
                    inUsername.Clear();
                    inPassword.Clear();
                    inPinCode.Clear();
                }
                else
                {
                    MessageBox.Show("You failed attempting to enter your connection informations too many times");
                    this.Close();
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CZURegister register = new CZURegister();
            register.Show();
        }
    }
}
