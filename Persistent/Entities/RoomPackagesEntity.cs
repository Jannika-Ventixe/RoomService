using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities;

public class RoomPackagesEntity
{

    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [ForeignKey(nameof(Room))]
    public string RoomId { get; set; } = null!;
    public RoomEntity Room { get; set; } = null!;

    [ForeignKey(nameof(Package))]
    public int PackageId { get; set; }
    public PackageEntity Package { get; set; } = null!;
}
