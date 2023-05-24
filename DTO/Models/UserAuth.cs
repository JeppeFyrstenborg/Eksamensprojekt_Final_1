namespace DTO.Models
{
    public class UserAuth
    {
        public int UserAuthId { get; set; }

        public string HashedPassword { get; set; }

        public string Salt { get; set; }

        public User User { get; set; }

        public UserAuth() { }

        public UserAuth(string hashedPassword, string salt, User user)
        {
            this.HashedPassword = hashedPassword;
            this.Salt = salt;
            this.User = user;
        }
    }
}
