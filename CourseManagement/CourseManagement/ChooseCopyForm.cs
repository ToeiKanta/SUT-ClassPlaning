using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseManagement
{
    public partial class ChooseCopyForm : Form
    {
        public int ReturnValue1 { get; set; }

        public ChooseCopyForm()
        {
            InitializeComponent();
        }

        public ChooseCopyForm(int thisTableState)
        {
            InitializeComponent();
            switch (thisTableState)
            {
                case 1: button1.Enabled = false;break;
                case 2: button2.Enabled = false; break;
                case 3: button3.Enabled = false; break;
                case 4: button4.Enabled = false; break;
                default: MessageBox.Show("Error..."); break;
            }
        }

        private void ChooseCopyForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ReturnValue1 = 1;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ReturnValue1 = 2;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.ReturnValue1 = 3;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.ReturnValue1 = 4;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
