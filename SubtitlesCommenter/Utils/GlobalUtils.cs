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
        /// <summary>
        /// 根据开始时间和持续时间返回结束时间，格式 0:00:00.00
        /// </summary>
        public static string GetEndTime(string StartTime, string ShowTime)
        {
            int carry = 0;
            string[] start = StartTime.Split(new char[] { ':', '.' });
            string[] show = ShowTime.Split(new char[] { ':', '.' });

            int ms = int.Parse(start[start.Length - 1]) + int.Parse(show[show.Length - 1]);
            if (ms > 99)
            {
                carry = 1;
                ms %= 100;
            }

            int s = int.Parse(start[start.Length - 2]) + int.Parse(show[show.Length - 2]) + carry;
            carry = 0;
            if (s > 59)
            {
                carry = 1;
                s %= 60;
            }

            int min = int.Parse(start[start.Length - 3]) + int.Parse(show[show.Length - 3]) + carry;
            carry = 0;
            if (min > 59)
            {
                carry = 1;
                min %= 60;
            }

            int h = int.Parse(start[start.Length - 4]) + int.Parse(show[show.Length - 4]) + carry;

            string minString = min < 10 ? "0" + min : min.ToString();
            string secString = s < 10 ? "0" + s : s.ToString();
            string msString = ms < 10 ? "0" + ms : ms.ToString();

            return h + ":" + minString + ":" + secString + "." + msString;
        }
    }
}
