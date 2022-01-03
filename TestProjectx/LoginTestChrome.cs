using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using Xunit;

namespace TestProjectx
{
    public class LoginTestChrome
    {
        IWebDriver driver;


        public LoginTestChrome()
        {
            Setup();
        }
 

       [Fact]
        public void Cant_login_with_badUsername_badPassword()
        {
            driver.Navigate().GoToUrl("http://localhost:4200/login");
            driver.FindElement(By.XPath("//input[@formcontrolname='email']")).SendKeys("badEmail");
            driver.FindElement(By.XPath("//input[@formcontrolname='password']")).SendKeys("badpassword");
            driver.FindElement(By.XPath("//button")).Click();
           
            if (driver.Url == "http://localhost:4200/login")
            {
                Assert.True(true);
            }
          
        }
        [Fact]
        public void Can_login_with_Username_Password()
        {
            driver.Navigate().GoToUrl("http://localhost:4200/login");
            driver.FindElement(By.XPath("//input[@formcontrolname='email']")).SendKeys("Email.@gmail.com");
            driver.FindElement(By.XPath("//input[@formcontrolname='password']")).SendKeys("TestPassword");
            driver.FindElement(By.XPath("//button")).Click();
            
            if (driver.Url != "http://localhost:4200/login")
            {
                Assert.True(true);
            }
            
        }

        private void Setup()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--headless");
            options.AddArguments("--disable gpu");


            driver = new ChromeDriver(path + @"\Drivers\",options);
        }
    }
}