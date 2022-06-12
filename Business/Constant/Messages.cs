using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constant
{
    public static class Messages
    {
        //Success Messages
        public static string EntityAdded = "Entity is successfully added";
        public static string EntityDeleted = "Entity is successfully deleted";
        public static string EntityUpdated = "Entity is successfully updated";
        public static string EntityListing = "Entity is listed";
        public static string EntityFound = "Entity found";
        public static string AccessTokenCreated = "Access token created";
        public static string UserCreated = "User is registered successfully";
        public static string UserDoesNotExist = "User does not exist";
        public static string SuccessfulLogin = "You've Successfully Logged in";
        //Error Messages
        public static string AddError = "Entity is not added";
        public static string CarImageLimitError = "Car image limit per car has exceeded the limit";
        public static string UserAlreadyExists = "There is already a user with that email";
        public static string WrongPassword = "You have entered your password wrong";
        public static string AuthorizationDenied = "Authorization is denied";
    }
}
