using Hospital.Models;
using System.Collections.Generic;

namespace Hospital.ViewModels
{
    //Data to be sent to the admin page//
    public class AdminViewModel
    {
        public List<UserData> users;
    }

    public class UserViewModel
    {
        public List<UserData> users;
    }
}

public class UserData
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }
    public List<string> UserRoles { get; set; }
    public string? StaffID { get; set; }

}

