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
            Database.update_statistics(statisticsUsers, "on");
        }
        private void CZUMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            string command = $"update users set connected = 'off' where name = '{connectedUser}'";
            Database.db_insert(command);

        }
    }
}
