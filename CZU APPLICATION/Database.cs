using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CZU_APPLICATION
{
    internal static class Database
    {
        private static string _path { get; } = "SERVER=localhost; PORT=3306;DATABASE=czuapp;UID=root;PASSWORD=Andrei123!?";


        // General method to insert in the database
        public static void insert(string command)
        {
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand cmd = new MySqlCommand(command, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        //

        // Getting the type of registration token
        public static string registrationToken(string t_registrationToken)
        {
            //  MYSQL connection
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand cmd = new MySqlCommand($"select regKey from StudentRegKey where regKey  = '{t_registrationToken}'", connection);
            MySqlDataReader dataReader;
            connection.Open();
            //

            // Student Token Validate Test
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                if (dataReader.GetString(0) != t_registrationToken)
                    t_registrationToken = null;
                else
                    t_registrationToken = "student";
            }
            dataReader.Close();
            //

            // Teacher Token Validate Test
            cmd.CommandText = $"select regKey from TeacherRegKey where regKey  = '{t_registrationToken}'";
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                if (dataReader.GetString(0) != t_registrationToken)
                    t_registrationToken = null;
                else
                    t_registrationToken = "teacher";
            }
            dataReader.Close();
            //

            // Ending MYSQL CONNECTION
            connection.Close();
            //
            return t_registrationToken;
        }
        //

        // Verifies if there exists records to the related query
        public static void recordExists(string t_query, ref int t_availableRecords)
        {
            // OPENING MYSQL CONNECTION
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            MySqlDataReader dataReader;
            connection.Open();
            //


            // Searching for records
            cmd.CommandText = t_query;
            dataReader = cmd.ExecuteReader();
            while(dataReader.Read())
            {
                ++t_availableRecords;
            }
            //
            connection.Close();
        }
        //

        // Method to get maximum one output from a query given to DB
        public static void getData(string t_query,  ref int t_output)
        {
            // OPENING MYSQL CONNECTION
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            MySqlDataReader dataReader;
            connection.Open();
            //

            // Searching for records
            cmd.CommandText = t_query;
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                    t_output = Convert.ToInt32(dataReader.GetString(0));
                
            }
            //

            connection.Close();
        }
        //


        // Method to get maximum n output from a query given to DB
        public static int getDataAndNoOfRecords(string t_query, int t_noOfColumns, ref int t_output)
        {
            // OPENING MYSQL CONNECTION
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            MySqlDataReader dataReader;
            connection.Open();
            //

            // Variables
            int count = 0;
            //

            // Searching for records
            cmd.CommandText = t_query;
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                for (int i = 0; i < t_noOfColumns; i++)
                {
                    t_output = Convert.ToInt32(dataReader.GetString(i));
                }
                ++count;
            }
            //

            connection.Close();
            return count;
        }
        //

    }
}
