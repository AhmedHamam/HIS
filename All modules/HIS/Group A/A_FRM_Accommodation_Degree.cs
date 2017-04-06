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
    public partial class A_FRM_Accommodation_Degree : Form
    {
        Connection con = new Connection();
        DataTable dt = new DataTable();
        public A_FRM_Accommodation_Degree()
        {
            InitializeComponent();
        }

        private void C_Help_Click(object sender, EventArgs e)
        {
        }

        private void C_Ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void C_Add_Click(object sender, EventArgs e)
        {

            int id = 1;
            A_FRM_Add_Accommodation_Degree frm = new A_FRM_Add_Accommodation_Degree();
            if (dt.Rows.Count > 0)
            {
                id = Convert.ToInt16(dt.Rows[dt.Rows.Count - 1][0]) + 1;
            }
            frm.Txt_id.Text = id.ToString();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][3].ToString() == "True")
                {
                    frm.C_default.Visible = false;
                    break;
                }
            }
            frm.C_Ok.Visible = false;
            frm.ShowDialog();
            this.A_FRM_Accommodation_Degree_Load(sender, e);
        }

        private void C_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void C_Delete_Click(object sender, EventArgs e)
        {

        }

        private void A_FRM_Accommodation_Degree_Load(object sender, EventArgs e)
        {
            #region
            object x = new object();
            try
            {
                con.OpenConection();
                x = con.ShowDataInGridViewUsingStoredProc("sp_Accommodation_Degrees_Select");
                dt = (DataTable)x;
                DGV.DataSource = dt;
            }
            catch (Exception)
            {
                throw;
            }
            #endregion

        }
    }
}
