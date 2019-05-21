using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

/// <summary>
/// Visual Studio 的單元測試
/// </summary>
namespace UnitTestProject1
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class VistudioUnitTest
    {
        /// <summary>
        /// 身分驗證
        /// </summary>
        /// <param name="Author"></param>
        /// <param name="Sex"></param>
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void TestMethod1()
        {
            string Author = "Louis";
            string Sex = "Man";
            //檢驗作者名字與性別
            bool result = (Author == "Louis" && Sex == "Man") ? true : false;

            Assert.AreSame(result, true);
        }

    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class WebSeleniumTest
    {
        [TestMethod]
        public void WebButtonCheck()
        {
            Assert.AreEqual(true, new AutoLogin().VerifyLogin());
        }

        /// <summary>
        /// 自動登入的類別
        /// </summary>
        private class AutoLogin
        {
            /// <summary>
            /// 測試登入網頁
            /// </summary>
            private string _url = "https://louislinebot.azurewebsites.net/login";
            /// <summary>
            /// Selenium C# Libary
            /// </summary>
            private IWebDriver driver;
            public AutoLogin()
            {
            }

            /// <summary>
            /// 進行登入
            /// </summary>
            public bool VerifyLogin()
            {
                bool is_Success = false;

                IWebDriver driver = new ChromeDriver();
                //開啟網頁
                driver.Navigate().GoToUrl(_url);
                //隱式等待 - 直到畫面跑出資料才往下執行
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10000);

                //輸入帳號
                IWebElement inputAccount = driver.FindElement(By.Name("Account"));
                Thread.Sleep(2000);
                //清除按鈕
                inputAccount.Clear();
                Thread.Sleep(2000);
                inputAccount.SendKeys("20180513");
                Thread.Sleep(2000);

                //輸入密碼
                IWebElement inputPassword = driver.FindElement(By.Name("Passwrod"));

                inputPassword.Clear();
                Thread.Sleep(2000);
                inputPassword.SendKeys("123456");
                Thread.Sleep(2000);

                //點擊執行
                IWebElement submitButton = driver.FindElement(By.XPath("/html/body/div[2]/form/table/tbody/tr[4]/td[2]/input"));

                Thread.Sleep(2000);
                submitButton.Click();
                Thread.Sleep(2000);

                ///檢查是否登入成功
                IWebElement getResult = driver.FindElement(By.XPath("/html/body/div[2]/form/p"));
                is_Success = getResult.Text.Contains("登入成功") ? true : false;

                driver.Quit();

                return is_Success;
            }

        }
    }

   
}
