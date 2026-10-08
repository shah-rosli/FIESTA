using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UtilityCore.Models;

namespace UtilityCore.Utility.Mail
{
    public class EmailService : IEmailService
    {
        private readonly string _host;
        private readonly string _sender;
        private readonly string _additionalRecipients;

        public EmailService(string host)
        {
            _host = host;
        }

        public EmailService(string host, string sender, string additionalReceipients)
        {
            _host = host;
            _sender = sender;
            _additionalRecipients = additionalReceipients;
        }

        public void SendEmail(EmailDto request)
        {
            SmtpClient smtp = new SmtpClient();
            MailMessage message = new MailMessage()
            {
                Subject = request.Subject,
                Body = request.Body,
                From = new MailAddress(request.From)
            };

            foreach(string mail in request.To)
            {
                message.To.Add(new MailAddress(mail));
            }
            foreach (string mail in request.Cc)
            {
                message.CC.Add(new MailAddress(mail));
            }
            foreach (string mail in request.Bcc)
            {
                message.Bcc.Add(new MailAddress(mail));
            }

            string host = _host;

            if (host.ToLower().Contains("-dev") || host.ToLower().Contains("localhost") || host.ToLower().Contains("-qa"))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("<br>Original To : {0}", request.To);
                sb.AppendFormat("<br>Original CC : {0}", request.Cc);
                sb.AppendFormat("<br>Original BCC : {0}", request.Bcc);

                if (host.ToLower().Contains("-dev") || host.ToLower().Contains("localhost"))
                    request.Subject = string.Format("Development : {0}", request.Subject);
                else if (host.ToLower().Contains("-qa"))
                    request.Subject = string.Format("QA : {0}", request.Subject);

                request.Body = string.Format("{0}{1}", request.Body, sb.ToString());

                message.To.Clear();
                message.CC.Clear();
                message.Bcc.Clear();

                message.From = new MailAddress(_sender);
                message.To.Add(_additionalRecipients);

            }

            try
            {
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        public void SendEmail(MailMessage message)
        {
            SmtpClient smtp = new SmtpClient(_host);

            string host = _host;

            if (host.ToLower().Contains("-dev") || host.ToLower().Contains("localhost") || host.ToLower().Contains("-qa"))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("<br>Original To : {0}", message.To);
                sb.AppendFormat("<br>Original CC : {0}", message.CC);
                sb.AppendFormat("<br>Original BCC : {0}", message.Bcc);

                if (host.ToLower().Contains("-dev") || host.ToLower().Contains("localhost"))
                    message.Subject = string.Format("Development : {0}", message.Subject);
                else if (host.ToLower().Contains("-qa"))
                    message.Subject = string.Format("QA : {0}", message.Subject);

                message.Body = string.Format("{0}{1}", message.Body, sb.ToString());

                message.To.Clear();
                message.CC.Clear();
                message.Bcc.Clear();

                message.From = new MailAddress(_sender);
                message.To.Add(_additionalRecipients);

            }

            try
            {
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                //add logging

                throw ex;
            }
            finally
            {
            }
        }
    }
}
