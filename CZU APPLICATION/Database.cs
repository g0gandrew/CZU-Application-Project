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

        public static void insert(string command)
        {
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand cmd = new MySqlCommand(command, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

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

    
        public static void deleteLogs(string t_connectedPeople, string t_dataType)
        {
            // after all users are disconnected, delete data from logs
        }
    }
}
