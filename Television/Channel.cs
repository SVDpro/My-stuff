namespace Television
{
    public class Channel
    {
        public Channel(string n, int num, string url, int frequency)
        {
            Name = n;
            Number = num;
            URL = url;
            Frequency = frequency;
        }
        public Channel DeepCopy()
        {
            return new Channel(Name, Number, URL, Frequency);
        }
        public int Number { set; get; }
        public string Name { set; get; }
        public string URL { set; get; }
        public int Frequency { set; get; }
    }
}
