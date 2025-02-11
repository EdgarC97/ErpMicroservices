namespace MemberService.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; } = string.Empty;
        public DateTime DateJoined { get; set; }
        public string Status { get; set; } = string.Empty;

        // Propiedades internas para el mapeo
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
