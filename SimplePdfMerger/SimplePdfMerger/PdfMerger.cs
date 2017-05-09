using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePdfMerger
{
    public class PdfMerger
    {
        public string MergePdfs(List<string> sourceFileList, string outputFilePath)
        {
            using (var stream = new FileStream(outputFilePath, FileMode.Create))
            {
                using (var pdfDoc = new Document())
                {
                    var pdf = new PdfCopy(pdfDoc, stream);
                    pdfDoc.Open();
                    foreach (string file in sourceFileList)
                    {
                        pdf.AddDocument(new PdfReader(file));
                    }
                }
            }

            return outputFilePath;
        }
    }
}
