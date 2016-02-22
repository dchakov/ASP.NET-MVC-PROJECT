namespace RealEstates.Web.ViewModels.Shared
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using RealEstates.Model;
    using RealEstates.Web.Infrastructure.Mapping;
    using Services.Web;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        private readonly IEmailHider emailHider;

        public CommentViewModel()
        {
            this.emailHider = new EmailHider();
        }

        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public int RealEstateId { get; set; }

        public string AuthorEmail { get; set; }

        public string FormattedCreatedOn
        {
            get
            {
                return this.CreatedOn.ToString("MMMM d, yyyy HH:mm");
            }
        }

        public string HiddentAuthorEmail
        {
            get
            {
                return this.emailHider.HideEmail(this.AuthorEmail);
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
               .ForMember(x => x.AuthorEmail, opt => opt.MapFrom(x => x.User.Email));
        }
    }
}