namespace AuthApi.Models {
public class UserDto(string username = "", string psw = "") {
    public string Username { get; set; } = username;
    public string Password { get; set; } = psw;
}
}
