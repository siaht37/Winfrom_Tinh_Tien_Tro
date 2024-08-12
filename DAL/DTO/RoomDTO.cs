using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RoomDTO
{
    public int RoomID { get; set; }
    public string RoomNumber { get; set; }
    public decimal RoomPrice { get; set; }
    public int? TenantID { get; set; }
}