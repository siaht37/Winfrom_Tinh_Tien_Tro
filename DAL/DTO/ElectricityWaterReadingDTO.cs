using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ElectricityWaterReadingDTO
{
    public int ReadingID { get; set; }
    public int RoomID { get; set; }
    public DateTime Month { get; set; }
    public int ElectricityUsage { get; set; }
    public int WaterUsage { get; set; }
    public decimal ElectricityUnitPrice { get; set; }
    public decimal WaterUnitPrice { get; set; }
}
