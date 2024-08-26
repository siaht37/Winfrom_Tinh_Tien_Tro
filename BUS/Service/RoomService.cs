using DAL;
using System.Collections.Generic;
using System.Linq;

public class RoomService
{
    private readonly DBContext _context;

    public RoomService(DBContext context)
    {
        _context = context;
    }

    public IEnumerable<RoomDTO> GetAll()
    {
        var rooms = _context.Rooms.ToList();
        return rooms.Select(room => ConvertToDTO(room)).ToList();
    }
    public RoomDTO GetById(int id)
    {
        var room = _context.Rooms.Find(id);
        return room == null ? null : ConvertToDTO(room);
    }

    public void AddRoom(RoomDTO roomDTO)
    {
        var room = new Room
        {
            RoomNumber = roomDTO.RoomNumber,
            RoomPrice = roomDTO.RoomPrice,
            TenantID = roomDTO.TenantID
        };
        _context.Rooms.Add(room);
        _context.SaveChanges();
    }

    public void DeleteRoom(int roomId)
    {
        var room = _context.Rooms.Find(roomId);
        if (room != null)
        {
            _context.Rooms.Remove(room);
            _context.SaveChanges();
        }
    }

    public void UpdateRoom(RoomDTO roomDTO)
    {
        var existingRoom = _context.Rooms.Find(roomDTO.RoomID);
        if (existingRoom != null)
        {
            existingRoom.RoomNumber = roomDTO.RoomNumber;
            existingRoom.RoomPrice = roomDTO.RoomPrice;
            existingRoom.TenantID = roomDTO.TenantID;

            // Đánh dấu đối tượng là "Modified"
            _context.Entry(existingRoom).State = System.Data.Entity.EntityState.Modified;

            _context.SaveChanges();
        }
    }

    public IEnumerable<UserDTO> GetAllTenants()
    {
        return _context.Users.Select(user => new UserDTO
        {
            UserID = user.UserID,
            FullName = user.FullName
        }).ToList();
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
