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
            // Calls the method that verifies the login details
            Authentication.login(inUsername, inPassword, t_inAuthKey, ref _count, this);
            //
        }

        private void signUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Creates an object of CZURegister class which serves as a form for registration
            CZURegister register = new CZURegister();
            //
            
            // Displaying the created form
            register.Show();
            //
        }
     }
}
