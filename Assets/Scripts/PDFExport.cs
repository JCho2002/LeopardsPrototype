using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.IO;

public class PDFExport : MonoBehaviour
{
    [SerializeField] private string[] _inputImagePaths;
    [SerializeField] private string _exportedPdfPath;

    private string _exportedPdfFileName;
    private string _exportedPdfDirectory;

    void Start()
    {
        InitPaths();
        CreatePdf(_inputImagePaths);
    }

    private void InitPaths()
    {
        string[] pathParts = _exportedPdfPath.Split('/');
        _exportedPdfFileName = pathParts[^1];
        _exportedPdfDirectory = string.Join('/', pathParts[0..^1]);
    }

    private void CreatePdf(string[] inputImagePaths)
    {
        PdfDocument pdfDocument = new PdfDocument();
        pdfDocument.Info.Title = "Test Export PDF Title";

        foreach (string imagePath in inputImagePaths)
            AddImagePage(pdfDocument, imagePath);

        pdfDocument.Save(_exportedPdfPath);
        LaunchPdf();
    }

    private void LaunchPdf()
    {
        var startInfo = new ProcessStartInfo()
        {
            FileName = _exportedPdfFileName,
            WorkingDirectory = _exportedPdfDirectory
        };
        Process.Start(startInfo);
    }

    private static void AddImagePage(PdfDocument pdfDocument, string inputImagePath)
    {
        // setup page
        PdfPage page = pdfDocument.AddPage();
        page.Size = PageSize.A4;
        page.Orientation = PageOrientation.Landscape;

        // draw image
        XImage image = XImage.FromFile(inputImagePath);
        XRect rect = GetScaledImageRect(image, page);
        XGraphics gfx = XGraphics.FromPdfPage(page);
        gfx.DrawImage(image, rect);
    }

    private static XRect GetScaledImageRect(XImage image, PdfPage page)
    {
        // calculate scaled image size to fit page
        double imageAspectRatio = (double)image.PixelWidth / image.PixelHeight;
        double pageAspectRatio = (double)page.Width / page.Height;
        double x, y, width, height;
        if (imageAspectRatio > pageAspectRatio)
        {
            width = page.Width;
            height = width / imageAspectRatio;
            x = 0;
            y = (page.Height - height) / 2;
        }
        else
        {
            height = page.Height;
            width = height * imageAspectRatio;
            x = (page.Width - width) / 2;
            y = 0;
        }
        return new XRect(x, y, width, height);
    }
}
