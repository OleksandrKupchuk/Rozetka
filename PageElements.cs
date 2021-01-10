using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using Selenium.Community.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using NUnit.Framework;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;
using System.Collections.Generic;

namespace Rozetka
{
    class PageElements
    {
        private IWebDriver driver;
        private string url = "https://www.google.com.ua/";
        private WebDriverWait wait;

        public PageElements(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement ElementSearchText { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".cfxYMc.JfZTW.c4Djg.MUxGbd.v0nnCb")]
        private IWebElement LinkWebSite { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".exponea-close.a_dma_christmas_231220 ")]
        private IWebElement ButtonClose { get; set; }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }

        public void Search(string textToType)
        {
            ElementSearchText.Clear();
            ElementSearchText.SendKeys(textToType + Keys.Enter);
        }

        public void ClickOnLink()
        {
            LinkWebSite.Click();
        }

        [Obsolete]
        public void CloseAdvertisingWindow()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".exponea-close.a_dma_christmas_231220 ")));
            ButtonClose.Click();
        }

        public void SearchTextOnPage(string text)
        {
            CheckExistenceTextOnPage(driver.PageSource.Contains(text), text);
            string textOnPage = driver.PageSource.ToString();
            Console.WriteLine(textOnPage);
        }

        private void CheckExistenceTextOnPage(bool textExistence, string text)
        {
            if (textExistence)
            {
                Console.WriteLine($"Текст знайдений = {text}");
            }

            else
            {
                Console.WriteLine($"Нажаль даний текст '{text}' не знайдено");
            }
        }

        public void Exit()
        {
            driver.Quit();
        }
    }
}
