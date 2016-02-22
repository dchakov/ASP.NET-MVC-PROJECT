namespace RealEstates.Services.Web
{
    public interface IReCaptchaServices
    {
        string Validate(string encodedResponse);
    }
}