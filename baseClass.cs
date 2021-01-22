using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;


namespace FlowlifeExc
{
	class Program
	{
		static public IWebDriver driver = new ChromeDriver();
		static Class1 class1 = new Class1();

		public static void Main(string[] args)
		{
			class1.PositiveTestOfSubmit("adam", "adamkeren1@gmail.com", "0505850404", driver);
			class1.ValidatorTest("", "", "", driver);
		}

	}
}