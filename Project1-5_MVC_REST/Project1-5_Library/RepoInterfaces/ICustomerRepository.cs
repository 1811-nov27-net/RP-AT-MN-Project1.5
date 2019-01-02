using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project1_5_Library.RepoInterfaces
{
    public interface ICustomerRepository
    {
        Task<IList<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        
        Task<Customer> CreateAsync(Customer model);
        Task<Customer> UpdateAsync(Customer model, int? id = null);

        Task DeleteAsync(int id);
        
        Task SaveChangesAsync();
    }
}
