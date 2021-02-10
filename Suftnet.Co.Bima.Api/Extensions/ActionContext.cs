namespace Suftnet.Co.Bima.Api.Extensions
{
    using Suftnet.Co.Bima.DataAccess.Actions;
    using System;

    public static class ActionContext
    {
        public static string CollectionAddress(this Produce produce)
        {
            var address = string.Empty;

            if (!string.IsNullOrWhiteSpace(produce.Address))
            {
                address += produce.Address + ", ";
            }

            if (!string.IsNullOrWhiteSpace(produce.City))
            {
                address += produce.City + ", ";
            }

            if (!string.IsNullOrWhiteSpace(produce.State))
            {
                address += produce.State + ", ";
            }

            if (!string.IsNullOrWhiteSpace(produce.Country))
            {
                address += produce.Country + ", ";
            }
           
            var lastIndex = address.LastIndexOf(",");

            if (lastIndex != -1)
            {
                address = address.Substring(0, lastIndex);
            }

            return address;
        }

        public static string DeliveryAddress(this Order order)
        {
            var address = string.Empty;

            if (!string.IsNullOrWhiteSpace(order.Address))
            {
                address += order.Address + ", ";
            }

            if (!string.IsNullOrWhiteSpace(order.City))
            {
                address += order.City + ", ";
            }

            if (!string.IsNullOrWhiteSpace(order.State))
            {
                address += order.State + ", ";
            }

            if (!string.IsNullOrWhiteSpace(order.Country))
            {
                address += order.Country + ", ";
            }

            var lastIndex = address.LastIndexOf(",");

            if (lastIndex != -1)
            {
                address = address.Substring(0, lastIndex);
            }

            return address;
        }

        public static DateTime ToDate(this string dateString)
        {
            DateTime dateTime;
            if (DateTime.TryParse(dateString, out dateTime))
            {
                return dateTime;
            }

            return DateTime.UtcNow.Date;
        }


    }
}
