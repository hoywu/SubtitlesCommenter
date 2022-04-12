using System;
using System.Drawing;

namespace SubtitlesCommenter.Utils
{
    internal class MainFormUtils
    {
        /// <summary>
        /// 接收一个字体名数组，返回成功找到的第一个Font对象，否则返回null
        /// </summary>
        /// <param name="fontNameList">包含字体全名的String数组</param>
        public static Font GetExistingFont(string[] fontNameList)
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
    }
}
