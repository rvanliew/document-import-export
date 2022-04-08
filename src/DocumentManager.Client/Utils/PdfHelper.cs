using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;

namespace DocumentExportUtility_API.Utils
{
    public class PdfHelper
    {
        public PdfHelper()
        {
        }

        public static PdfHelper Instance { get; } = new PdfHelper();

        internal void SaveImageAsPdf(string imageFileName, string pdfFileName, int width = 600, bool deleteImage = false)
        {
            using (var document = new PdfDocument())
            {
                PdfPage page = document.AddPage();
                using (XImage img = XImage.FromFile(imageFileName))
                {
                    // Calculate new height to keep image ratio
                    var height = (int)(((double)width / (double)img.PixelWidth) * img.PixelHeight);

                    // Change PDF Page size to match image
                    page.Width = width;
                    page.Height = height;

                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    gfx.DrawImage(img, 0, 0, width, height);
                }

                document.Save(pdfFileName);
            }

            //Cleanup images
            if (deleteImage)
                File.Delete(imageFileName);
        }

        internal void ConcatenateDocuments(string[] fileArray, string exportFolder, string attachmentTitle)
        {
            PdfDocument outputDocument = new PdfDocument();

            foreach (string file in fileArray)
            {
                PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import);
                int count = inputDocument.PageCount;
                for (int idx = 0; idx < count; idx++)
                {
                    PdfPage page = inputDocument.Pages[idx];
                    outputDocument.AddPage(page);
                }
            }

            string filename = @$"{exportFolder}\{attachmentTitle}.pdf";
            outputDocument.Save(filename);

            DirectoryInfo di = new DirectoryInfo(exportFolder);
            //Clean up non concat pdf pages
            foreach(FileInfo file in di.GetFiles())
            {
                //if (!file.Name.Contains($"{attachmentTitle}"))
                //{
                //    file.Delete();
                //}
                var foo = file.Name;
                var dashCount = foo.Count(c => c == '-');

                if (dashCount >= 4)
                {
                    file.Delete();
                }
            }
        }

        internal byte[] ConvertToByteArray(string fileName)
        {
            byte[] fileContent = null;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;

            fileContent = br.ReadBytes((int)numBytes);
            fs.Close();

            return fileContent;
        }
    }
}
