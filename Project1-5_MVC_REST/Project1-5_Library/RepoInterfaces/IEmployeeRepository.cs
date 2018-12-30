using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project1_5_Library.RepoInterfaces
{
    public interface IEmployeeRepository
    {
        Task<IList<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);

        Task<Employee> CreateAsync(Employee model);
        Task<Employee> UpdateAsync(Employee model, int? id = null);

        Task DeleteAsync(int id);

        Task SaveChangesAsync();
    }
}
