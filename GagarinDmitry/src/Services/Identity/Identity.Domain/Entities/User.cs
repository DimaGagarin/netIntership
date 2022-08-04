using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public decimal AccountBalance { get; set; }

        public string FirstName { get; set; } = null!;

        public string SecondName { get; set; } = null!;

        public int Age { get; set; }
    }
}
