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
    public partial class city : Form
    {
        Connection c = new Connection();
       
        public city()
        {
             

            InitializeComponent();
        }

        public void CreateMat()
        {
            int countryCount = 3;//count from DB
            int cityRowCount = 0;
            //allocate countries
            string[] countries = new string[countryCount];
            //fill countries
            //for (int i = 0; i < countryCount; i++)
            //{
                countries[0] = "مصر";//fill it with thew values you have
                countries[1] = "السعودية";
                countries[2] = "العراق";
                


            //}



            //allocate regions
            string[][] regions = new string[countryCount][];
            for (int i = 0; i < countryCount; i++)
            {
                regions[i] = new string[i + 1];
                cityRowCount += (i + 1);
            }
            //fill regoins
            for (int i = 0; i < regions.Length; i++)
                for (int j = 0; j < regions[i].Length; j++)
                {
                    regions[i][j] = "";//fill it with thew values you have
                }


            //allocate cities
            string[][] cities = new string[cityRowCount][];
            for (int i = 0; i < cityRowCount; i++)
                cities[i] = new string[i + 1];
            //fill cities
            for (int i = 0; i < cities.Length; i++)
                for (int j = 0; j < cities[i].Length; j++)
                {
                    cities[i][j] = "أسيوط"+"ddd"+"ddd";//fill it with thew values you have
                }
            //fill combobox
            for (int i = 0; i < countries.Length; i++)
            {
                for (int j = 0; j < regions[i].Length; j++)
                {
                    cb_country.Items.Add(countries[i]);
                    cb_region.Items.Add(regions[i][j]);
                    
                }
            }
        }

        private void city_Load(object sender, EventArgs e)
        {
            CreateMat();
            //c.OpenConection();
            //SqlDataReader dr = c.DataReader("select code from country");
            //while (dr.Read())
            //{
            //    cb_country.Items.Add(dr["code"].ToString());
            //}

            //c.CloseConnection();
            
        }

        private void cb_country_SelectedIndexChanged(object sender, EventArgs e)
        {

            //try
            //{
            //    c.OpenConection();
            //    SqlDataReader dr = c.DataReader("select ar_des from region where country_id =" + cb_country.Text);
            //    while (dr.Read())
            //    {
            //        cb_region.Items.Add(dr["ar_des"].ToString());
            //    }
            //    c.CloseConnection();
            //    cb_region.ResetText();
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            //check empty fields ...
            if (txt_city_id.Text == "" || txt_ar_des.Text == "" || txt_en_des.Text == "" || cb_region.Text == "")
            { MessageBox.Show("بعد البيانات مفقودة برجاء ادخل جميع البيانات ", "خطأ"); }
            else
            {

                try
                {
                    c.OpenConection();
                    string[] para_names = new string[] { "@city_id", "@ar_des", "@en_des", "@region_id" };
                    string[] para_values = new string[] { txt_city_id.Text, txt_ar_des.Text, txt_en_des.Text, cb_region.Text };
                    SqlDbType[] data_types = new SqlDbType[] { SqlDbType.Int, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int };
                    c.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("add_city", para_names, para_values, data_types);
                     
                    /* on duplcate key update this key 
                     * INSERt into cities(city_id,region_id) values (1,1)
                       ON DUPLICATE KEY UPDATE city_id=values(city_id) ,region_id= values(region_id) */
        
                    MessageBox.Show("تم إضافة المدينة بنجاح");


                }
                catch (Exception ex) { MessageBox.Show(ex.Message);
                if (ex.Message.ToString() == "duplicate primary key ")
                {             MessageBox.Show("duplicated !"); }
                }
            }

        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_cities.DataSource = (DataTable)c.ShowDataInGridViewUsingStoredProc("show_cities");
                c.CloseConnection();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dgv_cities_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int i = (int)dgv_cities.CurrentRow.Index;

                txt_ar_des.Text = dgv_cities.Rows[i].Cells["الوصف العربي"].Value.ToString();
                txt_en_des.Text = dgv_cities.Rows[i].Cells["الوصف اللاتيني "].Value.ToString();
                //cb_region.Text = dgv_cities.Rows[i].Cells["كود الإقليم"].Value.ToString();
                txt_city_id.Text= dgv_cities.Rows[i].Cells["كود المدينة"].Value.ToString();
             
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_city_id.Text == "")
                { MessageBox.Show("من فضلك اختر المدينة او ادخل كود المدينة المراد حذفها  !", "تنبيه"); }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("هل انت متأكد من الحذف  ؟", "تنبيه", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //do something
                        c.OpenConection();
                        string[] param_names = new string[] { "@city_id" };
                        string[] param_values = new string[] { txt_city_id.Text };
                        SqlDbType[] param_type = new SqlDbType[] { SqlDbType.Int };
                        c.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_city", param_names, param_values, param_type);
                        c.CloseConnection();
                        MessageBox.Show("تم حذف المدينة بنجاح");
                        txt_city_id.Clear();

                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        dialogResult = DialogResult.Cancel;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            //parent.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
        }
    }
}