using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Reporting.WebForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Data;
using WebApplication1.DTOs.Info;
using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class InfoesController : Controller
    {
        private TravelTourDBContext db = new TravelTourDBContext();
        private readonly IEmployeeRepository _employeeRepository;
        
        public InfoesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [Route("Infoes")]
        // GET: Infoes
        public async Task<ActionResult> Index()
        {
            var info = await _employeeRepository.GetAllInfoesAsync();

            return View(info);
        }

        public async Task<JsonResult> GetAllInfo()
        {
            List<Info> info =await db.Infos.ToListAsync();

            var json = JsonConvert.SerializeObject(info);

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public FileResult DownloadPDFReport()
        {
            string pdfFileName = "myInfo" + DateTime.Now + ".pdf";
            List<Info> info =  db.Infos.ToList();

            LocalReport localReport = new LocalReport();
            localReport.DataSources.Clear();
            localReport.DataSources.Add(new ReportDataSource("dsData", info));
            localReport.ReportPath = Server.MapPath("~/Reports/ListOfInfo.rdlc");

            byte[] bytes = localReport.Render("PDF");

            return File(bytes, "application/pdf", pdfFileName);
        }

        public FileResult DownloadExcelReport()
        {
            List<Info> info = db.Infos.ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("FatherName", typeof(string));

            foreach(var item in info)
            {
                DataRow row = dt.NewRow();
                row["Id"] = item.Id;
                row["Name"] = item.Name;
                row["FatherName"] = item.FatherName;

                dt.Rows.Add(row);
            }

            string FileName = "myInfoReport" + DateTime.Now.ToShortDateString();
            dt.TableName = "Info_Sheet"; // DataTable dt = new DataTable("Info_Sheet");
            using (XLWorkbook workbook = new XLWorkbook())
            {
                workbook.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    //https://stackoverflow.com/questions/4212861/what-is-a-correct-mime-type-for-docx-pptx-etc
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", FileName + ".xlsx");
                }
            }
        }

        public ActionResult SendEmail()
        {
            string pdfFileName = "myInfo" + DateTime.Now + ".pdf";
            List<Info> info = db.Infos.ToList();

            LocalReport localReport = new LocalReport();
            localReport.DataSources.Clear();
            localReport.DataSources.Add(new ReportDataSource("dsData", info));
            localReport.ReportPath = Server.MapPath("~/Reports/ListOfInfo.rdlc");

            byte[] bytes = localReport.Render("PDF");
            MemoryStream stream = new MemoryStream(bytes);
            stream.Seek(0, SeekOrigin.Begin);

            MailMessage message = new MailMessage("scm.kyawzayarwin@gmail.com","kyawzayarwin.ucst@gmail.com");
            Attachment attachment = new Attachment(stream, pdfFileName);

            message.Attachments.Add(attachment);
            //message.From = new MailAddress("scm.kyawzayarwin@gmail.com");
            //message.To.Add(new MailAddress("kyawzayarwin.ucst@gmail.com"));
            //if(message.CC != null)
            //{
            //    message.CC.Add(new MailAddress("kyawzayarwin.ucst@gmail.com"));
            //}
            //if (message.Bcc != null)
            //{
            //    message.Bcc.Add(new MailAddress("kyawzayarwin.ucst@gmail.com"));
            //}
            message.Subject = "Info Report";
            message.IsBodyHtml = true;
            message.BodyEncoding = Encoding.UTF8;
            message.Body = "Please find attached the Info Report";

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("scm.kyawzayarwin@gmail.com", "kawgebedyrkybib");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            //smtpClient.Host = "smtp.gmail.com";
            //smtpClient.Port = 587;
            try
            {
                smtpClient.Send(message);
            } catch(SmtpException ex)
            {
                throw ex;
            }
            smtpClient.Dispose();

            return RedirectToAction("DropDownListIndex", "Student");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Info info)
        {
            if(ModelState.IsValid)
            {
               bool infos = await _employeeRepository.AddInfoAsync(info);
               if(infos)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public FileResult PDF()
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                var image = iTextSharp.text.Image.GetInstance(Server.MapPath("~/ClientSideLibraries/images/laravel-featured.png"));
                image.Alignment = Element.ALIGN_CENTER;
                image.ScaleAbsolute(300f, 150f);
                
                document.Add(image);

                Paragraph para1 = new Paragraph("This is the First Paragraph", new Font(Font.FontFamily.HELVETICA, 20));
                para1.Alignment = Element.ALIGN_CENTER;
                para1.SpacingAfter = 10;
                document.Add(para1);

                Paragraph para2 = new Paragraph("This is the Second Paragraph", new Font(Font.FontFamily.HELVETICA, 15));
                para2.Alignment = Element.ALIGN_CENTER;
                document.Add(para2);

                Paragraph para3 = new Paragraph("This is the Third Paragraph", new Font(Font.FontFamily.HELVETICA, 10));
                para3.Alignment = Element.ALIGN_CENTER;
                para3.SetLeading(0.0f, 2.0f); //line spacing before
                document.Add(para3);
                document.Add(Chunk.NEWLINE);

                PdfPTable table = new PdfPTable(4);
                PdfPCell cell1 = new PdfPCell(new Phrase("Date", new Font(Font.FontFamily.HELVETICA, 10)));
                cell1.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell1.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                cell1.BorderWidthBottom = 1f;
                cell1.BorderWidthTop = 1f;
                cell1.BorderWidthLeft = 1f;
                cell1.BorderWidthRight = 1f;
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                cell1.VerticalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell1);

                PdfPCell cell2 = new PdfPCell(new Phrase("Name", new Font(Font.FontFamily.HELVETICA, 10)));
                cell2.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell2.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                cell2.BorderWidthBottom = 1f;
                cell2.BorderWidthTop = 1f;
                cell2.BorderWidthLeft = 1f;
                cell2.BorderWidthRight = 1f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell2);

                PdfPCell cell3 = new PdfPCell(new Phrase("Surname", new Font(Font.FontFamily.HELVETICA, 10)));
                cell3.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell3.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                cell3.BorderWidthBottom = 1f;
                cell3.BorderWidthTop = 1f;
                cell3.BorderWidthLeft = 1f;
                cell3.BorderWidthRight = 1f;
                cell3.HorizontalAlignment = Element.ALIGN_CENTER;
                cell3.VerticalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell3);

                PdfPCell cell4 = new PdfPCell(new Phrase("Address", new Font(Font.FontFamily.HELVETICA, 10)));
                cell4.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell4.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                cell4.BorderWidthBottom = 1f;
                cell4.BorderWidthTop = 1f;
                cell4.BorderWidthLeft = 1f;
                cell4.BorderWidthRight = 1f;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.VerticalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell4);

                for(int i=0; i<100; i++)
                {
                    PdfPCell cell_1 = new PdfPCell(new Phrase(i.ToString()));
                    PdfPCell cell_2 = new PdfPCell(new Phrase((i+1).ToString()));
                    PdfPCell cell_3 = new PdfPCell(new Phrase((i+2).ToString()));
                    PdfPCell cell_4 = new PdfPCell(new Phrase((i+3).ToString()));

                    cell_1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell_2.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell_3.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell_4.HorizontalAlignment = Element.ALIGN_CENTER;

                    table.AddCell(cell_1);
                    table.AddCell(cell_2);
                    table.AddCell(cell_3);
                    table.AddCell(cell_4);
                }

                document.Add(table);
                document.Close();
                writer.Close();

                var constant = memoryStream.ToArray();

                return File(constant, "application/vnd", "FirstPdf.pdf");
            }
        }

        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Info info = db.Infos.Find(id);
            if(info == null)
            {
                return HttpNotFound();
            }
            return View(info);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Info info)
        {
            if(ModelState.IsValid)
            {
                bool res = await _employeeRepository.UpdateInfoByIdAsync(info);
                if (res)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }
    }
}