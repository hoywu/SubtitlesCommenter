using System.Text;
using UtfUnknown;

namespace SubtitlesCommenter.Utils
{
    internal class RWFileUtils
    {
        /// <summary>
        /// 从byte[]获取文件编码，失败返回 Encoding.Default
        /// </summary>
        public static Encoding GetFileEncoding(byte[] file)
        {
            DetectionResult result = CharsetDetector.DetectFromBytes(file);
            DetectionDetail resultDetected = result.Detected;
            Encoding encoding = resultDetected.Encoding;
            if (encoding == null) return Encoding.Default;
            return encoding;
        }
    }
}
