using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Input;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace System_Control
{
    public partial class home : Form
    {
        public static string task;
        public static string appName;
        public static string path;
        public static int timeLeft;
        public static int hour;
        public static int min;
        public static int sec;
        [DllImport("user32")]
        public static extern void LockWorkStation();
        [DllImport("user32.dll")]   public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);
        [DllImport("Powrprof.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);


        public home()
        {
            InitializeComponent();
        //    chkStartWithWindows.Checked = WindowsStartupUtility.IsRegistered();
        }
        private void home_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.HideForm();
            }
        }
        private void home_Load(object sender, EventArgs e)
        {
            notifyIcon.Icon = this.Icon;
            notifyIcon.Text = this.Text;
            notifyIcon.Visible = true;
        }
      
    /*    public bool StartWithWindows
        {
            get
            {
               return chkStartWithWindows.Checked;
            }
        }*/
        private void ClearTimer()
        {
            hh.Text = "00";
            mm.Text = "00";
            ss.Text = "00";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            LockWorkStation();
        }

        
        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/s /t 0");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/r /t 0");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SetSuspendState(true, true, true);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ExitWindowsEx(0, 0);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            SetSuspendState(false, true, true);
        }

       private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Set system shutdown time";
            //button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button18.Enabled = false;
            hh.Enabled = mm.Enabled = ss.Enabled = button12.Enabled = true;
            task = "shutdown";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Set system restart time";
            //button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button18.Enabled = false;
            hh.Enabled = mm.Enabled = ss.Enabled = button12.Enabled = true;
            task = "restart";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "Set system hibernation time";
            //button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button18.Enabled = false;
            hh.Enabled = mm.Enabled = ss.Enabled = button12.Enabled = true;
            task = "hibernation";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            label1.Text = "Set system sleep time";
            //button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button18.Enabled = false;
            hh.Enabled = mm.Enabled = ss.Enabled = button12.Enabled = true;
            task = "sleep";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "Set system signout time";
            //button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button18.Enabled = false;
            hh.Enabled = mm.Enabled = ss.Enabled = button12.Enabled = true;
            task = "signout";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = "Set system lock time";
            //button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button18.Enabled = false;
            hh.Enabled = mm.Enabled = ss.Enabled = button12.Enabled = true;
            task = "lock";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (task.Equals("shutdown"))
            {
                label1.Text = "System is scheduled to shutdown in:";
                try
                {
                    hour = Int16.Parse(hh.Text);
                    min = Int16.Parse(mm.Text);
                    sec = Int16.Parse(ss.Text);
                    timeLeft = hour * 3600 + min * 60 + sec;
                    timer.Start();
                    button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button12.Enabled = button18.Enabled = false;
                    button11.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Time format is incorrect!", "Error!");
                }
            }
            else if (task.Equals("restart"))
            {
                label1.Text = "System is scheduled for a restart in:";
                try
                {
                    hour = Int16.Parse(hh.Text);
                    min = Int16.Parse(mm.Text);
                    sec = Int16.Parse(ss.Text);
                    timeLeft = hour * 3600 + min * 60 + sec;
                    timer1.Start();
                    button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button12.Enabled = button18.Enabled = false;
                    button11.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Time format is incorrect!", "Error!");
                }
            }
            else if (task.Equals("hibernation"))
            {
                label1.Text = "System is scheduled for hibernation in:";
                try
                {
                    hour = Int16.Parse(hh.Text);
                    min = Int16.Parse(mm.Text);
                    sec = Int16.Parse(ss.Text);
                    timeLeft = hour * 3600 + min * 60 + sec;
                    timer2.Start();
                    button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button12.Enabled = button18.Enabled = false;
                    button11.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Time format is incorrect!", "Error!");
                }
            }
            else if (task.Equals("sleep"))
            {
                label1.Text = "System is scheduled to sleep in:";
                try
                {
                    hour = Int16.Parse(hh.Text);
                    min = Int16.Parse(mm.Text);
                    sec = Int16.Parse(ss.Text);
                    timeLeft = hour * 3600 + min * 60 + sec;
                    timer3.Start();
                    button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button12.Enabled = button18.Enabled = false;
                    button11.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Time format is incorrect!", "Error!");
                }
            }
            else if (task.Equals("signout"))
            {
                label1.Text = "System is scheduled for signout in:";
                try
                {
                    hour = Int16.Parse(hh.Text);
                    min = Int16.Parse(mm.Text);
                    sec = Int16.Parse(ss.Text);
                    timeLeft = hour * 3600 + min * 60 + sec;
                    timer4.Start();
                    button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button12.Enabled = button18.Enabled = false;
                    button11.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Time format is incorrect!", "Error!");
                }
            }
            else if (task.Equals("lock"))
            {
                label1.Text = "System is scheduled to be locked in:";
                try
                {
                    hour = Int16.Parse(hh.Text);
                    min = Int16.Parse(mm.Text);
                    sec = Int16.Parse(ss.Text);
                    timeLeft = hour * 3600 + min * 60 + sec;
                    timer5.Start();
                    button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button12.Enabled = button18.Enabled = false;
                    button11.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Time format is incorrect!", "Error!");
                }
            }
            else
            {
                MessageBox.Show("Unhandled Exception");
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                hour = timeLeft / 3600;
                min = (timeLeft - (hour * 3600)) / 60;
                sec = timeLeft - (hour * 3600) - (min * 60);
                hh.Text = hour.ToString();
                mm.Text = min.ToString();
                ss.Text = sec.ToString();
                hh.Enabled = ss.Enabled = mm.Enabled = false;

            }
            else
            {
                timer.Stop();
                Process.Start("shutdown", "/s /t 0");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                hour = timeLeft / 3600;
                min = (timeLeft - (hour * 3600)) / 60;
                sec = timeLeft - (hour * 3600) - (min * 60);
                hh.Text = hour.ToString();
                mm.Text = min.ToString();
                ss.Text = sec.ToString();
                hh.Enabled = ss.Enabled = mm.Enabled = false;

            }
            else
            {
                timer1.Stop();
                Process.Start("shutdown", "/r /t 0");
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                hour = timeLeft / 3600;
                min = (timeLeft - (hour * 3600)) / 60;
                sec = timeLeft - (hour * 3600) - (min * 60);
                hh.Text = hour.ToString();
                mm.Text = min.ToString();
                ss.Text = sec.ToString();
                hh.Enabled = ss.Enabled = mm.Enabled = false;

            }
            else
            {
                timer2.Stop();
                label1.Text = "There is currently no scheduled task";
                ClearTimer();
                button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button18.Enabled = true;
                hh.Enabled = mm.Enabled = ss.Enabled = button11.Enabled = button12.Enabled = false;
                SetSuspendState(true, true, true);
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                hour = timeLeft / 3600;
                min = (timeLeft - (hour * 3600)) / 60;
                sec = timeLeft - (hour * 3600) - (min * 60);
                hh.Text = hour.ToString();
                mm.Text = min.ToString();
                ss.Text = sec.ToString();
                hh.Enabled = ss.Enabled = mm.Enabled = false;

            }
            else
            {           
                timer3.Stop();
                label1.Text = "There is currently no scheduled task";
                ClearTimer();
                button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button18.Enabled = true;
                hh.Enabled = mm.Enabled = ss.Enabled = button11.Enabled = button12.Enabled = false;
                SetSuspendState(false, true, true);
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                hour = timeLeft / 3600;
                min = (timeLeft - (hour * 3600)) / 60;
                sec = timeLeft - (hour * 3600) - (min * 60);
                hh.Text = hour.ToString();
                mm.Text = min.ToString();
                ss.Text = sec.ToString();
                hh.Enabled = ss.Enabled = mm.Enabled = false;
            }
            else
            {
                timer4.Stop();
                ExitWindowsEx(0, 0);
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                hour = timeLeft / 3600;
                min = (timeLeft - (hour * 3600)) / 60;
                sec = timeLeft - (hour * 3600) - (min * 60);
                hh.Text = hour.ToString();
                mm.Text = min.ToString();
                ss.Text = sec.ToString();
                hh.Enabled = ss.Enabled = mm.Enabled = false;

            }
            else
            {

                timer5.Stop();
                label1.Text = "There is currently no scheduled task";
                ClearTimer();
                button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button18.Enabled = true;
                hh.Enabled = mm.Enabled = ss.Enabled = button11.Enabled = button12.Enabled = false;
                LockWorkStation();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label1.Text = "There is currently no scheduled task";
            ClearTimer();
            timer.Stop();
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            timer4.Stop();
            timer5.Stop();
            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button12.Enabled = button18.Enabled = true;
            hh.Enabled = mm.Enabled = ss.Enabled = button11.Enabled = button12.Enabled = false;
        }

        private void showHideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowHideForm();
        }
        public void ShowHideForm()
        {
            if (this.Visible)
            {
                HideForm();
            }
            else
            {
                ShowForm();
            }
        }

        public void ShowForm()
        {
            this.ShowInTaskbar = true;
            this.Visible = true;
            this.scheduleTaskToolStripMenuItem.Enabled = false;
            this.WindowState = FormWindowState.Normal;
        }

        public void HideForm()
        {
            this.ShowInTaskbar = false;
            this.Visible = false;
            this.scheduleTaskToolStripMenuItem.Enabled = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/s /t 0");
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/r /t 0");
        }

        private void hibernateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSuspendState(true, true, true);
        }

        private void sleepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSuspendState(false, true, true);
        }

        private void signoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitWindowsEx(0, 0);
        }

        private void lockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LockWorkStation();
        }

        private void scheduleTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowForm();
        }
 
    }
}
