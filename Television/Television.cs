using System;
using System.Collections.Generic;
using System.IO;

namespace Television
{
    public class Television
    {
        private static int amount_of_channels = 10;
        private List<Channel> channels;
        private List<Channel> buffer_channels;
        private int buffer;
        public int volume;

        public int Channel_index { set; get; }
        public double Position { set; get; }
        public double Time { set; get; }
        public bool isPowered { set; get; }
        public bool isMuted { set; get; }

        public Television()
        {
            channels = new List<Channel>(amount_of_channels);
            buffer_channels = new List<Channel>(amount_of_channels);
            volume = buffer = 50;
            setChannels();
        }

        public void setChannels()
        {
            IEnumerable<string> file = File.ReadAllLines("Channels.txt");
            List<string> names = new List<string>();
            List<int> numbers = new List<int>();
            List<string> urls = new List<string>();
            bool toNames = false, toNumbers = false, toURLs = false, isChecked = false;
            foreach (string s in file)
            {
                switch (s)
                {
                    case "Names:": { toNames = isChecked = true; break; }
                    case "Numbers:": { toNumbers = isChecked = true; break; }
                    case "URLs:": { toURLs = isChecked = true; break; }
                    default: { isChecked = false; break; }
                }
                if (isChecked)
                    continue;

                string[] str = s.Split(' ');
                if (toNames)
                {
                    for (int i = 0; i < str.Length; i++)
                        names.Add(str[i]);
                    toNames = false;
                    continue;
                }
                if (toNumbers)
                {
                    for (int i = 0; i < str.Length; i++)
                        numbers.Add(int.Parse(str[i]));
                    toNumbers = false;
                    continue;
                }
                if (toURLs)
                {
                    urls.Add(s);
                    continue;
                }
            }

            Random r = new Random();
            for (int i = 0; i < names.Count; i++)
                channels.Add(new Channel(names[i], numbers[i], urls[i], r.Next(0, 1000)));
        }

        public void PowerOn(TelevisionSet tv_set)
        {
            tv_set.Play();
            isPowered = true;
        }
        public void PowerOff(TelevisionSet tv_set)
        {
            tv_set.ResetLabel();
            Position = tv_set.VideoPlayer.Ctlcontrols.currentPosition;
            tv_set.VideoPlayer.close();
            isPowered = false;
        }
        public void NextChannel(TelevisionSet tv_set)
        {
            Position = tv_set.VideoPlayer.Ctlcontrols.currentPosition;

            if (Channel_index == amount_of_channels - 1)
                Channel_index = 0;
            else
                Channel_index++;

            tv_set.Play();
        }
        public void PreviousChannel(TelevisionSet tv_set)
        {
            Position = tv_set.VideoPlayer.Ctlcontrols.currentPosition;

            if (Channel_index == 0)
                Channel_index = amount_of_channels - 1;
            else
                Channel_index--;

            tv_set.Play();
        }
        public void Mute(TelevisionSet tv_set)
        {
            isMuted = true;
            tv_set.VolumeTimer.Enabled = false;
            tv_set.VideoPlayer.settings.volume = volume = 0;
            tv_set.VolumeLabel.Text = "Muted";

            tv_set.VolumeLabel.Visible = true;
            tv_set.VolumeTimer.Enabled = true;
        }
        public void Unmute(TelevisionSet tv_set)
        {
            isMuted = false;
            tv_set.VolumeTimer.Enabled = false;
            tv_set.VideoPlayer.settings.volume = volume = buffer;

            if (volume > 0)
            {
                tv_set.DrawVolume();

                tv_set.VolumeLabel.Visible = true;
                tv_set.VolumeTimer.Enabled = true;
            }
        }
        public void VolumeUp(TelevisionSet tv_set)
        {
            tv_set.VolumeTimer.Enabled = false;
            int vol = volume;

            if (volume < 100)
                volume += 5;

            buffer = volume;
            tv_set.VideoPlayer.settings.volume = volume;

            if (volume == 100)
            {
                tv_set.VolumeLabel.Text = "Max volume";
                tv_set.VolumeLabel.Visible = true;
                tv_set.VolumeTimer.Enabled = true;
                return;
            }

            if (tv_set.VolumeLabel.Text == "Muted")
                tv_set.VolumeLabel.Text = "Volume: " + volume.ToString() + " ";
            else
                tv_set.VolumeLabel.Text = tv_set.VolumeLabel.Text.Replace(vol.ToString(), volume.ToString());

            tv_set.VolumeLabel.Text += " | ";
            tv_set.VolumeLabel.Visible = true;
            tv_set.VolumeTimer.Enabled = true;
        }
        public void VolumeDown(TelevisionSet tv_set)
        {
            tv_set.VolumeTimer.Enabled = false;
            int vol = volume;

            if (volume > 0)
                volume -= 5;

            buffer = volume;
            tv_set.VideoPlayer.settings.volume = volume;

            if (volume == 0)
            {
                tv_set.VolumeLabel.Text = "Muted";
                tv_set.VolumeLabel.Visible = true;
                tv_set.VolumeTimer.Enabled = true;
                return;
            }

            if (tv_set.VolumeLabel.Text == "Max volume")
                tv_set.DrawVolume();
            else
                tv_set.VolumeLabel.Text = tv_set.VolumeLabel.Text.Replace(vol.ToString(), volume.ToString());

            int index = tv_set.VolumeLabel.Text.LastIndexOf('|', tv_set.VolumeLabel.Text.Length - 1);
            tv_set.VolumeLabel.Text = tv_set.VolumeLabel.Text.Remove(index);
            tv_set.VolumeLabel.Visible = true;
            tv_set.VolumeTimer.Enabled = true;
        }
        public bool Reset()
        {
            if (channels.Count == 0)
                return false;

            foreach (Channel ch in Channels)
                buffer_channels.Add(ch.DeepCopy());

            channels.Clear();
            Channel_index = 0;
            Position = Time = 0;
            volume = buffer = 50;
            return true;
        }
        public void newSet()
        {
            int i = 0, number = 0;
            while (i <= 1000)
            {
                foreach (Channel ch in buffer_channels)
                    if (i == ch.Frequency)
                    {
                        ch.Number = number;
                        channels.Add(ch.DeepCopy());
                        number++;
                        continue;
                    }
                i++;
            }
            buffer_channels.Clear();
        }

        public Channel CurrentChannel
        {
            set { channels[Channel_index] = value; }
            get
            {
                if (Channel_index < amount_of_channels)
                    return channels[Channel_index];
                else
                    throw new Exception();
            }
        }
        public List<Channel> Channels { get { return channels; } }
    }
}