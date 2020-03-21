using dev7.EMS.BT.Domain;
using dev7.EMS.BT.Utilities;
using dev7.EMS.Domain.Entities;
using dev7.EMS.Domain.VendorType;
using dev7.EMS.PT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dev7.EMS.Domain.Vendor
{
    [Table("Vendor")]
    public class VendorDE : BaseDomain
    {
        [Key, ForeignKey("ApplicationUser")]
        public virtual int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Image { get; set; }
        public DateTime DateOfJoin { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("VendorType")]
        public int VendorTypeId { get; set; }
        public  VendorTypeDE VendorType { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public CompanyDE Company { get; set; }

        //public ICollection<BeverageDE> BeverageDE { get; set; }
        //public ICollection<ChillerDE> ChillerDE { get; set; }
        //public ICollection<DecorDE> DecorDE { get; set; }
        //public ICollection<FlowerDecorDE> FlowerDecorDE { get; set; }
        //public ICollection<GeneratorDE> GeneratorDE { get; set; }
        //public ICollection<HeaterDE> HeaterDE { get; set; }
        //public ICollection<LightDecorDE> LightDecorDE { get; set; }
        //public ICollection<SoundSystemDE> SoundSystemDE { get; set; }
        //public ICollection<WoodenFloorDE> WoodenFloorDE { get; set; }
    }
}