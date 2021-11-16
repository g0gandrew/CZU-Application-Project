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
        private string _connectedUser, _command;
        public CZUMain()
        {
            InitializeComponent();
        }

        private void CZUMain_Load(object sender, EventArgs e)
        {
            connectedId.Text = _connectedUser;
            _command = "select connected from users where connected =";
            Statistics.update(statisticsUsers, _command, "on");
        }
        private void CZUMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            string command = $"update users set connected = 'off' where name = '{_connectedUser}'";
            Database.insert(command);

        }
    }
}
