﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CZU_APPLICATION
{
    internal class Security
    {
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
            string path = "SERVER=localhost;PORT=3306;DATABASE=czu_app;UID=root;PASSWORD=Andrei123!?";
            string cmd = "select id, name, password, pin from users";
            // Opening SQL connection
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = path; 
            MySqlCommand query = new MySqlCommand(cmd, connection);
            MySqlDataReader dataReader;
            connection.Open();
            dataReader = query.ExecuteReader();
            bool loggedIn = false;
            while (dataReader.Read())
            {
                if (t_inUsername.Text == (string)dataReader.GetValue(1) && t_inPassword.Text == (string)dataReader.GetValue(2) &&  t_inPinCode.Text == (string)dataReader.GetValue(3))
                {
                    CZUMain form2 = new CZUMain();
                    CZURegister form3 = new CZURegister();
                    form2.connectedUser = $"{dataReader.GetValue(1)}";
                    string command = $"update users set connected = 'on' where id = {dataReader.GetValue(0)}";
                    dataReader.Close();
                    MySqlCommand nonquery = new MySqlCommand(command, connection);
                    nonquery.ExecuteNonQuery();
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

