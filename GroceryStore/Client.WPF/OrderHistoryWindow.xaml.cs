using iTextSharp.text;
using iTextSharp.text.pdf;
using Services.Contacts;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Web.UI;
using iTextSharp.text.html.simpleparser;
using System.Web;

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
            var orders = orderServise.GetAllById(this.userContext.LoggedUserId.Value);


            Forms.FolderBrowserDialog folderDialog = new Forms.FolderBrowserDialog();
            string hi = "";
            if (folderDialog.ShowDialog() == Forms.DialogResult.OK)
            {
                hi = folderDialog.SelectedPath.Replace("\\", "/") + "/Test.pdf";
                MessageBox.Show(hi);

                //Doc Setup
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                PdfWriter writter = PdfWriter.GetInstance(doc, new FileStream(hi, FileMode.Create));
                doc.Open();

                //Editting Doc
                foreach (var order in orders)
                {
                    string companyName = "The Serious Crocodiles";
                    int orderNo = order.Id;
                    DataTable dt = new DataTable();
                    dt.Columns.AddRange(new DataColumn[3] {
                            new DataColumn("ProductId", typeof(string)),
                            new DataColumn("Product", typeof(string)),
                            new DataColumn("Price", typeof(int))
                            });
                    foreach (var product in order.Products)
                    {
                        dt.Rows.Add(product.Id, product.Name, product.Price);
                    }
                    using (StringWriter sw = new StringWriter())
                    {
                        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                        {
                            StringBuilder sb = new StringBuilder();

                            //Generate Invoice (Bill) Header.
                            sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                            sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Order Sheet</b></td></tr>");
                            sb.Append("<tr><td colspan = '2'></td></tr>");
                            sb.Append("<tr><td><b>Order No: </b>");
                            sb.Append(orderNo);
                            sb.Append("</td><td align = 'right'><b>Date: </b>");
                            sb.Append(DateTime.Now);
                            sb.Append(" </td></tr>");
                            sb.Append("<tr><td colspan = '2'><b>Company Name: </b>");
                            sb.Append(companyName);
                            sb.Append("</td></tr>");
                            sb.Append("</table>");
                            sb.Append("<br />");

                            //Generate Invoice (Bill) Items Grid.
                            sb.Append("<table border = '1'>");
                            sb.Append("<tr>");
                            foreach (DataColumn column in dt.Columns)
                            {
                                sb.Append("<th style = 'background-color: #D20B0C;color:#ffffff'>");
                                sb.Append(column.ColumnName);
                                sb.Append("</th>");
                            }
                            sb.Append("</tr>");
                            foreach (DataRow row in dt.Rows)
                            {
                                sb.Append("<tr>");
                                foreach (DataColumn column in dt.Columns)
                                {
                                    sb.Append("<td>");
                                    sb.Append(row[column]);
                                    sb.Append("</td>");
                                }
                                sb.Append("</tr>");
                            }
                            sb.Append("<tr><td align = 'right' colspan = '");
                            sb.Append(dt.Columns.Count - 1);
                            sb.Append("'>Total</td>");
                            sb.Append("<td>");
                            sb.Append(dt.Compute("sum(Total)", ""));
                            sb.Append("</td>");
                            sb.Append("</tr></table>");

                            //Export HTML String as PDF.
                            StringReader sr = new StringReader(sb.ToString());
                            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);
                            pdfDoc.Open();
                            htmlparser.Parse(sr);
                            pdfDoc.Close();
                            System.Web.HttpContext.Current.Response.ContentType = "application/pdf";
                            System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=Invoice_" + orderNo + ".pdf");
                            System.Web.HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            System.Web.HttpContext.Current.Response.Write(pdfDoc);
                            System.Web.HttpContext.Current.Response.End();
                        }


                        doc.Close();
                    }
                }
            }
        }
    }
}