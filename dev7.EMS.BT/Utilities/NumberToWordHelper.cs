using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Framework
{
    public class Words
    {
        public Words(decimal num)
        {
            Number = num;
        }
        public decimal Number { get; set; }
        public string EnglishWord { get; set; }
        public string ArabicWord { get; set; }
    }
}
