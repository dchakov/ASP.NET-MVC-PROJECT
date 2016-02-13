namespace RealEstates.Web.Areas.Administration.Helpers
{
    using System.Collections.Generic;
    using System.Linq;
    using Controllers;
    using Web.Helpers;

    public static class AdminMenu
    {
        private static IEnumerable<string> controllers;

        public static IEnumerable<string> Items
        {
            get
            {
                return controllers ?? (controllers = GetControllerNames());
            }
        }

        private static IEnumerable<string> GetControllerNames()
        {
            return ReflectionHelper.GetSubClasses<AdminController>().Select(c => c.Name.Replace("Controller", string.Empty));
        }
    }
}