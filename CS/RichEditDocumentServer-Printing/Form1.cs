using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
#region #usings
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraPrinting;
#endregion #usings

namespace RichEditDocumentServer_Printing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            #region #serverprint
            RichEditDocumentServer richServer = new RichEditDocumentServer();

            // Specify default formatting
            richServer.Document.DefaultParagraphProperties.Alignment = ParagraphAlignment.Center;

            // Specify page settings
            richServer.Document.Sections[0].Page.Landscape = true;
            richServer.Document.Sections[0].Page.Height = DevExpress.Office.Utils.Units.InchesToDocumentsF(10.0f);
            richServer.Document.Sections[0].Page.Width = DevExpress.Office.Utils.Units.InchesToDocumentsF(4.5f);

            // Add document content
            richServer.Document.AppendText("This content is created programmatically\n");
            richServer.Document.Paragraphs.Append();

            //Create a table
            richServer.BeginUpdate();

            Table _table = richServer.Document.Tables.Create(richServer.Document.Selection.Start, 8, 8, AutoFitBehaviorType.FixedColumnWidth);
            _table.BeginUpdate();
            _table.Borders.InsideHorizontalBorder.LineThickness = 1;
            _table.Borders.InsideHorizontalBorder.LineStyle = TableBorderLineStyle.Double;
            _table.Borders.InsideVerticalBorder.LineThickness = 1;
            _table.Borders.InsideVerticalBorder.LineStyle = TableBorderLineStyle.Double;
            _table.TableAlignment = TableRowAlignment.Center;

            _table.ForEachCell((cell, rowIndex, columnIndex) =>
            {
                richServer.Document.InsertText(cell.Range.Start, String.Format("{0}*{1} is {2}",
                    rowIndex + 2, columnIndex + 2, (rowIndex + 2) * (columnIndex + 2)));
            });
            _table.EndUpdate();

            richServer.EndUpdate();

            // Invoke the Print Preview dialog
            using (PrintingSystem printingSystem = new PrintingSystem())
            {
                using (PrintableComponentLink link = new PrintableComponentLink(printingSystem))
                {
                    link.Component = richServer;
                    link.CreateDocument();
                    link.ShowPreviewDialog();
                }
            }
            #endregion #serverprint
        }
    }
}