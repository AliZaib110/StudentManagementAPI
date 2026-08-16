namespace StudentManagementAPI.Models
{
    public class User
    {
        public int Id { set; get; }
        public string Name { set; get; } = string.Empty;
        public string Email { set; get; } = string.Empty;
        public string PasswordHash { set; get; } = string.Empty;
        public string Role { set; get; } = string.Empty;


    }
}
