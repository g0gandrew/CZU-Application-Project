using System;
using System.Windows.Forms;

namespace CZU_APPLICATION
{
    
    public partial class CZULogin : Form
    {
        private int _count;
        public int count
        {
            get {  
                return _count; 
            }
            set
            {
                _count = value;
            }
        }
        public CZULogin()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Authentication.login(inUsername, inPassword, t_inAuthKey, ref _count, this);
        }

        private void signUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CZURegister register = new CZURegister();
            register.Show();
        }

        private void inPassword_TextChanged(object sender, EventArgs e)
        {

        }
     }
}
