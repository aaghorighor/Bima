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
    }

    public static class JwtClaimIdentifiers
    {
        public const string USER_ID = "UserId", USER_NAME = "UserName", FIRST_NAME ="FirstName", LAST_NAME ="LastName",  FULL_NAME ="FullName";
    }

    public static class UserType
    {
        public const string CUSTOMER = "Customer", DRIVER = "Driver", BACKOFFICE = "BackOffice", FRONTOFFICE = "FrontOffice";
    }

}
