namespace RealEstates.Web.Controllers
{
    using Ninject;
    using Services.Web;
    using System.Web.Mvc;

    public abstract class BaseController : Controller
    {
        [Inject]
        public ICacheService Cache { get; set; }
    }
}