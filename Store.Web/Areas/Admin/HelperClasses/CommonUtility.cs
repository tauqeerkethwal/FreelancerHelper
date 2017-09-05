using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using Freelancer.Model;


namespace Freelancer.Web.Areas.Admin.HelperClasses
{
    public static class CommonUtility
    {


        //public static void SetLoginUserInformation(UserModel userModel)
        //{
        //    var loginModel = new LoginUserDetailModel
        //    {
        //        UserId = userModel.Id,
        //        LoginName = userModel.Name,
        //        Initial = userModel.Initials,
        //        UserLevel = GetRoleType(userModel.Status),
        //        CanHandelComplain = userModel.CanHandleComplain,
        //        LastChangedOrderId = userModel.LastSavedOrderId
        //    };

        //    AdminLoginUser.SetLoginUser(loginModel);
        //}


        //private static RoleType GetRoleType(string name)
        //{
        //    RoleType type = RoleType.None;

        //    if (Enum.TryParse<RoleType>(name, out type))
        //    {
        //        return type;
        //    }

        //    return RoleType.None;
        //}


        public static string ConvertToDisplayString(this DateTime datetime)
        {

            return datetime.ToString(GetCurrentShortDateFormat());

        }

        public static string ConvertToDisplayString(this DateTime? datetime)
        {
            if (datetime.HasValue)
            {
                return ConvertToDisplayString(datetime.Value);
            }

            return "";
        }


        public static DateTime ConvertToUIDateTime(this string val)
        {
            var format = GetCurrentShortDateFormat();

            var v = DateTime.MinValue;


            if (DateTime.TryParseExact(val, format,
                                   System.Threading.Thread.CurrentThread.CurrentCulture,
                                   DateTimeStyles.None,
                                   out v))
                return v;


            return DateTime.Now;

        }


        public static string GetCurrentShortUIDateFormat()
        {
            return GetCurrentShortDateFormat().ToLower();
        }

        public static string GetCurrentShortDateFormat()
        {
            ////string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;


            //string sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;

            ////if (CultureInfo.CurrentCulture.Name == "en-US")
            ////{
            ////    return "MM/dd/yyyy";
            ////}
            ////else if (CultureInfo.CurrentCulture.Name == "da-DK")
            //{

            //    return "dd-MM-yyyy";
            //}

            ////return sysFormat;

            // return "MM/dd/yyyy";
            return "dd-MM-yyyy";
        }
        public static bool IsFileAllowedToUpload(string fileName)
        {
            if (fileName == null) return false;
            var notAllowedExtensions = new[] { ".cs", ".log", ".exe" };
            var extension = Path.GetExtension(fileName).ToLower();
            if (notAllowedExtensions.Contains(extension))
            {
                return false;
            }
            return true;
        }

    }
}