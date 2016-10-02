using System;
using System.Windows.Forms;

namespace Television
{
    public partial class RemoteControl : Form
    {
        private Television tv = null;
        private TelevisionSet tv_set = null;
        private bool isChangeChannelClicked = false;
        private bool isCompleteChannel = false;
        private bool isNoNumberClicked = true;
        private double time;

        public RemoteControl()
        {
            InitializeComponent();
        }
        public void addOwnership()
        {
            TelevisionSet tvs = Owner as TelevisionSet;
            tv_set = tvs;
            tv = tvs.TV;
            Show();
        }

        public void RCPowerBtn_Click(object sender, EventArgs e)
        {
            if (!tv.isPowered)
            {
                tv_set.PlayTimer.Enabled = false;
                tv.PowerOn(tv_set);
            }
            else
            {
                tv_set.PlayTimer.Enabled = true;
                tv.PowerOff(tv_set);
            }
        }

        private void RCMuteBtn_Click(object sender, EventArgs e)
        {
            if (tv.isPowered)
            {
                if (!tv.isMuted)
                    tv.Mute(tv_set);
                else
                    tv.Unmute(tv_set);
            }
        }

        private void RCVolumeDownBtn_Click(object sender, EventArgs e)
        {
            if (!tv.isMuted && tv.isPowered)
                tv.VolumeDown(tv_set);
        }
        private void RCVolumeUpBtn_Click(object sender, EventArgs e)
        {
            if (!tv.isMuted && tv.isPowered)
                tv.VolumeUp(tv_set);
        }

        private void RCNextChannelBtn_Click(object sender, EventArgs e)
        {
            if (tv.isPowered && tv.Channels.Count > 0)
                tv.NextChannel(tv_set);
        }
        private void RCPrevChannelBtn_Click(object sender, EventArgs e)
        {
            if (tv.isPowered && tv.Channels.Count > 0)
                tv.PreviousChannel(tv_set);
        }

        private void RCChangeChannelBtn_Click(object sender, EventArgs e)
        {
            if (tv.isPowered && tv.Channels.Count > 0)
            {
                isCompleteChannel = false;
                tv_set.DisappearTimer.Enabled = false;

                tv_set.NumberLabel.Text = "Channel#--";
                tv_set.NumberLabel.Visible = true;
                tv_set.NameLabel.Visible = false;

                isChangeChannelClicked = true;
                isNoNumberClicked = true;
                ChannelChangeTimer.Enabled = true;
            }
        }

        private void DisplayTextOnButtonClicked(string number)
        {
            if (isChangeChannelClicked)
            {
                isNoNumberClicked = false;
                int index = tv_set.NumberLabel.Text.IndexOf('-', 0);
                tv_set.NumberLabel.Text = tv_set.NumberLabel.Text.Remove(index, 1);
                tv_set.NumberLabel.Text = tv_set.NumberLabel.Text.Insert(index, number);

                if (!tv_set.NumberLabel.Text.Contains("-"))
                {
                    WaitTimer.Enabled = false;
                    tv.Channel_index = int.Parse(tv_set.NumberLabel.Text.Substring(tv_set.NumberLabel.Text.IndexOf('#') + 1, 2));
                    isCompleteChannel = true;
                    isChangeChannelClicked = false;
                    return;
                }
                WaitTimer.Enabled = true;
            }
        }

        private void RCFirstBtn_Click(object sender, EventArgs e)
        {
            DisplayTextOnButtonClicked("1");
        }
        private void RCSecondBtn_Click(object sender, EventArgs e)
        {
            DisplayTextOnButtonClicked("2");
        }
        private void RCThirdBtn_Click(object sender, EventArgs e)
        {
            DisplayTextOnButtonClicked("3");
        }
        private void RCFourthBtn_Click(object sender, EventArgs e)
        {
            DisplayTextOnButtonClicked("4");
        }
        private void RCFifthBtn_Click(object sender, EventArgs e)
        {
            DisplayTextOnButtonClicked("5");
        }
        private void RCSixthBtn_Click(object sender, EventArgs e)
        {
            DisplayTextOnButtonClicked("6");
        }
        private void RCSeventhBtn_Click(object sender, EventArgs e)
        {
            DisplayTextOnButtonClicked("7");
        }
        private void RCEighthBtn_Click(object sender, EventArgs e)
        {
            DisplayTextOnButtonClicked("8");
        }
        private void RCNinthBtn_Click(object sender, EventArgs e)
        {
            DisplayTextOnButtonClicked("9");
        }
        private void RCZeroBtn_Click(object sender, EventArgs e)
        {
            DisplayTextOnButtonClicked("0");
        }

        private void RCOKBtn_Click(object sender, EventArgs e)
        {
            if (isNoNumberClicked)
                return;

            if (isCompleteChannel)
                tv.Channel_index--;
            else
            {
                if (tv_set.NumberLabel.Text.Substring(tv_set.NumberLabel.Text.IndexOf('#') + 1, 1) != "0")
                    tv.Channel_index = int.Parse(tv_set.NumberLabel.Text.Substring(tv_set.NumberLabel.Text.IndexOf('#') + 1, 1)) - 1;
                else
                    tv.Channel_index = int.Parse(tv_set.NumberLabel.Text.Substring(tv_set.NumberLabel.Text.IndexOf('#') + 2, 1)) - 1;
                WaitTimer.Enabled = false;
            }

            isNoNumberClicked = true;
            ChannelChangeTimer.Enabled = false;

            tv.Position = tv_set.VideoPlayer.Ctlcontrols.currentPosition + time;
            time = 0;
            tv_set.Play();
        }

        private void ChannelChangeTimer_Tick(object sender, EventArgs e)
        {
            time++;
        }
        private void WaitTimer_Tick(object sender, EventArgs e)
        {
            string str = tv_set.NumberLabel.Text.Substring(tv_set.NumberLabel.Text.IndexOf('#') + 1, 1);
            tv_set.NumberLabel.Text = tv_set.NumberLabel.Text.Replace(str, "0");
            tv_set.NumberLabel.Text = tv_set.NumberLabel.Text.Replace("-", str);
            tv.Channel_index = int.Parse(tv_set.NumberLabel.Text.Substring(tv_set.NumberLabel.Text.IndexOf('#') + 1, 1));
            isChangeChannelClicked = false;
            WaitTimer.Enabled = false;
        }
    }
}
