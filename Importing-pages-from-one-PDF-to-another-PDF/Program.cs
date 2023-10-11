// See https://aka.ms/new-console-template for more information

using Syncfusion.Licensing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;


// register license with incorrect license key or random string crashes program
// no problems if register with correct license key
// SyncfusionLicenseProvider.RegisterLicense("123");


//Get stream from an existing PDF document.
FileStream inputFileStream = new FileStream(Path.GetFullPath(@"../../../Input.pdf"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputFileStream);

//Create a new PDF document.
PdfDocument document = new PdfDocument();
document.Pages.Add();
document.Pages.Insert(0, loadedDocument.Pages[0]);

using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
	//Save the PDF document to file stream.
	document.Save(outputFileStream);
}

//Closes both document instances.
loadedDocument.Close(true);
document.Close(true);