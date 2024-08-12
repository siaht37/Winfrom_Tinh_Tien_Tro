namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ElectricityWaterReading
    {
        [Key]
        public int ReadingID { get; set; }

        public int RoomID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Month { get; set; }

        public int ElectricityUsage { get; set; }

        public int WaterUsage { get; set; }

        public decimal ElectricityUnitPrice { get; set; }

        public decimal WaterUnitPrice { get; set; }

        public virtual Room Room { get; set; }
    }
}
