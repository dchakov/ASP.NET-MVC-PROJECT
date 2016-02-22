namespace RealEstates.Web.Areas.Administration.ViewModels
{
    using RealEstates.Model;
    using RealEstates.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class UserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [MaxLength(250)]
        [Display(Name = "ImageUrl")]
        public string ImageURL { get; set; }

        public string UserName { get; set; }

        public int? UserImageId { get; set; }
    }
}