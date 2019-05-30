using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using Trendyol.Enum;
using Trendyol.PageModel;

namespace Trendyol.Test
{
    [TestFixture]
    class TrendyolTest : XmlReader
    {
        [Test]
        public void LaunchTrendyol()
        {
            TrendyolModel trendyolModel = new TrendyolModel();
            trendyolModel.OpenUrl();//Trendyol Sayfasına girilir
            trendyolModel.ClickToClosePopUp();//Pop-up gelirse tıkanıp, kapatılır.
            trendyolModel.ClickToLogin();//Giriş Yap butonuna tıklanır.
            trendyolModel.SetToMail(Reader("mail")[0]);//Mail adresi belirtilir.
            trendyolModel.SetToPassword(Reader("password")[0]);//Şifre girilir.
            trendyolModel.ClickToSubmit();//Giriş Yap butonuna tıklanır.
            trendyolModel.ButiquesListed();//Her taba tıklayarak, butikler yüklendi mi kontrolü yapılır. yüklenmediğinde log basılır.
            trendyolModel.ClickToWomenMenu();//Kadın menüsüne tıklanır.
            trendyolModel.ClickToWomenBoutique();//İlk butiğe tıklanır.
            trendyolModel.ClickToProduct();//İlk ürüne tıklanır.
            trendyolModel.SelectToSizeCombo();//Ürünün bedeni combosuna tıklanır.
            trendyolModel.SelectToSize();//Ürün bedeni seçilir.
            trendyolModel.ClickToAddButton();//Sepete ekle butonuna tıklanır.
            trendyolModel.ClickToBasket();//Sepetim butonuna tıklanır.
            trendyolModel.IsBasketEmpty();//Sepetin boş olup/olmadığını kontrol eder.
            trendyolModel.CheckProductInBasket();//Sepete ürün eklenip/eklenmediğini kontrol eder.
        }
    }
}
