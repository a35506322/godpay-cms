using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Entity
{
    public class CMS_Logs
    {
        public string Level { get; set; } = string.Empty;
        public DateTime? TimeStamp { get; set; }
        public string Exception { get; set; } = string.Empty;
        public string Account { get; set; } = string.Empty;
        public string RequestMethod { get; set; } = string.Empty;
        public string EndpointName { get; set; } = string.Empty;
        public string StatusCode { get; set; } = string.Empty;
        public string RequestPath { get; set; } = string.Empty;
        public string RequestHeader { get; set; } = string.Empty;
        public string QueryString { get; set; } = string.Empty;
        public string Host { get; set; } = string.Empty;
        public string Protocol { get; set; } = string.Empty;
        public string Scheme { get; set; } = string.Empty;
        public string RequestBody { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public string ResponseBody { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Data { get; set; } = string.Empty;
    }
}
