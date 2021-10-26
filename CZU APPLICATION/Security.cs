using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CZU_APPLICATION
{
    internal class Security
    {
        static string path = @"Data Source=DESKTOP-3GAOIRP;Initial Catalog=czu_users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static void gender(CheckBox t_maleCheck, CheckBox t_femaleCheck, CheckBox t_unspecifiedCheck, string t_sexValue)
        {
            if (t_maleCheck.Checked)
                t_sexValue = "male";
            if (t_femaleCheck.Checked)
                t_sexValue = "female";
            else
                t_sexValue = "unspecified";
            while (t_maleCheck.Checked && t_femaleCheck.Checked || t_maleCheck.Checked && t_unspecifiedCheck.Checked || t_femaleCheck.Checked && t_unspecifiedCheck.Checked)
            {
                t_maleCheck.Checked = false;
                t_femaleCheck.Checked = false;
                t_unspecifiedCheck.Checked = false;
                MessageBox.Show("Select just one gender");
            }
        }

        public static void login(TextBox t_inUsername, TextBox t_inPassword, TextBox t_inPinCode, ref int t_count, CZULogin Login)
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
                if (t_inUsername.Text == (string)dataReader.GetValue(1) && t_inPassword.Text == (string)dataReader.GetValue(2) && t_inPinCode.Text == (string)dataReader.GetValue(3))
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
                    Login.Hide();
                    form2.Show();
                    connection.Close();
                    // Closing SQL connection
                    break;
                }
            }
            if (!loggedIn)
            {

                t_count++;
                if (t_count != 3)
                {
                    MessageBox.Show($"Incorrect credentials");
                    t_inUsername.Clear();
                    t_inPassword.Clear();
                    t_inPinCode.Clear();
                }
                else
                {
                    MessageBox.Show("You failed attempting to enter your connection informations too many times");
                    Login.Close();
                }
            }
        }
    }
}

