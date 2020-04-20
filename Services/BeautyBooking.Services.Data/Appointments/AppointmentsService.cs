﻿namespace BeautyBooking.Services.Data.Appointments
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BeautyBooking.Data.Common.Repositories;
    using BeautyBooking.Data.Models;
    using BeautyBooking.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class AppointmentsService : IAppointmentsService
    {
        private readonly IDeletableEntityRepository<Appointment> appointmentsRepository;

        public AppointmentsService(IDeletableEntityRepository<Appointment> appointmentsRepository)
        {
            this.appointmentsRepository = appointmentsRepository;
        }

        public int GetAllAppointmentsCount()
        {
            return this.appointmentsRepository.All().Count();
        }

        public async Task<IEnumerable<T>> GetByUserAsync<T>(string userId)
        {
            var appointments = await this.appointmentsRepository.All()
                .Where(x => x.UserId == userId)
                .To<T>().ToListAsync();
            return appointments;
        }
    }
}
