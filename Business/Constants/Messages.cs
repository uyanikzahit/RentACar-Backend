using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        //System Messages
        public static string MaintenanceTime = "Sistem Bakımda.";
        
        //Car Messages
        public static string CarAdded = "Araba Eklendi";
        public static string CarDeleted = "Araba Silindi";
        public static string CarUpdated = "Araba Güncellendi";
        public static string CarNameInvalid = "Araba İsmi Geçersiz";
        public static string CarsListed = "Arabalar Listelendi";
        public static string CarListed = "Araba Listelendi";
        public static string CarDetailsListed = "Araba Detayları Listelendi";

        //Brand Messages
        public static string BrandAdded = "Marka Eklendi";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandUpdated = "Marka Güncellendi";
        public static string BrandNameInvalid = "Marka İsmi geçersiz";
        public static string BrandsListed = "Markalar Listelendi";
        public static string BrandListed = "Marka Listelendi";

        //Color Messages
        public static string ColorAdded = "Renk Eklendi";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorUpdated = "Renk Güncellendi";
        public static string ColorsListed = "Renkler Listelendi";
        public static string ColorListed = "Renk Listelendi";

        //Rental Messages
        public static string RentalAdded = "Kiralama Eklendi.";
        public static string RentalDeleted = "Kiralama Silindi.";
        public static string RentalUpdated = "Kiralama Güncellendi.";
        public static string RentalsListed = "Kiralamalar Listelendi.";
        public static string RentalListed = "Kiralama Listelendi.";
        public static string RentalCarError = "Araç Kiralanamaz.";

        //Customer Messages
        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerUpdated = "Müşteri Güncellendi"; 
        public static string CustomersListed = "Müşteriler Listelendi";
        public static string CustomerListed = "Müşteri Listelendi";

        //User Messages
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string UsersListed = "Kullanıcılar Listelendi";
        public static string UserListed = "Kullanıcı Listelendi";

        //CarImage Messages
        public static string CarImageLimit = "Bir arabaya beşten fazla resim eklenemez";
        public static string CarImageDeleted = "Resim silindi";
        public static string CarImageUpdated = "Resim güncellendi";
        public static string CarImageAdded = "Resim eklendi";

        //Process Messages
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı Giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}
