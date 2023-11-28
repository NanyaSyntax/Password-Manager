namespace NanyaPasswordManager.Core.DTO
{
    public class UserRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
