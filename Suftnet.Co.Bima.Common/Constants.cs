namespace Suftnet.Co.Bima.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class ValidationError
    {
        public const string PASSWORD_OR_USERNAME = "Invalid username or password.";
        public const string USER_NOT_FOUND = "application user id not found";
        public const string PASSWORD_RESET = "Error while generating password reset token, please try later";
        public const string EMAIL_FOUND = "A match found for your Email address, please try another email";
        public const string PRODUCE_NOT_FOUND = "A match not found for your Produce Id";
        public const string SELLER_NOT_FOUND = "A match not found for this Farmer";
        public const string BUYER_NOT_FOUND = "A match not found for this Buyer";
    }

    public static class JwtClaimIdentifiers
    {
        public const string USER_ID = "UserId", PHONE_NUMBER = "PhoneNumber", USER_NAME = "UserName", FIRST_NAME ="FirstName", LAST_NAME ="LastName",  FULL_NAME ="FullName";
    }

    public static class UserType
    {
        public const string BUYER = "Buyer", SELLER = "Farmer", Logistic = "Logistic", BACKOFFICE = "BackOffice";
    }

    public static class CompanyType
    {
        public const string Buyer = "ED9EB336-D246-4747-ADB1-42FD95D98E4C";
        public const string Seller = "FFA01FE4-8B49-41E9-A630-70FD7E756ECC";
        public const string Logistic = "BFF4A1B2-8D64-4919-A91D-4E96E61E1A5B";
    }

    public static class Constants
    {
        public const string DefaultPassword = "Vx!1234567";      
    }

    public static class DateTimeFormat
    {
        public static string FormatDate = "dddd, dd MMMM yyyy";
        public static string FormatDateTime = "dddd, dd MMMM yyyy";
    }

    public static class eOrderStatus
    {
        public const string Pending = "ED9EB336-D246-4747-ADB1-42FD95D98E4C";
        public const string Completed = "BFF4A1B2-8D64-4919-A91D-4E96E61E1A5B";
        public const string Processing = "FFA01FE4-8B49-41E9-A630-70FD7E756ECC";
        public const string Delivery = "3dbd5a6d-cf74-4343-9b51-b2446b6cdcf9";
    }

    public static class ePaymentStatus
    {
        public const string Paid = "115924fb-79f9-4e0c-ab5f-d4e1dfc1c893";
        public const string Pending = "ed9eb336-d246-4747-adb1-42fd95d98e4c";     
    }
}
