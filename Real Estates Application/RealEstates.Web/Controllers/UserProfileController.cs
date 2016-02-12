namespace RealEstates.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using Ninject;
    using RealEstates.Model;
    using RealEstates.Services.Contracts;
    using RealEstates.Web.ViewModels.UserM;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class UserProfileController : Controller
    {
        [Inject]
        public IUsersService UsersService { get; set; }

        [Inject]
        public ICitiesService CitiesService { get; set; }

        [Inject]
        public IRealEstatesService RealEstatesService { get; set; }

        [Inject]
        public IImageService ImageService { get; set; }

        [Authorize]
        public ActionResult MyProfile()
        {
            var currentUserId = this.User.Identity.GetUserId();

            if (currentUserId != null)
            {
                return this.RedirectToAction("Index", new { Id = currentUserId });
            }
            else
            {
                return this.RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Index(string id)
        {
            User appUser = this.UsersService.GetByUserId(id);

            UserPageViewModel vm = new UserPageViewModel()
            {
                ImageURL = appUser.ImageURL,
                Comments = appUser.Comments.OrderByDescending(c => c.RealEstate).ToList(),
                RealEstates = appUser.RealEstates.OrderByDescending(r => r.CreatedOn).ToList(),
                Ratings = appUser.Ratings.ToList()
            };

            return this.View(vm);
        }

        public ActionResult CreateRealEstate()
        {
            this.ViewBag.Cities = this.CitiesService.GetAll();
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRealEstate(
            [Bind(Include = "Id,Title,Description,Address,Contact,ConstructionYear,SellingPrice,RentingPrice,Type,CreatedOn,Bedrooms,SquareMeter,UserId,CityId")] RealEstate realEstate,
            IEnumerable<HttpPostedFileBase> files)
        {
            if (this.ModelState.IsValid)
            {
                string userID = this.User.Identity.GetUserId();
                realEstate.UserId = userID;
                realEstate.CreatedOn = DateTime.Now;
                int realEstateId = this.RealEstatesService.AddNew(realEstate, userID);

                var supportedTypes = new[] { "jpg", "jpeg", "png" };
                foreach (var file in files)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileExt = Path.GetExtension(file.FileName).Substring(1);
                        if (!supportedTypes.Contains(fileExt))
                        {
                            this.ModelState.AddModelError("photo", "Invalid type. Only the following types (jpg, jpeg, png) are supported.");
                            return this.View(realEstate);
                        }

                        string fileName = Path.GetFileName(file.FileName);
                        string path = Path.Combine(this.Server.MapPath("~/App_Data/Images"), fileName);
                        Image newImage = new Image()
                        {
                            FileName = fileName,
                            ImageUrl = path,
                            RealEstateId = realEstateId
                        };
                        this.ImageService.AddNew(newImage, realEstateId);
                        file.SaveAs(path);
                    }
                }

                return this.RedirectToAction("MyProfile");
            }

            this.ViewBag.CityId = new SelectList(this.CitiesService.GetAll(), "Id", "Name", realEstate.CityId);
            return this.View(realEstate);
        }
    }
}