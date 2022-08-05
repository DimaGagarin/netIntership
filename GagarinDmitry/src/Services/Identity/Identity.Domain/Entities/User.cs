using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Entities
{
    /// <summary>
    /// Represents a user in the identity system
    /// </summary>
    public class User : IdentityUser<int>
    {
        /// <summary>
        /// User account balance.
        /// </summary>
        public decimal AccountBalance { get; set; }

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
    }
}
