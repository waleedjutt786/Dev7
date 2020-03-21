//using dev7.EMS.Domain.Entities;
//using dev7.EMS.Domain.Vehicle;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.UI.WebControls;

//namespace dev7.EMS.BT.Domain.Entities
//{
//    [Table("VehicleType")]
//    public class VehicleTypeDE : BaseDomain
//    {
//        public int Id { get; set; }
//        public string Type { get; set; }
//        public string Description { get; set; }

//        [ForeignKey("Company")]
//        public int CompanyId { get; set; }
//        public CompanyDE Company { get; set; }

//        //[ForeignKey("Vehicle")]
//        //public int VehicleId { get; set; }
//        //public VehicleDE Vehicle { get; set; }
//    }
//}
