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
            // read the csv file
            System.IO.TextReader readFile = new StreamReader("C:\\Users\\jamie.vanwalsum.BCS\\Source\\Repos\\InvoiceFromCsv\\data folder\\datafile04092014.csv");
            CsvReader reader = new CsvReader(readFile);

            // convert each line in the csv into a list of invoice objects
            var invoices = reader.GetRecords<Invoice>().ToList();

            // loop through each invoice
            foreach (var inv in invoices)
            {
                string account = "Account: " + inv.InvoiceId;
                string amount = "Amount: " + inv.InvoiceAmount;
                string name = "Account name: " + inv.InvoiceName;

                // create the new pdf filename, use the invoice id as the unique identifer
                string filename = inv.InvoiceId + ".pdf";

                // specify the output path
                string path = Path.Combine("X:\\Invoices\\", filename);

                // create a new filestream using the path
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
