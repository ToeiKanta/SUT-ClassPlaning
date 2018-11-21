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
using System.Text.RegularExpressions;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace CourseManagement
{
    public partial class MainForm : Form
    {
        public int timeTotal = 0;
        public int tableState = 1;

        public MainForm()
        {
            InitializeComponent();
            
            dataGridView1.BorderStyle = BorderStyle.FixedSingle;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            /*
            if(dataGridView1.SelectedColumns.ToString() == "3" )
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            else
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.White;
            */
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersHeight = 35;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            richTextBox1.Visible = false;
            updateTable();
        }

        public void clearTable()
        {
                tableCourse.Controls.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddNewCourse addNewCourse = new AddNewCourse(this);
            addNewCourse.Show();
        }

        private void updateFontTable()
        {
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Cordia New", 16);
            }
        }

        private void Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //Change Color of Column Color
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    Color color = Color.FromName(row.Cells[1].Value.ToString());
                    row.Cells[1].Style.ForeColor = color;
                    row.Cells[1].Style.BackColor = color;
                    //Edit Column
                    row.Cells[6].Style.BackColor = Color.DarkCyan;
                    //Delete Column
                    row.Cells[7].Style.BackColor = Color.DarkRed;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Filed : " + ex.Message.ToString());
                }
            }
                //int qtyEntered = Convert.ToInt16(row.Cells[1].Value);
                //if (qtyEntered <= 0)
                //{
                //    ItemDg[0, count].Style.BackColor = Color.Red;//to color the row
                //    ItemDg[1, count].Style.BackColor = Color.Red;

                //    ItemDg[0, count].ReadOnly = true;//qty should not be enter for 0 inventory                       
                //}
                //ItemDg[0, count].Value = "0";//assign a default value to quantity enter
                //count++;
            
            //dataGridView1.Rows[0].Cells[1].Style.BackColor = Color.Red;
        }

        public bool updateTable()
        {
            try {
                noCourseLabel2.Visible = true;
                noCourseLabel.Visible = true;
                //TableCourse.Controls.Clear();
                //TableCourse.RowStyles.Clear();
                SQLiteConnection myconn = new SQLiteConnection(@"Data Source = .\Database.db");
                myconn.Open();
                DataTable dt1 = new DataTable();
                string query = "SELECT ID,Color,NameID,Name,Credit,Date FROM Course WHERE TableState LIKE " + tableState;
            
                SQLiteDataAdapter myadap = new SQLiteDataAdapter(query, myconn);

                myadap.Fill(dt1);
                dt1.Columns.Add(new DataColumn("Edit", typeof(Label)));
                dt1.Columns.Add(new DataColumn("Delete", typeof(Label)));
                dataGridView1.DataSource = dt1;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToResizeColumns = false;
                dataGridView1.AllowUserToResizeRows = false;
                dataGridView1.DefaultCellStyle.BackColor = Color.DarkTurquoise;

                dataGridView1.Columns[0].HeaderText = "ไอดี";
                dataGridView1.Columns[1].HeaderText = " เลือกสี";
                dataGridView1.Columns[2].HeaderText = "รหัสวิชา";
                dataGridView1.Columns[3].HeaderText = "ชื่อวิชา";
                dataGridView1.Columns[4].HeaderText = "หน่วยกิต";
                dataGridView1.Columns[5].HeaderText = "วันเวลาเรียน";
                dataGridView1.Columns[6].HeaderText = "แก้ไขข้อมูล";
                dataGridView1.Columns[7].HeaderText = "ลบข้อมูล";

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Width = 60;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                updateFontTable();
                //dataGridView1.RowCount = 5;

                //Update MainTable with show course
                int creditTotal = 0;
                int courseTotal = 0;
                using (SQLiteCommand fmd = myconn.CreateCommand())
                {
                    fmd.CommandText = @"SELECT NameID,Name,Date,Color,Credit FROM Course WHERE TableState LIKE " + tableState;
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    this.timeTotal = 0;
                    
                    while (r.Read())
                    {
                        courseTotal++;
                        creditTotal += Convert.ToInt16(r["Credit"]);
                        //color
                        Color courseColor = Color.FromName(Convert.ToString(r["Color"]));
                        //
                        
                        bool isSucess = timeAnalizeAndUpdateTable(Convert.ToString(r["Date"]), Convert.ToString(r["NameID"]) + " " + Convert.ToString(r["Name"]), courseColor);
                        
                        if (!isSucess)
                        {
                            myconn.Close();
                            return false;
                        }
                    }
                    this.TimeTotal.Text = this.timeTotal.ToString();
                }
                if(courseTotal != 0)
                {
                    noCourseLabel2.Visible = false;
                    noCourseLabel.Visible = false;
                } 
                CourseTotal.Text = courseTotal.ToString();
                CredtiTotal.Text = creditTotal.ToString();
                myconn.Close();
                
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }

        private bool timeAnalizeAndUpdateTable(string s,string name,Color courseColor)
        {
            try
            {
                //RichTextTestSeperateDate
                richTextBox1.Visible = false; // Test only
                                              //Label 
                                              // string s = "Mo10:00-12:00 B4101We10:00-12:00 B4101Fr08:00-10:00 B2102";
                string regExp = @"(?<Day>[A-Za-z]+)(?<Time>[0-9:-]+)(?<remove>[ ])";
                Regex reg = new Regex(regExp);
                Int32 row = 0;
                Int32 col = 0;
                Int32 colSpan = 1;
                foreach (Match item in reg.Matches(s))
                {
                    if (item.Groups["Day"].Value == "Su")
                    {
                        row = 6;
                        richTextBox1.AppendText("อาทิตย์\r\n");
                    }
                    else
                    if (item.Groups["Day"].Value == "Mo")
                    {
                        row = 0;
                        richTextBox1.AppendText("จันทร์\r\n");
                    }
                    else
                    if (item.Groups["Day"].Value == "Tu")
                    {
                        row = 1;
                        richTextBox1.AppendText("อังคาร\r\n");
                    }
                    else
                     if (item.Groups["Day"].Value == "We")
                    {
                        row = 2;
                        richTextBox1.AppendText("พุธ\r\n");
                    }
                    else
                    if (item.Groups["Day"].Value == "Th")
                    {
                        row = 3;
                        richTextBox1.AppendText("พฤหัสบดี\r\n");
                    }
                    else
                    if (item.Groups["Day"].Value == "Fr")
                    {
                        row = 4;
                        richTextBox1.AppendText("ศุกร์\r\n");
                    }
                    else
                    if (item.Groups["Day"].Value == "Sa")
                    {
                        row = 5;
                        richTextBox1.AppendText("เสาร์\r\n");
                    }
                    else
                    {
                        MessageBox.Show("ไม่มีวันนี้ในระบบ กรุณาตรวจสอบรูปแบบอีกครั้ง \nSu Mo Tu We Th Fr Sa");
                        return false;
                    }

                    //
                    Console.WriteLine("Name = " + name);
                    Console.WriteLine("Row = " + col);
                    string[] str2 = item.Groups["Time"].Value.Split('-');
                    bool firstTime = true;
                    foreach (string str in str2)
                    {
                        string regExp2 = @"(?<Time>[0-9]+)";
                        Regex reg2 = new Regex(regExp2);

                        foreach (Match item2 in reg2.Matches(str))
                        {
                            if (item2.ToString() != "00")
                            {
                                if (firstTime == true)
                                {
                                    col = Int32.Parse(item2.ToString()) - 8;
                                    Console.WriteLine("Col = "+ col);
                                    firstTime = false;
                                }
                                else
                                {
                                    colSpan = Int32.Parse(item2.ToString()) - 8 - col;
                                }
                                richTextBox1.AppendText(item2 + "col: " + col + "\r\n");
                            }
                        }
                    }
                    Console.WriteLine("Colspan = " + colSpan);
                    Console.WriteLine("===============");
                    if ( ! createTableLabel(name, col, row, colSpan, courseColor))
                    {
                        //MessageBox.Show("Failed : createTableLabel");
                        return false;
                    }
                    this.timeTotal += colSpan;
                    // richTextBox1.AppendText(item.Groups["Time"].Value + "\r\n"); //10.00-13.00

                }
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
            
     
        }

        public bool CheckCanUpdateTable(string nameID,string name , string date,Color color)
        {
            
            try
            {
                bool isSucess = timeAnalizeAndUpdateTable(date, nameID + " " + name, color);
                if (!isSucess)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }

        int count = 0;
        private bool createTableLabel(string name, int col, int row, int colSpan, Color courseColor)
        {
            try
            {
                Label myLabel = new Label();
                myLabel.Name = "TableLabel" + count++;
                myLabel.Parent = tableCourse;
                myLabel.Visible = false;
                myLabel.Text = name;

                if (tableCourse.GetControlFromPosition(col, row) != null )
                {
                    if(tableCourse.GetControlFromPosition(col, row).Text == myLabel.Text)
                    {
                        Controls.Remove(myLabel);
                        myLabel.Dispose();
                        return false;
                    }
                    //เมื่อเวลาทับกัน
                    //var temp = TableCourse.GetControlFromPosition(col, row).BackColor;
                    //TableCourse.GetControlFromPosition(col, row).BackColor = Color.Red;
                    //var result = MessageBox.Show("กรุณาเช็คเวลาเรียนอีกครั้ง", "เวชาซ้ำซ้อน",MessageBoxButtons.OK);
                    //if(result == DialogResult.OK)
                    //{
                    //    TableCourse.GetControlFromPosition(col, row).BackColor = temp;
                    //}

                    string txtRow = "";

                    switch (row)
                    {
                        case 0:
                            txtRow = "จันทร์";
                            break;
                        case 1:
                            txtRow = "อังคาร";
                            break;
                        case 2:
                            txtRow = "พุธ";
                            break;
                        case 3:
                            txtRow = "พฤหัส";
                            break;
                        case 4:
                            txtRow = "ศุกร์";
                            break;
                        case 5:
                            txtRow = "เสาร์";
                            break;
                        case 6:
                            txtRow = "อาทิตย์";
                            break;
                    }
                    MessageBox.Show("เวลาตรงกันกับ \n" + tableCourse.GetControlFromPosition(col, row).Text + "\nวัน" + txtRow + " เวลา " + (col+8)  + ".00 น.\nไม่สามารถเพิ่มรายวิชานี้ได้", "เวชาซ้ำซ้อน", MessageBoxButtons.OK);
                    return false;
                }
                else
                {
                    //test button create TableLabel
                    
                    myLabel.BackColor = courseColor;
                    myLabel.Dock = DockStyle.Fill;
                    myLabel.Margin = new Padding(0, 0, 0, 0);
                    myLabel.ForeColor = Color.White;
                    myLabel.TextAlign = ContentAlignment.MiddleCenter;
                    myLabel.Font = new Font("Cordia New", 14, FontStyle.Bold);
                    myLabel.Visible = true;

                    tableCourse.SetColumnSpan(myLabel, colSpan);
                    tableCourse.Controls.Add(myLabel);

                    TableLayoutPanelCellPosition TempPos = new TableLayoutPanelCellPosition();
                    TempPos.Column = col;
                    TempPos.Row = row;
                    tableCourse.SetCellPosition(myLabel, TempPos);

                    //label.Location = new System.Drawing.Point(317, 119 + customLabels.Count * 26);
                    // label.Parent = tabPage2;
                    // label.Name = "label" + ValutaCustomScelta;
                    //label.Text = ValutaCustomScelta;
                    //label.Size = new System.Drawing.Size(77, 21);
                    //customLabels.Add(label);
                    //tabPage2.Controls.Add(label);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //ColorPicker
            if (dataGridView1.CurrentCell.ColumnIndex == 1 && e.RowIndex != -1 && e.RowIndex != dataGridView1.RowCount - 1)
            {
                if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                {
                    Console.WriteLine(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    ColorPicker cPicker = new ColorPicker(this,dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    cPicker.ShowDialog();
                }
            }
            //Edit
            if (dataGridView1.CurrentCell.ColumnIndex == 6 && e.RowIndex != -1 && e.RowIndex != dataGridView1.RowCount - 1)
            {
                if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                {
                    string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    AddNewCourse editCourse = new AddNewCourse(this,id);
                    editCourse.Show();
                }
            }
            //Delete
            if (dataGridView1.CurrentCell.ColumnIndex == 7 && e.RowIndex != -1 && e.RowIndex != dataGridView1.RowCount-1) 
            {
                if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                {
                    DialogResult dialogResult = MessageBox.Show("กดยืนยัน เพื่อลบรายวิชานี้", "Delete this course", MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.OK)
                    {
                        SQLiteConnection myconn = new SQLiteConnection(@"Data Source = .\Database.db");
                        myconn.Open();
                        string query = "DELETE FROM Course WHERE ID = " + dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                       
                        SQLiteCommand command = new SQLiteCommand(query, myconn);
                        command.ExecuteNonQuery();
                        myconn.Close();
                        //TableCourse.Controls.RemoveByKey(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()); 
                        clearTable();
                        updateTable();
                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        //do nothing
                    }
                }
            }
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            clearTable();
            updateTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void clearDataBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("กด ยืนยัน หากต้องการลบข้อมูลรายวิชาในตารางเรียนที่" + tableState + " ทั้งหมด \nหากลบแล้วจะไม่สามารถกู้คืนข้อมูลเก่าได้", "ยืนยันการลบข้อมูล", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string dataSource = "Database.db";
                    using (SQLiteConnection connection = new SQLiteConnection())
                    {
                        connection.ConnectionString = "Data Source=" + dataSource;
                        connection.Open();

                        using (SQLiteCommand cmd = new SQLiteCommand(connection))
                        {
                            cmd.CommandText = "DELETE FROM Course WHERE TableState = " + tableState;
                            cmd.ExecuteNonQuery();
                        }
                        connection.Close();
                    }
                    this.clearTable();
                    this.updateTable();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error... กรุณาติดต่อผู้พัฒนา" + ex.Message.ToString());
                }
            }
            else if (result == DialogResult.No)
            {
                //...
            }
            else
            {
                //...
            }


        }

        private void ShowTabel_Click(object sender, EventArgs e)
        {
            Label courseChoosen = (Label) sender;
            int choosenIndex = 1;
            if (courseChoosen.Name.ToString() == "ShowTable1")
                choosenIndex = 1;
            else
            if (courseChoosen.Name.ToString() == "ShowTable2")
                choosenIndex = 2;
            else
            if (courseChoosen.Name.ToString() == "ShowTable3")
                choosenIndex = 3;
            else
            if (courseChoosen.Name.ToString() == "ShowTable4")
                choosenIndex = 4;
            else
            {
                MessageBox.Show("Error...");
            }

            if (this.tableState != choosenIndex)
            {
                noCourseLabel2.Text = "ในตารางเรียน " + choosenIndex;
                ShowTable1.ForeColor = Color.White;
                ShowTable2.ForeColor = Color.White;
                ShowTable3.ForeColor = Color.White;
                ShowTable4.ForeColor = Color.White;
                if(choosenIndex == 1) 
                    ShowTable1.ForeColor = Color.Yellow;
                else
                if (choosenIndex == 2)
                    ShowTable2.ForeColor = Color.Yellow;
                else
                if (choosenIndex == 3)
                    ShowTable3.ForeColor = Color.Yellow;
                else
                    ShowTable4.ForeColor = Color.Yellow;

                this.tableState = choosenIndex;
                this.clearTable();
                this.updateTable();
            }

        }

        
    }
}
