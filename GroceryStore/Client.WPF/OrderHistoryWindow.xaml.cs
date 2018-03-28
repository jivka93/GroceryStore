using iTextSharp.text;
using iTextSharp.text.pdf;
using Services.Contacts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Forms = System.Windows.Forms;

namespace Client.WPF
{
    /// <summary>
    /// Interaction logic for OrderHistoryWindow.xaml
    /// </summary>
    public partial class OrderHistoryWindow : Window
    {
        private readonly IOrderService orderServise;
        private readonly IUserContext userContext;
        private readonly IUserService userservice;

        public OrderHistoryWindow(IOrderService orderServise, IUserContext userContext, IUserService userservice)
        {
            InitializeComponent();

            this.orderServise = orderServise;
            this.userContext = userContext;
            this.userservice = userservice;
            Fillinfo();
        }

        private void Fillinfo()
        {
            //var b = orderServise.GetAllById(14);
            this.OrdersContent.ItemsSource = orderServise.GetAllById(this.userContext.LoggedUserId.Value);
        }

        private void GeneratePdf_Click(object sender, RoutedEventArgs e)
        {
            Forms.FolderBrowserDialog folderDialog = new Forms.FolderBrowserDialog();
            string hi = "";
            if (folderDialog.ShowDialog() == Forms.DialogResult.OK)
            {
                hi = folderDialog.SelectedPath.Replace("\\", "/") + "/Test.pdf";
                MessageBox.Show(hi);

                //Doc Setup
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                PdfWriter writter = PdfWriter.GetInstance(doc, new FileStream(hi, FileMode.Create));
                var order = orderServise.GetAllById((int)userContext.LoggedUserId);
                doc.Open();

                //Editting Doc
                foreach (var item in order)
                {
                    iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph($"Customer ID:{userContext.LoggedUserId}" + "   " + $"OrderId:{item.Id}" +"   " + $"OrderedTime:{item.Date}");
                    doc.Add(paragraph);

                    doc.Add(new Chunk("\n"));
                    doc.Add(new Chunk("\n"));

                    PdfPTable table = new PdfPTable(3);
                    table.AddCell("ProductID");
                    table.AddCell("ProductName");
                    table.AddCell("ProdutPrice");
                    foreach (var product in item.Products)
                    {
                        table.AddCell($"{product.Id}");
                        table.AddCell($"{product.Name}");
                        table.AddCell($"{product.Price}");
                    }
                    doc.Add(table);
                    doc.NewPage();
                }

                doc.Close();
            }
        }
    }
}