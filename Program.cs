
using Microsoft.Office.Interop.Word;

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
    public static Microsoft.Office.Interop.Word.Document wordDocument { get; set; }
    public static string DocToPdf(string base64)
    {
        string docPath = "temp.docx", pdfPath = "temp.pdf";
        File.WriteAllBytes(docPath, Convert.FromBase64String(base64));
        Microsoft.Office.Interop.Word.Application appWord = new Microsoft.Office.Interop.Word.Application();
        wordDocument = appWord.Documents.Open(docPath);
        wordDocument.ExportAsFixedFormat(pdfPath, WdExportFormat.wdExportFormatPDF);

        return Convert.ToBase64String(File.ReadAllBytes(pdfPath));
    }
}