using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InvoiceDTO
{
    public int InvoiceID { get; set; }
    public int RoomID { get; set; }
    public DateTime Month { get; set; }
    public decimal ElectricityCharge { get; set; }
    public decimal WaterCharge { get; set; }
    public decimal RoomCharge { get; set; }
    public decimal TotalAmount { get; set; }
    public bool? Status { get; set; }
}
