using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtitlesCommenter.Utils
{
    internal class MainFormUtils
    {
        /// <summary>
        /// 接收一个字体名数组，返回成功找到的第一个Font对象，否则返回null
        /// </summary>
        /// <param name="fontNameList">字体全名列表</param>
        /// <returns></returns>
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
