namespace Data.Entities
{
    public class Account
    {
        public int AccId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }

}
