using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CZU_APPLICATION
{
    internal class Security
    {
        private void genderSecurity(CheckBox maleCheck, CheckBox femaleCheck, CheckBox unspecified)
        {
            if (maleCheck.Checked)
                sex_value = "male";
            if (femaleCheck.Checked)
                sex_value = "female";
            else
                sex_value = "unspecified";
            while (maleCheck.Checked && femaleCheck.Checked || maleCheck.Checked && unspecifiedCheck.Checked || femaleCheck.Checked && unspecifiedCheck.Checked)
            {
                maleCheck.Checked = false;
                femaleCheck.Checked = false;
                unspecifiedCheck.Checked = false;
                MessageBox.Show("Select just one gender");
            }
        }



    }
}
