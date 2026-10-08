namespace FIESTA_Backend.Models.Common
{using FIESTA_Backend.Converters;
using Microsoft.EntityFrameworkCore;

    public class EnvironmentProperties
    {
        private IConfiguration _config;
        private HttpContext _context;
        private string host;
        public EnvironmentProperties(IConfiguration configuration, HttpContext httpContext)
        {
            this._context = httpContext;
            this._config = configuration;
            this.host = _context.Request.Host.ToString();
        }

        public string CONN_STRING()
        {
            if (host.ToLower().Contains("dev") || host.ToLower().Contains("localhost")) {
                var environmentName = Environment.GetEnvironmentVariable("FIESTA_ENVIRONMENT", EnvironmentVariableTarget.Machine);
                return _config.GetConnectionString("ConnectionString_SB_" + environmentName);
            }
            //return _config.GetConnectionString("ConnectionString_SB_DEV");
            else if (host.ToLower().Contains("mdm-dev1."))
                return _config.GetConnectionString("ConnectionString_SB_DEV2");
            else if (host.ToLower().Contains("-qas."))
                return _config.GetConnectionString("ConnectionString_SB_QAS");
            else if (host.ToLower().Contains("-qas2."))
                return _config.GetConnectionString("ConnectionString_SB_QA2");
            else if (host.ToLower().Contains("-qas3."))
                return _config.GetConnectionString("ConnectionString_SB_QA3");
            else if (host.ToLower().Contains("-qas4."))
                return _config.GetConnectionString("ConnectionString_SB_QA4");
            else if (host.ToLower().Contains("-qas5."))
                return _config.GetConnectionString("ConnectionString_SB_QA5");
            else
                return _config.GetConnectionString("ConnectionString_SB_PRD");

        }

        public string SENDER_EMAIL()
        {
            if (host.ToLower().Contains("-dev") || host.ToLower().Contains("localhost"))
                return _config.GetSection("SenderEmail_Dev").Value;
            else if (host.ToLower().Contains("qa"))
                return _config.GetSection("SenderEmail_Qa").Value;
            else
                return _config.GetSection("SenderEmail_Prod").Value;
        }

        public string ADDITIONAL_RECIPIENT_EMAIL()
        {
            if (host.ToLower().Contains("-dev") || host.ToLower().Contains("localhost"))
                return _config.GetSection("AdditionalRecipientEmail_Dev").Value;
            else if (host.ToLower().Contains("qa"))
                return _config.GetSection("AdditionalRecipientEmail_Qa").Value;
            else
                return _config.GetSection("AdditionalRecipientEmail_Prod").Value;
        }
    }
}
