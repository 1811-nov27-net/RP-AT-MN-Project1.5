using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Project1_5_Library.RepoInterfaces;
using Project1_5_DataAccess.Repositories;
using AutoMapper;
using Project1_5_DataAccess;
using Project1_5_Library;
using Microsoft.EntityFrameworkCore;

namespace Project1_5_MVC_REST
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Repositories
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IEventCustomerRepository, EventCustomerRepository>();

            //Mapper
            Mapper.Initialize(cfg => {
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

            services.AddDbContext<Project15Context>(optionsBuilder => optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Project1-5")));

            services
							.AddMvc(options =>
								{
									options.Filters.Add(typeof(GetLoggedInEmployeeFilter));
								})
							.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
