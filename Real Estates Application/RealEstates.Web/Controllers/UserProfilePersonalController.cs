namespace RealEstates.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using Model;
    using Ninject;
    using Services.Contracts;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class UserProfilePersonalController : BaseController
    {
        private const string SuccessfulMessageOnVisitBanner = "You successfully updated profile picture!";

        [Inject]
        public IUsersService UsersService { get; set; }

        [Inject]
        public IUsersImageService UsersImageService { get; set; }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateImage(HttpPostedFileBase uploadedImage)
        {
            if (uploadedImage != null)
            {
                var user = this.UsersService.GetByUserId(this.User.Identity.GetUserId());

                using (var memory = new MemoryStream())
                {
                    uploadedImage.InputStream.CopyTo(memory);
                    var content = memory.GetBuffer();
                    user.UserImage = this.CreateImageModel(uploadedImage.FileName, content);
                }

                this.SetSuccessfullMessage(SuccessfulMessageOnVisitBanner);
                this.UsersService.SaveChanges();
                user.UserImageId = user.UserImage.ImageId;
                this.UsersService.SaveChanges();
            }

            return this.RedirectToAction("Index");
        }

        public ActionResult Image()
        {
            var user = this.UsersService.GetByUserId(this.User.Identity.GetUserId());

            var image = this.UsersImageService.GetById(user.UserImageId);
            if (image == null)
            {
                string path = Path.Combine(this.Server.MapPath("~/Resources/Files"), "default.png");
                return this.File(path, "png");
            }

            return this.File(image.Content, "image/" + image.FileExtension);
        }

        private UserImage CreateImageModel(string fileName, byte[] content)
        {
            var image = new UserImage
            {
                Content = content,
                FileExtension = fileName.Split(new[] { '.' }).Last()
            };

            return image;
        }

        private void SetSuccessfullMessage(string message)
        {
            this.TempData["successfulMessage"] = message;
        }
    }
}