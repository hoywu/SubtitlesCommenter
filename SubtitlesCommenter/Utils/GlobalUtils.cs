using System;

namespace SubtitlesCommenter.Utils
{
    internal class GlobalUtils
    {
        /// <summary>
        /// 取出中间文本
        /// </summary>
        public static string GetMiddleString(string String, string LeftString, string RightString)
        {
            if (string.IsNullOrEmpty(String) || string.IsNullOrEmpty(LeftString) || string.IsNullOrEmpty(RightString)) return "";

            // LeftString 在 String 中的第一个匹配项的索引
            int LeftIndex = String.IndexOf(LeftString);
            if (LeftIndex == -1) return "";
            // RightString 起始搜索索引，所需文本的起始索引
            int StartIndex = LeftIndex + LeftString.Length;
            int RightIndex = String.IndexOf(RightString, StartIndex);
            if (RightIndex == -1) return "";
            return String.Substring(StartIndex, RightIndex - StartIndex);
        }
    }
}
