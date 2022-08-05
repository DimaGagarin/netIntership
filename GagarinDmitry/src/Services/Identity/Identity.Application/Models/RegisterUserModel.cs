namespace Identity.Application.Models
{
    /// <summary>
    /// Model for user registration.
    /// </summary>
    public class RegisterUserModel
    {
        /// <summary>
        /// Username.
        /// </summary>
        public string UserName { get; set; } = null!;

        /// <summary>
        /// User password.
        /// </summary>
        public string Password { get; set; } = null!;

        /// <summary>
        /// User first name.
        /// </summary>
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// User second name.
        /// </summary>
        public string SecondName { get; set; } = null!;

        /// <summary>
        /// User Email.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// User phone number.
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// User Age.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// User account balance.
        /// </summary>
        public decimal AccountBalance { get; set; }
    }
}
