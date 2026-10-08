using FIESTA_Backend.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using UtilityCore.Utility.Mail;

namespace FIESTA_Backend.Controllers
{
    [ApiController]
    public class EmailController : ControllerBase
    {

        private IConfiguration _config;
        private HttpContext _httpContext;
        private EnvironmentProperties _envProperties;
        public EmailController(IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
            _envProperties = new EnvironmentProperties(_config, _httpContext);
        }

        // POST: api/Email
        [Route("api/email/{emailfrom}/{emailto}")]
        [HttpPost]
        public ActionResult Post(string emailfrom, string emailto)
        {
            try
            {
                MailMessage msg = GetMailMessage();
                msg.To.Add(new MailAddress(emailto));
                msg.From = new MailAddress(emailfrom);
                msg.CC.Add("kian-ann.puen.cj@renesas.com");
                msg.Subject = "Test Email from BPMS Upgrade";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment("C:\\Temp\\web\\R14Upload\\fakeERPNumber\\SYS_PersonImportTemplate (1).csv");
                msg.Attachments.Add(attachment);

                EmailService emailService = new EmailService(_config.GetSection("SmtpServer").Value,
                                                         _envProperties.SENDER_EMAIL(),
                                                         _envProperties.ADDITIONAL_RECIPIENT_EMAIL());

                emailService.SendEmail(msg);
                //SendEmail(msg);
                //SmtpConnection.send
                return Ok("Email sent successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private MailMessage GetMailMessage()
        {
            MailMessage msg = new MailMessage();

            msg.Subject = "GPR Email";
            msg.IsBodyHtml = true;
            msg.Body = "GPR is sent successfully";

            return msg;
        }

        private void SendEmail(MailMessage msg)
        {
            EmailService emailService = new EmailService(_config.GetSection("SmtpServer").Value,
                                                         _envProperties.SENDER_EMAIL(),
                                                         _envProperties.ADDITIONAL_RECIPIENT_EMAIL());
            try
            {

                emailService.SendEmail(msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        // PUT: api/Email/5
        [Route("api/email")]
        [HttpPut]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Email/5
        [Route("api/email")]
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
