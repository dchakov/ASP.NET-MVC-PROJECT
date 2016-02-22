﻿namespace RealEstates.Web.Controllers
{
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Model;
    using Ninject;
    using Services.Contracts;
    using Services.Web;
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using ViewModels.Home;
    using ViewModels.Shared;

    public class RealEstateController : BaseController
    {
        private const int CommentPageSize = 4;

        private IIdentifierProvider identifier = new IdentifierProvider();

        [Inject]
        public IRealEstatesService RealEstatesService { get; set; }

        [Inject]
        public IUsersService UserService { get; set; }

        [Inject]
        public ICommentsService CommentsService { get; set; }

        [HttpGet]
        public ActionResult RealEstateById(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RealEstate realEstate = this.RealEstatesService.GetByEncodedId(id);

            if (realEstate == null)
            {
                return this.HttpNotFound();
            }

            var viewRealEstate = this.Mapper
                .Map<RealEstateViewModel>(realEstate);

            int page = 1;

            if (this.Request.QueryString["page"] != null)
            {
                page = int.Parse(this.Request.QueryString["page"]);
            }

            int allICommentsCount = this.CommentsService.GetCommentsForRealEstate(id).Count();
            int totalPages = (int)Math.Ceiling(allICommentsCount / (double)CommentPageSize);
            int itemsToSkip = (page - 1) * CommentPageSize;

            var realEstateComments = this.CommentsService
                .GetCommentsForRealEstate(id)
                .Skip(itemsToSkip)
                .Take(CommentPageSize)
                .To<CommentViewModel>()
                .ToList();

            var viewModel = new RealEstateDetailsViewModel()
            {
                RealEstate = viewRealEstate,
                RealEstateId = viewRealEstate.Id,
                Comments = realEstateComments,
                CurrentCommentPage = page,
                TotalCommentPages = totalPages,
                Images = viewRealEstate.Images
            };

            return this.View(viewModel);
        }

        public ActionResult AddComment(RealEstateDetailsViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.User.Identity.GetUserId();
            if (userId == null)
            {
                return this.RedirectToAction("Login", "Account");
            }

            var user = this.UserService.GetByUserId(userId);

            string currentIp = this.Request.ServerVariables["REMOTE_ADDR"];
            this.CommentsService.Create(model.Content, user.Email, userId, model.RealEstateId);

            return this.RedirectToAction("RealEstateById", new { id = this.identifier.EncodeId(model.RealEstateId) });
        }
    }
}