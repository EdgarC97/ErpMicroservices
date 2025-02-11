using MemberService.Models;

namespace MemberService.Data
{
    public static class DataSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Members.Any())
            {
                context.Members.AddRange(
                    new Member { FirstName = "Juan", LastName = "Pérez", DateOfBirth = new DateTime(1980, 5, 15), Email = "juan.perez@example.com", Phone = "555-1234", Address = "Calle 1", Status = "Activo" },
                    new Member { FirstName = "María", LastName = "Gómez", DateOfBirth = new DateTime(1975, 9, 20), Email = "maria.gomez@example.com", Phone = "555-5678", Address = "Calle 2", Status = "Activo" },
                    new Member { FirstName = "Carlos", LastName = "Rodríguez", DateOfBirth = new DateTime(1990, 3, 10), Email = "carlos.rodriguez@example.com", Phone = "555-9012", Address = "Calle 3", Status = "Activo" }
                );
                context.SaveChanges();
            }
        }
    }
}
