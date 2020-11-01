namespace ExtJSBack.Model
{
    /// <summary>Класс для хранения пользаков и аутентификации.</summary>
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
