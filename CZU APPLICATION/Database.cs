using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlTypes;

namespace CZU_APPLICATION
{
    internal class Database
    {
        public static void db_insert(string command)
        {
            string path = @"Data Source=DESKTOP-3GAOIRP;Initial Catalog=czu_users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(path);
            SqlDataAdapter dataAdapter;
            SqlCommand cmd;
            dataAdapter = new SqlDataAdapter();
            connection.Open();
            cmd = new SqlCommand(command, connection);
            dataAdapter.InsertCommand = cmd;
            dataAdapter.InsertCommand.ExecuteNonQuery();
            dataAdapter.Dispose();
            connection.Close();
        }
        public static int db_read_statistics(string t_command, string t_searchedKey)
        {
            int count = 0;
            string path = @"Data Source=DESKTOP-3GAOIRP;Initial Catalog=czu_users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(path);
            SqlCommand cmd = new SqlCommand(t_command, connection);
            SqlDataReader dataReader;
            connection.Open();
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read()) // counting for statistics 
            {
                if ((string)dataReader.GetValue(0) == t_searchedKey)
                    ++count;
            }
            dataReader.Close();
            connection.Close();
            return count;
        }
        public static void update_statistics(Label t_a, string t_aKeyword)
        {
            string a_command = $"select connected from users where connected = '{t_aKeyword}'";
            t_a.Text = $"{db_read_statistics(a_command, t_aKeyword)}";
        }


    }
}
