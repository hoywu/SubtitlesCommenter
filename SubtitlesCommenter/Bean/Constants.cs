namespace SubtitlesCommenter.Bean
{
    internal class Constants
    {
        public const string VERSION = "v0.1";
        //public static readonly string SettingPath = Environment.CurrentDirectory + "\\Setting.json";
        public const string STYLE_FORMAT_V4P = "[V4+ Styles]";
        public const string V4P_STYLE_COUNTER = "\nStyle: ";
    }

    internal class MainFormConstants
    {
        public const int MAIN_FORM_WIDTH = 573;
        public const int MAIN_FORM_HEIGHT_HIDE_ADV = 349;
        public const int MAIN_FORM_HEIGHT_SHOW_ADV = 458;
        public const string OPEN_FILE_DIALOG_TITLE = "选择字幕文件";
        public const string OPEN_FILE_DIALOG_FILTER = "ASS Subtitles File|*.ass";
        public const string ERROR_MESSAGE_TITLE = "错误";
        public const string ERROR_MESSAGE_FILE_NOT_FOUND = "文件不存在";
        public const string ERROR_MESSAGE_FILE_READ_FAILURE = "文件读取失败";
        public const string ERROR_MESSAGE_EMPTY_FILE = "文件是空的，请选择有内容的字幕文件";
        public const string ERROR_MESSAGE_UNKNOWN_STYLE = "没有在该字幕文件中找到任何样式 或 样式格式不合法 或 样式不受支持，请反馈开发者";
        public const string ERROR_MESSAGE_UNKNOWN_ERROR = "出现意料之外的异常，请反馈开发者";
        public const string ERROR_MESSAGE_NO_STYLE_SELECTED = "没有打开字幕文件或没有选择注释样式，请先打开一个字幕文件";
    }
}
