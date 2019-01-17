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
        FileStream file = new FileStream("time_tracker.conf", FileMode.OpenOrCreate);
        StreamWriter WriteFile = new StreamWriter("log.txt");


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
            date_total = date.AddSeconds(1);

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
            else if (hht < 10)
            {
                time_t += "0" + hht;
            }
            else
            {
                time += hh;
                time_t += hht;
            }
            time += ":";
            time_t += ":";

            //Минуты
            if (mm < 10)
            {
                time += "0" + mm;
            }
            else if (mmt < 10)
            {
                time_t += "0" + mmt;
            }
            else
            {
                time += mm;
                time_t += mmt;
            }
            time += ":";
            time_t += ":";

            //Секунды
            if (ss < 10)
            {
                time += "0" + ss;
            }
            else if (sst < 10)
            {
                time_t += "0" + sst;
            }
            else
            {
                time += ss;
                time_t += sst;
            }

            label_current.Text = time;
            label_total.Text = time_t;
        }

        private void ReadInfoFromFile()
        {
            StreamReader ReadFile = File.OpenText("time_tracker.cfg");
            string[] lines = ReadFile.ReadToEnd().Split('\n');
            time_total = lines[0];
            label_total.Text = lines[0];
            label_last.Text = lines[1];
        }

        private void WriteInfoToFile()
        {
            //byte[] array = System.Text.Encoding.Default.GetBytes(label_total.Text);
            //file.Write(array, 0, array.Length);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadInfoFromFile();
            date = DateTime.MinValue;
            date_total = DateTime.MinValue;
            date_total = date_total.AddHours(int.Parse(time_total.Substring(0, 2)));
            date_total = date_total.AddMinutes(int.Parse(time_total.Substring(2, 2)));
            date_total = date_total.AddSeconds(int.Parse(time_total.Substring(4, 2)));
            //label_total.Text = date_total.Hour.ToString();

            timer1.Enabled = true;
        }

        //Удалить
        private void timer_tick(object sender, EventArgs e)
        {
            int hh = 0, mm = 0, ss = 0;
            if(start)
            {
                date = DateTime.MinValue;
                hh = date.Hour;
                mm = date.Minute;
                ss = date.Second;
                //hh = DateTime.Now.Hour;
                //mm = DateTime.Now.Minute;
                //ss = DateTime.Now.Second;
            }

            string time = "";
            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }

            label_current.Text = time;
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            //ReadInfoFromFile();
            //timer.Interval = 1000;
            //timer.Tick += new EventHandler(this.timer_tick);
            //timer.Start();
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}
