using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityCore.Models;

namespace UtilityCore.Utility.Mail
{
    internal interface IEmailService
    {
        public void SendEmail(EmailDto request);
    }
}
