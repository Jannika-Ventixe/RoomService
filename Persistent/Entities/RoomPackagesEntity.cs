using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities;

public class RoomPackagesEntity
{

    public string RoomId { get; set; } = null!;
    public RoomEntity Room { get; set; } = null!;

   
    public int PackageId { get; set; }
    public PackageEntity Package { get; set; } = null!;
}
