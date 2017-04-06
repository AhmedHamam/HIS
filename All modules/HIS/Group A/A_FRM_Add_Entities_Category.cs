using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS
{
    public partial class A_FRM_Add_Entities_Category : Form
    {
        public A_FRM_Add_Entities_Category()
        {
            InitializeComponent();
        }

        private void btn_PC_Search_Click(object sender, EventArgs e)
        {
            A_FRM_Patients_Category frm = new A_FRM_Patients_Category();
            frm.view = false;
            frm.ShowDialog();
            txt_PC_name.Text = frm.name;
            txt_PC_id.Text = frm.id;
        }
    }
}
