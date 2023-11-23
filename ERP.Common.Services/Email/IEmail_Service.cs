using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ERP.Common.Services
{
    public interface IEmail_Service
    {
        Task SendEmailAsync(string to, string subject, string body, bool isHtml = false);
        Task SendBulkEmailAsync(List<string> toList, string subject, string content, bool isHtml = true);
    }
}
