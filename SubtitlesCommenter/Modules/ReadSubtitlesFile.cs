using SubtitlesCommenter.Bean;
using SubtitlesCommenter.Enum;
using SubtitlesCommenter.Exceptions;
using SubtitlesCommenter.Utils;

namespace SubtitlesCommenter.Modules
{
    internal class ReadSubtitlesFile
    {
        /// <summary>
        /// 从字幕文件中取出所有样式，构造样式对象存放到SubtitlesStyleBase数组并返回
        /// </summary>
        public static SubtitlesStyleBase[] GetSubtitlesStyles(string subtitlesFile, StyleStandardEnum styleStandard)
        {
            // [V4+ Styles]
            if (styleStandard == StyleStandardEnum.V4P)
            {
                #region 取出样式块内容styles，取出Format行切割存放在formatArray，得到样式数量styleNumber
                // 取出样式块的内容
                string styles = GlobalUtils.GetMiddleString(subtitlesFile, ReadFileConstants.STYLE_STANDARD_V4P, "\n\n");
                if (string.IsNullOrEmpty(styles))
                {
                    // 取出样式为空
                    throw new UnknownStyleException("读取样式块失败或样式块为空");
                }

                // 取出样式Format行
                string formatLine = GlobalUtils.GetMiddleString(styles, "Format: ", "\n");
                if (string.IsNullOrEmpty(formatLine))
                {
                    throw new UnknownStyleException("没有找到样式Format行或格式错误");
                }
                string[] formatArray = formatLine.Replace(", ", ",").Split(',');

                // 找到有几个定义好的样式
                int styleNumber = GetStyleNumber(styles, ReadFileConstants.STYLE_STANDARD_V4P_COUNTER);
                if (styleNumber == 0)
                {
                    // 没有定义好的样式
                    throw new UnknownStyleException("未在该字幕文件中发现任何样式，请先在字幕制作软件中添加至少一个样式");
                }
                #endregion

                SubtitlesStyleV4P[] retArray = new SubtitlesStyleV4P[styleNumber];

                // remain 存放尚未构造成对象的样式块内容
                string remain = styles + "\n";
                int index;
                // style 存放一个样式行
                string style;
                // 构造对象并存入数组
                for (int i = 0; i < retArray.Length; i++)
                {
                    // 取出一行Style
                    style = GlobalUtils.GetMiddleString(remain, ReadFileConstants.STYLE_STANDARD_V4P_COUNTER, "\n");
                    // 从 remain 中去掉这一行
                    index = remain.IndexOf(ReadFileConstants.STYLE_STANDARD_V4P_COUNTER) + ReadFileConstants.STYLE_STANDARD_V4P_COUNTER.Length;
                    remain = remain.Substring(index);

                    // 切割取到的Style行，存放到styleArray数组
                    string[] styleArray = style.Replace(", ", ",").Split(',');

                    // 构造SubtitlesStyleV4P对象，存放到数组中
                    try
                    {
                        retArray[i] = BuildV4P(formatArray, styleArray);
                    }
                    catch (Exception e)
                    {
                        throw new UnknownStyleException(e.Message);
                    }
                }
                return retArray;
            }
            else
            {
                // 不应该执行到此，StyleStandardEnum 所有可能的值应该在上面处理完
                throw new UnknownStyleException(Constants.ERROR_MESSAGE_PROGRAMING_ERROR);
            }
        }
        /// <summary>
        /// 判断字幕文件string样式标准，以便确定解析方式，返回 StyleFormatEnum 枚举型，无法判断返回 StyleStandardEnum.Unknown
        /// </summary>
        public static StyleStandardEnum GetStyleStandard(string subtitlesFile)
        {
            // 在字幕文件中寻找STYLE_STANDARD_?常量
            int index = subtitlesFile.IndexOf(ReadFileConstants.STYLE_STANDARD_V4P);
            if (index != -1)
            {
                return StyleStandardEnum.V4P;
            }
            return StyleStandardEnum.Unknown;
        }
        /// <summary>
        /// 返回字幕文件string中有几个STYLE_COUNTER
        /// </summary>
        /// <param name="s">字幕文件</param>
        /// <param name="STYLE_COUNTER">计数用常量</param>
        private static int GetStyleNumber(string s, string STYLE_COUNTER)
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
        /// <summary>
        /// 构造一个SubtitlesStyleV4P对象
        /// </summary>
        /// <param name="formats">Format行，定义style数组对应元素的含义</param>
        /// <param name="style">构造对象用数据，元素数量必须与formats相同</param>
        private static SubtitlesStyleV4P BuildV4P(string[] formats, string[] style)
        {
            if (formats.Length != style.Length)
            {
                throw new UnknownStyleException("Format行与Style行无法对应");
            }

            SubtitlesStyleV4P retObj = new();

            for (int i = 0; i < formats.Length; i++)
            {
                switch (formats[i])
                {
                    case "Name":
                        retObj.Name = style[i];
                        break;
                    case "Fontname":
                        retObj.Fontname = style[i];
                        break;
                    case "Fontsize":
                        retObj.Fontsize = style[i];
                        break;
                    case "PrimaryColour":
                        retObj.PrimaryColour = style[i];
                        break;
                    case "SecondaryColour":
                        retObj.SecondaryColour = style[i];
                        break;
                    case "OutlineColour":
                        retObj.OutlineColour = style[i];
                        break;
                    case "BackColour":
                        retObj.BackColour = style[i];
                        break;
                    case "Bold":
                        retObj.Bold = int.Parse(style[i]);
                        break;
                    case "Italic":
                        retObj.Italic = int.Parse(style[i]);
                        break;
                    case "Underline":
                        retObj.Underline = int.Parse(style[i]);
                        break;
                    case "StrikeOut":
                        retObj.StrikeOut = int.Parse(style[i]);
                        break;
                    case "ScaleX":
                        retObj.ScaleX = int.Parse(style[i]);
                        break;
                    case "ScaleY":
                        retObj.ScaleY = int.Parse(style[i]);
                        break;
                    case "Spacing":
                        retObj.Spacing = int.Parse(style[i]);
                        break;
                    case "Angle":
                        retObj.Angle = int.Parse(style[i]);
                        break;
                    case "BorderStyle":
                        retObj.BorderStyle = int.Parse(style[i]);
                        break;
                    case "Outline":
                        retObj.Outline = int.Parse(style[i]);
                        break;
                    case "Shadow":
                        retObj.Shadow = int.Parse(style[i]);
                        break;
                    case "Alignment":
                        retObj.Alignment = int.Parse(style[i]);
                        break;
                    case "MarginL":
                        retObj.MarginL = int.Parse(style[i]);
                        break;
                    case "MarginR":
                        retObj.MarginR = int.Parse(style[i]);
                        break;
                    case "MarginV":
                        retObj.MarginV = int.Parse(style[i]);
                        break;
                    case "Encoding":
                        retObj.Encoding = int.Parse(style[i]);
                        break;


                    default:
                        break;
                }
            }

            return retObj;
        }
    }
}
