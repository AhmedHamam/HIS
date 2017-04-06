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
    public partial class ServiceLabForm : Form
    {
        Connection c = new Connection();
 
        
        public ServiceLabForm()
        {
            //parent = p;
            InitializeComponent();
             
        }

        private void ServiceLabForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //parent.Show();
            this.Close();
        }

        private void ServiceLabForm_Load(object sender, EventArgs e)
        {
           
             try
            {
                c.OpenConection();
                string query = "select patient_id as 'كود المريض', patient_name as 'الاسم', gender as 'النوع',bed as 'السرير' from Registeration_patientRegisteration,entranceoffice_internalpatient ";
                SqlDataReader dr ;
                dr = c.DataReader(query);
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridPatients.DataSource = dt;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
            
        

        private void dataGridPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //txtpatient_code.Text = dataGridPatients.Rows[1].Cells["الكود"].Value.ToString();

        }

        private void dataGridPatients_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {}

      //private void selectedRowsButton_Click(object sender, System.EventArgs e)
    
      //{
      //  Int32 selectedRowCount =
      //      dataGridPatients.Rows.GetRowCount(DataGridViewElementStates.Selected);
      //  if (selectedRowCount > 0)
      //  {
      //      System.Text.StringBuilder sb = new System.Text.StringBuilder();

      //      for (int i = 0; i < selectedRowCount; i++)
      //      {
      //          sb.Append("Row: ");
      //          sb.Append(dataGridPatients.SelectedRows[i].Index.ToString());
      //          sb.Append(Environment.NewLine);
      //      }

      //      sb.Append("Total: " + selectedRowCount.ToString());
      //      MessageBox.Show(sb.ToString(), "Selected Rows");
      //  }
    
    //        txtpatient_code.Text = dataGridPatients.Rows[0].Cells["الكود"].Value.ToString();

        

      private void dataGridPatients_SelectionChanged(object sender, EventArgs e)
      {
          try
          {
              int i = dataGridPatients.CurrentRow.Index;
              txtpatient_code.Text = dataGridPatients.Rows[i].Cells["كود المريض"].Value.ToString();
              txtArabic_name.Text = dataGridPatients.Rows[i].Cells["الاسم"].Value.ToString();
              cbGender.Text = dataGridPatients.Rows[i].Cells["النوع"].Value.ToString();
          }
          catch (Exception ee)
          {
              MessageBox.Show(ee.Message);
          }
          
      }

      private void dataGridPatients_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
      {

      }

      private void dataGridServices_SelectionChanged(object sender, EventArgs e)
      {
         
      }

      private void listbxlapCato_SelectedValueChanged(object sender, EventArgs e)
      {
          
              try
              {
                  if (listbxlapCato.SelectedIndex == 0)
                  {
                      c.OpenConection();
                      string query = "select Service_code as 'كود الخدمة', Service_name as 'اسم الخدمة',Repeat as 'التكرار', price as 'السعر', Notes as 'ملاحظات' from orders_lap_service where lap_code='lap2'";

                      DataTable dt = (DataTable)c.ShowDataInGridView(query);
                      dataGridServices.DataSource = dt;
                      c.CloseConnection();
                  }
                  else if (listbxlapCato.SelectedIndex == 1)
                  {
                      c.OpenConection();
                      string query="select Service_code as 'كود الخدمة', Service_name as 'اسم الخدمة',Repeat as 'التكرار', price as 'السعر', Notes as 'ملاحظات' from orders_lap_service where lap_code='lap1'";
                     DataTable dt = (DataTable)c.ShowDataInGridView(query);
                      dataGridServices.DataSource=dt;
                      c.CloseConnection();
                  }
              }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.ToString());
              }
      }

      private void btnRequest_Click(object sender, EventArgs e)
      {
           if (txtpatient_code.Text == "" || txtService_code.Text == "" || txtArabic_name.Text == "")
          { MessageBox.Show("من فضلك قم بإختيار المريض والخدمة المطلوبة من قائمة الخدمات ", "رسالة"); }
          else
          {
               try
               { 
              c.OpenConection();
              string[] para_names = new string[] { "@account_number,@Service_code,@_date,@Quantity " };
              string[] para_values = new string[] { txtpatient_code.Text, txtService_code.Text, dateTimePicker1.Text, numericQuantity.Value.ToString() };
              SqlDbType [] data_types= new SqlDbType[]{SqlDbType.Int,SqlDbType.Int,SqlDbType.Int,SqlDbType.Date};
              c.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("[add_lap_service]", para_names, para_values, data_types);

               MessageBox.Show("تم إضافة الخدمة بنجاح");
               c.CloseConnection();   
              }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.ToString());


              }
          }
      }


      private void btnshowCurrent_click(object sender, EventArgs e)
      {
          if (txtpatient_code.Text == "")
          { MessageBox.Show("من فضلك اختر المريض الذي تود ان تستعلم عن الخدمات الحالية لديه ", "تنبيه"); }
          else
          { 
              try
              {
                  c.OpenConection();
                  string[] param_names = new string[]{"@account_number"};
                  string[] param_values = new string[] { txtService_code.Text };
                  SqlDbType[] param_types = new SqlDbType[] { SqlDbType.NVarChar };
                  DataTable dt = new DataTable();
                  dataGridcurrentService.DataSource=(DataTable) c.ShowDataInGridViewUsingStoredProc("show_current_service");
                  c.CloseConnection();
              }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.ToString());
              }
          }


      }
     
      private void dataGridServices_MouseClick(object sender, MouseEventArgs e)
      {
          try
          {
              int i = dataGridServices.CurrentRow.Index;
              txtService_code.Text = dataGridServices.Rows[i].Cells["كود الخدمة"].Value.ToString();
          }
          catch (Exception ee)
          {
              MessageBox.Show(ee.Message);
          }
      }

      private void dataGridPatients_MouseClick(object sender, MouseEventArgs e)
      {
          try
          {
              int i = dataGridPatients.CurrentRow.Index;
              txtpatient_code.Text = dataGridPatients.Rows[i].Cells["كود المريض"].Value.ToString();
              txtArabic_name.Text = dataGridPatients.Rows[i].Cells["الاسم"].Value.ToString();
              cbGender.Text = dataGridPatients.Rows[i].Cells["النوع"].Value.ToString();
          }
          catch (Exception ee)
          {
              MessageBox.Show(ee.Message);
          }
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
              try
          {
              
              if (txtcurrent.Text == "")
              { MessageBox.Show("من فضلك اختر الخدمة المراد إلغاؤها  !", "تنبيه"); }
              else 
              {
               DialogResult dialogResult = MessageBox.Show("هل انت متأكد من إلغاء الخدمة المحددة ؟", "تنبيه", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                c.OpenConection();
                string[] param_names = new string[] { "@service_code" };
                string[] param_values = new string[] { txtcurrent.Text };
                SqlDbType[] param_type = new SqlDbType[] { SqlDbType.NVarChar };
                c.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_service", param_names, param_values, param_type);
                string[]param_name = new string[]{"@account_number","@Service_code","@_date","@Quantity"};
                string[]param_value = new string[]{txtpatient_code.Text,txtService_code.Text,dateTimePicker1.Text,numericQuantity.Value.ToString()};
                SqlDbType [] types = new SqlDbType[] {SqlDbType.Int,SqlDbType.NVarChar,SqlDbType.Date,SqlDbType.Int};
                c.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("add_deleted_service", param_name, param_value,types);
                c.CloseConnection();
              MessageBox.Show("تم إلغاءالخدمة بنجاح");
              txtcurrent.Clear();

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

      private void dataGridcurrentService_MouseClick(object sender, MouseEventArgs e)
      {
          try
          {
              int i = dataGridcurrentService .CurrentRow.Index;
              txtcurrent.Text = dataGridcurrentService .Rows[i].Cells["كود الخدمة"].Value.ToString();
          }
          catch (Exception ee)
          {
              MessageBox.Show(ee.Message);
          }
      }

      private void txtArabic_name_KeyPress(object sender, KeyPressEventArgs e)
      {
          validate.letter(sender, e, this);

      }

      private void txtpatient_code_KeyPress(object sender, KeyPressEventArgs e)
      {
          validate.integer(sender, e, this);

      }

      private void txtService_code_KeyPress(object sender, KeyPressEventArgs e)
      {
          validate.integer(sender, e, this);

      }

      private void txtcurrent_KeyPress(object sender, KeyPressEventArgs e)
      {
          validate.integer(sender, e, this);

      }
      }
      }
    
