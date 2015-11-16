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
using AutomatedTests.CMP.Enterprise;

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Enterprise
{
    class EntityTypes :BaseActions
    {


        public void EntityTypesFunctionality()
        {
            GoToMain1("Enterprise", "Types");

            CreateType();

            ModifyType();

            DeleteType();

            Console.WriteLine("Entity Types passed Smoke Test Successfully");

        }
        public void CreateType()
        {

            popupframe();
            javascriptClick(By.Id("ttab2"));
            Thread.Sleep(2000);
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('frmName').value='Aut1'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('frmDescription').value='Automated Description of Types'");
            javascriptClick(By.XPath(Enterp.Default.CreateB));
            Thread.Sleep(3000);
            popupframe();
        //    Assert.AreEqual("Auto1", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("div[title=\"Auto1\"]")).Text);
            
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='Aut1']")), "Creation of Entity Type failed ");
            
            Console.WriteLine("New Entity Type Created Successfully");


        }

        public void ModifyType()
        {
           // javascriptClick(By.XPath(Enterp.Default.ModifyB));
          //  Thread.Sleep(2000);
            popupframe();
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='Aut1']")).Click();
            Thread.Sleep(2000);
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('frmName')[0].value='auto2'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('frmDescription')[0].value='Modified Description of Types'");
            javascriptClick(By.XPath(Enterp.Default.ModifyB));
            Thread.Sleep(2000);
            popupframe();
            javascriptClick(By.XPath("//div[.='auto2']"));
           // Thread.Sleep(2000);
            popupframe();
        //    Assert.AreEqual("Auto2", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("div[title=\"Auto2\"]")).Text);
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='auto2']")), "Modification of Entity Type failed ");

            Console.WriteLine("Entity Type Modified Successfully");

        }

        public void DeleteType()
        {

            javascriptClick(By.XPath("//div[.='auto2']"));
            Thread.Sleep(2000);
            popupframe();
            javascriptClick(By.XPath(Enterp.Default.DeleteB));
            Thread.Sleep(2000);
            popupframe();
            Assert.IsFalse(IsElementVisible(By.XPath("//div[.='auto2']")), "Modification of Entity Type failed ");
//            Assert.AreNotEqual("Auto2", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("div[title=\"1-1\"]")).Text);
            Console.WriteLine("Entity deleted Successfully");
            javascriptClick(By.XPath(Enterp.Default.CancelB));


        }
        //public void EntityType()
        //{
        //    BrowserDriver.Instance.Driver.FindElement(By.Id("menuMainEnterprise")).Click();
        //    BrowserDriver.Instance.Driver.FindElement(By.Id("mnuEnterprise_Types")).Click();
        //    Thread.Sleep(2000);
        //    //Create Entity Type 
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
        //    BrowserDriver.Instance.Driver.SwitchTo().Frame("POPUP_CONTENT");
        //    BrowserDriver.Instance.Driver.FindElement(By.Id("ttab2")).Click();
        //    BrowserDriver.Instance.Driver.FindElement(By.Id("frmName")).Clear();
        //    BrowserDriver.Instance.Driver.FindElement(By.Id("frmName")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.typeName));
        //    BrowserDriver.Instance.Driver.FindElement(By.Id("frmDescription")).Clear();
        //    BrowserDriver.Instance.Driver.FindElement(By.Id("frmDescription")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.typeDescription));
        //    BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
        //    BrowserDriver.Instance.Driver.SwitchTo().Frame("POPUP_CONTENT");
        //    BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='CreateEntityTypeForm']/div[2]/input[1]")).SendKeys(Keys.Enter);
        //    Thread.Sleep(2000);
        //    //Modify Entity Type
        //    BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
        //    BrowserDriver.Instance.Driver.SwitchTo().Frame("POPUP_CONTENT");
        //    Assert.AreEqual("Name", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='Name']")).Text);
        //    Assert.IsTrue(IsElementVisible(By.XPath("//div[.='Name']")), "Creation of Entity Type failed ");
        //    Console.WriteLine("Entity Type Added Successfully");
        //    BrowserDriver.Instance.Driver.FindElement(By.Name("frmName")).Clear();
        //    BrowserDriver.Instance.Driver.FindElement(By.Name("frmName")).SendKeys("S-2");
        //    BrowserDriver.Instance.Driver.FindElement(By.Name("frmDescription")).Clear();
        //    BrowserDriver.Instance.Driver.FindElement(By.Name("frmDescription")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.typeDescription));
        //    BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='CreateEntityTypeForm']/div[2]/input[2]")).SendKeys(Keys.Enter);
        //    BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
        //    BrowserDriver.Instance.Driver.SwitchTo().Frame("POPUP_CONTENT");
        //    Assert.AreEqual("S-2", BrowserDriver.Instance.Driver.FindElement(By.Name("frmName")).Text);
        //    Assert.IsTrue(IsElementVisible(By.Name("frmName")), "Modification of Entity Type failed ");
        //    Console.WriteLine("Entity Type modified successfully");
        //    //Delete Entity Type
        //    BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
        //    BrowserDriver.Instance.Driver.SwitchTo().Frame("POPUP_CONTENT");
        //    BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='ttab1']/form[2]/input[4]")).Click();
        //    Thread.Sleep(2000);
        //    Console.WriteLine("Entity deleted Successfully");
        //    BrowserDriver.Instance.Driver.FindElement(By.Name("frmCancel")).SendKeys(Keys.Enter);

        //}

        public void popupframe()
        {
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
        //    BrowserDriver.Instance.Driver.SwitchTo().Frame("POPUP_BANNER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("POPUP_CONTENT");


        }


        
    }
}
