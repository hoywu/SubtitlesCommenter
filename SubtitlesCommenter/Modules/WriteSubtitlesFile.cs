using SubtitlesCommenter.Bean;
using System.IO;

namespace SubtitlesCommenter.Modules
{
    internal class WriteSubtitlesFile
    {
        public static void SaveToSubtitlesFile(AddContentConfigDTO add)
        {
            using (StreamWriter sw = new StreamWriter(add.FilePath, true, add.Encoding))
            {
                // todo
            }
        }
    }
}
