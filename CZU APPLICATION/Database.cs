using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CZU_APPLICATION
{
    internal class Database
    {
        public static void insert(string command)
        {
            string path = "SERVER=localhost; PORT=3306;DATABASE=czu_app;UID=root;PASSWORD=Andrei123!?";
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = path;
            MySqlCommand cmd = new MySqlCommand(command, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
