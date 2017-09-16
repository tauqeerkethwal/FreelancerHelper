using Freelancer.Model.Models.Employee;
using Freelancer.Model.Models.Pets;
using System.Collections.Generic;
using System.Linq;
using static Freelancer.Model.Common.Extensions.EnitityFrameworkExtensions;
namespace Freelancer.Model.Common
{
    public static class CommonHelper
    {



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
        public static IQueryable<Employee> ApplyEmployeePaging(SearchParameters searchParameters, IQueryable<Employee> items)
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

        public static IQueryable<Pet> ApplyPetPaging(SearchParameters searchParameters, IQueryable<Pet> items)
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
