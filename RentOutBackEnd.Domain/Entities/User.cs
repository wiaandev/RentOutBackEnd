using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace RentOutBackEnd.Domain.Entities;

public class User: IdentityUser<int>
{
    [ForeignKey(nameof(PropertyPost))] 
    public PropertyPost Property { get; set; } = null!;
    
    public int PropertyPostId { get; set; }
}