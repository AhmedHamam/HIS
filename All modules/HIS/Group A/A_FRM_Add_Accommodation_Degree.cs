using System;
using System.Data;
using System.Windows.Forms;

namespace HIS
{
    public partial class A_FRM_Add_Accommodation_Degree : Form
    {
        bool def;
        bool status;
        string Acc_type;
        string AD_type;
        string AD_col_type;
        Connection con = new Connection();
        public A_FRM_Add_Accommodation_Degree()
        {
            InitializeComponent();
        }

        private void Txt_aname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void C_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void C_Help_Click(object sender, EventArgs e)
        {
            
        }

        private void C_Ok_Click(object sender, EventArgs e)
        {
            this.Close();
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

            if (String.IsNullOrEmpty(Txt_ename.Text))
            {
                MessageBox.Show("برجاء ادخال البيانات الناقصة ");
                Txt_ename.Focus();
                return false;
            }
            if (CB_Status.SelectedItem == null)
            {
                MessageBox.Show("برجاء اختيار حالة درجة الاقامة   ");
                CB_Status.Focus();
                return false;
            }
            if (CB_Col_Type.SelectedItem == null)
            {
                MessageBox.Show("برجاء تحديد نوع تجميع الاقامة   ");
                CB_Col_Type.Focus();
                return false;
            }
            if (CB_AD_type.SelectedItem == null)
            {
                MessageBox.Show("برجاء اختيار نوع الاقامة  ");
                CB_AD_type.Focus();
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
                    string[] paramname = new string[9];
                    string[] paramvalue = new string[9];
                    SqlDbType[] paramtype = new SqlDbType[9];

                    paramname[0] = "@id";
                    paramname[1] = "@Aname";
                    paramname[2] = "@Ename";
                    paramname[3] = "@Statuse";
                    paramname[4] = "@Type";
                    paramname[5] = "@Collection_Type";
                    paramname[6] = "@Default";
                    paramname[7] = "@Account_Type";
                    paramname[8] = "@time";


                    paramvalue[0] = Txt_id.Text;
                    paramvalue[1] = Txt_aname.Text;
                    paramvalue[2] = Txt_ename.Text;
                    paramvalue[3] = status.ToString();
                    paramvalue[4] = AD_type;
                    paramvalue[5] = AD_col_type;
                    paramvalue[6] = def.ToString();
                    paramvalue[7] = Acc_type;
                    paramvalue[8] = txt_time.Text;


                    paramtype[0] = SqlDbType.Int;
                    paramtype[1] = SqlDbType.NVarChar;
                    paramtype[2] = SqlDbType.NVarChar;
                    paramtype[3] = SqlDbType.Bit;
                    paramtype[4] = SqlDbType.NVarChar;
                    paramtype[5] = SqlDbType.NVarChar;
                    paramtype[6] = SqlDbType.Bit;
                    paramtype[7] = SqlDbType.NVarChar;
                    paramtype[8] = SqlDbType.Int;


                    con.OpenConection();
                    con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("sp_Accommodation_Degrees_insert", paramname, paramvalue, paramtype);
                    // con.ExecutenonReturnProcdure("sp_Access_Method_insert", paramname, paramvalue, paramtype);

                    MessageBox.Show("تمت الاضافة بنجاح ");
                    this.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            #endregion insert
          
        }

        private void C_default_CheckedChanged(object sender, EventArgs e)
        {
            if (C_default.Checked == true)
            {
                def = true;
            }
            else
            {
                def = false;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);

        }

        private void CB_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Status.SelectedIndex == 0)
                status = false;
            else
                status = true;
        }

        private void C_AD_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_AD_type.SelectedIndex > -1)
                AD_type = CB_AD_type.Items[CB_AD_type.SelectedIndex].ToString();
           

        }

        private void C_Acc_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Acc_Type.SelectedIndex > -1)
                Acc_type = CB_Acc_Type.Items[CB_Acc_Type.SelectedIndex].ToString();
            else
                Acc_type = null;
           
        }

        private void C_Col_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Col_Type.SelectedIndex > -1)
                AD_col_type = CB_Col_Type.Items[CB_Col_Type.SelectedIndex].ToString();
            else
                Acc_type = null;
        }

        private void txt_time_TextChanged(object sender, EventArgs e)
        {
            if (txt_time.Text == "")
                txt_time.Text = "0";
        }


     
    }
}
