﻿namespace RealEstates.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Ninject;
    using RealEstates.Model;
    using RealEstates.Services.Contracts;
    using RealEstates.Web.ViewModels.UserM;

    [HandleError]
    public class UserProfileController : BaseController
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
                Comments = appUser.Comments.OrderByDescending(c => c.CreatedOn).ToList(),
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
            [Bind(Include = "Id,Title,Description,Address,Contact,ConstructionYear,SellingPrice,RentingPrice,Type,CreatedOn,Bedrooms,Bathrooms,SquareMeter,UserId,CityId")] RealEstate realEstate,
            IEnumerable<HttpPostedFileBase> files)
        {
            if (this.ModelState.IsValid)
            {
                string userID = this.User.Identity.GetUserId();
                realEstate.UserId = userID;
                realEstate.Contact = userID;
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
                        string path = Path.Combine(this.Server.MapPath("~/Resources/Images"), fileName);
                        Image newImage = new Image()
                        {
                            FileName = fileName,
                            ImageUrl = "~/Resources/Images/" + fileName,
                            RealEstateId = realEstateId
                        };
                        this.ImageService.AddNew(newImage, realEstateId);
                        file.SaveAs(path);
                    }
                }

                this.TempData["Notification"] = "Thank you for your Real Estate!";
                return this.RedirectToAction("MyProfile");
            }

            this.ViewBag.CityId = new SelectList(this.CitiesService.GetAll(), "Id", "Name", realEstate.CityId);
            return this.View(realEstate);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RealEstate realEstate = this.RealEstatesService.GetById(id);
            if (realEstate == null)
            {
                return this.HttpNotFound();
            }

            this.ViewBag.Cities = this.CitiesService.GetAll();
            return this.View(realEstate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Address,Contact,ConstructionYear,SellingPrice,RentingPrice,Type,CreatedOn,Bedrooms,SquareMeter,UserId,CityId")] RealEstate realEstate)
        {
            if (this.ModelState.IsValid)
            {
                realEstate.UserId = this.User.Identity.GetUserId();
                this.RealEstatesService.UpdateRealEstate(realEstate);
                this.RealEstatesService.SaveChanges();
                return this.RedirectToAction("MyProfile");
            }

            this.ViewBag.Cities = this.CitiesService.GetAll();
            return this.View(realEstate);
        }
    }
}