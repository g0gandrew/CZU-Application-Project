﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CZU_APPLICATION
{
    internal static class Authentication
    {

        private static string _path { get; } = "SERVER=localhost; PORT=3306;DATABASE=czuapp;UID=root;PASSWORD=Andrei123!?";

        // Registration
        public static void registration(string t_username, string t_firstName, string t_lastName, string t_password, string t_authKey, string t_email, string t_phoneNumber, string t_sex, string t_birthDate, string t_regKey)
        {
            string nonquery = null;
            string registrationType = null;
            registrationType = Database.registrationToken(t_regKey); // Getting token type (teacher or student)
            MessageBox.Show(registrationType);
            MessageBox.Show(t_birthDate);

            switch (registrationType)
            {
                case "teacher":
                {
                    nonquery = $"insert into teacher(username, firstName, lastName, password, authKey, email, phoneNumber, sex, birthDate) values('{t_username}', '{t_firstName}', '{t_lastName}', '{t_password}', '{t_authKey}', '{t_email}', {t_phoneNumber}, '{t_sex}', '{t_birthDate}')";
                    MySqlConnection connection = new MySqlConnection();
                    connection.ConnectionString = _path;
                    MySqlCommand cmd = new MySqlCommand(nonquery, connection);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    break;
              
                    } 

                case "student":
                {

                    string studyingYear = null, classID = null;
                    // Getting data for updating student studying year and classID related to registration token 
                    MySqlConnection connection = new MySqlConnection();
                    connection.ConnectionString = _path;
                    MySqlCommand cmd = new MySqlCommand($"select classID from StudentRegKey where regKey = '{t_regKey}'", connection);
                    MySqlDataReader dataReader;
                    connection.Open();

                    // Getting classID
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        classID = dataReader.GetString(0);
                    }
                    dataReader.Close();
                    //

                    // Getting studying year
                    cmd.CommandText = $"select year from class where ID = '{classID}'";
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        studyingYear = dataReader.GetString(0);
                    }
                    dataReader.Close();
                    //

                    // Inserting the data into database
                    nonquery = $"insert into student(username, firstName, lastName, studyingYear, classID, password, authKey, email, phoneNumber, sex, birthDate) values('{t_username}', '{t_firstName}', '{t_lastName}', {studyingYear}, {classID}, '{t_password}', '{t_authKey}', '{t_email}', {t_phoneNumber}, '{t_sex}', '{t_birthDate}')";
                    cmd.CommandText = nonquery;
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    //
                    break;
                }
                default:
                {
                        MessageBox.Show("Registration Token is invalid");
                        break;
                }
        }
         
        }
        //

        // Login
        public static void login(TextBox t_inUsername, TextBox t_inPassword, TextBox t_inAuthKey, ref int t_count, CZULogin Login)
        {
            // Opening SQL connection
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand query = new MySqlCommand($"select id, username, password, authKey from student", connection);
            MySqlDataReader dataReader;
            connection.Open();
            dataReader = query.ExecuteReader();
            bool loggedIn = false;
            
            // Student Table Data Verifying
            while (dataReader.Read())
            {
                if (t_inUsername.Text == (string)dataReader.GetValue(1) && t_inPassword.Text == (string)dataReader.GetValue(2) && t_inAuthKey.Text == (string)dataReader.GetValue(3))
                {
                    CZUMain form2 = new CZUMain();
                    CZURegister form3 = new CZURegister();
                    form2.connectedUser = $"{dataReader.GetValue(1)}";
                    string command = $"update student set connected = 'on' where id = {dataReader.GetValue(0)}";
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
            // 
            // Teacher Table Data Verifying
            dataReader.Close();
            dataReader = query.ExecuteReader();
            query.CommandText = $"select id, username, password, authKey from teacher";
            while (dataReader.Read())
            {
                if (t_inUsername.Text == (string)dataReader.GetValue(1) && t_inPassword.Text == (string)dataReader.GetValue(2) && t_inAuthKey.Text == (string)dataReader.GetValue(3))
                {
                    CZUMain form2 = new CZUMain();
                    CZURegister form3 = new CZURegister();
                    form2.connectedUser = $"{dataReader.GetValue(1)}";
                    string command = $"update teacher set connected = 'on' where id = {dataReader.GetValue(0)}";
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
            //

            // Too Many Attempts Security Feature
            if (!loggedIn)
            {
                t_count++;
                if (t_count != 3)
                {
                    MessageBox.Show($"Incorrect credentials");
                    t_inUsername.Clear();
                    t_inPassword.Clear();
                    t_inAuthKey.Clear();
                }
                else
                {
                    MessageBox.Show("You failed attempting to enter your connection informations too many times");
                    Login.Close();
                }
            }
            //
        }
        // 




    }
}