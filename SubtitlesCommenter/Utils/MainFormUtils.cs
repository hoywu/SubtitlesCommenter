namespace SubtitlesCommenter.Utils
{
    internal class MainFormUtils
    {
        /// <summary>
        /// 接收一个字体名数组，返回成功找到的第一个Font对象，否则返回null
        /// </summary>
        /// <param name="fontNameList">包含字体全名的String数组</param>
        public static Font? GetExistingFont(string[] fontNameList)
        {
            Font font;
            foreach (var fontName in fontNameList)
            {
                try
                {
                    font = new Font(fontName, 9F, FontStyle.Regular, GraphicsUnit.Point);
                    if (font.Name == fontName)
                        return font;
                }
                catch (Exception) { }
            }
            return null;
        }

        /// <summary>
        /// 检查是否存在过长的行，返回第一个过长的行号，否则返回0
        /// </summary>
        public static int CheckOverLengthLine(string text, string showTime)
        {
            if (string.IsNullOrEmpty(text)) return 0;

            string[] lines = text.Replace("\r\n", "\n").Replace(" ", "").Split('\n');
            int showTimesec = GlobalUtils.ShowTimeToSec(showTime);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Length / showTimesec > 15) return i + 1;
            }

            return 0;
        }
    }
}
