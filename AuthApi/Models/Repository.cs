namespace AuthApi.Models {
    public class Repository {
        public Dictionary<string,User> Users { get; set; }

        public Repository() {
            this.Users = new Dictionary<string,User>();
        }

        public async Task AddUser(User user) {
            await Task.Delay(200);
            Console.WriteLine("Current Users: ");
            foreach(var pair in this.Users) {
                Console.WriteLine($"{pair.Key}: {pair.Value.PasswordHash}");
            }
            Console.WriteLine($"Adding {user.Username} to the database");
            this.Users.Add(user.Username,user);
        }

        public async Task<User?> FindUser(string username) {
            await Task.Delay(200);
            try {
                Console.WriteLine("Current Users: ");
                foreach(var pair in this.Users) {
                    Console.WriteLine($"{pair.Key}: {pair.Value.PasswordHash}");
                }

                User? user = this.Users[username];
                return user;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }
}
