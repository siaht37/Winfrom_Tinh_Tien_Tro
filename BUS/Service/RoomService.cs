using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class RoomService
{
    private readonly DBContext _context;

    public RoomService(DBContext context)
    {
        _context = context;
    }

    public RoomDTO GetById(int id)
    {
        // Lấy dữ liệu từ cơ sở dữ liệu
        var room = _context.Rooms.Find(id);
        // Chuyển đổi dữ liệu sau khi truy xuất
        return room == null ? null : ConvertToDTO(room);
    }

    public IEnumerable<RoomDTO> GetAll()
    {
        // Lấy dữ liệu từ cơ sở dữ liệu
        var rooms = _context.Rooms.ToList();
        // Chuyển đổi dữ liệu sau khi truy xuất
        return rooms.Select(room => ConvertToDTO(room)).ToList();
    }

    public void Update(RoomDTO roomDTO)
    {
        var existingRoom = _context.Rooms.Find(roomDTO.RoomID);
        if (existingRoom != null)
        {
            existingRoom.RoomNumber = roomDTO.RoomNumber;
            existingRoom.RoomPrice = roomDTO.RoomPrice;
            existingRoom.TenantID = roomDTO.TenantID;
            _context.SaveChanges();
        }
    }

    private RoomDTO ConvertToDTO(Room room)
    {
        return new RoomDTO
        {
            RoomID = room.RoomID,
            RoomNumber = room.RoomNumber,
            RoomPrice = room.RoomPrice,
            TenantID = room.TenantID
        };
    }
}