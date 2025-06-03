using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Entities;
using Persistence.Models;

namespace Persistence.Repositories;

public class RoomRepository(DataContext context) : BaseRepository<RoomEntity>(context), IRoomRepository
{
    public Task<RepositoryResult> AddAsync(RoomEntity room)
    {
        throw new NotImplementedException();
    }

    public override async Task<RepositoryResult<IEnumerable<RoomEntity>>> GetAllAsync()

    {
        try
        {
            var entities = await _table.Include(x => x.Packages).ToListAsync();
            return new RepositoryResult<IEnumerable<RoomEntity>> { Success = true, Result = entities };

        }
        catch (Exception ex)
        {
            return new RepositoryResult<IEnumerable<RoomEntity>>
            {
                Success = false,
                Error = ex.Message,
            };
        }
    }

    public override async Task<RepositoryResult<RoomEntity?>> GetAsync(Expression<Func<RoomEntity, bool>> expression)
    {
        try
        {
            var entity = await _table.Include(x => x.Packages).FirstOrDefaultAsync(expression) ?? throw new Exception("Not Found.");
            return new RepositoryResult<RoomEntity?> { Success = true, Result = entity };
        }

        catch (Exception ex)
        {
            return new RepositoryResult<RoomEntity?>
            {
                Success = false,
                Error = ex.Message,
            };
        }
    }
}
