using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project1_5_Library.RepoInterfaces
{
    public interface IReservationRepository
    {
        Task<IList<Reservation>> GetAllAsync();
        Task<Reservation> GetByIdAsync(int id);

        Task<Reservation> CreateAsync(Reservation model);
        Task<Reservation> UpdateAsync(Reservation model, int? id = null);

        Task DeleteAsync(int id);

        Task<IList<Reservation>> GetByCustomerIdAsync(int id);

        Task SaveChangesAsync();
    }
}
