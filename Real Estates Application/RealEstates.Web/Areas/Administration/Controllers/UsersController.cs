namespace RealEstates.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using RealEstates.Model;
    using Ninject;
    using Services.Contracts;
    using ViewModels;
    using Infrastructure.Mapping;

    public class UsersController : Controller
    {
        [Inject]
        public IUsersService UsersService { get; set; }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Users_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.UsersService.GetAll()
                .To<UserViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Update([DataSourceRequest]DataSourceRequest request, UserViewModel user)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.UsersService.GetByUserId(user.Id);

                entity.ImageURL = user.ImageURL;
                entity.Name = user.Name;
                entity.UserImageId = user.UserImageId;
                entity.Email = user.Email;
                entity.UserName = user.UserName;

                this.UsersService.Update(entity);
                this.UsersService.SaveChanges();
            }

            var userToDispley = this.UsersService.GetAll()
               .To<UserViewModel>()
               .FirstOrDefault(x => x.Id == user.Id);

            return this.Json(new[] { userToDispley }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Destroy([DataSourceRequest]DataSourceRequest request, User user)
        {
            this.UsersService.Delete(user.Id);
            this.UsersService.SaveChanges();

            return this.Json(new[] { user }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.UsersService.Dispose();
            base.Dispose(disposing);
        }
    }
}
