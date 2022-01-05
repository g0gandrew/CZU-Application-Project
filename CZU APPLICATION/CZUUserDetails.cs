using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CZU_APPLICATION
{
    public partial class CZUUserDetails : Form
    {

        private string _studentID { get; set; }

        public CZUUserDetails(string t_studentID)
        {
            _studentID = t_studentID;
            InitializeComponent();
        }

      
    }
}
