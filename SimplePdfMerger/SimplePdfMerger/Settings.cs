using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePdfMerger
{
    public class Settings
    {
        public string RootFolder { get; set; }
        public List<string> FileList { get; set; } = new List<string>();
        public bool AllInFolder { get; set; } = false;
        public string OutputPath { get; set; }
    }
}
