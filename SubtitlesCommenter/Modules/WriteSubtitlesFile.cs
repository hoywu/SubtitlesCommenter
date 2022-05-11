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

                int layer = v4PDTO.Layer;
                string startTime = v4PDTO.AddLocation;
                string endTime;
                string styleName = v4PDTO.Style.Name;
                string name = v4PDTO.Name;
                int MarginL = v4PDTO.MarginL;
                int MarginR = v4PDTO.MarginR;
                int MarginV = v4PDTO.MarginV;
                string effect = AddEffect(v4PDTO);
                string theText;

                StringBuilder text = new();

                if (v4PDTO.AddMode == AddModeEnum.SINGLE_LINE)
                {
                    // 单行模式
                    for (int i = 0; i < addLine.Length; i++)
                    {
                        if ("".Equals(addLine[i])) continue;
                        text.Append("Dialogue: ");

                        theText = AddASSTagsToText(addLine[i], v4PDTO);
                        endTime = GetEndTime(v4PDTO, startTime, theText);

                        foreach (string s in formats)
                        {
                            switch (s)
                            {
                                case "Layer":
                                    text.Append("," + layer);
                                    break;
                                case "Start":
                                    text.Append("," + startTime);
                                    break;
                                case "End":
                                    text.Append("," + endTime);
                                    break;
                                case "Style":
                                    text.Append("," + styleName);
                                    break;
                                case "Name":
                                    text.Append("," + name);
                                    break;
                                case "MarginL":
                                    text.Append("," + MarginL);
                                    break;
                                case "MarginR":
                                    text.Append("," + MarginR);
                                    break;
                                case "MarginV":
                                    text.Append("," + MarginV);
                                    break;
                                case "Effect":
                                    text.Append("," + effect);
                                    break;
                                case "Text":
                                    text.Append("," + theText);
                                    break;
                            }
                        }
                        text.Append(Environment.NewLine);
                        startTime = endTime;
                    }
                }
                else if (v4PDTO.AddMode == AddModeEnum.MULTI_LINE)
                {
                    // 整段模式
                    text.Append("Dialogue: ");

                    theText = AddASSTagsToText(GetMultiLineText(addLine), v4PDTO);
                    endTime = GetEndTime(v4PDTO, v4PDTO.AddLocation, theText);

                    foreach (string s in formats)
                    {
                        switch (s)
                        {
                            case "Layer":
                                text.Append("," + layer);
                                break;
                            case "Start":
                                text.Append("," + startTime);
                                break;
                            case "End":
                                text.Append("," + endTime);
                                break;
                            case "Style":
                                text.Append("," + styleName);
                                break;
                            case "Name":
                                text.Append("," + name);
                                break;
                            case "MarginL":
                                text.Append("," + MarginL);
                                break;
                            case "MarginR":
                                text.Append("," + MarginR);
                                break;
                            case "MarginV":
                                text.Append("," + MarginV);
                                break;
                            case "Effect":
                                text.Append("," + effect);
                                break;
                            case "Text":
                                text.Append("," + theText);
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
        /// 获取结束时间，自适应时间为每秒6字、最低1秒
        /// </summary>
        /// <param name="baseObj"></param>
        /// <param name="StartTime">单行模式每次调用需要更新开始时间</param>
        /// <param name="theText">传入字幕文本用于自适应时间</param>
        private static string GetEndTime(AddContentConfigBaseDTO baseObj, string StartTime, string theText)
        {
            // [V4+ Styles]
            if (baseObj.SubtitlesStyleStandard == StyleStandardEnum.V4P)
            {
                AddContentConfigV4PDTO v4PDTO = (AddContentConfigV4PDTO)baseObj;
                if (v4PDTO.autoShowTime == false)
                {
                    return GlobalUtils.GetEndTime(StartTime, v4PDTO.ShowTime);
                }
                string cleanText = new string(theText.Where(c => !char.IsPunctuation(c)).ToArray()).Replace(" ", "").Replace("	", "");

                double showTimeSec = 0;
                showTimeSec = Math.Round(cleanText.Length / 6.0, 2);
                if (showTimeSec < 1.0) showTimeSec = 1.0;

                return GlobalUtils.GetEndTime(StartTime, GlobalUtils.SecToShowTime(showTimeSec));
            }
            else
            {
                // 不应执行到此
                throw new Exception(Constants.ERROR_MESSAGE_PROGRAMING_ERROR);
            }
        }

        /// <summary>
        /// Effect效果
        /// </summary>
        private static string AddEffect(AddContentConfigBaseDTO baseObj)
        {
            // [V4+ Styles]
            if (baseObj.SubtitlesStyleStandard == StyleStandardEnum.V4P)
            {
                AddContentConfigV4PDTO v4PDTO = (AddContentConfigV4PDTO)baseObj;
                if (v4PDTO.banner == false) return v4PDTO.Effect;

                StringBuilder text = new("Banner;");

                text.Append(v4PDTO.bannerSpeed + ";");
                text.Append(v4PDTO.bannerDirection);

                v4PDTO.Effect = text.ToString();
                return v4PDTO.Effect;
            }
            else
            {
                // 不应执行到此
                throw new Exception(Constants.ERROR_MESSAGE_PROGRAMING_ERROR);
            }
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
                if (v4PDTO.italics == 1)
                {
                    text.Append("\\i1");
                }
                if (v4PDTO.boldface == 1)
                {
                    text.Append("\\b1");
                }
                if (v4PDTO.underlined == 1)
                {
                    text.Append("\\u1");
                }
                if (v4PDTO.strikeout == 1)
                {
                    text.Append("\\s1");
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
