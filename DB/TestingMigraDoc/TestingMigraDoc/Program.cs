using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingMigraDoc
{
    class Program
    {
        static string[,] data = new string[,]
        {
            { "1", "Name 1", "Description 1"},
            { "2", "Name 2", "Description 2"},
            { "3", "Name 3", "Description 3"},
            { "4", "Name 4", "Description 4"},
            { "5", "Name 5", "Description 5"},
        };

        static void Main(string[] args)
        {
            var document = new Document();

            var section = document.AddSection();

            var table = section.AddTable();
            table.Borders.Width = 1;

            for (int col = 0; col < 5; col++)
            {
                var column = table.AddColumn();
            }

            var newRow = table.AddRow();
            newRow.HeadingFormat = true;
            newRow.Format.Alignment = ParagraphAlignment.Center;
            newRow.Format.Font.Bold = true;
            newRow.Cells[0].AddParagraph("One cell");
            newRow.Cells[0].MergeRight = 2;
            newRow = table.AddRow();
            newRow.HeadingFormat = true;
            newRow.Format.Alignment = ParagraphAlignment.Center;
            newRow.Format.Font.Bold = true;

            for (int col = 0; col < data.GetLength(1); col++)
            {
                newRow.Cells[col].AddParagraph(data[0, col]);
                newRow.Cells[col].Format.Font.Bold = false;
                newRow.Cells[col].Format.Alignment = ParagraphAlignment.Left;
                newRow.Cells[col].VerticalAlignment = VerticalAlignment.Bottom;
            }

            for (int row = 1; row < data.GetLength(0); row++)
            {
                newRow = table.AddRow();

                for (int col = 0; col < data.GetLength(1); col++)
                {
                    newRow.Cells[col].AddParagraph(data[row, col]);
                }
            }

            var pdfRenderer = new PdfDocumentRenderer(true);
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();
            pdfRenderer.Save("Test.pdf");
        }
    }
}
