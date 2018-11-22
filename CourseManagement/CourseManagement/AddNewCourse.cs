using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace CourseManagement
{
    public partial class AddNewCourse : Form
    {
        MainForm mainForm;
        public AddNewCourse(MainForm mFrm)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            mainForm = mFrm;
            this.webBrowser1.Navigate("http://reg5.sut.ac.th/registrar/class_info.asp");
        }
        
        public AddNewCourse(MainForm mFrm,string id)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            mainForm = mFrm;
            this.webBrowser1.Navigate("http://reg5.sut.ac.th/registrar/class_info.asp");
            loadEditForm(id);
            txtTime.ForeColor = Color.Black;
            txtNameID.ForeColor = Color.Black;
            txtName.ForeColor = Color.Black;
            topicName.Text = "แก้ไขรายวิชา";
        }

        string editID = "";
        private void loadEditForm(string id)
        {
            this.editID = id;
            SQLiteConnection myconn = new SQLiteConnection(@"Data Source = .\Database.db");
            myconn.Open();
            using (SQLiteCommand fmd = myconn.CreateCommand())
            {
                fmd.CommandText = @"SELECT NameID,Name,Date,Credit FROM Course WHERE ID =" + id;
                fmd.CommandType = CommandType.Text;
                SQLiteDataReader r = fmd.ExecuteReader();
                while (r.Read())
                {
                    txtNameID.Text = r["NameID"].ToString();
                    txtName.Text = r["Name"].ToString();
                    selectCredit.SelectedIndex = Convert.ToInt16(r["Credit"])-1;
                    FindCourseBtn.Visible = false;
                    ClearFormBtn.Visible = false;
                    EditCourseBtn.Visible = true;
                    CancelEditBtn.Visible = true;
                    txtTime.Text = r["Date"].ToString();
                    //MessageBox.Show(r["NameID"].ToString());
                }
            }
            myconn.Close();

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.webBrowser1.GoBack();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        

        private void btnFindCourse_Click(object sender, EventArgs e)
        {
            try
            {
                if (isCompleteForm())
                {
                    SQLiteConnection myconn = new SQLiteConnection(@"Data Source = .\Database.db");
                    myconn.Open();
                    DataTable dt1 = new DataTable();
                    var nameID = this.txtNameID.Text.ToString();
                    var name = this.txtName.Text.ToString();
                    var credit = this.selectCredit.SelectedItem;
                    var date = this.txtTime.Text.ToString();
                    Color color = Color.DarkGray;
                    string txtColor = "DarkGray";
                    if (mainForm.CheckCanUpdateTable(nameID, name, date, color))
                    {
                        string sql = "insert into Course (NameID, Name, Credit ,Date,TableState,Color) values ('" + nameID + "', '" + name + "' , " + credit + ", '" + date + "', " + mainForm.tableState + ",'" + txtColor + "' )";
                        SQLiteCommand command = new SQLiteCommand(sql, myconn);
                        command.ExecuteNonQuery();
                        //MessageBox.Show("Passed");
                        mainForm.clearTable();
                        mainForm.updateTable();
                        SuccessLabel.Visible = true;
                        this.Close();
                    }
                    else
                    {

                        //MessageBox.Show("Error มีรายวิชาซ้ำซ้อน");
                    }
                    myconn.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด กรุณาติดต่อผู้พัฒนา \n"+ex.Message.ToString());
            }
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        bool isDateChange = false;
        private void EditCourseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (isCompleteForm())
                {

                    var nameID = this.txtNameID.Text.ToString();
                    var name = this.txtName.Text.ToString();
                    var credit = this.selectCredit.SelectedItem;
                    var date = this.txtTime.Text.ToString();
                    Color color = Color.DarkGray;

                    string dataSource = "Database.db";

                    //กรณีเวลาไม่เปลี่ยน
                    if (this.isDateChange == false)
                    {
                        using (SQLiteConnection connection = new SQLiteConnection())
                        {
                            connection.ConnectionString = "Data Source=" + dataSource;
                            connection.Open();

                            using (SQLiteCommand cmd = new SQLiteCommand(connection))
                            {
                                cmd.CommandText =
                                    "UPDATE Course SET NameID = :nameID, name = :name, Credit = :credit, Date = :date where ID=:id";
                                cmd.Parameters.Add("nameID", DbType.String).Value = txtNameID.Text;
                                cmd.Parameters.Add("name", DbType.String).Value = txtName.Text;
                                cmd.Parameters.Add("credit", DbType.Int16).Value = selectCredit.SelectedIndex + 1;
                                cmd.Parameters.Add("date", DbType.String).Value = txtTime.Text;
                                cmd.Parameters.Add("id", DbType.Int64).Value = this.editID;
                                cmd.ExecuteNonQuery();
                            }
                            connection.Close();

                        }
                        DialogResult dialogResult = MessageBox.Show("ยืนยันการแก้ไข", "ดำเนินการต่อหรือไม่", MessageBoxButtons.OKCancel);
                        if (dialogResult == DialogResult.OK)
                        {
                            this.Close();
                            mainForm.clearTable();
                            mainForm.updateTable();
                        }
                    }
                    else
                    //กรณีเวลาเปลี่ยน
                    if (mainForm.CheckCanUpdateTable(nameID, name, date, color))
                    {
                        using (SQLiteConnection connection = new SQLiteConnection())
                        {
                            connection.ConnectionString = "Data Source=" + dataSource;
                            connection.Open();

                            using (SQLiteCommand cmd = new SQLiteCommand(connection))
                            {
                                cmd.CommandText =
                                    "UPDATE Course SET NameID = :nameID, name = :name, Credit = :credit, Date = :date where ID=:id";
                                cmd.Parameters.Add("nameID", DbType.String).Value = txtNameID.Text;
                                cmd.Parameters.Add("name", DbType.String).Value = txtName.Text;
                                cmd.Parameters.Add("credit", DbType.Int16).Value = selectCredit.SelectedIndex + 1;
                                cmd.Parameters.Add("date", DbType.String).Value = txtTime.Text;
                                cmd.Parameters.Add("id", DbType.Int64).Value = this.editID;
                                cmd.ExecuteNonQuery();
                            }
                            connection.Close();
                        }
                        DialogResult dialogResult = MessageBox.Show("ยืนยันการแก้ไข", "ดำเนินการต่อหรือไม่", MessageBoxButtons.OKCancel);
                        if (dialogResult == DialogResult.OK)
                        {
                            this.Close();
                            mainForm.clearTable();
                            mainForm.updateTable();

                        }
                        else if (dialogResult == DialogResult.Cancel)
                        {
                            //do something else
                        }
                    }
                    else
                    {
                        MessageBox.Show("เกิดข้่อผิดพลาด กรุณาตรวจสอบฟอร์มอีกครั้ง หรือทำการลบวิชาแล้วทำการเพิ่มรายวิชาใหม่อีกครั้ง");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด กรุณาติดต่อผู้พัฒนา \n" + ex.Message.ToString());
            }

           
            
        }

        private void txtTime_Enter(object sender, EventArgs e)
        {
            if (txtTime.Text == "Mo10:00-12:00 B1111\nWe10:00-12:00 B1111\nFr08:00-10:00 B1111")
            {
                txtTime.Text = "";
            }
            txtTime.ForeColor = Color.Black;
        }

        private void txtTime_Leave(object sender, EventArgs e)
        {
            
            if (txtTime.Text == "")
            {
                txtTime.Text = "Mo10:00-12:00 B1111\nWe10:00-12:00 B1111\nFr08:00-10:00 B1111";
                txtTime.ForeColor = Color.Gray;
            }
        }

        private bool isCompleteForm()
        {
            if (txtNameID.Text == getPlaceHolder("txtNameID") || string.IsNullOrWhiteSpace(txtNameID.Text))
            {
                MessageBox.Show("กรุณากรอกรหัสวิชา");
                return false;
            }else
            if (txtName.Text == getPlaceHolder("txtName") || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("กรุณากรอกชื่อวิชา");
                return false;
            }else
            if (selectCredit.SelectedIndex == -1)
            {
                MessageBox.Show("กรุณาเลือกหน่วยกิต");
                return false;
            }
            else
            if(txtTime.Text == "Mo10:00-12:00 B1111\nWe10:00-12:00 B1111\nFr08:00-10:00 B1111" || string.IsNullOrWhiteSpace(txtTime.Text))
            {
                MessageBox.Show("กรุณากรอกวันและเวลาเรียน");
                return false;
            }
            return true;
        }

        private string getPlaceHolder(string str)
        {
            if (str == "txtNameID")
                // NameID
                return "121234";
            else
            if (str == "txtName")
                // NameID
                return "Course Name";
            else
                return "";

        }

        private void TxtPlaceHoler_Enter(object sender, EventArgs e)
        {
           TextBox txtBox = (TextBox)sender;
            //MessageBox.Show(txtBox.Name.ToString());
            if(txtBox.Text == getPlaceHolder(txtBox.Name.ToString()))
            {
                txtBox.Text = "";
            }
            txtBox.ForeColor = Color.Black;
        }

        private void TxtPlaceHoler_Leave(object sender, EventArgs e)
        {
            TextBox txtBox = (TextBox)sender;
            if (txtBox.Text == "")
            {
                txtBox.Text = getPlaceHolder(txtBox.Name.ToString());
                txtBox.ForeColor = Color.Gray;
            }
            
        }

        private void CancelEditBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearFormBtn_Click(object sender, EventArgs e)
        {
            this.txtNameID.Text = "";
            this.txtName.Text = "";
            this.selectCredit.SelectedIndex = -1;
            this.txtTime.Text = "";
        }

        private void txtTime_TextChanged(object sender, EventArgs e)
        {
            this.isDateChange = true;
        }
    }
}
