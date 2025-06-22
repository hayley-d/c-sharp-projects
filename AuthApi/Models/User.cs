namespace AuthApi.Models {
    public class User(string username = "", string pswHash = "") {
        public Guid Id { get; set; } = new Guid();
        public string Username { get; set; } = username;
        public string PasswordHash { get; set; } = pswHash;
    }
}
