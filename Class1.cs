using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.SDK.PageObjects;

namespace Ofakim360Final_1
{
    public class Class1
    {

        public Class1()
        {

            PageFactory.InitElements(Program.driver, this);
        }

        [FindsBy(How = How.Id, Using = "Name")]
        private IWebElement Name;

        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement Email;

        [FindsBy(How = How.Id, Using = "Phone")]
        private IWebElement Phone;

        [FindsBy(How = How.XPath, Using = "/html/body/table/tbody/tr/td[2]/table/tbody/tr[4]/td[1]")]
        private IWebElement FirstRowAddedByMe;

        [FindsBy(How = How.Id, Using = "NameValidationError")]
        private IWebElement validator;










        public void PositiveTestOfSubmit(string Name_txt, string Email_txt, string Phone_txt, IWebDriver driver)
        {
            try
            {

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                driver.Navigate().GoToUrl("https://adamflowlive.000webhostapp.com/");
                driver.Manage().Window.Maximize();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Name));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Email));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Phone));
                Name.SendKeys(Name_txt);
                Email.SendKeys(Email_txt);
                Phone.SendKeys(Phone_txt);
                IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                ((IJavaScriptExecutor)driver).ExecuteScript("$('.submit').click();");
                IWebElement rowAddedElem = driver.FindElement(By.XPath("/html/body/table/tbody/tr/td[2]/table/tbody/tr[4]/td[1]"));
                Assert.AreEqual(rowAddedElem.Get(), Name_txt);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ValidatorTest(string Name_txt, string Email_txt, string Phone_txt, IWebDriver driver)
        {
            try
            {
                Name.SendKeys(Name_txt);
                Email.SendKeys(Email_txt);
                Phone.SendKeys(Phone_txt);
                IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                ((IJavaScriptExecutor)driver).ExecuteScript("$('.submit').click();");
                Assert.assertEquals(true, validator.isDisplayed());
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }




        }

    }
}
