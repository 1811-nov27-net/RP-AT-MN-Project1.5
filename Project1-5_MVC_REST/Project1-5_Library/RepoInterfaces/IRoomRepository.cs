using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project1_5_Library.RepoInterfaces
{
    public interface IRoomRepository
    {
        Task<IList<Room>> GetAllAsync();
        Task<Room> GetByIdAsync(int id);

        Task<Room> CreateAsync(Room model);
        Task<Room> UpdateAsync(Room model, int? id = null);

        Task DeleteAsync(int id);

        Task SaveChangesAsync();

        Task<IList<Room>> CheckRoomAvailabilityAsync(DateTime beginDate);
    }
}
