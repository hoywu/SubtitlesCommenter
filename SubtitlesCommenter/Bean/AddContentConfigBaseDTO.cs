﻿using SubtitlesCommenter.Enum;
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

        //自定义特效标签
        public string custom { get; set; }
    }
}
