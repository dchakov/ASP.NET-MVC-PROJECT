namespace RealEstates.Web.Areas.Administration.Controllers
{
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Ninject;
    using RealEstates.Model;
    using RealEstates.Services.Contracts;
    using RealEstates.Web.Controllers;
    using System.Linq;
    using System.Web.Mvc;

    public class CitiesController : BaseController
    {
        [Inject]
        public ICitiesService CitiesService { get; set; }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Cities_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<City> cities = this.CitiesService.GetAll();
            DataSourceResult result = cities.ToDataSourceResult(request, city => new
            {
                Id = city.Id,
                Name = city.Name
            });

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Cities_Create([DataSourceRequest]DataSourceRequest request, City city)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new City
                {
                    Name = city.Name
                };

                this.CitiesService.Add(entity);
                this.CitiesService.SaveChanges();
                city.Id = entity.Id;
            }

            return this.Json(new[] { city }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Cities_Update([DataSourceRequest]DataSourceRequest request, City city)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.CitiesService.GetById(city.Id);
                entity.Name = city.Name;
                this.CitiesService.SaveChanges();
            }

            return this.Json(new[] { city }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Cities_Destroy([DataSourceRequest]DataSourceRequest request, City city)
        {
            this.CitiesService.Delete(city.Id);
            this.CitiesService.SaveChanges();

            return this.Json(new[] { city }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.CitiesService.Dispose();
            base.Dispose(disposing);
        }
    }
}
