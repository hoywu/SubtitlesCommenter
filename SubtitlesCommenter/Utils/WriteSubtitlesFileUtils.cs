using System.Text;
using UtfUnknown;

namespace SubtitlesCommenter.Utils
{
    internal class WriteSubtitlesFileUtils
    {
        /// <summary>
        /// 获取文件编码
        /// </summary>
        public static Encoding GetFileEncoding(string filename)
        {
            DetectionResult result = CharsetDetector.DetectFromFile(filename);
            DetectionDetail resultDetected = result.Detected;
            Encoding encoding = resultDetected.Encoding;
            if (encoding == null) return Encoding.Default;
            return encoding;
        }
    }
}
