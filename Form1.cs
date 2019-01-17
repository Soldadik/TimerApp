using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        bool start = true;
        int i = 0;
        string time_total;
        DateTime date = new DateTime();
        DateTime date_total = new DateTime();

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = "";
            string time_t = "";
            //string time_t = time_total;

            i++;

            date = date.AddSeconds(1);
            date_total = date_total.AddSeconds(1);

            int hh = date.Hour;
            int mm = date.Minute;
            int ss = date.Second;

            int hht = date_total.Hour;
            int mmt = date_total.Minute;
            int sst = date_total.Second;

            /*Лог
            WriteFile.WriteLine("HH = " + date_total.Hour);
            WriteFile.WriteLine("MM = " + date_total.Minute);
            WriteFile.WriteLine("SS = " + date_total.Second);
            */
            
            //Часы
            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }

            if (hht < 10)
            {
                time_t += "0" + hht;
            }
            else
            {
                time_t += hht;
            }
            time += ":";
            time_t += ":";

            //Минуты
            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }

            if (mmt < 10)
            {
                time_t += "0" + mmt;
            }
            else
            {
                time_t += mmt;
            }
            time += ":";
            time_t += ":";

            //Секунды
            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }

            if (sst < 10)
            {
                time_t += "0" + sst;
            }
            else
            {
                time_t += sst;
            }

            label_current.Text = time;
            label_total.Text = time_t;
        }

        private void ReadInfoFromFile()
        {
            StreamReader ReadFile = File.OpenText("time_tracker.cfg");
            string[] lines = ReadFile.ReadToEnd().Split('\n');
            ReadFile.Close();
            date_total = DateTime.MinValue;

            time_total = lines[0];
            label_total.Text = lines[0];
            label_last.Text = lines[1];

            TimeSpan ts = new TimeSpan();
            ts = TimeSpan.Parse(time_total);
            date_total = date_total.Date + ts;

        }

        private void WriteInfoToFile()
        {
            StreamWriter WriteFile = new StreamWriter("time_tracker.cfg");
            WriteFile.WriteLine(label_total.Text);
            WriteFile.WriteLine(label_current.Text);
            WriteFile.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadInfoFromFile();
            date = DateTime.MinValue;
            timer1.Enabled = true;
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            WriteInfoToFile();
        }
    }
}
