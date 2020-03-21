using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Domain.ResultMessages
{
    public class ResultMessage
    {
        [Key]
        public int Id { get; set; }
        public string MessageType { get; set; }

        public string Message { get; set; }
    }
}
