using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ElectricityWaterReadingService
{
    private readonly DBContext _context;

    public ElectricityWaterReadingService(DBContext context)
    {
        _context = context;
    }

    public ElectricityWaterReadingDTO GetById(int id)
    {
        var reading = _context.ElectricityWaterReadings.Find(id);
        return reading == null ? null : ConvertToDTO(reading);
    }

    public IEnumerable<ElectricityWaterReadingDTO> GetAll()
    {
        var readings = _context.ElectricityWaterReadings.ToList();
        return readings.Select(reading => ConvertToDTO(reading)).ToList();
    }

    public void Add(ElectricityWaterReadingDTO readingDTO)
    {
        var reading = new ElectricityWaterReading
        {
            RoomID = readingDTO.RoomID,
            Month = readingDTO.Month,
            ElectricityUsage = readingDTO.ElectricityUsage,
            WaterUsage = readingDTO.WaterUsage,
            ElectricityUnitPrice = readingDTO.ElectricityUnitPrice,
            WaterUnitPrice = readingDTO.WaterUnitPrice
        };

        _context.ElectricityWaterReadings.Add(reading);
        _context.SaveChanges();
    }

    public void Update(ElectricityWaterReadingDTO readingDTO)
    {
        var existingReading = _context.ElectricityWaterReadings.Find(readingDTO.ReadingID);
        if (existingReading != null)
        {
            existingReading.RoomID = readingDTO.RoomID;
            existingReading.Month = readingDTO.Month;
            existingReading.ElectricityUsage = readingDTO.ElectricityUsage;
            existingReading.WaterUsage = readingDTO.WaterUsage;
            existingReading.ElectricityUnitPrice = readingDTO.ElectricityUnitPrice;
            existingReading.WaterUnitPrice = readingDTO.WaterUnitPrice;
            _context.SaveChanges();
        }
    }

    private ElectricityWaterReadingDTO ConvertToDTO(ElectricityWaterReading reading)
    {
        return new ElectricityWaterReadingDTO
        {
            ReadingID = reading.ReadingID,
            RoomID = reading.RoomID,
            Month = reading.Month,
            ElectricityUsage = reading.ElectricityUsage,
            WaterUsage = reading.WaterUsage,
            ElectricityUnitPrice = reading.ElectricityUnitPrice,
            WaterUnitPrice = reading.WaterUnitPrice
        };
    }
}