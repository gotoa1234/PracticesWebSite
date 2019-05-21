using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject2
{
    /// <summary>
    /// TestFixtrue 可以塞入初始參數
    /// </summary>
    [TestFixture("Louis", 1988)]
    public class NUnitTest
    {
        private string _name;
        private int _birth;

        public NUnitTest(string name , int birth)
        {
            this._name = name;
            this._birth = birth;
        }

        [Test]
        public void TestMethod1()
        {
            //驗證是否是本人
            bool is_Success = (_name == "Louis" && _birth == 1988 )? true : false;
            Assert.True(is_Success);
        }
    }

    public class WebSeleniumTest
    {
        [Test]
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
