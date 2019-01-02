using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project1_5_Library.RepoInterfaces
{
    public interface IEventRepository
    {
        Task<IList<Event>> GetAllAsync();
        Task<Event> GetByIdAsync(int id);

        Task<Event> CreateAsync(Event model);
        Task<Event> UpdateAsync(Event model, int? id = null);

        Task DeleteAsync(int id);

        Task SaveChangesAsync();
    }
}
