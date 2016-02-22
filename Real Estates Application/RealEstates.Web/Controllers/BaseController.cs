namespace RealEstates.Web.Controllers
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using Ninject;
    using Services.Web;
    using System.Web.Mvc;

    public abstract class BaseController : Controller
    {
        [Inject]
        public ICacheService Cache { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}