using System;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace CourseManagement
{
    public partial class FindCourse : Form
    {
        public FindCourse()
        {
            InitializeComponent();
        }
        #region UI Event Handlers
        private void button1_Click(object sender, EventArgs e)
        {
            
            RESTClient rClient = new RESTClient();

            rClient.endPoint = txtRequestURI.Text;
            //debugOutput("RESTClient Object created.");

            string strJSON = string.Empty;
            strJSON = rClient.makeRequest();
            deserializeJSON(strJSON);
            //Change ComboBox Selection
            debugOutput("ชื่อวิชา " + jCourseG.Name);
            debugOutput("ชื่อวิชา " + jCourseG.Name);
            debugOutput("หน่วยกิต " + jCourseG.Credit);
            debugOutput("กลุ่มทั้งหมด " + jCourseG.Groups.Count);
            /*
                
       
            */
            
            for (int z = 1; z <= jCourseG.Groups.Count; z++)
            {
                SelectGroup.Items.Add(z);
            }
        }
        #endregion

        //Global Variable
        public static CourseManagement.Courses jCourseG;

        #region function json
        private void deserializeJSON(string strJSON) {
            try
            {
                
                var jCourse = JsonConvert.DeserializeObject<Courses>(strJSON);
                jCourseG = jCourse;
               
            }
            catch(Exception ex)
            {
                debugOutput("We have problem with " + ex.Message.ToString());
            }
        }
        #endregion
        private void debugOutput(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                txtResponse.Text = txtResponse.Text + strDebugText + Environment.NewLine;
                txtResponse.SelectionStart = txtResponse.TextLength;
                txtResponse.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }
        }
        //monitor
        private void showOnMonitor(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                CourseMonitor.Text = CourseMonitor.Text + strDebugText + Environment.NewLine;
                CourseMonitor.SelectionStart = CourseMonitor.TextLength;
                CourseMonitor.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }
        }

        private void txtResponse_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtResponse.Text = " ";
            int x = SelectGroup.SelectedIndex+1;
            debugOutput("===========กลุ่ม " + x.ToString() + "===========");
            for (int z = 1; z <= 2; z++)
            {
                switch (z)
                {
                    case 1:
                        if(jCourseG.Groups[x.ToString()].The0 != null)
                        {
                            debugOutput("ข้อมูลรายวิชา");
                            debugOutput("");
                            debugOutput("วัน" + jCourseG.Groups[x.ToString()].The0.Date + " " +
                                        "เวลา " + jCourseG.Groups[x.ToString()].The0.Time);
                            debugOutput("ห้องเรียน " + jCourseG.Groups[x.ToString()].The0.Room + " " +
                                        "อาคาร " + jCourseG.Groups[x.ToString()].The0.Building);
                        }
                  
                        break;
                    case 2:
                        if (jCourseG.Groups[x.ToString()].The1 != null)
                        {
                            debugOutput("");
                            debugOutput("วัน" + jCourseG.Groups[x.ToString()].The1.Date + " " + "เวลา " + jCourseG.Groups[x.ToString()].The1.Time);
                            debugOutput("ห้องเรียน " + jCourseG.Groups[x.ToString()].The1.Room + " " + "อาคาร " + jCourseG.Groups[x.ToString()].The1.Building);
                        }
                        break;
                    case 3:
                        if (jCourseG.Groups[x.ToString()].The2 != null)
                        {
                            debugOutput("");
                            debugOutput("วัน" + jCourseG.Groups[x.ToString()].The2.Date + " " + "เวลา " + jCourseG.Groups[x.ToString()].The2.Time);
                            debugOutput("ห้องเรียน " + jCourseG.Groups[x.ToString()].The2.Room + " " + "อาคาร " + jCourseG.Groups[x.ToString()].The2.Building);
                        }
                        break;
                    default:
                        debugOutput("No Data");
                        break;
                }
            }
            debugOutput("======================");
            debugOutput(jCourseG.Groups[x.ToString()].Detail);
        }
    }
}
