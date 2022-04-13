namespace SubtitlesCommenter.Bean
{
    internal class SubtitlesStyleV4P : SubtitlesStyleBase
    {
        //public new string Name { get; set; }
        public string Fontname { get; set; }
        public string Fontsize { get; set; }
        public string PrimaryColour { get; set; }
        public string SecondaryColour { get; set; }
        public string OutlineColour { get; set; }
        public string BackColour { get; set; }
        public int Bold { get; set; }
        public int Italic { get; set; }
        public int Underline { get; set; }
        public int StrikeOut { get; set; }
        public int ScaleX { get; set; }
        public int ScaleY { get; set; }
        public int Spacing { get; set; }
        public int Angle { get; set; }
        public int BorderStyle { get; set; }
        public int Outline { get; set; }
        public int Shadow { get; set; }
        public int Alignment { get; set; }
        public int MarginL { get; set; }
        public int MarginR { get; set; }
        public int MarginV { get; set; }
        public int Encoding { get; set; }

        public SubtitlesStyleV4P()
        {
            SubtitlesStyleStandard = Enum.StyleStandardEnum.V4P;
        }
    }
}
