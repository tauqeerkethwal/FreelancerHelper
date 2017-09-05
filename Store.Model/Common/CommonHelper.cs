using Freelancer.Model.Models.Pets;
using System.Collections.Generic;
using System.Linq;
using static Freelancer.Model.Common.Extensions.EnitityFrameworkExtensions;
namespace Freelancer.Model.Common
{
    public static class CommonHelper
    {

        public const string AflystIndenfo12No = "5ff15c0f-e5f7-47c7-93db-19867c5a5518";


        public static List<long?> ExcludeCustomerType
        {
            get
            {
                long?[] temp = { 2, 3 };

                return temp.ToList();
            }
        }
        public static List<string> TestEmails
        {
            get
            {
                string[] temp = { "", "" };

                return temp.ToList();
            }
        }

        public static int Total24HoursMinutes
        {
            get
            {
                int total24HoursMinutes = 1440;
                return total24HoursMinutes;
            }
        }
        public static int BetweenTimeDay
        {
            get
            {
                int betweenTimeDay = 480;
                return betweenTimeDay;
            }
        }
        public static int BetweenTimeEvening
        {
            get
            {
                int betweenTimeEvening = 1020;
                return betweenTimeEvening;
            }
        }
        public static int StartTimeComparision
        {
            get
            {
                int startTimeComparision = 1439;
                return startTimeComparision;
            }
        }

        public static List<long> IsSignLanguageOrder
        {
            get
            {
                long[] temp = { 4, 5, 8 };

                return temp.ToList();
            }
        }
        public static List<long> IsTele
        {
            get
            {
                long[] temp = { 2, 6 };

                return temp.ToList();
            }
        }


        public static IQueryable<Pet> ApplyOrderPaging(SearchParameters searchParameters, IQueryable<Pet> items)
        {
            // Apply Sort Order
            if (!string.IsNullOrEmpty(searchParameters.SortColumnName))
            {
                items = items.ApplySortingAndPagging(searchParameters.SortColumnName, searchParameters.SortOrderDescending, searchParameters.PageSize, searchParameters.PageStart);
            }
            else
            {
                List<SortInfo> sortList = new List<SortInfo>();



                sortList.Add(new SortInfo { SortColumnName = "DateCreated", SortOrderDescending = false });


                items = items.ApplySortingAndPagging(sortList, searchParameters.PageSize, searchParameters.PageStart);
            }

            return items;
        }


        public static IQueryable<Pet> ApplyOrderComplainPaging(SearchParameters searchParameters, IQueryable<Pet> items)
        {
            // Apply Sort Order
            if (!string.IsNullOrEmpty(searchParameters.SortColumnName))
            {
                items = items.ApplySortingAndPagging(searchParameters.SortColumnName, searchParameters.SortOrderDescending, searchParameters.PageSize, searchParameters.PageStart);
            }
            else
            {
                List<SortInfo> sortList = new List<SortInfo>();

                sortList.Add(new SortInfo { SortColumnName = "DateCreated", SortOrderDescending = false });

                items = items.ApplySortingAndPagging(sortList, searchParameters.PageSize, searchParameters.PageStart);
            }

            return items;
        }


    }
}
