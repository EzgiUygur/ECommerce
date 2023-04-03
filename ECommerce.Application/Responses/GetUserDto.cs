namespace ECommerce.Application.Responses
{
    public class GetUserDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public long RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
