namespace Identity.Application.Models
{
    /// <summary>
    /// Model that represents user info
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// Username.
        /// </summary>
        public string UserName { get; set; } = null!;

        /// <summary>
        /// User first name.
        /// </summary>
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// User second name.
        /// </summary>
        public string SecondName { get; set; } = null!;

        /// <summary>
        /// User age.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// User account balance.
        /// </summary>
        public decimal AccountBalance { get; set; }
    }
}
