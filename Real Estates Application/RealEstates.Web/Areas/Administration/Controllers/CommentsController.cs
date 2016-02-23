namespace RealEstates.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using RealEstates.Model;
    using Web.Controllers;
    using Ninject;
    using Services.Contracts;

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
            IQueryable<Comment> comments = this.CommentsService.GetAll();
            DataSourceResult result = comments.ToDataSourceResult(request, comment => new
            {
                Id = comment.Id,
                Content = comment.Content,
                CreatedOn = comment.CreatedOn,
            });

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Comments_Update([DataSourceRequest]DataSourceRequest request, Comment comment)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.CommentsService.GetById(comment.Id);
                entity.Content = comment.Content;
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
