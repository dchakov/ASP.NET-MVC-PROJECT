﻿namespace RealEstates.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Common.Constants;
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