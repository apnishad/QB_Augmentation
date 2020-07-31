using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentUiTest
{
    [TestFixture]
    public class AppointmentUiTest
    {
        IWebDriver iwd = null;
        
        [SetUp]
        public void Initialize()
        {
            iwd = new ChromeDriver();
            iwd.Navigate().GoToUrl(@"http://localhost:51098/Home/Index");
            iwd.FindElement(By.XPath(@"/html/body/div[2]/div/a")).Click();
        }

        [Test]
        public void Booking_Validation_error_check()
        {
            iwd.FindElement(By.XPath(@"/html/body/div[2]/form/div/div[7]/div/input")).Click();
            string actualerror = iwd.FindElement(By.XPath(@"/html/body/div[2]/form/div/div[2]/div/span")).Text;
            Assert.AreEqual("Please enter first name.", actualerror);
            actualerror = iwd.FindElement(By.XPath(@"/html/body/div[2]/form/div/div[3]/div/span")).Text;
            Assert.AreEqual("Please enter middle name.", actualerror);
            actualerror = iwd.FindElement(By.XPath(@"/html/body/div[2]/form/div/div[4]/div/span")).Text;
            Assert.AreEqual("Please enter last name.", actualerror);
            actualerror = iwd.FindElement(By.XPath(@"/html/body/div[2]/form/div/div[5]/div/span")).Text;
            Assert.AreEqual("Please select gender.", actualerror);
            actualerror = iwd.FindElement(By.XPath(@"/html/body/div[2]/form/div/div[6]/div/span")).Text;
            Assert.AreEqual("Please enter mobile no.", actualerror);
            actualerror = iwd.FindElement(By.XPath(@"/html/body/div[2]/form/div/div[7]/div/span")).Text;
            Assert.AreEqual("Please select appointment date.", actualerror);
        }

        [Test]
        public void Booking_Success_check()
        {
            iwd.FindElement(By.XPath(@"/html/body/div[2]/form/div/div[1]/div/input")).SendKeys("Somesh");
            iwd.FindElement(By.XPath(@"/html/body/div[2]/form/div/div[2]/div/input")).SendKeys("Tushar");
            iwd.FindElement(By.XPath(@"/html/body/div[2]/form/div/div[3]/div/input")).SendKeys("Wagh");
            iwd.FindElement(By.XPath(@"/html/body/div[2]/form/div/div[4]/div/input")).SendKeys("Male");
            iwd.FindElement(By.XPath(@"/html/body/div[2]/form/div/div[5]/div/input")).SendKeys("+91 9900887766");
            iwd.FindElement(By.XPath(@"/html/body/div[2]/form/div/div[6]/div/input")).SendKeys("7/31/2020");
            iwd.FindElement(By.XPath(@"/html/body/div[2]/form/div/div[7]/div/input")).Click();
            var pname = iwd.FindElement(By.XPath(@"/html/body/div[2]/p[1]/b[1]")).Text;
            Assert.AreEqual("Ram Naresh Verma", pname);
            var id = iwd.FindElement(By.XPath(@"/html/body/div[2]/p[1]/b[2]")).Text;
            Assert.AreEqual("1", id);
            var date = iwd.FindElement(By.XPath(@"/html/body/div[2]/p[2]/b[1]")).Text;
            Assert.AreEqual("7/27/2020", date);
            var time = iwd.FindElement(By.XPath(@"/html/body/div[2]/p[2]/b[2]")).Text;
            Assert.AreEqual("10:00 AM", time);
        }

        [Test]
        public void mobile_Validation_error_check() {
            iwd.FindElement(By.XPath(@"/html/body/div[2]/form/div/div[5]/div/input")).SendKeys("9089898");
            iwd.FindElement(By.XPath(@"/html/body/div[2]/form/div/div[7]/div/input")).Click();
            string actualerror = iwd.FindElement(By.XPath(@"/html/body/div[2]/form/div/div[2]/div/span")).Text;
            Assert.AreEqual("Please enter first name.", actualerror);
            actualerror = iwd.FindElement(By.XPath(@"/html/body/div[2]/form/div/div[3]/div/span")).Text;
            Assert.AreEqual("Please enter middle name.", actualerror);
            actualerror = iwd.FindElement(By.XPath(@"/html/body/div[2]/form/div/div[4]/div/span")).Text;
            Assert.AreEqual("Please enter last name.", actualerror);
            actualerror = iwd.FindElement(By.XPath(@"/html/body/div[2]/form/div/div[5]/div/span")).Text;
            Assert.AreEqual("Please select gender.", actualerror);
            actualerror = iwd.FindElement(By.XPath(@"/html/body/div[2]/form/div/div[6]/div/span")).Text;
            Assert.AreEqual("Please enter valid mobile no.[+91 0000000000]", actualerror);
            actualerror = iwd.FindElement(By.XPath(@"/html/body/div[2]/form/div/div[7]/div/span")).Text;
            Assert.AreEqual("Please select appointment date.", actualerror);
        }

        

        [TearDown]
        public void DeInitialize() {
            iwd.Quit();
        }
    }
}
