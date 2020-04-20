﻿namespace BeautyBooking.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using BeautyBooking.Common;
    using BeautyBooking.Services.Data.Categories;
    using BeautyBooking.Services.Data.Salons;
    using BeautyBooking.Services.Data.SalonServicesServices;
    using BeautyBooking.Services.Data.Services;
    using BeautyBooking.Web.ViewModels.Administration.Services;
    using Microsoft.AspNetCore.Mvc;

    public class ServicesController : AdministrationController
    {
        private readonly IServicesService servicesService;
        private readonly ICategoriesService categoriesService;
        private readonly ISalonsService salonsService;
        private readonly ISalonServicesService salonServicesService;

        public ServicesController(
            IServicesService servicesService,
            ICategoriesService categoriesService,
            ISalonsService salonsService,
            ISalonServicesService salonServicesService)
        {
            this.servicesService = servicesService;
            this.categoriesService = categoriesService;
            this.salonsService = salonsService;
            this.salonServicesService = salonServicesService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new ServicesListViewModel
            {
                Services = await this.servicesService.GetAllAsync<ServiceViewModel>(),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> AddService()
        {
            var categoriesNames = await this.categoriesService.GetAllCategoriesNamesAsync();

            this.ViewData["Categories"] = categoriesNames;

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddService(ServiceInputModel input)
        {
            // Get CategoryId
            var categoryId = await this.categoriesService.GetIdByNameAsync(input.Category);

            // Add Service
            var serviceId = await this.servicesService.AddServiceAsync(input.Name, categoryId, input.Description);

            // Add the Service to all Salons in the Category
            var salonsIds = await this.salonsService.GetAllSalonsInCategoryAsync(categoryId);
            await this.salonServicesService.AddSalonServicesAsync(salonsIds, serviceId);

            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            if (id <= GlobalConstants.SeededDataCounts.Services)
            {
                return this.RedirectToAction("Index");
            }

            await this.servicesService.DeleteServiceAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
