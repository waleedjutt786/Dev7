using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Model
{
    public class EmailModel
    {
        public EmailModel()
        {
            SentDate = DateTime.UtcNow;
            To = string.Empty;
            CC = string.Empty;
        }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        // ReSharper disable once InconsistentNaming
        public string CC { get; set; }
        public DateTime SentDate { get; set; }
        public string MessageType { get; set; }
    }
}
