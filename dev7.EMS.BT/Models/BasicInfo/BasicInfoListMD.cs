using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Model.BasicInfo
{
    public class BasicInfoListMD : ModelBase
    {
        public BasicInfoListMD()
        {
            BasicInfoList = new List<BasicInfoMD>();
        }
        public List<BasicInfoMD> BasicInfoList { get; set; }
    }
}
