using System.Text;

namespace SubtitlesCommenter.Bean
{
    internal class AddContentConfigDTO
    {
        public Encoding Encoding { get; set; }
        public string FilePath { get; set; }
        public int AddMode { get; set; }
        public int Layer { get; set; } = 0;
        public string AddLocation { get; set; }
        public string ShowTime { get; set; }
        public string StyleName { get; set; }
        public string Name { get; set; } = "";
        public int MarginL { get; set; } = 0;
        public int MarginR { get; set; } = 0;
        public int MarginV { get; set; } = 0;
        public string Effect { get; set; } = "";
        public string Text { get; set; }
    }
}
