using SubtitlesCommenter.Bean;
using SubtitlesCommenter.Enum;
using SubtitlesCommenter.Exceptions;
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
            if (add.SubtitlesStyleStandard == StyleStandardEnum.V4P)
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
            if (baseObj.SubtitlesStyleStandard == StyleStandardEnum.V4P)
            {
                AddContentConfigV4PDTO v4PDTO = (AddContentConfigV4PDTO)baseObj;

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

                if (v4PDTO.AddMode == AddModeEnum.SINGLE_LINE)
                {
                    // 单行模式
                    string startTime = v4PDTO.AddLocation;
                    for (int i = 0; i < addLine.Length; i++)
                    {
                        if ("".Equals(addLine[i])) continue;
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
                                    text.Append("," + v4PDTO.Style.Name);
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
                                    text.Append("," + AddASSTagsToText(addLine[i], v4PDTO));
                                    break;
                            }
                        }
                        text.Append(Environment.NewLine);
                        startTime = GlobalUtils.GetEndTime(startTime, v4PDTO.ShowTime);
                    }
                }
                else if (v4PDTO.AddMode == AddModeEnum.MULTI_LINE)
                {
                    // 整段模式
                    text.Append("Dialogue: ");
                    foreach (string s in formats)
                    {
                        switch (s)
                        {
                            case "Layer":
                                text.Append("," + v4PDTO.Layer);
                                break;
                            case "Start":
                                text.Append("," + v4PDTO.AddLocation);
                                break;
                            case "End":
                                text.Append("," + GlobalUtils.GetEndTime(v4PDTO.AddLocation, v4PDTO.ShowTime));
                                break;
                            case "Style":
                                text.Append("," + v4PDTO.Style.Name);
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
                                text.Append("," + AddASSTagsToText(GetMultiLineText(addLine), v4PDTO));
                                break;
                        }
                    }
                }
                else
                {
                    // 不应执行到此
                    throw new Exception(Constants.ERROR_MESSAGE_PROGRAMING_ERROR);
                }

                string retText = text.ToString().Replace("Dialogue: ,", "Dialogue: ");
                // 删除最后一个换行符
                retText = retText.Remove(retText.Length - Environment.NewLine.Length);

                return retText;
            }
            else
            {
                // 不应执行到此
                throw new Exception(Constants.ERROR_MESSAGE_PROGRAMING_ERROR);
            }
        }

        /// <summary>
        /// 获得整段模式Text
        /// </summary>
        private static string GetMultiLineText(string[] addLine)
        {
            StringBuilder text = new();
            for (int i = 0; i < addLine.Length; i++)
            {
                if ("".Equals(addLine[i])) continue;
                text.Append(addLine[i]);
                text.Append("\\N");
            }
            string retString = text.ToString();
            retString = retString.Remove(retString.Length - "\\N".Length);
            return retString + Environment.NewLine;
        }

        /// <summary>
        /// 将特效标签加入Text中，如果没有特效标签返回原Text
        /// </summary>
        private static string AddASSTagsToText(string Text, AddContentConfigBaseDTO baseObj)
        {
            // [V4+ Styles]
            if (baseObj.SubtitlesStyleStandard == StyleStandardEnum.V4P)
            {
                AddContentConfigV4PDTO v4PDTO = (AddContentConfigV4PDTO)baseObj;
                if (v4PDTO.AdvOption == false)
                {
                    return Text;
                }

                StringBuilder text = new("{");

                if (v4PDTO.fad > 0)
                {
                    text.Append("\\fad(" + v4PDTO.fad.ToString() + "," + v4PDTO.fad.ToString() + ")");
                }
                if (v4PDTO.alpha > 0)
                {
                    text.Append("\\alpha&H" + Convert.ToString(v4PDTO.alpha, 16) + "&");
                }
                if (!string.IsNullOrEmpty(v4PDTO.custom))
                {
                    text.Append(v4PDTO.custom);
                }

                text.Append("}");
                string newText = text.ToString();
                return "{}".Equals(newText) ? Text : newText + Text;
            }
            else
            {
                // 不应执行到此
                throw new Exception(Constants.ERROR_MESSAGE_PROGRAMING_ERROR);
            }
        }
    }
}
