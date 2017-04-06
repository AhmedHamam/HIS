using System;
using System.Data;
using System.Windows.Forms;

namespace HIS
{
    public partial class A_FRM_Contracting_Entities : Form
    {

        Connection con = new Connection();
        DataTable dt = new DataTable();
        public A_FRM_Contracting_Entities()
        {
            InitializeComponent();
        }

        private void A_FRM_Contracting_Entities_Load(object sender, EventArgs e)
        {

            object x = new object();
            try
            {
                con.OpenConection();
                x = con.ShowDataInGridViewUsingStoredProc("sp_Contracting_Entities_Select");
                dt = (DataTable)x;
                DGV.DataSource = dt;
                DGV.Columns[0].HeaderText = "الكود";
                DGV.Columns[1].HeaderText = "الاسم العربى";
                DGV.Columns[2].HeaderText = "الاسم اللاتينى";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void C_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void C_Help_Click(object sender, EventArgs e)
        {
        }

        private void C_Add_Click(object sender, EventArgs e)
        {
            A_FRM_Add_Contracting_Entities frm = new A_FRM_Add_Contracting_Entities();
            try
            {
                if (DGV.Rows.Count > 0)
                {
                    frm.Txt_id.Text = ((int)DGV.Rows[DGV.Rows.Count - 1].Cells[0].Value + 1).ToString();
                }
                else
                {
                    frm.Txt_id.Text = "1";
                }
                frm.ShowDialog();
                this.A_FRM_Contracting_Entities_Load(sender, e);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void C_Delete_Click(object sender, EventArgs e)
        {

        }

        private void txt_id_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
        private void txt_aname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
    }
}
