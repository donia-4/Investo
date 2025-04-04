namespace Investo.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; } = Role.user;
        public DateTime RegistrationDate { get; set; }
        public byte[] ProfilePictureURL { get; set; }
        public string Bio { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<Notification> Notifications { get; set; }

    }
    public enum Role
    {
        user,
        BusinessOwner,
        Investor,
        admin
    }
}
