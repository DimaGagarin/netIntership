namespace Identity.Application.Models
{
    public class UserInfo
    {
        public string UserName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string SecondName { get; set; } = null!;

        public int Age { get; set; }

        public decimal AccountBalance { get; set; }
    }
}
