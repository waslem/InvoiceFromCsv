using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace csvToInvoice
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.TextReader readFile = new StreamReader("C:\\Users\\jamie.vanwalsum.BCS\\Source\\Repos\\InvoiceFromCsv\\data folder\\datafile04092014.csv");
            CsvReader reader = new CsvReader(readFile);

            var records = reader.GetRecords<Invoice>().ToList();

            foreach (var rec in records)
            {
                string account = "Account:" + rec.InvoiceId;
                string amount = "Amount: $" + rec.InvoiceAmount;
                string name = "Account name: " + rec.InvoiceName;

                string filename = rec.InvoiceId + ".pdf";

                string path = Path.Combine("X:\\Invoices\\", filename);

                FileStream fs = new FileStream(path, FileMode.Create);

                Document document = new Document(PageSize.A4, 10, 10, 90, 10);
                PdfWriter.GetInstance(document, fs);

                document.AddAuthor("Jamie van Walsum");
                document.AddSubject("Testing 123");
                document.Open();

                document.Add(new Paragraph(account));
                document.Add(new Paragraph(amount));
                document.Add(new Paragraph(name));

                document.CloseDocument();
                

            }

            Console.WriteLine();
        }
    }

    public class Invoice
    {
        public string InvoiceId { get; set; }
        public string InvoiceAmount { get; set; }
        public string InvoiceName { get; set; }
    }
}
