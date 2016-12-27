using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortMp3
{
    class Options
    {
        public Options()
        {
            this.NumberFormat = "000";
        }

        [Option('p', "path", Required = true, HelpText = "Path to Mp3's")]
        public string Mp3Path { get; set; }

        [Option('o', "outputpath", Required = true, HelpText = "Outputpath")]
        public string OutputPath { get; set; }

        [Option('f', "format", Required = false, HelpText = "Numberformat e.g. 000 -> 001 - 999")]
        public string NumberFormat { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            HeadingInfo loHeadingInfo = new HeadingInfo("SortMp3");
            HelpText loHelp = new HelpText(loHeadingInfo);
            loHelp.Copyright = "Copyright © PinBack 2016";
            loHelp.AddOptions(this);
            return loHelp;
        }
    }
}
