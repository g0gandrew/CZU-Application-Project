using System;
using System.Windows.Forms;

namespace CZU_APPLICATION
{
    
    public partial class CZULogin : Form
    {
        int count = 0;
        string path = "SERVER=localhost; PORT=3306;DATABASE=czu_app;UID=root;PASSWORD=Andrei123!?";
        public CZULogin()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Security.login(inUsername, inPassword, inPinCode, ref count, this);
            // text adaugat
        }

        private void signUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CZURegister register = new CZURegister();
            register.Show();
        }
    }
}
