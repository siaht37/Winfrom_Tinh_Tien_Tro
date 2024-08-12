using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UserService
{
    private readonly DBContext _context;

    public UserService(DBContext context)
    {
        _context = context;
    }

    public UserDTO GetById(int id)
    {
        // Lấy dữ liệu từ cơ sở dữ liệu
        var user = _context.Users.Find(id);
        // Chuyển đổi dữ liệu sau khi truy xuất
        return user == null ? null : ConvertToDTO(user);
    }

    public IEnumerable<UserDTO> GetAll()
    {
        // Lấy dữ liệu từ cơ sở dữ liệu
        var users = _context.Users.ToList();
        // Chuyển đổi dữ liệu sau khi truy xuất
        return users.Select(user => ConvertToDTO(user)).ToList();
    }

    public void Update(UserDTO userDTO)
    {
        var existingUser = _context.Users.Find(userDTO.UserID);
        if (existingUser != null)
        {
            existingUser.Username = userDTO.Username;
            existingUser.Role = userDTO.Role;
            existingUser.FullName = userDTO.FullName;
            existingUser.PhoneNumber = userDTO.PhoneNumber;
            existingUser.Email = userDTO.Email;
            _context.SaveChanges();
        }
    }

    private UserDTO ConvertToDTO(User user)
    {
        return new UserDTO
        {
            UserID = user.UserID,
            Username = user.Username,
            Role = user.Role,
            FullName = user.FullName,
            PhoneNumber = user.PhoneNumber,
            Email = user.Email
        };
    }
}