Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
#Region "#usings"
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraPrinting
#End Region ' #usings

Namespace RichEditDocumentServer_Printing
	Partial Public Class Form1
		Inherits Form

        Dim richServer As RichEditDocumentServer

		Public Sub New()
			InitializeComponent()
		End Sub

Private Sub btn_Print_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Print.Click
'#Region "#serverprint"
            richServer = New RichEditDocumentServer()
	richServer.CreateNewDocument()
	' Add the document content.
	richServer.BeginUpdate()
	richServer.Document.AppendText("This content is created programmatically" & Constants.vbLf)
	richServer.Document.AppendParagraph()
	' Call a method defined in this project that creates a table.
	InsertTableIntoDocument(richServer)
	richServer.EndUpdate()
	' Specify page settings
	richServer.Document.Sections(0).Page.Landscape = True
	richServer.Document.Sections(0).Page.Height = DevExpress.Office.Utils.Units.InchesToDocumentsF(10.0f)
	richServer.Document.Sections(0).Page.Width = DevExpress.Office.Utils.Units.InchesToDocumentsF(5.0f)
	' Invoke the Print Preview dialog.
	Using printingSystem As New PrintingSystem()
		Using link As New PrintableComponentLink(printingSystem)
			link.Component = richServer
			link.CreateDocument()
			link.PrintingSystem.PreviewFormEx.ShowDialog()
		End Using
	End Using
'#End Region ' #serverprint
End Sub
        Private Sub InsertTableIntoDocument(ByVal richServer As RichEditDocumentServer)
            Dim _table As Table = richServer.Document.Tables.Add(richServer.Document.Range.End, 8, 8, AutoFitBehaviorType.AutoFitToContents)
            _table.BeginUpdate()
            _table.Borders.InsideHorizontalBorder.LineThickness = 1
            _table.Borders.InsideHorizontalBorder.LineStyle = TableBorderLineStyle.Double
            _table.Borders.InsideVerticalBorder.LineThickness = 1
            _table.Borders.InsideVerticalBorder.LineStyle = TableBorderLineStyle.Double
            _table.TableAlignment = TableRowAlignment.Center

            _table.ForEachCell(New TableCellProcessorDelegate(AddressOf MakeMultiplicationTable))

            _table.EndUpdate()
        End Sub
		 Private Sub MakeMultiplicationTable(ByVal cell As TableCell, ByVal i As Integer, ByVal j As Integer)
            richServer.Document.InsertText(cell.Range.Start, String.Format("{0}*{1} is {2}", i + 2, j + 2, (i + 2) * (j + 2)))
        End Sub
	End Class
End Namespace