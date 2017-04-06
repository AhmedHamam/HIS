using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HIS
{
    public partial class regions : Form
    {
        Connection c = new Connection();
        SqlConnection con  = new SqlConnection( @"Data Source=(localdb)\projects;" +
              "Initial Catalog=PHIS;" +
              "User id=sa;" +
              "Password=root;");
       
        public regions()
        {
           
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            //perant.Show();
            this.Close();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                c.OpenConection();
                 
                if (txtregionId.Text == "" || txtarb_des.Text == "" || txteng_des.Text == "")
                {
                    MessageBox.Show("بعض الحقول فارغة الرجاء اعادة المحاولة");
                   
                }
                else
                {
                     
                    //addreg
                        
                    string[] param_names= new string[]{"@region_id"};
                    string[] param_values= new string[]{txtregionId.Text};
                    SqlDbType[] param_types= new SqlDbType[]{SqlDbType.Int};

                    dataGridView2.DataSource = (DataTable)c.ShowDataInGridViewUsingStoredProc("show_region", param_names, param_values, param_types);
                    c.CloseConnection();

                    }
                }
           

            catch (Exception ee) { MessageBox.Show(ee.Message); }
            finally { con.Close(); }
           
        }
        public void dis_data()
        {
            //con.Open();
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "select  regionId as 'كود الاقليم' , countryId as 'كود القطر', [ar des] as 'الوصف العربى' , [en des] as 'الوصف اللاتينى' from region ";
            //cmd.ExecuteNonQuery();
            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(dt);
            //dataGridView2.DataSource = dt;
            //con.Close();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (txtregionId.Text == "")
            { MessageBox.Show("من فضلك اختر الصف المراد حذفه ", "تنبيه"); }
            else
            {
                DialogResult dialogResult = MessageBox.Show("هل انت متأكد من الحذف ؟ ", "تنبيه ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string id = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                    con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Esraa Ibrahim\HIS.mdf;Integrated Security=True;Connect Timeout=30");
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "delete from country where countryId='" + id + "'";
                    cmd.ExecuteNonQuery();
                    dis_data();
                    txtregionId.Text = "";
                    txtarb_des.Text = "";
                    txteng_des.Text = "";
                    MessageBox.Show("تمت الحذف");
                    con.Close();

                }
                if (dialogResult == DialogResult.No)
                {
                    dialogResult = DialogResult.Cancel;
                    txtregionId.Text = "";
                    txtarb_des.Text = "";
                    txteng_des.Text = "";
                }

            }
          
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void regions_Load(object sender, EventArgs e)
        {
           
        }

    }
}
// **************************adding without procdure

//con.Open();
//SqlCommand cmd = con.CreateCommand();
//cmd.CommandType = CommandType.Text;
//if (txtregionId.Text == "" || txtcountryId.Text == "" || txtarb_des.Text == "" || txteng_des.Text == "")
//{
//    MessageBox.Show("!!من فضلك ادخل جميع البيانات بعض الحقول فارغة");
//    txtregionId.Text = "";
//    txtcountryId.Text = "";
//    txtarb_des.Text = "";
//    txteng_des.Text = "";
//}
//else
//{


//    cmd.CommandText = "insert into region values('" + txtregionId.Text + "','" + txtarb_des.Text + "','" + txteng_des.Text + "','" + txtcountryId.Text + "')";
//    cmd.ExecuteNonQuery();
//    txtregionId.Text = "";
//    txtcountryId.Text = "";
//    txtarb_des.Text = "";
//    txteng_des.Text = "";
//    con.Close();

//    dis_data();
//    MessageBox.Show("تمت الاضافة بنجاح ");

//}


/***************************************************************************************************/



//****************************delete with choose the id

//con.Open();
//SqlCommand cmd = con.CreateCommand();
//cmd.CommandType = CommandType.Text;
//cmd.CommandText = "delete from region where regionId='" + txtregionId.Text + "'";
//cmd.ExecuteNonQuery();
//txtregionId.Text = "";
//con.Close();
//dis_data();
//MessageBox.Show("تمت الحذف");