using System.Collections.Generic;

namespace dev7.EMS.Model.Address
{
    public class AddressesMD : ModelBase
    {
        public AddressesMD()
        {
            addresses = new List<AddressMD>();
        }
        public List<AddressMD> addresses { get; set; }
    }
}
 