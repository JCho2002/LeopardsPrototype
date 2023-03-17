using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PDFExport : MonoBehaviour
{
    [SerializeField] private string[] _inputImagePaths;
    [SerializeField] private string _exportedPDFPath;

    void Start()
    {
        CreatePDF(_inputImagePaths);
    }

    private void CreatePDF(string[] inputImagePaths)
    {
        PdfDocument pdfDocument = new PdfDocument();
        pdfDocument.Info.Title = "Test Export PDF Title";

        foreach (string imagePath in inputImagePaths)
            AddImagePage(pdfDocument, imagePath);

        pdfDocument.Save(_exportedPDFPath);

        // open the pdf
        Process.Start(_exportedPDFPath);
    }

    private static void AddImagePage(PdfDocument pdfDocument, string inputImagePath)
    {
        PdfPage page1 = pdfDocument.AddPage();
        // graphics drawer class
        XGraphics gfx = XGraphics.FromPdfPage(page1);

        PdfPage page2 = pdfDocument.AddPage();
    }
}
