namespace RealEstates.Services.Web
{
    using System;
    using System.Net.Mail;
    using System.Text;

    public class EmailHider : IEmailHider
    {
        public string HideEmail(string email)
        {
            var result = new StringBuilder();

            MailAddress address = new MailAddress(email);
            string username = address.User;
            string domain = address.Host;

            if (username.Length > 3)
            {
                result.Append(username.Substring(0, 3));
                for (int i = 3; i <= username.Length - 1; i++)
                {
                    result.Append('*');
                }
            }
            else
            {
                result.Append(username);
            }

            result.Append("@");

            var domainParts = domain.Split(new[] { '.' });
            if (domainParts[0].Length > 3)
            {
                result.Append(domainParts[0].Substring(0, 3));
                for (int i = 3; i <= domainParts[0].Length - 1; i++)
                {
                    result.Append('*');
                }
            }
            else
            {
                result.Append(domainParts[0]);
            }

            result.Append('.');
            result.Append(domainParts[1]);

            return result.ToString();
        }
    }
}
