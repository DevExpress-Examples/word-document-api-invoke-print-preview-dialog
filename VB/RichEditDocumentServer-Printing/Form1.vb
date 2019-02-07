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
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub btn_Print_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Print.Click
            '#Region "#serverprint"
            Dim richServer As New RichEditDocumentServer()
            ' Specify default formatting
            richServer.Document.DefaultParagraphProperties.Alignment = ParagraphAlignment.Center
            ' Specify page settings
            richServer.Document.Sections(0).Page.Landscape = True
            richServer.Document.Sections(0).Page.Height = DevExpress.Office.Utils.Units.InchesToDocumentsF(10.0F)
            richServer.Document.Sections(0).Page.Width = DevExpress.Office.Utils.Units.InchesToDocumentsF(4.5F)
            ' Add document content
            richServer.Document.AppendText("This content is created programmatically" & Constants.vbLf)
            richServer.Document.Paragraphs.Append()

            ' Create a table
            richServer.BeginUpdate()

            Dim _table As Table = richServer.Document.Tables.Create(richServer.Document.Selection.Start, 8, 8, AutoFitBehaviorType.FixedColumnWidth)
            _table.BeginUpdate()
            _table.Borders.InsideHorizontalBorder.LineThickness = 1
            _table.Borders.InsideHorizontalBorder.LineStyle = TableBorderLineStyle.Double
            _table.Borders.InsideVerticalBorder.LineThickness = 1
            _table.Borders.InsideVerticalBorder.LineStyle = TableBorderLineStyle.Double
            _table.TableAlignment = TableRowAlignment.Center

            _table.ForEachCell(Sub(cell, rowIndex, columnIndex)
                                   richServer.Document.InsertText(cell.Range.Start, String.Format("{0}*{1} is {2}",
                                                                rowIndex + 2, columnIndex + 2, (rowIndex + 2) * (columnIndex + 2)))
                               End Sub)
            _table.EndUpdate()

            richServer.EndUpdate()

            ' Invoke the Print Preview dialog
            Using printingSystem As New PrintingSystem()
                Using link As New PrintableComponentLink(printingSystem)
                    link.Component = richServer
                    link.CreateDocument()
                    link.ShowPreviewDialog()
                End Using
            End Using
            '#End Region ' #serverprint
        End Sub
    End Class
End Namespace