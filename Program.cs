using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortMp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var loOptions = new Options();
            string lsFullFileName;
            int lnCounter = 1;
            if (CommandLine.Parser.Default.ParseArguments(args, loOptions))
            {
                if (!Directory.Exists(loOptions.OutputPath))
                    Directory.CreateDirectory(loOptions.OutputPath);
                
                foreach (var loFileInfo in ReadMp3Files(loOptions.Mp3Path).OrderBy(item => item.CreationTime))
                {
                    lsFullFileName = Path.Combine(loOptions.OutputPath, GetFileName(loFileInfo, lnCounter, loOptions));
                    if (File.Exists(lsFullFileName))
                        File.Delete(lsFullFileName);
                    File.Copy(loFileInfo.FullName, lsFullFileName);
                    lnCounter++;
                }

            }
        }

        private static List<FileInfo> ReadMp3Files(string psPath)
        {
            DirectoryInfo loDirectoryInfo = new DirectoryInfo(psPath);
            return loDirectoryInfo.EnumerateFiles("*.mp3", SearchOption.AllDirectories).ToList();
        }

        private static string GetFileName(FileInfo poFileInfo, int pnCounter, Options poOptions)
        {
            string lsFormatString = "{0:" + poOptions.NumberFormat + "}_{1}";
            return string.Format(lsFormatString, pnCounter, poFileInfo.Name);
        }
    }
}
