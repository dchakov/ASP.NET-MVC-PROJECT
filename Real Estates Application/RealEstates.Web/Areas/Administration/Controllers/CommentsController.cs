namespace RealEstates.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Ninject;
    using RealEstates.Model;
    using Services.Contracts;
    using ViewModels;
    using Web.Controllers;

    public class CommentsController : BaseController
    {
        [Inject]
        public ICommentsService CommentsService { get; set; }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Comments_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.CommentsService.GetAll()
                .To<CommentAdminViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Comments_Update([DataSourceRequest]DataSourceRequest request, Comment comment)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.CommentsService.GetById(comment.Id);
                entity.AuthorEmail = comment.AuthorEmail;
                entity.Content = comment.Content;
                this.CommentsService.UpdateComment(entity);
                this.CommentsService.SaveChanges();
            }

            return this.Json(new[] { comment }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Comments_Destroy([DataSourceRequest]DataSourceRequest request, Comment comment)
        {
            this.CommentsService.Delete(comment.Id);
            this.CommentsService.SaveChanges();

            return this.Json(new[] { comment }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.CommentsService.Dispose();
            base.Dispose(disposing);
        }
    }
}
