using NUnit.Framework;
using System;
using System.Threading;

namespace Rozetka
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [Obsolete]
        public void Browser_Chrome()
        {
            PageElements pageEleements = new PageElements(BrowserFactory.Driver("Chrome"));
            pageEleements.Navigate();
            pageEleements.Search("www.rozetka.com.ua");
            pageEleements.ClickOnLink();
            pageEleements.CloseAdvertisingWindow();
            pageEleements.SearchTextOnPage("Доставка по всій Україні");
            pageEleements.Exit();
        }

        [Test]
        [Obsolete]
        public void Browser_FireFox()
        {
            PageElements pageEleements = new PageElements(BrowserFactory.Driver("FireFox"));
            pageEleements.Navigate();
            pageEleements.Search("www.rozetka.com.ua");
            pageEleements.ClickOnLink();
            pageEleements.CloseAdvertisingWindow();
            pageEleements.SearchTextOnPage("Доставка по всій Україні");
            pageEleements.Exit();
        }
    }
}