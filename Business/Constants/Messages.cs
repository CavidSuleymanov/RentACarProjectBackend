using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarNameInvalid = "Araba ismi gecersiz";
        public static string CarAdded = "Araba eklendi";
        public static string CarPriceInvalid = "Araba gunluk fiyati 0-dan buyuk olmalidir";
        internal static string AddedCarErrorNameisColor="Boyle Araba zaten var";

        public static string AddedRentalErrorRentedCar="Araba kirayelenmis";
        public static string AddedRental="Araba kirayelendi";
        public static string AuthorizationDenied="Yetkin yok";
        public static string UserNotFound="kullanici bulunamadi";
        public static string PasswordError="Parola Hatasi";
        public static string SuccessfulLogin = "Giris yapildi";
        public static string UserAlreadyExists="Kullanici Mevcut";
        public static string AccessTokenCreated="Token Olusturuldu";
        public static string UserRegistered="kullanici eklendi";
		public static string UserGetAll = "All Users Listed!";
	}
}
