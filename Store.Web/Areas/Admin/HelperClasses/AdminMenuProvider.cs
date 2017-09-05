using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Freelancer.Web.Areas.Admin.HelperClasses
{
    public class AdminMenuProvider
    {


        public static List<MenuItem> GetMenu(MenuItemType selected)
        {
            var requestContext = HttpContext.Current.Request.RequestContext;
            var url = new UrlHelper(requestContext);


            var items = new List<MenuItem>();

            // Dashboard
            items.Add(new MenuItem
            {
                MenuItemType = MenuItemType.Dashboard,
                DisplayText = "Dashboard",
                Icon = "fa-dashboard",
                Url = url.Action("Index", "AdminHome")
            });


            // Advance Search
            items.Add(new MenuItem
            {
                MenuItemType = MenuItemType.AdvanceSearch,
                DisplayText = "Søg",
                Icon = "fa-search-plus",
                Url = url.Action("Index", "AdvanceSearch")
            });
            // TolkWeeklyReport











            #region Management


            // Animals
            items.Add(


                new MenuItem
                {
                    MenuItemType = MenuItemType.Animals,
                    DisplayText = "Pet",
                    Icon = "fa-cog",
                    Url = "#",
                    Childs = new List<MenuItem>()
                    {


                        new MenuItem
                        {
                            MenuItemType = MenuItemType.AddAnimals,
                            DisplayText = "Add",
                            Icon = "fa-language",
                            Url = url.Action("Add", "Pet")
                        },
                         new MenuItem
                        {
                            MenuItemType = MenuItemType.ListAnimals,
                            DisplayText = "View/Edit",
                            Icon = "fa-language",
                            Url = url.Action("List", "Pet"),
                            IsActive=true
                        }

                    }
                });
            #endregion










            SetActiveMenu(items, selected);
            return items;

        }




        private static void SetActiveMenu(List<MenuItem> items, MenuItemType selected)
        {

            foreach (var menuItem in items)
            {

                bool isChildSelected = false;
                if (menuItem.Childs != null && menuItem.Childs.Count > 0)
                {
                    SetActiveMenu(menuItem.Childs, selected);

                    isChildSelected = menuItem.Childs.Count(x => x.IsActive) > 0;
                }

                menuItem.IsActive = (menuItem.MenuItemType == selected) || isChildSelected;


            }

        }

    }


    public enum MenuItemType
    {
        None = 0,
        Dashboard = 1,
        Animals,
        AddAnimals,
        ListAnimals,
        WeeklyReport,
        NewBooking,
        Brugerprofiler,
        TolkReport,
        Search,
        AdvanceSearch,
        ReportPrices,
        Management,
        Users,
        Languages,
        PostalCode,
        PricesFinal,
        Status,
        Administration,

        Stats,

        Customers,
        CustomerInsertPrices,
        Accounts,

        Danlon,
        GotoDanlon,
        DownloadDanlon,
        DanlonAutomatic,

        EconomicsMain,
        Economics,
        EconomicsMixTime,
        EconomicsAuto,
        EconomicsAutoEan,
        EconomicsAutoEmail,
        EconomicsAutoTele,
        EconomicsTeleRest,
        EconomicsWritten,
        EconomicsRest,
        EconomicsNotMatch,
        EconomicsUpdateEan,


        PricesEconomics,

        Complains,


        TolkBilagNotChecked,
        TolkBilagChecked,
        TolkBilagStats,

        SMSLog,
        EmailLog,


        ComplainList,
        NewComplainList,
        ActiveComplainList,


    }



    public class MenuItem
    {
        public MenuItem()
        {
            Childs = new List<MenuItem>();
        }

        public MenuItemType MenuItemType { get; set; }

        public bool IsActive { get; set; }

        public string DisplayText { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }

        public List<MenuItem> Childs { get; set; }


    }


}