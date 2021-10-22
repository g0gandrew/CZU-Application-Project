using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Data.SqlClient;


namespace CZU_APPLICATION
{
    public partial class CZUMain : Form
    {
        public string connectedUser;
        public CZUMain()
        {
            InitializeComponent();
        }

        private void CZUMain_Load(object sender, EventArgs e)
        {
            connectedId.Text = connectedUser;
            update_statistics(statisticsUsers, "on");

        }
        private static int db_read_statistics(string t_command, string t_searchedKey)
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

        private static void update_statistics(Label t_a, string t_aKeyword)
        {
            string a_command = $"select connected from users where connected = '{t_aKeyword}'";
            t_a.Text =  $"{db_read_statistics(a_command, t_aKeyword)}";
        }

        private void db_insert(string command)
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


        private void CZUMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            string command = $"update users set connected = 'off' where name = '{connectedUser}'";
            db_insert(command);
        }
    }
}
