using Persistence.Models;

namespace Application.Models;

public class RoomResult
{
    public bool Success { get; set; }
    public string? Error { get; set; }
}

public class RoomResult<T> : RoomResult
{
    public T? Result { get; set; }

}
