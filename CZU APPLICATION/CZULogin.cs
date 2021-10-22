using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace CZU_APPLICATION
{
    public partial class CZULogin : Form
    {
        int count = 0;
        public CZULogin()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            // Opening SQL connection
            string path = @"Data Source=DESKTOP-3GAOIRP;Initial Catalog=czu_users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(path);
            SqlCommand query;
            SqlDataReader dataReader;
            connection.Open();
            string cmd = "select id, name, password, pin from users";
            query = new SqlCommand(cmd, connection);
            dataReader = query.ExecuteReader();
            bool logged_in = false;     
            while (dataReader.Read())
            {
                if(inUsername.Text == (string) dataReader.GetValue(1) && inPassword.Text == (string) dataReader.GetValue(2) && inPinCode.Text == (string) dataReader.GetValue(3))
                {
                    CZUMain form2 = new CZUMain();
                    CZURegister form3 = new CZURegister();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand nonquery;
                    string command = $"update users set connected = 'on' where id = {dataReader.GetValue(0)}";
                    form2.connected_user = $"{dataReader.GetValue(1)}";
                    dataReader.Close();
                    nonquery = new SqlCommand(command, connection);
                    adapter.InsertCommand = nonquery;
                    adapter.InsertCommand.ExecuteNonQuery();
                    nonquery.Dispose();
                    dataReader.Close();
                    logged_in = true;
                    MessageBox.Show("Succesfully logged in");
                    this.Hide();
                    form2.Show();
                    connection.Close();
                    // Closing SQL connection
                    break;
                }
            }
            if (!logged_in)
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


