using Newtonsoft.Json.Converters;
namespace Freelancer.Core.Common
{
    public class DateTimeHelper
    {

        public class CustomDateTimeFormatter : IsoDateTimeConverter
        {
            public CustomDateTimeFormatter()
            {
                base.DateTimeFormat = "dd-MM-yyyy HH:mm:ss";
            }
        }

        public class CustomDateFormatter : IsoDateTimeConverter
        {
            public CustomDateFormatter()
            {
                base.DateTimeFormat = "dd-MM-yyyy";
            }
        }

        public class CustomTimeFormatter : IsoDateTimeConverter
        {
            public CustomTimeFormatter()
            {
                base.DateTimeFormat = "HH:mm";
            }
        }
    }
}