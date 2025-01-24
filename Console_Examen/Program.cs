using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_Examen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DeleteFile(System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\debug.log");
            RobotML();
        }

        private static void RobotML()
        {
            IWebDriver driver = new ChromeDriver();
            try
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Url = ConfigurationManager.AppSettings["Url"];
                Thread.Sleep(2000);

                driver.FindElement(By.Id("MX")).Click();
                Thread.Sleep(2000);

                driver.FindElement(By.Id("cb1-edit")).SendKeys("playstation 5");
                Thread.Sleep(2000);


                driver.FindElement(By.ClassName("nav-search-btn")).Click();
                Thread.Sleep(2000);


                //cookie-banner
                driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div/div[2]/button[1]")).Click();
                Thread.Sleep(2000);

                //cookie-banner
                driver.FindElement(By.XPath("/html/body/div[5]/div/div/div[2]/div/div/div[2]/button[2]")).Click();
                Thread.Sleep(2000);

                //Condicion Nuevo
                IWebElement link_new = driver.FindElement(By.XPath("//*[@id=\"root-app\"]/div/div[3]/aside/section[2]/div[4]/ul/li[1]/a"));
                Thread.Sleep(2000);
                link_new.GetAttribute("href");
                if (((OpenQA.Selenium.WebElement)link_new).ComputedAccessibleLabel.Contains("Nuevo"))
                {
                    Thread.Sleep(2000);
                    link_new.Click();
                    Thread.Sleep(2000);
                };
                Thread.Sleep(2000);

                //Ubicacion CDMX
                IWebElement link_CDMX = driver.FindElement(By.XPath("//*[@id=\"root-app\"]/div/div[3]/aside/section[2]/div[11]/ul/li[1]/a"));
                Thread.Sleep(2000);
                link_CDMX.GetAttribute("href");
                if (((OpenQA.Selenium.WebElement)link_CDMX).ComputedAccessibleLabel.Contains("Distrito Federal"))
                {
                    Thread.Sleep(2000);
                    link_CDMX.Click();
                    Thread.Sleep(2000);
                };
                Thread.Sleep(2000);


                driver.FindElement(By.ClassName("ui-search-sort-filter")).Click();
                Thread.Sleep(2000);

                driver.FindElement(By.Id(":R2m55ee:-menu-list-option-price_desc")).Click();
                Thread.Sleep(2000);

                var list = driver.FindElement(By.XPath("//*[@id=\"root-app\"]/div/div[3]/section/ol"));
                Thread.Sleep(2000);

                Console.WriteLine(((OpenQA.Selenium.WebElement)list).Text);

                Thread.Sleep(5000);
                Console.ReadLine();
                driver.Quit();
                driver.Dispose();


                Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");

                foreach (var chromeDriverProcess in chromeDriverProcesses)
                {
                    chromeDriverProcess.Kill();
                }

                Process[] chromeInstances = Process.GetProcessesByName("chrome");

                foreach (Process p in chromeInstances)
                    p.Kill();

            }
            catch (Exception)
            {
                driver.Quit();
                driver.Dispose();
            }
        }

        private static void DeleteFile(string ruta)
        {
            File.Delete(ruta);
        }
    }
}
