using System;
using System.Windows.Forms;

namespace Television
{
    public partial class TelevisionSet : Form
    {
        private Television tv = new Television();
        private RemoteControl rc;
        private int tick = 0;

        public TelevisionSet()
        {
            InitializeComponent();
            rc = new RemoteControl();
            rc.Owner = this;
            rc.addOwnership();

            DrawVolume();

            VideoPlayer.settings.setMode("loop", true);
        }

        public void UpdateLabel()
        {
            ResetLabel();
            NumberLabel.Text = "Channel#";

            NumberLabel.Text += (tv.CurrentChannel.Number + 1);
            NameLabel.Text += tv.CurrentChannel.Name;

            NumberLabel.Visible = true;
            NameLabel.Visible = true;
            DisappearTimer.Enabled = true;
        }
        public void ResetLabel()
        {
            NumberLabel.Text = "";
            NameLabel.Text = "";

            NumberLabel.Visible = false;
            NameLabel.Visible = false;
            VolumeLabel.Visible = false;
        }
        public void Play()
        {
            if (!tv.isPowered)
            {
                tv.Position += tv.Time;
                tv.Time = 0;
            }
            try
            {
                UpdateLabel();
                VideoPlayer.URL = Environment.CurrentDirectory + tv.CurrentChannel.URL;
                VideoPlayer.Ctlcontrols.currentPosition = tv.Position;
                VideoPlayer.Ctlcontrols.play();
            }
            catch (Exception)
            {
                VideoPlayer.URL = Environment.CurrentDirectory + "\\Resources\\videos\\channel isn't found.avi";
                VideoPlayer.Ctlcontrols.currentPosition = tv.Position;
                NumberLabel.Text = "Channel isn't found";
                NumberLabel.Visible = true;
                VideoPlayer.Ctlcontrols.play();
            }
        }
        public void DrawVolume()
        {
            VolumeLabel.Text = "Volume: " + tv.volume.ToString() + " ";
            for (int i = 0; i < tv.volume / 5; i++)
                VolumeLabel.Text += " | ";
        }
        private void EnableDisableButtons(bool option) {
            rc.RCPowerBtn.Enabled = option;
            rc.RCMuteBtn.Enabled = option;
            rc.RCVolumeUpBtn.Enabled = option;
            rc.RCVolumeDownBtn.Enabled = option;
            rc.RCNextChannelBtn.Enabled = option;
            rc.RCPrevChannelBtn.Enabled = option;
            rc.RCOKBtn.Enabled = option;
            rc.RCChangeChannelBtn.Enabled = option;
        }

        private void PowerBtn_Click(object sender, EventArgs e)
        {
            if (!tv.isPowered)
            {
                PlayTimer.Enabled = false;
                tv.PowerOn(this);
            }
            else
            {
                PlayTimer.Enabled = true;
                tv.PowerOff(this);
            }
        }
        private void NextChannelBtn_Click(object sender, EventArgs e)
        {
            if (tv.isPowered && tv.Channels.Count > 0)
                tv.NextChannel(this);
        }
        private void PreviousChannelBtn_Click(object sender, EventArgs e)
        {
            if (tv.isPowered && tv.Channels.Count > 0)
                tv.PreviousChannel(this);
        }
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            if (tv.isPowered)
            {
                if (tv.Reset())
                {
                    VideoPlayer.Ctlcontrols.stop();
                    ResetLabel();
                    DrawVolume();

                    ResetTimer.Enabled = true;
                    EnableDisableButtons(true);
                }
            }
        }

        private void PlayTimer_Tick(object sender, EventArgs e)
        {
            tv.Time++;
        }
        private void DisappearTimer_Tick(object sender, EventArgs e)
        {
            NumberLabel.Visible = false;
            NameLabel.Visible = false;
            DisappearTimer.Enabled = false;
        }
        private void VolumeTimer_Tick(object sender, EventArgs e)
        {
            VolumeLabel.Visible = false;
            VolumeTimer.Enabled = false;
        }
        private void ResetTimer_Tick(object sender, EventArgs e)
        {
            tick++;
            Random r = new Random();

            ProcessLabel.Visible = true;
            SignalLabel.Visible = true;

            ProcessLabel.Text += ".";
            SignalLabel.Location = new System.Drawing.Point(r.Next(100, 700), r.Next(50, 250));

            if (tick == 4)
            {
                ProcessLabel.Visible = false;
                SignalLabel.Visible = false;
                tick = 0;
                tv.newSet();
                Play();

                foreach (Channel ch in tv.Channels)
                    ch.Frequency = r.Next(0, 1000);

                ResetTimer.Enabled = false;
                ProcessLabel.Text = "Reseting";
                EnableDisableButtons(true);
            }
        }

        public Television TV { get { return tv; } }
    }
}