using System.Data;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using ClosedXML.Excel;

namespace UtilityCore.Utility.Mail
{
    public static class EmailOperation
    {
        public static void SendEmailWithErrorLog(string host, string subject, string recipients, string sender, string path, string fileName)
        {
            string body = "Error log file in attachment.";

            SmtpClient smtp = new SmtpClient(host);
            MailMessage mailMessage = new MailMessage();
            var recipientArray = recipients.Split(";").Where(e => !string.IsNullOrWhiteSpace(e));
            foreach (string email in recipientArray)
            {
                mailMessage.To.Add(new MailAddress(email));
            }
            mailMessage.From = new MailAddress(sender);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            //add attachment
            ContentType contentType = new ContentType();
            contentType.MediaType = MediaTypeNames.Application.Octet;
            contentType.Name = fileName;
            mailMessage.Attachments.Add(new Attachment(path, contentType));

            smtp.Send(mailMessage);
        }

        public static void SendEmailWithHtml(string host, string subject, string recipients, string body, string environment, Attachment? attachment)
        {
            if (string.IsNullOrWhiteSpace(environment))
            {
                throw new Exception("Invalid environment provided");
            }
            var formattedEnvName = char.ToUpper(environment[0]) + environment.Substring(1).ToLower();
            var sender = $"FIESTA-{formattedEnvName}-NoReply@lm.renesas.com";
            if (environment == "PRD")
            {
                sender = "FIESTA-NoReply@lm.renesas.com";
            }

            SmtpClient smtp = new SmtpClient(host);
            MailMessage mailMessage = new MailMessage();
            var recipientArray = recipients.Split(";").Where(e => !string.IsNullOrWhiteSpace(e));
            foreach (string email in recipientArray)
            {
                mailMessage.To.Add(new MailAddress(email));
            }
            mailMessage.From = new MailAddress(sender);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.IsBodyHtml = true;

            if (attachment != null)
            {
                mailMessage.Attachments.Add(attachment);
            }

            smtp.Send(mailMessage);
        }

        public static string CompileNotificationEmail(string title, string body, string? link)
        {
            string templateFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "NotificationEmail.html");
            string emailContent = File.ReadAllText(templateFilePath);
            emailContent = emailContent.Replace("{title}", title);
            emailContent = emailContent.Replace("{information}", body);
            emailContent = emailContent.Replace("{table}", "");
            emailContent = emailContent.Replace("{link}", link);
            emailContent = string.IsNullOrEmpty(link)
                ? emailContent.Replace("{styleurllnk}", "display:none")
                : emailContent.Replace("{styleurllnk}", "display:block");

            return emailContent;
        }

        public static string CompileNotificationEmail(string title, string body, string? link, DataTable table)
        {
            var htmlTable = new StringBuilder();
            htmlTable.Append("<table  border=");
            htmlTable.Append(string.Format("\"{0}\"", "1"));
            htmlTable.Append(" ");
            htmlTable.Append("cellspacing = ");
            htmlTable.Append(string.Format("\"{0}\"", "0"));
            htmlTable.Append(" ");
            htmlTable.Append("cellpadding = ");
            htmlTable.Append(string.Format("\"{0}\"", "0"));
            htmlTable.Append(" ");
            htmlTable.Append("style =");
            htmlTable.Append(string.Format("\"{0}\"", "font-family:sans-serif;font-size:12px; border-radius:2px; width:100%;"));
            htmlTable.Append("><thead><tr style=");
            htmlTable.Append(string.Format("\"{0}\"", "font-weight:bold"));
            htmlTable.Append(">");

            foreach (DataColumn col in table.Columns)
            {
                htmlTable.Append("<td>" + col.ColumnName + "</td>");
            }

            htmlTable.Append("</tr></thead>");

            foreach (DataRow row in table.Rows)
            {
                htmlTable.Append("<tr>");
                foreach (DataColumn column in table.Columns)
                {
                    htmlTable.Append("<td>");
                    htmlTable.Append(row[column.ColumnName]);
                    htmlTable.Append("</td>");
                }
                htmlTable.Append("</tr>");
            }

            htmlTable.Append("</table>");

            string templateFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "NotificationEmail.html");
            string emailContent = File.ReadAllText(templateFilePath);
            emailContent = emailContent.Replace("{title}", title);
            emailContent = emailContent.Replace("{information}", body);
            emailContent = emailContent.Replace("{table}", htmlTable.ToString());
            emailContent = emailContent.Replace("{link}", link);
            emailContent = string.IsNullOrEmpty(link)
                ? emailContent.Replace("{styleurllnk}", "display:none")
                : emailContent.Replace("{styleurllnk}", "display:block");

            return emailContent;
        }

        public static Attachment DataTableToExcelMailAttachment(DataTable dataTable, string attachmentFileName)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.AddWorksheet();

            // header
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                var headerCell = worksheet.Cell(1, i + 1);
                headerCell.Value = dataTable.Columns[i].ColumnName;
                headerCell.Style.Font.Bold = true;
                headerCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }

            // data
            worksheet.Cell(2, 1).InsertData(dataTable);

            worksheet.SheetView.FreezeRows(1);
            worksheet.Columns().AdjustToContents();

            var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Seek(0, SeekOrigin.Begin);
            return new Attachment(stream, attachmentFileName, MediaTypeNames.Application.Octet);
        }
    }
}
