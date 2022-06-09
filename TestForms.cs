using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TomatoTimer
{
    public partial class TestForms : Form
    {
        List<MyInterval> TimeInter;
        myStopWotch Woch;
        MyTomatoTim TomTim;
        public TestForms()
        {
            InitializeComponent();
            TimeInter = null;
            Woch = new myStopWotch();
            TomTim = null;
            

        }

        void textLabl1(string str) { label1.Text = str; }
        void textLabl2(string str) { label2.Text = str; }
        void ShowMyMess(string str) 
        {
            MessageBox.Show(str);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (TimeInter == null) { TimeInter = new List<MyInterval>(); }
            if (!btn_Create.Enabled) { btn_Create.Enabled = true; }
            TimeInter.Add(new MyInterval(textBox1.Text, (int)numericUpDown1.Value));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0) { btnAdd.Enabled = false; }
            else btnAdd.Enabled = true;
        }
        private void btn_Create_Click(object sender, EventArgs e)
        {
            btn_Create.Enabled = false;
            TomTim = new MyTomatoTim(TimeInter);
            Woch.getTime = TomTim.newTimeIntervalActiv;
            TomTim.getMyMinute = Woch.StartInterval;
            TomTim.getMyNamInterval = textLabl1;
            TomTim.MyTimeNow = textLabl2;
            TomTim.EndTimer = ShowMyMess;
            TimeInter = null;
            groupBox2.Enabled = false;
            groupBox1.Enabled = true;
        }

        private void btn_newTim_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            groupBox1.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            TomTim.StartTimer();
        }
    }
}
