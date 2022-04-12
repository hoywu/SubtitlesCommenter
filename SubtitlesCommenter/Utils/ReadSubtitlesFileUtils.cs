using SubtitlesCommenter.Bean;

namespace SubtitlesCommenter.Utils
{
    internal class ReadSubtitlesFileUtils
    {
        /// <summary>
        /// 判断字幕文件样式格式，返回找到的STYLE_FORMAT常量，未找到返回null
        /// </summary>
        public static string? GetStyleFormat(string subtitlesFile)
        {
            // 在字幕文件中寻找STYLE_FORMAT常量
            int index = subtitlesFile.IndexOf(Constants.STYLE_FORMAT_V4P);
            if (index != -1)
            {
                return Constants.STYLE_FORMAT_V4P;
            }
            return null;
        }
        /// <summary>
        /// 返回字幕文件中有几个STYLE_COUNTER
        /// </summary>
        /// <param name="s">字幕文件</param>
        /// <param name="STYLE_COUNTER">计数用常量</param>
        public static int GetStyleNumber(string s, string STYLE_COUNTER)
        {
            int index;
            int count = 0;
            while ((index = s.IndexOf(STYLE_COUNTER)) != -1)
            {
                s = s.Substring(index + STYLE_COUNTER.Length);
                count++;
            }
            return count;
        }
    }
}
