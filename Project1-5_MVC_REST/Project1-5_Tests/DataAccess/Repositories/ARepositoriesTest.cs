using AutoMapper;
using Project1_5_DataAccess;
using Project1_5_Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project1_5_Tests.DataAccess.Repositories
{
    public abstract class ARepositoriesTest
    {
        public ARepositoriesTest()
        {
            try
            {
                AutoMapper.Mapper.Configuration.AssertConfigurationIsValid();
            }
            catch (InvalidOperationException ex)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Customers, Customer>();
                    cfg.CreateMap<Customer, Customers>();

                    cfg.CreateMap<Employees, Employee>();
                    cfg.CreateMap<Employee, Employees>();

                    cfg.CreateMap<Events, Event>();
                    cfg.CreateMap<Event, Events>();

                    cfg.CreateMap<Reservations, Reservation>();
                    cfg.CreateMap<Reservation, Reservations>();

                    cfg.CreateMap<Rooms, Room>();
                    cfg.CreateMap<Room, Rooms>();

                    cfg.CreateMap<EventsCustomers, EventCustomer>();
                    cfg.CreateMap<EventCustomer, EventsCustomers>();
                });
            }
        }

        public abstract Task CreateAsync();
        public abstract Task UpdateWorksAsync();
        public abstract Task UpdateWithWrongIdShouldReturnExceptionAsync();
        public abstract Task UpdateWithNoIdShouldReturnExceptionAsync();
        public abstract Task GetAllWorksAsync();
        public abstract Task GetByIdWorksAsync();
        public abstract Task GetByIdThatDoesntExistReturnsNullAsync();
        public abstract Task DeleteWorksAsync();
        public abstract Task DeleteWithIdThatDoesntExistThrowsExceptionAsync();
    }
}
