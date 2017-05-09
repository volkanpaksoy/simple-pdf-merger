using Fclp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePdfMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new FluentCommandLineParser<Settings>();
            parser.Setup(arg => arg.RootFolder).As('d', "directory");
            parser.Setup(arg => arg.FileList).As('f', "files");
            parser.Setup(arg => arg.OutputPath).As('o', "output").Required();
            parser.Setup(arg => arg.AllInFolder).As('a', "all");

            var result = parser.Parse(args);
            if (result.HasErrors)
            {
                DisplayUsage();
                return;
            }

            var p = new Program();
            p.Run(parser.Object);
        }

        static void DisplayUsage()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("------");
            Console.WriteLine("pdfMerge -d {root folder full path} -a -f {list of input files} -o {output pdf full path} ");
            Console.WriteLine("-d, --directory ....: Root folder. If file list is specified, only names without the folder can be used. The same root path is used for all files. ");
            Console.WriteLine("-a, --all ..........: Find and merge all PDFs in the root folder ");
            Console.WriteLine("-f, --files ........: List of files. Full path required if direcotry is not specified");
            Console.WriteLine("-o, --output .......: Full path for the output PDF file");
        }

        void Run(Settings settings)
        {
            Console.WriteLine("Running merger...");

            var merger = new PdfMerger();
            var files = new List<String>();

            // If there is no root folder, use individual files as provided
            if (string.IsNullOrEmpty(settings.RootFolder))
            {
                files = settings.FileList;
            }
            else
            {
                var rootDirectory = new DirectoryInfo(settings.RootFolder);
                if (settings.AllInFolder)
                {
                    var allPdfs = rootDirectory.GetFiles("*.pdf", SearchOption.TopDirectoryOnly);
                    files = allPdfs.Select(f => f.FullName).ToList();
                }
                else
                {
                    files = settings.FileList.Select(f => Path.Combine(settings.RootFolder, f)).ToList();
                }
            }

            merger.MergePdfs(files, settings.OutputPath);

            Console.WriteLine($"Merged succesfully. Output saved: {settings.OutputPath}");
        }
    }
}
