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
        public const string EMAIL_FOUND = "A match found for your email address, please try another email";
    }

    public static class JwtClaimIdentifiers
    {
        public const string USER_ID = "UserId", USER_NAME = "UserName", FIRST_NAME ="FirstName", LAST_NAME ="LastName",  FULL_NAME ="FullName";
    }

    public static class UserType
    {
        public const string BUYER = "Buyer", SELLER = "Seller", DRIVER = "Driver", BACKOFFICE = "BackOffice", FRONTOFFICE = "FrontOffice";
    }

    public static class CompanyType
    {
        public const string Buyer = "ED9EB336-D246-4747-ADB1-42FD95D98E4C";
        public const string Seller = "FFA01FE4-8B49-41E9-A630-70FD7E756ECC";
        public const string Logistic = "BFF4A1B2-8D64-4919-A91D-4E96E61E1A5B";
    }

}
