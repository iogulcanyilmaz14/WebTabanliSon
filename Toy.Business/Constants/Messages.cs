using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Toy.Core.Entities.Concrete;
namespace Toy.Business.Constants
{
   public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists = "Bu isimde zaten başka bir ürün var";
        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string AuthorizationDenied = "Yetkiniz yok.";

        public static string EducationalToyAdded = "Eğitim Oyuncağı Eklendi";
        public static string EducationalToyDeleted = "Eğitim Oyuncağı Silindi";
        public static string EducationalToyUpdated = "Eğitim Oyuncağı Güncellendi";
        public static string EducationalToyNameAlreadyExists = "Bu İsimde Oyuncak Mevcut";

        public static string PlushToyNameAlreadyExists = "Bu İsimde Oyuncak Mevcut";
        public static string PlushToyAdded = "Peluş Oyuncak Eklendi";
        public static string PlushToyDeleted = "Peluş Oyuncak Silindi";
        public static string PlushToyUpdated = "Peluş Oyuncak Güncellendi";

        public static string PuzzleToyAdded = "Puzzle Oyuncağı Eklendi";
        public static string PuzzleToyDeleted = "Puzzle Oyuncağı Silindi";
        public static string PuzzleToyUpdated = "Puzzle Oyuncağı Güncellendi";
        public static string PuzzleToyNameAlreadyExists = "Bu İsimde Oyuncak Mevcut";

        public static string ScienceToyAdded = "Bilim Oyuncağı Eklendi";
        public static string ScienceToyDeleted = "Bilim Oyuncağı Silindi";
        public static string ScienceToyUpdated = "Bilim Oyuncağı Güncellendi";
        public static string ScienceToyNameAlreadyExists = "Bu İsimde Oyuncak Mevcut";

        public static string UserNameAlreadyExists = "Bu İsimde Kullanıcı Mevcut";
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserDeleted = "Kulanıcı Silindi";
        public static string UserUpdated = "Kullanıcı Güncellendi";

        public static string UserRegistered = "Kullanıcı Kaydoldu";
        public static string UserAlreadyExist = "Kayıtlı Kullanıcı Girildi";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserNotFound = "Böyle Bir Kullanıcı Yok";
        public static string PasswordNotMatch = "Şİfre Yanlış";
        public static string AccessTokenCreated = "Token Oluşturuldu";
    }
}
