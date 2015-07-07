using AutomatedTests.Tangoe.Cmp.Automation.Common;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Abstract;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Driver.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Enterprise
{
    class EntityTypes :BaseActions
    {
        public void EntityType()
        {
            BrowserDriver.Instance.Driver.FindElement(By.Id("menuMainEnterprise")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Id("mnuEnterprise_Types")).Click();
            Thread.Sleep(2000);
            //Create Entity Type 
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("POPUP_CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.Id("ttab2")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Id("frmName")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("frmName")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.typeName));
            BrowserDriver.Instance.Driver.FindElement(By.Id("frmDescription")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("frmDescription")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.typeDescription));
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("POPUP_CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='CreateEntityTypeForm']/div[2]/input[1]")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            //Modify Entity Type
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("POPUP_CONTENT");
            Assert.AreEqual("Name", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='Name']")).Text);
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='Name']")), "Creation of Entity Type failed ");
            Console.WriteLine("Entity Type Added Successfully");
            BrowserDriver.Instance.Driver.FindElement(By.Name("frmName")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("frmName")).SendKeys("S-2");
            BrowserDriver.Instance.Driver.FindElement(By.Name("frmDescription")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("frmDescription")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.typeDescription));
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='CreateEntityTypeForm']/div[2]/input[2]")).SendKeys(Keys.Enter);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("POPUP_CONTENT");
            Assert.AreEqual("S-2", BrowserDriver.Instance.Driver.FindElement(By.Name("frmName")).Text);
            Assert.IsTrue(IsElementVisible(By.Name("frmName")), "Modification of Entity Type failed ");
            Console.WriteLine("Entity Type modified successfully");
            //Delete Entity Type
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("POPUP_CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='ttab1']/form[2]/input[4]")).Click();
            Thread.Sleep(2000);
            Console.WriteLine("Entity deleted Successfully");
            BrowserDriver.Instance.Driver.FindElement(By.Name("frmCancel")).SendKeys(Keys.Enter);

        }
    }
}
