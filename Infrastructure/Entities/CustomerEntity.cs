using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class CustomerEntity
{
    [Key]
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;

    [ForeignKey(nameof(AdressEntity.Id))]
    public int AdressId { get; set; }
    public AdressEntity Adress { get; set; } = null!;

    [ForeignKey(nameof(RoleEntity.Id))]
    public int RoleId { get; set; }
    public RoleEntity Role { get; set; } = null!;
}
