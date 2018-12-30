using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project1_5_Library.RepoInterfaces
{
    public interface IEventCustomerRepository
    {
        Task<IList<EventCustomer>> GetAllAsync();
        Task<EventCustomer> GetByIdAsync(int id);

        Task<EventCustomer> CreateAsync(EventCustomer model);
        Task<EventCustomer> UpdateAsync(EventCustomer model, int? id = null);

        Task DeleteAsync(int id);

        Task<IList<EventCustomer>> GetByCustomerIdAsync(int id);

        Task SaveChangesAsync();
    }
}
