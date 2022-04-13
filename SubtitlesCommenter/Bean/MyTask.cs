using SubtitlesCommenter.Enum;
using SubtitlesCommenter.Exceptions;
using SubtitlesCommenter.Modules;
using SubtitlesCommenter.Utils;
using System.Text;

namespace SubtitlesCommenter.Bean
{
    internal class MyTask
    {
        // 文件路径
        public string FilePath { get; }
        // 文件编码
        private readonly Encoding FileEncoding;
        // 字幕文件样式标准
        public StyleStandardEnum StyleStandard { get; }
        // 字幕文件中的所有样式
        public SubtitlesStyleBase[] StyleArray { get; }

        /// <summary>
        /// 调用此构造器将判断文件编码，读取文件后提取出所有样式，读取失败抛出异常
        /// </summary>
        /// <param name="FilePath">字幕文件路径</param>
        public MyTask(string FilePath)
        {
            this.FilePath = FilePath;
            // 将文件读入为byte[]，判断出编码后再转为string取出所有样式
            byte[] filebytes = File.ReadAllBytes(FilePath);
            this.FileEncoding = RWFileUtils.GetFileEncoding(filebytes);
            string file = this.FileEncoding.GetString(filebytes).Replace("\r\n", "\n");
            this.StyleStandard = ReadSubtitlesFile.GetStyleStandard(file);
            if (StyleStandard == StyleStandardEnum.Unknown)
            {
                // 未知的样式标准
                throw new UnknownStyleException("无法判断字幕文件的样式标准或不受支持");
            }
            this.StyleArray = ReadSubtitlesFile.GetSubtitlesStyles(file, this.StyleStandard);
        }

        public void WriteContant(AddContentConfigBaseDTO addContent)
        {
            addContent.SubtitlesStyleStandard = this.StyleStandard;
            addContent.Encoding = this.FileEncoding;
            addContent.FilePath = this.FilePath;
            WriteSubtitlesFile.SaveToSubtitlesFile(addContent);
        }
    }
}
