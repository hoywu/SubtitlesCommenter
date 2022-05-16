namespace SubtitlesCommenter.Bean
{
    internal class Constants
    {
        public const string VERSION = "v1.2";
        //public static readonly string SettingPath = Environment.CurrentDirectory + "\\Setting.json";
        public const string ERROR_MESSAGE_PROGRAMING_ERROR = "程序错误，请联系开发者反馈问题";
    }

    internal class MainFormConstants
    {
        public const string OPEN_FILE_DIALOG_TITLE = "选择字幕文件";
        public const string OPEN_FILE_DIALOG_FILTER = "ASS Subtitles File|*.ass";

        public const string ERROR_MESSAGE_TITLE = "错误";
        public const string ERROR_MESSAGE_FILE_READ_FAILURE = "文件读取失败";
        public const string ERROR_MESSAGE_UNKNOWN_ERROR = "出现意料之外的异常，请反馈开发者";
        public const string ERROR_MESSAGE_NO_STYLE_SELECTED = "没有打开字幕文件或没有选择注释样式，请先打开一个字幕文件";
        public const string ERROR_MESSAGE_ADD_FAILURE = "注释插入失败";
        public const string ERROR_MESSAGE_EMPTY_CONTENT = "没有要插入的内容，请先输入一些内容";

        public const string NOTICE_MESSAGE_TITLE = "提示";
        public const string NOTICE_MESSAGE_SUCCEED = "写入成功";

        public const string NOTICE_MESSAGE_LINETOOLONG = "发现文字过多显示时间过短的行，确定继续吗？";
    }

    internal class ReadFileConstants
    {
        public const string STYLE_STANDARD_V4P = "[V4+ Styles]";
        public const string STYLE_STANDARD_V4P_COUNTER = "\nStyle: ";
    }
}
