using SubtitlesCommenter.Enum;
using System.Text;

namespace SubtitlesCommenter.Bean
{
    internal class AddContentConfigBaseDTO
    {
        public StyleStandardEnum SubtitlesStyleStandard { get; set; }
        public Encoding Encoding { get; set; }
        public string FilePath { get; set; }
        public AddModeEnum AddMode { get; set; }
        public string AddLocation { get; set; }
        public string ShowTime { get; set; }
        public SubtitlesStyleBase Style { get; set; }
        public string Text { get; set; }
    }
}
