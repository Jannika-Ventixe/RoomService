using Persistence.Entities;
using Persistence.Models;

namespace Persistence.Repositories;

public interface IRoomRepository : IBaseRepository<RoomEntity>
{
    Task<RepositoryResult> AddAsync(RoomEntity room);
}