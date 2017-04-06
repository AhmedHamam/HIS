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
    public partial class scanner_prosess : Form
    {

        Connection con = new Connection();

        public scanner_prosess(string value, string value2)
        {
            InitializeComponent();
            //ssageBox.Show(value);
            textBox2.Text = value;
            textBox1.Text = value2;
        }



        private void sanner_prosess_Load(object sender, EventArgs e)
        {
            try
            {

                con.OpenConection();

                DataTable dt = new DataTable();
                dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("loadcombox");
                comboBox1.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; ++i)
                    comboBox1.Items.Add(dt.Rows[i][0].ToString());

            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }

            try
            {
                con.OpenConection();

                DataTable dt = new DataTable();
                dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("loadcomboxc");
                comboBox2.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; ++i)
                    comboBox2.Items.Add(dt.Rows[i][0].ToString());
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }

        }


        //***********************************************************************

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //***********************************************************************************

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string x = "";
                con.OpenConection();
                SqlConnection con1 = new SqlConnection(@"server=(localdb)\v11.0;Initial Catalog=PHIS;Integrated Security=True");
                con1.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con1;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select catagory_id from document_catagory where arabic_name=@name";
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = comboBox2.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                //  string y = dr["catagory_id"].ToString();
                if (dr.HasRows)
                {
                    x = dr["catagory_id"].ToString();



                    //  DataTable dt = new DataTable();
                    string[] s = new string[] { "@param1", "@param2", "@param3", "@param4" };
                    string[] s2 = new string[] { x, textBox1.Text, textBox3.Text, dateTimePicker1.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Date };
                    con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("insertdocument", s, s2, s3);

                    comboBox1.Text = "";
                    comboBox2.Text = "";
                }

                con1.Close();
                dr.Close();

                con.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        //********************************************************************************************
        private void button7_Click(object sender, EventArgs e)
        {
            string userSelectedFilePath;
            OpenFileDialog ofd = new OpenFileDialog();

            System.Windows.Forms.DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                try
                {
                    userSelectedFilePath = ofd.FileName;
                    con.OpenConection();
                    textBox3.Text = userSelectedFilePath;


                }
                catch (Exception s)
                {
                    MessageBox.Show(s.Message);
                }
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {

            //SaveFileDialog FBD = new SaveFileDialog();

            //if (FBD.ShowDialog() == DialogResult.OK)
            //{
            //    int n = Convert.ToInt32(textBox1.Text);
            //    for (int i = 0; i < n; i++)
            //    {
            //        ScannerService sr = new ScannerService();
            //        ImageFile image = sr.Scan();


            //        image.SaveFile(FBD.FileName + ".jpg");

            //    }
            //}

        }

       






    }
    //public class ScannerService
    //{
    //    public ImageFile Scan()
    //    {
    //        ImageFile image;

    //        WIA.CommonDialog dialog = new WIA.CommonDialog();
    //        DeviceManager dm = new DeviceManagerClass();

    //        Device scannerDevice = dialog.ShowSelectDevice(WIA.WiaDeviceType.ScannerDeviceType, false, false);

    //        Item scannerItem;

    //        if (scannerDevice == null)
    //            MessageBox.Show("No");
    //        if (scannerDevice != null)
    //        {
    //            scannerItem = scannerDevice.Items[1];

    //            image = dialog.ShowAcquireImage(
    //                WIA.WiaDeviceType.ScannerDeviceType,
    //                WIA.WiaImageIntent.ColorIntent,
    //                WIA.WiaImageBias.MaximizeQuality,
    //                WIA.FormatID.wiaFormatJPEG,
    //                false,
    //                true,
    //                false);

    //            return image;


    //        }
    //        return null;
    //    }
    }

