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
    public partial class A_FRM_Add_Contracting_Entities : Form
    {
        Connection con = new Connection();
        public A_FRM_Add_Contracting_Entities()
        {
            InitializeComponent();
        }
        bool stopdealing;
        bool ELimitb;
        bool MLimitb;
        private void btn_RP_Search_Click(object sender, EventArgs e)
        {
            A_FRM_Regulation_Prices frm = new A_FRM_Regulation_Prices();          
            frm.view = false;
            frm.ShowDialog();
           // this.txt_RP_id.Text = A_FRM_Regulation_Prices.id;
            //this.txt_RP_Aname.Text = A_FRM_Regulation_Prices.name;
            this.txt_RP_id.Text = frm.id;
            this.txt_RP_Aname.Text = frm.name;
        }

        private void btn_OSD_Search_Click(object sender, EventArgs e)
        {

            A_FRM_Operation_Skills_Desc frm = new A_FRM_Operation_Skills_Desc();
            frm.view = false;
            frm.ShowDialog();
            txt_OSD_id.Text = A_FRM_Operation_Skills_Desc.id;
            txt_OSD_name.Text = A_FRM_Operation_Skills_Desc.name;
        }

        private void btn_EType_Search_Click(object sender, EventArgs e)
        {
            A_FRM_Types_of_Entities frm = new A_FRM_Types_of_Entities();
            frm.view = false;
            frm.ShowDialog();
            txt_ET_id.Text = A_FRM_Types_of_Entities.id;
            txt_ET_name.Text = A_FRM_Types_of_Entities.name;
        }

        private void btn_Region_Search_Click(object sender, EventArgs e)
        {
            A_FRM_Region frm = new A_FRM_Region();
            frm.view = false;
            frm.ShowDialog();
            txt_Region_id.Text = A_FRM_Region.id;
            txt_Region_name.Text = A_FRM_Region.name;
        }

        private void C_Reset_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(Control c in gro_byanat_elgeha.Controls)
                {
                    
                    if(c is TextBox)
                    {
                        c.Text = "";
                    }
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        bool valdate()
        {

            #region valdate
            if (String.IsNullOrEmpty(Txt_aname.Text))
            {
                MessageBox.Show("برجاء ادخال البيانات الناقصة ");
                Txt_aname.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(Txt_Ename.Text))
            {
                MessageBox.Show("برجاء ادخال البيانات الناقصة ");
                Txt_Ename.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txt_RP_id.Text))
            {
                MessageBox.Show("برجاء اختيار لائحة الاسعار  ");
                btn_RP_Search.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txt_ET_id.Text))
            {
                MessageBox.Show("برجاء اختيار نوع الجهة  ");
                btn_EType_Search.Focus();
                return false;
            }
            #endregion valdate

            return true;
        }
        private void C_Save_Click(object sender, EventArgs e)
        {
            #region insert

            if (valdate())
            {
                try
                {
                    string[] paramname = new string[17];
                    string[] paramvalue = new string[17];
                    SqlDbType[] paramtype = new SqlDbType[17];

                    paramname[0] = "@id";
                    paramname[1] = "@Aname";
                    paramname[2] = "@Ename";
                    paramname[3] = "@StartDD";
                    paramname[4] = "@StopDD";
                    paramname[5] = "@Stopdealing";
                    paramname[6] = "@EOpenblance";
                    paramname[7] = "@MOpenblance";
                    paramname[8] = "@ELimitblance";
                    paramname[9] = "@MLimitblance";
                    paramname[10] = "@TE_id";
                    paramname[11] = "@Employee";
                    paramname[12] = "@RP_id";
                    paramname[13] = "@Region_id";
                    paramname[14] = "@HEmployee_id";
                    paramname[15] = "@OSD_id";
                    paramname[16] = "@AD_id";



                    paramvalue[0] = Txt_id.Text;
                    paramvalue[1] = Txt_aname.Text;
                    paramvalue[2] = Txt_Ename.Text;
                    paramvalue[3] = dtp_start.Value.ToShortDateString();
                    paramvalue[4] = dtp_stop.Value.ToShortDateString();
                    paramvalue[5] = stopdealing.ToString();
                    paramvalue[6] = ELimitb.ToString();
                    paramvalue[7] = MLimitb.ToString();
                    paramvalue[8] = Txt_Climitb.Text;
                    paramvalue[9] = Txt_Mlimitb.Text;
                    paramvalue[10] = txt_ET_id.Text;
                    paramvalue[11] = Txt_employee.Text;
                    paramvalue[12] = txt_RP_id.Text;
                    paramvalue[13] = txt_Region_id.Text;
                    paramvalue[14] = Txt_HEid.Text;
                    paramvalue[15] = txt_OSD_id.Text;
                    paramvalue[16] = Txt_AD_id.Text;


                    paramtype[0] = SqlDbType.Int;
                    paramtype[1] = SqlDbType.NVarChar;
                    paramtype[2] = SqlDbType.NVarChar;
                    paramtype[3] = SqlDbType.Date;
                    paramtype[4] = SqlDbType.Date;
                    paramtype[5] = SqlDbType.Bit;
                    paramtype[6] = SqlDbType.Bit;
                    paramtype[7] = SqlDbType.Bit;
                    paramtype[8] = SqlDbType.Int;
                    paramtype[9] = SqlDbType.Int;
                    paramtype[10] = SqlDbType.Int;
                    paramtype[11] = SqlDbType.NVarChar;
                    paramtype[12] = SqlDbType.Int;
                    paramtype[13] = SqlDbType.Int;
                    paramtype[14] = SqlDbType.Int;
                    paramtype[15] = SqlDbType.Int;
                    paramtype[16] = SqlDbType.Int;


                    int x;
                    con.OpenConection();
                    x=con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("sp_Contracting_Entites_insert", paramname, paramvalue, paramtype);
                    // con.ExecutenonReturnProcdure("sp_Access_Method_insert", paramname, paramvalue, paramtype);
                    if (x == 1)
                    {
                        MessageBox.Show("تمت الاضافة بنجاح ");
                    }
                    this.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            #endregion insert

        }

        private void ch_MLimit_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_MLimit.Checked)
            {
                MLimitb = true;
            }
            else
            {
                MLimitb = true;
            }
        }

        private void ch_CLimit_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_CLimit.Checked)
            {
                ELimitb = true;
            }
            else
            {
                ELimitb = true;
            }
        }

        private void CB_Check_stop_CheckedChanged(object sender, EventArgs e)
        {
           if (CB_Check_stop.Checked)
            {
                stopdealing = true;
            }
            else
            {
                stopdealing = true;
            }
        }

        private void Txt_Climitb_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
