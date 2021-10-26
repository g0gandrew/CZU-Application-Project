using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CZU_APPLICATION
{
    
    public partial class CZULogin : Form
    {
        int count = 0;
        string path = @"Data Source=DESKTOP-3GAOIRP;Initial Catalog=czu_users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public CZULogin()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Security.login(inUsername, inPassword, inPinCode, count, this);

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CZURegister register = new CZURegister();
            register.Show();
        }
    }
}
