using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Configuration;
using Trendyol.Enum;

namespace Trendyol.PageModel
{
    public class TrendyolModel : Driver
    {
        IWebDriver WebApp;

        /// <summary>
        /// Browser parametrik verilerek uygulama açılır.
        /// </summary>
        public void OpenUrl()
        {
            WebApp = SelectBrowser();
            WebApp.Navigate().GoToUrl(ConfigurationSettings.AppSettings["ApplicationUrl"]);
        }

        /// <summary>
        /// Pop-up gelirse kapatır.
        /// </summary>
        public void ClickToClosePopUp()
        {

            IWebElement homePopUp = WebApp.FindElement(By.XPath("//*[@id='ls-global']/div[8]/div/div/a"));
            if (homePopUp != null)
            {
                homePopUp.Click();
            }
        }

        /// <summary>
        /// 'Giriş Yap' butonuna tıklanır
        /// </summary>
        public void ClickToLogin()
        {
            IWebElement btnLogin = WebApp.FindElement(By.XPath("//*[@id='accountNavigationRoot']/div/ul/li[1]"));
            btnLogin.Click();
        }

        /// <summary>
        /// E-mail parametrik olarak xml'den çekilerek setlenir.
        /// </summary>
        /// <param name="mail"></param>
        public void SetToMail(string mail)
        {
            IWebElement txtMail = WebApp.FindElement(By.XPath("//*[@id='email']"));
            txtMail.SendKeys(mail);
        }

        /// <summary>
        /// Password parametrik olarak xml'den çekilerek setlenir.
        /// </summary>
        /// <param name="password"></param>
        public void SetToPassword(string password)
        {
            IWebElement txtPassword = WebApp.FindElement(By.XPath("//*[@id='password']"));
            txtPassword.SendKeys(password);
        }

        /// <summary>
        /// E-Mail ve şifre girildikten sonra Giriş Yap butonuna tıklanır.
        /// </summary>
        public void ClickToSubmit()
        {
            IWebElement btnSubmit = WebApp.FindElement(By.XPath("//*[@id='loginSubmit']"));
            btnSubmit.Click();
        }

        /// <summary>
        /// Her kategoriye tıklayarak butiklerin yüklendiğini kontrol eder. Yüklenmediğinde log basıp devam eder.
        /// </summary>
        public void ButiquesListed()
        {

            for (int index = 1; index < 10; index++)
            {
                try
                {
                    IWebElement mainMenu = WebApp.FindElement(By.Id("item" + index));
                    mainMenu.Click();
                    IWebElement butiqueList = WebApp.FindElement(By.XPath("//*[@id='dynamic-boutiques']/div/div"));
                    bool controlFlag = butiqueList.Enabled;
                }
                catch (System.Exception ex)
                {

                    this.WriteLog(ex.Message);
                }
            }
        }

        /// <summary>
        /// Kadın menüsüne tıklanır.
        /// </summary>
        public void ClickToWomenMenu()
        {
            IWebElement womenMenu = WebApp.FindElement(By.Id("item1"));
            womenMenu.Click();
        }

        /// <summary>
        /// İlk butiğe tıklanır.
        /// </summary>
        public void ClickToWomenBoutique()
        {
            IWebElement womenBoutique = WebApp.FindElement(By.XPath("//*[@id='dynamic-boutiques']/div/div/div[1]"));
            Assert.IsTrue(womenBoutique.Displayed, "Butik yüklenemedi!");
            womenBoutique.Click();
        }

        /// <summary>
        /// İlk ürüne tıklanır.
        /// </summary>
        public void ClickToProduct()
        {
            IWebElement imgProduct = WebApp.FindElement(By.XPath("//*[@id='root']/div/ul/li[1]/div"));
            imgProduct.Click();
        }

        /// <summary>
        /// Ürünün bedeni combosuna tıklanır.
        /// </summary>
        public void SelectToSizeCombo()
        {
            IWebElement cboSize = WebApp.FindElement(By.XPath("//*[@id='product-detail-app']/div/div[2]/div[2]/div[2]/div[2]/div[2]/div/div[2]"));
            cboSize.Click();
        }

        /// <summary>
        /// Ürün bedeni seçilir.
        /// </summary>
        public void SelectToSize()
        {
            IWebElement cboSize = WebApp.FindElement(By.XPath("//*[@id='product-detail-app']/div/div[2]/div[2]/div[2]/div[2]/div[2]/div/div[3]/ul/li[1]"));
            cboSize.Click();
        }

        /// <summary>
        /// Sepete ekle butonuna tıklanır.
        /// </summary>
        public void ClickToAddButton()
        {
            IWebElement btnAdd = WebApp.FindElement(By.XPath("//*[@id='product-detail-app']/div/div[2]/div[2]/div[2]/div[3]/button[1]/div[1]"));
            btnAdd.Click();
        }

        /// <summary>
        /// Sepetim butonuna tıklanır.
        /// </summary>
        public void ClickToBasket()
        {
            IWebElement btnBasket = WebApp.FindElement(By.XPath("//*[@id='myBasketListItem']/div[2]"));
            btnBasket.Click();
        }

        /// <summary>
        /// Sepetin boş olup/olmadığını kontrol eder.Boş ise hata verir.
        /// </summary>
        public void IsBasketEmpty()
        {
            IWebElement lblMessage = WebApp.FindElement(By.XPath("//*[@id='basketNoProductPage']/div[2]/div"));
            Assert.IsFalse(lblMessage.Displayed, "Sepete ürün eklenmedi!");
        }

        /// <summary>
        /// Sepete ürün eklenip/eklenmediğini kontrol eder. Boş ise hata verir.
        /// </summary>
        public void CheckProductInBasket()
        {
            IWebElement productInBasket = WebApp.FindElement(By.XPath("//*[@id='basketContent']"));
            Assert.IsTrue(productInBasket.Displayed, "Sepete ürün eklenmedi!");
        }
    }
}