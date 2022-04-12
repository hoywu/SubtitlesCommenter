using SubtitlesCommenter.Bean;
using SubtitlesCommenter.CustomException;
using SubtitlesCommenter.Utils;
using System.Text;

namespace SubtitlesCommenter.Modules
{
    internal class WriteSubtitlesFile
    {
        /// <summary>
        /// 按照AddContentConfig中的信息保存到文件
        /// </summary>
        public static void SaveToSubtitlesFile(AddContentConfigBaseDTO add)
        {
            List<string> fileLines = File.ReadAllLines(add.FilePath, add.Encoding).ToList();

            // [V4+ Styles]
            if (Constants.STYLE_FORMAT_V4P.Equals(add.SubtitlesStyleFormat))
            {
                AddContentConfigV4PDTO v4PDTO = (AddContentConfigV4PDTO)add;
                string writeText = GetTextToWrite(fileLines, v4PDTO);
                fileLines.Insert(fileLines.IndexOf("[Events]") + 2, writeText);
                File.WriteAllLines(v4PDTO.FilePath, fileLines, v4PDTO.Encoding);
            }
        }

        /// <summary>
        /// 将AddContentConfig转换为用于写入文件的文本
        /// </summary>
        /// <param name="subtitlesFile">ReadAllLines读入的字幕文件List，将从中解析Format</param>
        /// <param name="baseObj">DTO对象</param>
        private static string GetTextToWrite(List<string> subtitlesFile, AddContentConfigBaseDTO baseObj)
        {
            // [V4+ Styles]
            if (Constants.STYLE_FORMAT_V4P.Equals(baseObj.SubtitlesStyleFormat))
            {
                AddContentConfigV4PDTO v4PDTO = (AddContentConfigV4PDTO)baseObj;

                // 单行模式
                if (Constants.ADD_MODE_SINGLE_LINE.Equals(v4PDTO.AddMode))
                {
                    string format = subtitlesFile.ElementAt(subtitlesFile.IndexOf("[Events]") + 1);
                    format = format.Replace("\r\n", "\n");
                    format = GlobalUtils.GetMiddleString(format + "\n", "Format: ", "\n");
                    format = format.Replace(", ", ",");
                    if (string.IsNullOrEmpty(format))
                    {
                        throw new UnknownStyleException("没有找到字幕Format行，文件格式错误");
                    }

                    // 格式数组
                    string[] formats = format.Split(',');

                    // 判断用户输入了多少行
                    string[] addLine = (v4PDTO.Text.Replace("\r\n", "\n") + "\n").Split('\n');

                    StringBuilder text = new();
                    string startTime = v4PDTO.AddLocation;
                    for (int i = 0; i < addLine.Length; i++)
                    {
                        if (addLine[i] == "") continue;
                        text.Append("Dialogue: ");
                        foreach (string s in formats)
                        {
                            switch (s)
                            {
                                case "Layer":
                                    text.Append("," + v4PDTO.Layer);
                                    break;
                                case "Start":
                                    text.Append("," + startTime);
                                    break;
                                case "End":
                                    text.Append("," + GlobalUtils.GetEndTime(startTime, v4PDTO.ShowTime));
                                    break;
                                case "Style":
                                    text.Append("," + v4PDTO.StyleName);
                                    break;
                                case "Name":
                                    text.Append("," + v4PDTO.Name);
                                    break;
                                case "MarginL":
                                    text.Append("," + v4PDTO.MarginL);
                                    break;
                                case "MarginR":
                                    text.Append("," + v4PDTO.MarginR);
                                    break;
                                case "MarginV":
                                    text.Append("," + v4PDTO.MarginV);
                                    break;
                                case "Effect":
                                    text.Append("," + v4PDTO.Effect);
                                    break;
                                case "Text":
                                    text.Append("," + addLine[i]);
                                    break;
                            }
                        }
                        text.Append(Environment.NewLine);
                        startTime = GlobalUtils.GetEndTime(startTime, v4PDTO.ShowTime);
                    }

                    string retText = text.ToString();
                    retText = retText.Replace("Dialogue: ,", "Dialogue: ");
                    // 删除最后一个换行符
                    retText = retText.Remove(retText.Length - Environment.NewLine.Length);

                    return retText;
                }
                // 整段模式
                else if (Constants.ADD_MODE_MULTI_LINE.Equals(v4PDTO.AddMode))
                {
                    // todo
                    return null;
                }
                else
                {
                    // 不应执行到此
                    throw new Exception(Constants.ERROR_MESSAGE_PROGRAMING_ERROR);
                }
            }
            else
            {
                // 不应执行到此
                throw new Exception(Constants.ERROR_MESSAGE_PROGRAMING_ERROR);
            }
        }
    }
}
