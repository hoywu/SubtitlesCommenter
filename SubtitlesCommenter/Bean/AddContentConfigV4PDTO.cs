namespace SubtitlesCommenter.Bean
{
    internal class AddContentConfigV4PDTO : AddContentConfigBaseDTO
    {
        //public new Encoding Encoding { get; set; }
        //public new string FilePath { get; set; }
        //public new Enum.AddModeEnum AddMode { get; set; }
        public int Layer { get; set; } = 0;
        //public new string AddLocation { get; set; }
        //public new string ShowTime { get; set; }
        //public new string StyleName { get; set; }
        public string Name { get; set; } = "";
        public int MarginL { get; set; } = 0;
        public int MarginR { get; set; } = 0;
        public int MarginV { get; set; } = 0;
        public string Effect { get; set; } = "";
        //public new string Text { get; set; }

        public AddContentConfigV4PDTO()
        {
            SubtitlesStyleStandard = Enum.StyleStandardEnum.V4P;
        }
    }
}
