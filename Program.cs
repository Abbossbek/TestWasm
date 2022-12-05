
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;

using System;
using System.IO;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {

        Assembly a = typeof(Program).Assembly;
        Console.WriteLine(a.GetName().Name);
        Console.WriteLine("Hello from C#!");
    }
}
public static class TestClass
{
    public static string Hello(string name)
    {
        Console.WriteLine($"Hello {name}!");
        return $"Hello {name}!";
    }
    public static string DocToPdf(string base64)
    {
        using (MemoryStream docStream = new(Convert.FromBase64String(base64)))
        using (MemoryStream pdfStream = new())
        {

            //Creates a new Word document.
            WordDocument wordDocument = new WordDocument(docStream, Syncfusion.DocIO.FormatType.Docx);
            //Create instance for DocIORenderer for Word to PDF conversion
            DocIORenderer render = new DocIORenderer();
            //Converts Word document to PDF.
            PdfDocument pdfDocument = render.ConvertToPDF(wordDocument);
            //Release the resources used by the Word document and DocIO Renderer objects.
            render.Dispose();
            wordDocument.Dispose();
            pdfDocument.Save(pdfStream);
            //Closes the instance of PDF document object.
            pdfDocument.Close();
            return Convert.ToBase64String(pdfStream.ToArray());
        }
    }
}