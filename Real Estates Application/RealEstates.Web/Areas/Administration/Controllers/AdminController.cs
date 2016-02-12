namespace RealEstates.Web.Areas.Administration.Controllers
{
    using Common.Constants;
    using Helpers;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [ValidateInput(false)]
    public class AdminController : BaseController
    {
        [ChildActionOnly]
        public ActionResult Menu()
        {
            IEnumerable<string> items = new List<string>() { "RealEstates", "Comments", "Cities", "Users" };
            return this.PartialView("_AdminMenu", items);
        }
    }
}