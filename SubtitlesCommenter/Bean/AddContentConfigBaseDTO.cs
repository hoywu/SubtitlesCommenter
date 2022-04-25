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

        //高级选项是否启用
        public bool AdvOption { get; set; } = false;

        //渐出渐入毫秒数
        public int fad { get; set; } = 0;

        //透明度
        public int alpha { get; set; } = 0;

        //斜体
        public int italics { get; set; } = 0;

        //粗体
        public int boldface { get; set; } = 0;

        //下划线
        public int underlined { get; set; } = 0;

        //删除线
        public int strikeout { get; set; } = 0;

        //自定义特效标签
        public string custom { get; set; }

        //横幅效果
        public bool banner { get; set; } = false;
        //横幅速度
        public int bannerSpeed { get; set; }
        //横幅方向
        public int bannerDirection { get; set; }
    }
}
