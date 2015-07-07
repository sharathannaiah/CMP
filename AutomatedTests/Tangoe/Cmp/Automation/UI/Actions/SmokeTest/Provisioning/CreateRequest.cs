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

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Provisioning
{
    class CreateRequest :BaseActions
    {
        public void CreateRequestt()
        {
            GoToMain("Provisioning");
            //BrowserDriver.Instance.Driver.FindElement(By.Id("mnuProvisionExplorer")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Id("mnuProvisiontCreate")).Click();
            WaitForElement(By.Id("pageTitle"));
            //[selectFrame | CONTENT | ]]
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //      BrowserDriver.Instance.Driver.SwitchTo().Frame("menuFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("createFrame");
            BrowserDriver.Instance.Driver.FindElement(By.LinkText("Key System")).Click();
            Thread.Sleep(5000);

            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //     BrowserDriver.Instance.Driver.SwitchTo().Frame("menuFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("createFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_setup");
            BrowserDriver.Instance.Driver.FindElement(By.Id("addServiceLink")).Click();
            Thread.Sleep(4000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.XPath("(//input[@type='checkbox'])[22]")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Id("bnOK")).Click();
            Thread.Sleep(2000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //      BrowserDriver.Instance.Driver.SwitchTo().Frame("menuFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("createFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame");
            BrowserDriver.Instance.Driver.FindElement(By.Id("reqWiz_nextButton")).Click();
            Thread.Sleep(5000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //    BrowserDriver.Instance.Driver.SwitchTo().Frame("menuFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header");
            //[selectWindow | null | ]]
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderPriorityId"))).SelectByText("Medium");
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderBusinessJustification")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderBusinessJustification")).SendKeys("None");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderSourceId"))).SelectByText("Internal");
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderTicketNumber")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderTicketNumber")).SendKeys("7777777");
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderPONumber")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderPONumber")).SendKeys("5555555");
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderAdditionalInfoName")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderAdditionalInfoName")).SendKeys("sharath");
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderAdditionalInfoValue")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderAdditionalInfoValue")).SendKeys("777");
            BrowserDriver.Instance.Driver.FindElement(By.Id("bnAddAdditionalInfo")).Click();
            Thread.Sleep(2000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectFrame | CONTENT | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [selectFrame |  | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [selectFrame |  | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //      BrowserDriver.Instance.Driver.SwitchTo().Frame("menuFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header");
            BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookuppm2HeaderOrgEntityId")).Click();
            //[selectWindow | CMP_DIALOG_FRAME | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Name("entityName")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("entityName")).SendKeys("ACS");
            BrowserDriver.Instance.Driver.FindElement(By.Name("queryEntityButton")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Id("returnButtonIds")).Click();
            Thread.Sleep(2000);
            //[selectWindow | EditFrame | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //       BrowserDriver.Instance.Driver.SwitchTo().Frame("menuFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header");
            BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookuppm2HeaderPrimaryContactId")).Click();
            Thread.Sleep(2000);
            //[selectWindow | CMP_DIALOG_FRAME | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Name("queryContactsButton")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).Click();
            Thread.Sleep(2000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //     BrowserDriver.Instance.Driver.SwitchTo().Frame("menuFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header");

            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderVendorId"))).SelectByText("AT&T");
            BrowserDriver.Instance.Driver.FindElement(By.XPath("(//input[@name='pm2HeaderBillingType'])[2]")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Id("costCenterAddButton")).Click();
            Thread.Sleep(2000);
            //[selectWindow | CMP_DIALOG_FRAME | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");

            BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookupeditCostCenterId")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");

            BrowserDriver.Instance.Driver.FindElement(By.Name("costCenterName")).SendKeys("Trane");
            BrowserDriver.Instance.Driver.FindElement(By.Name("queryCostCentersButton")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");


            BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Id("cca_saveButton")).Click();
            Thread.Sleep(2000);

            BrowserDriver.Instance.Driver.FindElement(By.Id("cca_okButton")).Click();

            //[selectWindow | editFrame | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //      BrowserDriver.Instance.Driver.SwitchTo().Frame("menuFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header");
            BrowserDriver.Instance.Driver.FindElement(By.Id("reqWiz_nextButton")).Click();
            Thread.Sleep(5000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //          BrowserDriver.Instance.Driver.SwitchTo().Frame("menuFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_EQUIPMENT");

            BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookuppm2VendorContactId")).Click();
            Thread.Sleep(2000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");

            BrowserDriver.Instance.Driver.FindElement(By.Name("queryContactsButton")).Click();
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).Click();
            Thread.Sleep(2000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_EQUIPMENT");
            BrowserDriver.Instance.Driver.FindElement(By.Id("dtControlpm2DueDate")).SendKeys("07/07/2015");


            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("ddl_pm2BusinessUnitLuid"))).SelectByText("srd1");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("pm2ManufacturerId"))).SelectByText("Unknown/Other");
            BrowserDriver.Instance.Driver.FindElement(By.CssSelector("option[value=\"11100\"]")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.FindElement(By.XPath("(//input[@name='pm2ShipToTypeId'])[2]")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookuppm2ShipToContactId")).Click();
            Thread.Sleep(2000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");

            BrowserDriver.Instance.Driver.FindElement(By.Name("queryContactsButton")).Click();
            Thread.Sleep(2000);

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");

            BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).Click();
            Thread.Sleep(2000);


            //[selectWindow | null | ]] Fill in the template details
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_EQUIPMENT");
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryAddress1")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryAddress1")).SendKeys("123");
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryAddress2")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryAddress2")).SendKeys("456");
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryAddress3")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryAddress3")).SendKeys("789");
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryCity")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryCity")).SendKeys("Bangalore");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryCountryId"))).SelectByText("United States");
            Thread.Sleep(3000);
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryZip")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryZip")).SendKeys("560001");


            //[selectWindow | reqWizFrame_header | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header");

            BrowserDriver.Instance.Driver.FindElement(By.Id("reqWiz_nextButton")).Click();
            Thread.Sleep(2000);


            //[selectWindow | Equipment 2 | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_EQUIPMENT");

            BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookuppm2VendorContactId")).Click();
            Thread.Sleep(2000);
            // [selectWindow | CMP_DIALOG_FRAME | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Name("queryContactsButton")).Click();
            Thread.Sleep(2000);

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).Click();
            Thread.Sleep(2000);

            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_EQUIPMENT");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("ddl_pm2BusinessUnitLuid"))).SelectByText("srd1");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("pm2ManufacturerId"))).SelectByText("Unknown/Other");
            BrowserDriver.Instance.Driver.FindElement(By.CssSelector("option[value=\"11100\"]")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.XPath("(//input[@name='pm2ShipToTypeId'])[2]")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookuppm2ShipToContactId")).Click();
            Thread.Sleep(2000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Name("queryContactsButton")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_EQUIPMENT");

            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryAddress1")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryAddress1")).SendKeys("123");
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryAddress2")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryAddress2")).SendKeys("456");
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryAddress3")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryAddress3")).SendKeys("678");
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryCity")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryCity")).SendKeys("Bangalore");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryCountryId"))).SelectByText("United States");
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryZip")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryZip")).SendKeys("560097");
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header");

            BrowserDriver.Instance.Driver.FindElement(By.Id("reqWiz_nextButton")).Click();
            Thread.Sleep(5000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame");
            Thread.Sleep(5000);
            //       BrowserDriver.Instance.Driver.FindElement(By.CssSelector("div[title=\"Key System(Qty:1)\"]")).Click();
            Assert.AreEqual("Key System(Qty:1)", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("div[title=\"Key System(Qty:1)\"]")).Text);
            //driver.FindElement(By.CssSelector("div[title=\"PC Hardware(Qty:1)\"]")).Click();
            Assert.AreEqual("PC Hardware(Qty:1)", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("div[title=\"PC Hardware(Qty:1)\"]")).Text);
            BrowserDriver.Instance.Driver.FindElement(By.Id("generateOrder_sendButton")).Click();
            Thread.Sleep(3000);
            IAlert alert = BrowserDriver.Instance.Driver.SwitchTo().Alert();
            alert.Accept();

            Console.WriteLine("Provisioning Request Created Successfully");

        }

    }
}
