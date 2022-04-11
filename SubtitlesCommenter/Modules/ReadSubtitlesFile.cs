using SubtitlesCommenter.Bean;
using SubtitlesCommenter.CustomException;
using SubtitlesCommenter.Utils;
using System;
using System.IO;

namespace SubtitlesCommenter.Modules
{
    internal class ReadSubtitlesFile
    {
        /// <summary>
        /// 从字幕文件中取出所有样式，构造样式对象存放到SubtitlesStyleBase数组并返回
        /// </summary>
        /// <param name="SubtitlesFilePath"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="EmptyFileException"></exception>
        /// <exception cref="UnknownStyleException"></exception>
        public static SubtitlesStyleBase[] GetSubtitlesStyles(string SubtitlesFilePath)
        {
            #region 文件合法性校验
            if (!File.Exists(SubtitlesFilePath))
            {
                // 文件不存在
                throw new FileNotFoundException();
            }
            string file;
            try
            {
                file = File.ReadAllText(SubtitlesFilePath);
                file = file.Replace("\r\n", "\n");
            }
            catch (Exception e)
            {
                // 读取失败
                throw new IOException(e.Message);
            }
            if (string.IsNullOrEmpty(file))
            {
                // 文件为空
                throw new EmptyFileException();
            }

            string styleFormat = ReadSubtitlesFileUtils.GetStyleFormat(file);
            // 判断字幕文件样式格式
            if (string.IsNullOrEmpty(styleFormat))
            {
                // 不支持的样式
                throw new UnknownStyleException("无法判断该字幕文件的样式格式或不受支持");
            }
            #endregion

            // [V4+ Styles]
            if (Constants.STYLE_FORMAT_V4P.Equals(styleFormat))
            {
                #region 取出样式块内容styles，取出Format行切割存放在formats数组，得到样式数量styleNumber
                // 取出样式块的内容
                string styles = GlobalUtils.GetMiddleString(file, Constants.STYLE_FORMAT_V4P, "\n\n");
                if (string.IsNullOrEmpty(styles))
                {
                    // 取出样式为空
                    throw new UnknownStyleException("获取样式块失败或样式块为空");
                }

                string formatLine = GlobalUtils.GetMiddleString(styles, "Format: ", "\n");
                if (string.IsNullOrEmpty(formatLine))
                {
                    // 未找到样式Format
                    throw new UnknownStyleException("没有找到样式Format行，文件格式错误");
                }
                formatLine = formatLine.Replace(", ", ",");
                string[] formats = formatLine.Split(',');

                // 找到有几个定义好的样式
                int styleNumber = ReadSubtitlesFileUtils.GetStyleNumber(styles, Constants.V4P_STYLE_COUNTER);
                if (styleNumber == 0)
                {
                    // 没有定义好的样式
                    throw new UnknownStyleException("未在该字幕文件中发现任何样式，请先在字幕制作软件中添加至少一个样式");
                }
                #endregion

                SubtitlesStyleV4P[] retArray = new SubtitlesStyleV4P[styleNumber];

                int index = 0;
                // remain 存放尚未构造成对象的样式块内容
                string remain = styles + "\n";
                // style 存放一个样式行
                string style;
                // 构造对象并存入数组
                for (int i = 0; i < retArray.Length; i++)
                {
                    // 取出一行Style
                    style = GlobalUtils.GetMiddleString(remain, Constants.V4P_STYLE_COUNTER, "\n");
                    // 从 remain 中去掉这一行
                    index = remain.IndexOf(Constants.V4P_STYLE_COUNTER) + Constants.V4P_STYLE_COUNTER.Length;
                    remain = remain.Substring(index);

                    // 切割取到的Style行，存放到styleArray数组
                    style = style.Replace(", ", ",");
                    string[] styleArray = style.Split(',');

                    // 构造SubtitlesStyleV4P对象，存放到数组中
                    try
                    {
                        retArray[i] = BuildV4P(formats, styleArray);
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
                // 不应该执行到此，GetStyleFormat可能返回的所有内容应该在上面处理完
                throw new UnknownStyleException("程序错误，请联系开发者反馈问题");
            }
        }
        /// <summary>
        /// 构造一个SubtitlesStyleV4P对象
        /// </summary>
        /// <param name="formats">Format行，定义style数组对应元素的含义</param>
        /// <param name="style">构造对象用数据，元素数量必须与formats相同</param>
        /// <returns></returns>
        private static SubtitlesStyleV4P BuildV4P(string[] formats, string[] style)
        {
            if (formats.Length != style.Length)
            {
                throw new UnknownStyleException("Format行与Style行无法对应");
            }

            SubtitlesStyleV4P retObj = new SubtitlesStyleV4P();
            retObj.SubtitlesStyleFormat = Constants.STYLE_FORMAT_V4P;

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
