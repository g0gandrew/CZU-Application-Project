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
    public partial class CZUAssignment : Form
    {

        private string _assignmentID { get; set; }
        private string _studentID { get; set; }
        private string _interfaceMode { get; set; }
        public CZUAssignment()
        {
            InitializeComponent();
        }
        public CZUAssignment(string t_assignmentID, string t_studentID) // For student, to add the assignment solution
        {
            // Initializing the main variables
            _assignmentID = t_assignmentID;
            _studentID = t_studentID;
            //

            // 
                _interfaceMode = "studentAddsSolution";
            //

            InitializeComponent();
        }






        private void CZUAssignment_Load(object sender, EventArgs e)
        {

        }

        private void submit_Click(object sender, EventArgs e)
        {
            switch(_interfaceMode)
            {
                case "studentAddsSolution":
                    {
                        break;
                    }
                case "teacherAddsAssignment":
                    {
                        break;
                    }
                case "studentViewsAssignment":
                    {
                        break;
                    }
                case "teacherGradesSolution":
                    {
                        break;
                    }

            }
        }
    }
}
