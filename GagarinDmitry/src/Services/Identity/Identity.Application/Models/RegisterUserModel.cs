namespace Identity.Application.Models
{
    public class RegisterUserModel
    {
        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string SecondName { get; set; } = null!;

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public int Age { get; set; }

        public decimal AccountBalance { get; set; }
    }
}
