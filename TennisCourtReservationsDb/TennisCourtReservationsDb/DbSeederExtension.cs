using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TennisCourtReservationsDb
{
    public static class DbSeederExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Console.WriteLine("Seeding Persons...");
            modelBuilder.Entity<Person>().HasData(new Person
            {
                Id = 1,
                Firstname = "Hansi",
                Lastname = "Huber",
                Age = 66
            });

            modelBuilder.Entity<Person>().HasData(new Person
            {
                Id = 2,
                Firstname = "Fritzi",
                Lastname = "Müller",
                Age = 23
            });

            modelBuilder.Entity<Person>().HasData(new Person
            {
                Id = 3,
                Firstname = "Susi",
                Lastname = "Berger",
                Age = 31
            });

            Console.WriteLine("Seeding Bookings...");
            modelBuilder.Entity<Booking>().HasData(new Booking { Id = 1, Week = 22, DayOfWeek = 1, Hour = 12, PersonId = 1 });
            modelBuilder.Entity<Booking>().HasData(new Booking { Id = 2, Week = 22, DayOfWeek = 4, Hour = 12, PersonId = 3 });
            modelBuilder.Entity<Booking>().HasData(new Booking { Id = 3, Week = 22, DayOfWeek = 2, Hour = 14, PersonId = 2 });
            modelBuilder.Entity<Booking>().HasData(new Booking { Id = 4, Week = 22, DayOfWeek = 2, Hour = 11, PersonId = 1 });

        }
    }
}
