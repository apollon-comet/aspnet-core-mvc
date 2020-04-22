﻿namespace BeautyBooking.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using BeautyBooking.Common;
    using BeautyBooking.Data.Models;

    public class SalonsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Salons.Any())
            {
                return;
            }

            var salons = new Salon[]
                {
                    // 1. Hair Salons
                    new Salon
                    {
                        Name = "Salon De Style",
                        CategoryId = 1,
                        CityId = 1,
                        Address = "Laidlaw Close 28",
                        ImageUrl = GlobalConstants.Images.Hair1,
                        Rating = 5,
                    },
                    new Salon
                    {
                        Name = "Happy Hair Salon",
                        CategoryId = 1,
                        CityId = 1,
                        Address = "Francis Way 198",
                        ImageUrl = GlobalConstants.Images.Hair2,
                        Rating = 4,
                    },
                    new Salon
                    {
                        Name = "Angel Hair Salon",
                        CategoryId = 1,
                        CityId = 2,
                        Address = "Rosehill Crescent 93",
                        ImageUrl = GlobalConstants.Images.Hair3,
                        Rating = 5,
                    },

                    // 2. Hair removal Salons
                    new Salon
                    {
                        Name = "Pretty Her Salon",
                        CategoryId = 2,
                        CityId = 1,
                        Address = "Pintail Close 5",
                        ImageUrl = GlobalConstants.Images.HairRemoval1,
                        Rating = 3,
                    },
                    new Salon
                    {
                        Name = "Charms Salon",
                        CategoryId = 2,
                        CityId = 1,
                        Address = "Ellesmere Gardens 143",
                        ImageUrl = GlobalConstants.Images.HairRemoval2,
                        Rating = 5,
                    },
                    new Salon
                    {
                        Name = "Little Sweets Salon",
                        CategoryId = 2,
                        CityId = 2,
                        Address = "Sykes Avenue 128",
                        ImageUrl = GlobalConstants.Images.HairRemoval3,
                        Rating = 4,
                    },

                    // 3. Massage ans Spa Salons
                    new Salon
                    {
                        Name = "Your Style Spa",
                        CategoryId = 3,
                        CityId = 1,
                        Address = "Swinton Road 158",
                        ImageUrl = GlobalConstants.Images.Massage1,
                        Rating = 4,
                    },
                    new Salon
                    {
                        Name = "Treat Yourself",
                        CategoryId = 3,
                        CityId = 1,
                        Address = "Sunnydale 38",
                        ImageUrl = GlobalConstants.Images.Massage2,
                        Rating = 5,
                    },
                    new Salon
                    {
                        Name = "Little Castle",
                        CategoryId = 3,
                        CityId = 2,
                        Address = "Penywern Road 43",
                        ImageUrl = GlobalConstants.Images.Massage3,
                        Rating = 5,
                    },

                    // 4. Nail Salons
                    new Salon
                    {
                        Name = "Cool Colors",
                        CategoryId = 4,
                        CityId = 1,
                        Address = "Greenview Drive 119",
                        ImageUrl = GlobalConstants.Images.Nails1,
                        Rating = 5,
                    },
                    new Salon
                    {
                        Name = "The Barbie Boutique",
                        CategoryId = 4,
                        CityId = 1,
                        Address = "Stratford Crescent 15",
                        ImageUrl = GlobalConstants.Images.Nails2,
                        Rating = 4,
                    },
                    new Salon
                    {
                        Name = "Salon Don",
                        CategoryId = 4,
                        CityId = 2,
                        Address = "Malet Close 28",
                        ImageUrl = GlobalConstants.Images.Nails3,
                        Rating = 5,
                    },

                    // 5. Face Treatments
                    new Salon
                    {
                        Name = "Makeover Paradise",
                        CategoryId = 5,
                        CityId = 1,
                        Address = "Abbotsbury Way 81",
                        ImageUrl = GlobalConstants.Images.Face1,
                        Rating = 4,
                    },
                    new Salon
                    {
                        Name = "The Beauty Studio",
                        CategoryId = 5,
                        CityId = 1,
                        Address = "Trossachs Road 62",
                        ImageUrl = GlobalConstants.Images.Face2,
                        Rating = 2,
                    },
                    new Salon
                    {
                        Name = "Hot Chic",
                        CategoryId = 5,
                        CityId = 2,
                        Address = "Apsley Way 16",
                        ImageUrl = GlobalConstants.Images.Face3,
                        Rating = 5,
                    },

                    // 6. Body Treatments
                    new Salon
                    {
                        Name = "Harmony",
                        CategoryId = 6,
                        CityId = 1,
                        Address = "Warmington Road 122",
                        ImageUrl = GlobalConstants.Images.Body1,
                        Rating = 5,
                    },
                    new Salon
                    {
                        Name = "Bubbles Of Love",
                        CategoryId = 6,
                        CityId = 1,
                        Address = "Ingoe Close 75",
                        ImageUrl = GlobalConstants.Images.Body2,
                        Rating = 4,
                    },
                    new Salon
                    {
                        Name = "Beautiful Bodies",
                        CategoryId = 6,
                        CityId = 2,
                        Address = "Pool View 42",
                        ImageUrl = GlobalConstants.Images.Body3,
                        Rating = 3,
                    },
                };

            await dbContext.AddRangeAsync(salons);
        }
    }
}
