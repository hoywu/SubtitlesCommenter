using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtitlesCommenter.Bean
{
    internal class AddContentConfigBaseDTO
    {
        public string SubtitlesStyleFormat { get; set; }
        public Encoding Encoding { get; set; }
        public string FilePath { get; set; }
    }
}
