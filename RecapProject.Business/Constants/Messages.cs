using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RecapProject.Business.Constants
{
    public static class Messages
    {
        public static string BrandAdd = "Brand added";
        public static string BrandUpdate = "Brand updated";
        public static string BrandDelete = "Brand deleted";

        public static string CarAdd = "Car added";
        public static string CarUpdate = "Car updated";
        public static string CarDelete = "Car deleted";

        public static string ColorAdd = "Color added";
        public static string ColorUpdate = "Color updated";
        public static string ColorDelete = "Color deleted";

        public static string UserAdd = "User added";

        public static string RentalAdd = "Rental added";

        public static string CarRentedError = "The car must be delivered in order for the car to be rented.";

        public static string RentTimeError = "Return time must be greater than rent time";
        public static string RentAndReturnTimeError = "Return time and rent time must be smaller than now";
    }
}
