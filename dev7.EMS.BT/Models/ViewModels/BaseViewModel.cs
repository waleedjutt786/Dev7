using dev7.EMS.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Model.ViewModels
{
    public class BaseViewModel : ModelBase
    {
    }

    public class BasePageableViewModel : ModelBase
    {
        public BasePageableViewModel()
        {
            PaginatedResult = new PaginatedResultModel();
        }

        public PaginatedResultModel PaginatedResult { get; set; }
    }
}
