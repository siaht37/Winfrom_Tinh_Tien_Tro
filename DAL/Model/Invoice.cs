namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Invoice
    {
        public int InvoiceID { get; set; }

        public int RoomID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Month { get; set; }

        public decimal ElectricityCharge { get; set; }

        public decimal WaterCharge { get; set; }

        public decimal RoomCharge { get; set; }

        public decimal TotalAmount { get; set; }

        public bool? Status { get; set; }

        public virtual Room Room { get; set; }
    }
}
