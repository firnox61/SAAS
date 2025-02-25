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
       
        public static string CustomerNot = "Müşteri bulunamadı";

       
        public static string HataSonuc="Hatalı işlem";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "pasaword hatalı";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz Yok";
        public static string TarihHata = "Bu tarihlerde Araç Dolu";
        public static string TarihUygun="Bu tarih aralğı uygun";
        public static string PaymentDelete="Ödeme Silindi.";


        public static string UserRegistered = "Kullanıcı kayıt oldu";

        public static string SuccessfulLogin = "Başarılı kayıt";
        public static string UserAlreadyExists = "kullanıcı mevcut";

        public static string SuccessfulLog = "Başarılı bir giriş yapıldı";
       
        public static string CustomerGet = "Müşteri getirildi";
        public static string CustomerUpdate = "Müşteri güncellendi";
        public static object BuyError="Kart bilgilerinde hata var kontrol ediniz";
        public static string UserInfo="Kullanıcı Bilgiler;";
        public static string UserUpdate="Kullanıcı bilgileri güncellendi";
    }
}
