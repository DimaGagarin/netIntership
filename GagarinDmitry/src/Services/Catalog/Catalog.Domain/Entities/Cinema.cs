namespace Catalog.Domain.Entities
{
    public class Cinema : BaseEntity
    {
        public string Title { get; set; } = null!;

        public string City { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;
    }
}
