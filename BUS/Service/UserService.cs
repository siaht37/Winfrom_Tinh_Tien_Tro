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
        var user = _context.Users.Find(id);
        return user == null ? null : ConvertToDTO(user);
    }

    public IEnumerable<UserDTO> GetAll()
    {
        var users = _context.Users.ToList();
        return users.Select(user => ConvertToDTO(user)).ToList();
    }

    public void AddUser(UserDTO userDTO)
    {
        var user = new User
        {
            Username = userDTO.Username,
            PasswordHash = "defaultHash", // Tùy chỉnh việc hash password
            Role = userDTO.Role,
            FullName = userDTO.FullName,
            PhoneNumber = userDTO.PhoneNumber,
            Email = userDTO.Email
        };
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void UpdateUser(UserDTO userDTO)
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

    public void DeleteUser(int userId)
    {
        var user = _context.Users.Find(userId);
        if (user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
    public UserDTO Authenticate(string username, string password)
    {
        var user = _context.Users
            .SingleOrDefault(u => u.Username == username && u.PasswordHash == password);

        return user == null ? null : ConvertToDTO(user);
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
