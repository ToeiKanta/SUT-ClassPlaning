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

namespace CourseManagement
{
    public partial class ColorPicker : Form
    {

        MainForm mainForm;

        public ColorPicker(MainForm mFrm)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private string globalId;

        public ColorPicker(MainForm mFrm,String id)
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            mainForm = mFrm;
            globalId = id;
        }

        private void ColorPicker_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            SQLiteConnection myconn = new SQLiteConnection(@"Data Source = .\Database.db");
            myconn.Open();

            string regExp = @"(?<unuse>[ []+)(?<color>[A-za-z]+)(?<unuse2>[]]+)";

            Regex reg = new Regex(regExp);
            string colorName = " ";
            Panel colorChoosen = (Panel)sender;
            foreach (Match item in reg.Matches(colorChoosen.BackColor.ToString()))
            {
                //MessageBox.Show(item.Groups["color"].Value.ToString());
                 colorName = item.Groups["color"].Value.ToString();
            }
            string query = "UPDATE Course SET Color = '" + colorName + "' WHERE ID = " + globalId ;

            SQLiteCommand command = new SQLiteCommand(query, myconn);
            command.ExecuteNonQuery();
            myconn.Close();
            mainForm.clearTable();
            mainForm.updateTable();
            //MessageBox.Show(sender.ToString());
            this.Close();
        }
    }
}
