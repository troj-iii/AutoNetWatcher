using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoNetWatcher
{
    public partial class MainFrame : Form
    {
        private System.Timers.Timer getIpEngine_ = null;
        private string ipstr_ = null;
        private readonly int TRY_TIMES = 3;
        private int tryTimes_ = 0;
        private bool stopGetIpEngine_ = true;
        private bool closedFromTray_ = false;
        private string NetcardName = null;
        private readonly string[] NetcardNames = { "Intel(R) PRO/1000 MT Network Connection",
                                                   "Intel(R) PRO/1000 MT Desktop Adapter"};

        public MainFrame()
        {
            InitializeComponent();
        }

        private void about__Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void start__Click(object sender, EventArgs e)
        {
            start_.Enabled = false;
            stop_.Enabled = true;

            ipstr_ = null;
            stopGetIpEngine_ = false;

            getIpEngine_.Interval = 2000;
            getIpEngine_.Elapsed += GetIpEngine__Elapsed; ;
            getIpEngine_.Start();
        }

        private void stop__Click(object sender, EventArgs e)
        {
            start_.Enabled = true;
            stop_.Enabled = false;

            stopGetIpEngine_ = true;
            tray_.Text = "停止";
            tooltip_.Text = "停止";

            getIpEngine_.Stop();
        }

        private void exit__Click(object sender, EventArgs e)
        {
            closedFromTray_ = true;

            getIpEngine_.Stop();
            this.Close();
        }

        private void tray__MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void tray__MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                tray_.ShowBalloonTip(3000, "提示", tooltip_.Text, ToolTipIcon.Info);
            }
        }

        private void MainFrame_Shown(object sender, EventArgs e)
        {
            num_.Text = "3";

            Timer t = new Timer();
            t.Tick += T_Tick;
            t.Interval = 1000;
            t.Start();

            start__Click(null, null);
        }

        private void GetIpEngine__Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            getIpEngine_.Stop();
            try
            {
                string getIpUrl = "http://1212.ip138.com/ic.asp";
                System.Net.WebClient wc = new System.Net.WebClient();
                string ipText = wc.DownloadString(getIpUrl);

                Regex rgx = new Regex("<center>(.*?)</center>");
                var m = rgx.Match(ipText);

                if (m.Success)
                {
                    string ipstr = m.Groups[1].Value;
                    if (ipstr_ == null) // 第一次获取IP
                    {
                        this.Invoke(new Action(() =>
                        {
                            ipstr_ = ipstr;
                            tooltip_.Text = ipstr_;
                            tray_.Text = ipstr_;
                            tray_.ShowBalloonTip(7000, "提示", tooltip_.Text, ToolTipIcon.Info);
                            tryTimes_ = 0;
                        }));
                    }
                    else if (ipstr_ != ipstr) // IP 不一致
                    {
                        this.Invoke(new Action(() =>
                        {
                            tooltip_.Text = "IP变化\n旧IP：" + ipstr_ + "\n新IP：" + ipstr;
                            tray_.ShowBalloonTip(7000, "警告", tooltip_.Text, ToolTipIcon.Warning);
                        }));

                        throw new ForbiddenException();
                    }
                    else // IP 一致
                    {
                        tryTimes_ = 0;
                    }
                }
                else
                {
                    tryTimes_++;
                }
            }
            catch (ForbiddenException)
            {
                tryTimes_ = 4;
            }
            catch (Exception)
            {
                tryTimes_++;
            }
            finally
            {
                if (tryTimes_ >= TRY_TIMES)
                {
                    this.Invoke(new Action(() =>
                    {
                        stop__Click(null, null);
                    }));

                    DisableNet();
                }

                if (!stopGetIpEngine_)
                {
                    getIpEngine_.Start();
                }
            }
        }

        private void DisableNet()
        {
            NetHelper net = new NetHelper();
            var netcard = net.NetWork(NetcardName);
            if (netcard == null)
            {
                string[] netcards = net.NetWorkList();
                string txt = "禁用网卡失败\n";
                txt += string.Join("\n", netcards);
                txt += "\n期望网卡：\n";
                txt += NetcardName;
                tray_.ShowBalloonTip(5000, "错误", txt, ToolTipIcon.Error);
                return;
            }

            if (!net.DisableNetWork(netcard))
            {
                tray_.ShowBalloonTip(5000, "错误", $"禁用网卡失败：" + NetcardName, ToolTipIcon.Error);
            }
        }

        int showIdx = 3;
        private void T_Tick(object sender, EventArgs e)
        {
            showIdx--;

            num_.Text = showIdx.ToString();

            if (showIdx == 0)
            {
                this.Hide();
                (sender as Timer).Stop();
                (sender as Timer).Dispose();
            }
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {
            getIpEngine_ = new System.Timers.Timer();
            NetHelper net = new NetHelper();
            string[] netcards = net.NetWorkList();
            netcards_.Items.AddRange(netcards);

            foreach (var n in NetcardNames)
            {
                if ( 0 <= netcards.ToList().IndexOf(n))
                {
                    netcards_.SelectedItem = n;
                    NetcardName = n;
                }
            }
        }

        private void enableNetcard__Click(object sender, EventArgs e)
        {
            NetHelper net = new NetHelper();
            var netcard = net.NetWork(NetcardName);
            if (netcard == null)
            {
                string[] netcards = net.NetWorkList();
                string txt = "网卡\n";
                txt += string.Join("\n", netcards);
                txt += "\n期望网卡：\n";
                txt += NetcardName;
                tray_.ShowBalloonTip(5000, "错误", txt, ToolTipIcon.Error);
                return;
            }

            if (!net.EnableNetWork(netcard))
            {
                tray_.ShowBalloonTip(5000, "错误", $"启用网卡失败：" + NetcardName, ToolTipIcon.Error);
            }
        }

        private void MainFrame_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closedFromTray_)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void MainFrame_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void disableNetcard__Click(object sender, EventArgs e)
        {
            DisableNet();
        }
    }

    class ForbiddenException : Exception
    { }
}
