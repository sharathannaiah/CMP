
using AutomatedTests.Tangoe.Cmp.Automation.Common;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Driver.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using AutomatedTests.CMP.Inventory;
using AutomatedTests.CMP.Admin;

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Abstract
{
    abstract class BaseActions : IBaseAction
    {
        #region Test Execution Mode

        private ExecutionMode testExecutionMode;

        public void SetExecutionMode(ExecutionMode mode)
        {
            this.testExecutionMode = mode;
        }

        protected bool IsFATMode()
        {
            return testExecutionMode.Equals(ExecutionMode.FAT);
        }

        protected bool IsPATMode()
        {
            return testExecutionMode.Equals(ExecutionMode.PAT);
        }

        protected bool IsPATAndFATMode()
        {
            return testExecutionMode.Equals(ExecutionMode.PAT_AND_FAT);
        }

        #endregion

        #region Common Wait Methods

        /// <summary>
        /// find webelement depending on provided locator and return WebElement 
        /// </summary>
        /// <param name="by">Locator type</param>
        /// <returns>webelement</returns>
        public IWebElement FindElement(By by)
        {
            return BrowserDriver.Instance.Driver.FindElement(by);
        }

        /// <summary>
        /// Waits for an element to be present on the page
        /// </summary>
        /// <param name="by">Defines how to find the element on the UI</param>
        protected void WaitForElement(By by)
        {
            int timeout = TestProperties.Instance.GetTimeoutSeconds();
            WebDriverWait wait = new WebDriverWait(BrowserDriver.Instance.Driver, TimeSpan.FromSeconds(timeout));
            wait.Until<IWebElement>((d) => { return d.FindElement(by); });
            Thread.Sleep(500);
        }

        /// <summary>
        /// Wait for element not to present on UI
        /// </summary>
        /// <param name="by">Defines how to wait for displayed element to disappear</param>
        public void WaitForElementNotPresent(By by)
        {
            int timeout = TestProperties.Instance.GetTimeoutSeconds();
            WebDriverWait wait = new WebDriverWait(BrowserDriver.Instance.Driver, TimeSpan.FromSeconds(timeout));
            wait.Until<bool>((d) =>
            {
                return !d.FindElement(by).Displayed;
            });
        }

        /// <summary>
        /// Wait for UI Busy (loading symbol) to disappear
        /// </summary>
        public void WaitForUIBusyToDisappear()
        {
            int timeout = TestProperties.Instance.GetTimeoutSeconds();
            WebDriverWait wait = new WebDriverWait(BrowserDriver.Instance.Driver, TimeSpan.FromSeconds(timeout));
            wait.Until<bool>((d) =>
            {
                try
                {
                    // If the find succeeds, the element exists, and
                    // we want the element to *not* exist, so we want
                    // to return true when the find throws an exception.
                    IWebElement element = d.FindElement(By.XPath("(//div[contains(@class, 'ui-busy')])[1]"));
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
        }

        /// <summary>
        /// Waits for an element to be present on the page. Use a parameter passed in for wait time.
        /// </summary>
        /// <param name="by">Defines how to find the element on the UI</param>
        /// <param name="waitTimeInSeconds"></param>Time to wait in seconds
        protected void WaitForElementWithParameter(By by, int waitTimeInSeconds)
        {
            int timeout = waitTimeInSeconds; // to seconds.
            WebDriverWait wait = new WebDriverWait(BrowserDriver.Instance.Driver, TimeSpan.FromSeconds(timeout));
            wait.Until<IWebElement>((d) => { return d.FindElement(by); });
            Thread.Sleep(500);
        }

        /// <summary>
        /// Waits for text to be present in the page body.
        /// </summary>
        /// <param name="Text">String to look for.
        /// <param name="WaitTime">How long to wait for.
        /// <returns>True if string present, false othewise</returns>
        /// 
        protected bool WaitForTextNotPresent(string Text, int WaitTime)
        {
            //Console.WriteLine("         Wait for text '{0}'", Text);
            var startTime = DateTime.UtcNow;
            while (DateTime.UtcNow - startTime < TimeSpan.FromSeconds(WaitTime))
            {
                //Console.WriteLine("         Wait Loop", Text);
                if (!PageBodyContainsText(Text))
                {
                    //Console.WriteLine("         Text '{0}' found.", Text);
                    return true;
                }
            }
            //Console.WriteLine("         Text '{0}' not found.", Text);
            return false;
        }

        /// <summary>
        /// Waits for text to be present in the page body.
        /// </summary>
        /// <param name="Text">String to look for.
        /// <param name="WaitTime">How long to wait for.
        /// <returns>True if string present, false othewise</returns>
        /// 
        protected bool WaitForTextPresent(string Text, int WaitTime)
        {
            //Console.WriteLine("         Wait for text '{0}'", Text);
            var startTime = DateTime.UtcNow;
            while (DateTime.UtcNow - startTime < TimeSpan.FromSeconds(WaitTime))
            {
                //Console.WriteLine("         Wait Loop", Text);
                if (PageBodyContainsText(Text))
                {
                    //Console.WriteLine("         Text '{0}' found.", Text);
                    return true;
                }
            }
            //Console.WriteLine("         Text '{0}' not found.", Text);
            return false;
        }

        /// <summary>
        /// Wait for element to be visible
        /// </summary>
        /// <param name="by">Defines how to wait for element to be visible on the UI</param>
        public void WaitForElementToVisible(By by)
        {
            int timeout = TestProperties.Instance.GetTimeoutSeconds();
            WebDriverWait wait = new WebDriverWait(BrowserDriver.Instance.Driver, TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.ElementIsVisible(by));//Wait until the element is visible
            Thread.Sleep(600);
        }

        /// <summary>
        /// Wait for text to appear in supplied text field. If no text is supplied as second parameter then it waits til text appears in textbox
        /// If text supplies then it will wait till supplied text exactly matched
        /// </summary>
        /// <param name="by">Locator for text field</param>
        /// <param name="text">Optional. Text to wait</param>
        public void WaitForTextToAppearInTextBox(By by, string text = null)
        {
            int timeout = TestProperties.Instance.GetTimeoutSeconds();
            WebDriverWait wait = new WebDriverWait(BrowserDriver.Instance.Driver, TimeSpan.FromSeconds(timeout));

            if (text == null)
                wait.Until(d => d.FindElement(by).GetAttribute("value") != "");
            else
                wait.Until(d => d.FindElement(by).GetAttribute("value").Equals(text));
        }

        /// <summary>
        /// This method will wait for element to visible on Next Page. This is will help in when we are navigating to another page,
        /// or click on 'Add' button and waiting for Add page to displayed
        /// </summary>
        /// <param name="by">Locator name</param>
        /// <param name="message">Optional. Message to be displayed, if element is not available</param>
        public void WaitForElementOnNextPage(By by, string message = "")
        {
            int timeout = TestProperties.Instance.GetTimeoutSeconds();
            try
            {
                WebDriverWait wait = new WebDriverWait(BrowserDriver.Instance.Driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementIsVisible(by));//Wait until the element is visible
            }
            catch (WebDriverTimeoutException e)
            {
                throw new WebDriverTimeoutException(message);
            }
        }

        /// <summary>
        /// Wait for element to be displayed and Enabled. This method is useful when we need to click on any button's or hyperlinks.
        /// Before clicking use this method and then perform click operation
        /// </summary>
        /// <param name="by">Locatore query</param>
        public void WaitForElementPresentAndEnabled(By by)
        {
            int timeout = TestProperties.Instance.GetTimeoutSeconds();
            WebDriverWait wait = new WebDriverWait(BrowserDriver.Instance.Driver, TimeSpan.FromSeconds(timeout));
            wait.Until<IWebElement>((d) =>
            {
                IWebElement element = BrowserDriver.Instance.Driver.FindElement(by);
                if (element.Displayed && element.Enabled) 
                   
                {
                    return element;
                }

                return null;
            });
        }

        /// <summary>
        /// Wait for table data to appear on UI. This method checks if table contains no data by checking the no data text(text may change for different screens)
        /// If no data text is not present then it waits for record found text (this text is different for different screens
        /// </summary>
        /// <param name="textOfWhenNoDataFound">Text of when no data lists in table</param>
        /// <param name="textOfDataRecordsFound">Text of records found header when table has data</param>
        public void WaitForTableDataToAppear(string textOfWhenNoDataFound, string textOfDataRecordsFound)
        {
            if (!PageBodyContainsText(textOfWhenNoDataFound))
            {
                WaitForElementToVisible(By.XPath("//span[contains(text(), '" + textOfDataRecordsFound + "')]"));
            }
        }

        /// <summary>
        /// See if string passed to this method is found in the body text.
        /// </summary>
        /// <param name="TextToFind"></param>
        public bool PageBodyContainsText(string TextToFind)
        {
            IWebElement bodyTag = BrowserDriver.Instance.Driver.FindElement(By.TagName("body"));
            return bodyTag.Text.Contains(TextToFind);
        }

        /// <summary>
        /// Verifies if the element is visible and enabled
        /// </summary>
        /// <param name="by">Defines how to find the element on the UI</param>
        /// <returns>True if the element is visible and enabled, false othewise</returns>
        public bool IsElementVisible(By by)
        {
            try
            {
                // Is the element on the HTML code?
                IWebElement element = BrowserDriver.Instance.Driver.FindElement(by);
                // the element is displayed & enabled for the user?
                return element.Displayed && element.Enabled;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Method to check whether element contains attribute or not
        /// </summary>
        /// <param name="by">Locator Id</param>
        /// <param name="attribute">Attribute Name</param>
        /// <returns>if attribut is present it returns 'True' else return 'False'</returns>
        public bool isAttribtuePresent(By by, string attribute)
        {
            IWebElement element = BrowserDriver.Instance.Driver.FindElement(by);

            try
            {
                string value = element.GetAttribute(attribute);
                if (value != null)
                    return true;
            }
            catch (Exception e)
            {
            }

            return false;
        }

        /// <summary>
        /// Checks for success notification displayed on UI, if Yes then returns 'true', else returns 'false'
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsSuccessNotificationDisplayed()
        {
            if (IsElementVisible(By.XPath("//div[contains(@class, 'ui-notificationbar-success')]")))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks for error notification displayed on UI, if Yes then returns 'true', else returns 'false'
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsErrorNotificationDisplayed()
        {
            if (IsElementVisible(By.XPath("//div[contains(@class, 'ui-notificationbar-error')]")))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks for warning notification displayed on UI, if Yes then returns 'true', else returns 'false'
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsWarningNotificationDisplayed()
        {
            if (IsElementVisible(By.XPath("//div[contains(@class, 'ui-notificationbar-warning')]")))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks for info notification displayed on UI, if Yes then returns 'true', else returns 'false'
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsInfoNotificationDisplayed()
        {
            if (IsElementVisible(By.XPath("//div[contains(@class, 'ui-notificationbar-info')]")))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Keys in a text into an input.
        /// Lookup the input, clear it if clearInput=true then key in the textToEnter
        /// </summary>
        /// <param name="findInputBy">How to find the input (ID, xPath, etc...)</param>
        /// <param name="textToEnter">Text to enter in the input</param>
        /// <param name="clearInput"></param>
        public void EnterTextInInput(By findInputBy, string textToEnter, bool clearInput = true)
        {
            //find the element
            IWebElement input = BrowserDriver.Instance.Driver.FindElement(findInputBy);

            //clear it
            if (clearInput)
            {
                input.Clear();
            }

            //key in the new text
            input.SendKeys(textToEnter);
        }

        #endregion

        #region IE flickering with any Element By Parameter
        public Boolean retryingFindClick(By by)
        {
            Boolean result = false;
            int attempts = 0;
            while (attempts < 4)
            {
                try
                {
                    BrowserDriver.Instance.Driver.FindElement(by).Click();
                    result = true;
                    break;
                }
                catch (StaleElementReferenceException e)
                {
                }
                attempts++;
            }
            return result;
        }
#endregion

        #region IE flickering1 with XPath as Parameter
        public Boolean retryingFindClickk(String ObjByXPath)
        {
            Boolean result = false;
            int attempts = 0;
            while (attempts < 5)
            {
                try
                {
                    //Actions action = new Actions(BrowserDriver.Instance.Driver);

                    //action.MoveToElement(BrowserDriver.Instance.Driver.FindElement(By.XPath(ObjByXPath))).DoubleClick().Perform();

                    BrowserDriver.Instance.Driver.FindElement(By.XPath(ObjByXPath)).Click();

                    result = true;
                    break;
                }
                catch (Exception e)
                {
                }
                attempts++;
            }
            return result;
        }

        #endregion

        #region Common UI Navigation Methods

        /// <summary>
        /// Navigates to a specific menu
        /// </summary>
        /// <param name="webpage">The page to navigate to</param>
        protected void GoToMenu(string webpage)
        {
            //Get the properties needed to build the URL
            //string type = TestProperties.Instance.getPropertyByName(TestProperties.TestProperty.type);
            string type = TestProperties.Instance.GetPropertyByName(TestProperty.type);
            this.GoToMenu(webpage, type);
        }

        /// <summary>
        /// Navigates to a specific menu while specifying the page type
        /// </summary>
        /// <param name="webpage">The page to navigate to</param>
        /// <param name="type">the type of the page</param>
        protected void GoToMenu(string webpage, string type)
        {
            //Get the properties needed to build the URL
            string menu = TestProperties.Instance.GetPropertyByName(TestProperty.menu);
            string method = TestProperties.Instance.GetPropertyByName(TestProperty.method);

            //Build the URL and Execute the Script
            IWebElement element = (IWebElement)((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript(menu + method + webpage + ", type: " + type + "})");
        }


        public void SelectChildPopupRecordWithoutQuerying()
        {
            SwitchToPopUps();
            javascriptClick(By.XPath(Inven.Default.QSubmitB));
            Thread.Sleep(3000);
            SwitchToPopUps();
            javascriptClick(By.XPath(Inven.Default.OKB));
            Thread.Sleep(3000);


        }
        //////////////////////////////////////////////CMP General Main Menu Navigation//////////////////////////////////////////////

        #region IE11 navigation
       
      
        public void GoToMain(string mainmenu)
        {
            Thread.Sleep(1000);
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//a[normalize-space()='" + mainmenu + "']")).Click();
        }

        public void GoToMain1(string mainmenu, string submenu1)
        {
            Thread.Sleep(1000);
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//a[normalize-space()='" + mainmenu + "']")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//td[normalize-space()='" + submenu1 + "']")).Click();
            Thread.Sleep(2000);
        }

        public void GoToMain2(string mainmenu, string submenu, string submenu1)
        {
            Thread.Sleep(1000);
            //Actions builder = new Actions(BrowserDriver.Instance.Driver);
            //IWebElement menuLink = BrowserDriver.Instance.Driver.FindElement(By.XPath("//a[normalize-space()='" + mainmenu + "']"));
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//a[normalize-space()='" + mainmenu + "']")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//a[normalize-space()='" + submenu + "']")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//a[normalize-space()='" + submenu1 + "']")).Click();
            //  BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='menuMainEnterprise']"));
            //builder.MoveToElement(menuLink).Click().Build().Perform();
        }


        public void SwitchToContent()
        {
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            }
            else 
            {
                Console.WriteLine("Failed to Navigate to CONTENT Frame");
            }
        }

        public void SwitchToPopUps()
        {
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            }
            else
            {
                Console.WriteLine("Failed to Navigate to POPup Frame");
            }
        }


        public void SearchQuery(String field, String data)
        {
            SwitchToPopUps();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('" + field + "')[0].value='" + data + "'");
            javascriptClick(By.XPath(General.Default.SubmitB));
            Thread.Sleep(2000);
            SwitchToPopUps();
        }
        #endregion


        public void SendText(String Type, String Path)
        { 
                    
        }
        #endregion

        #region Common Authentication Methods

        /// <summary>
        /// Login to CMP using the URL, User and Password for the Admin. Those are properties specified in the config file
        /// </summary>
     
        // CMP Login
        
        public void Login()
        {
            BrowserDriver.Instance.Driver.Navigate().GoToUrl(TestProperties.Instance.GetPropertyByName(TestProperty.baseURL));
            BrowserDriver.Instance.Driver.Manage().Window.Maximize();
            BrowserDriver.Instance.Driver.Navigate().GoToUrl("javascript:document.getElementById('overridelink').click()");
            //BrowserDriver.Instance.Driver.FindElement(By.Id("overridelink")).Click();
            WaitForElementToVisible(By.Id("tgx-main-header"));
          //  BrowserDriver.Instance.Driver.Manage().Window.Maximize();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Id("userNameTextBox")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.user));
            BrowserDriver.Instance.Driver.FindElement(By.Id("passwordTextBox")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.password));
            BrowserDriver.Instance.Driver.FindElement(By.Name("Submit")).Click();
            WaitForElementToVisible(By.Id("menuMainHome"));
        }

        public void Login1()
        {
            BrowserDriver.Instance.Driver.Navigate().GoToUrl(TestProperties.Instance.GetPropertyByName(TestProperty.employeeURL));
            BrowserDriver.Instance.Driver.Manage().Window.Maximize();
            BrowserDriver.Instance.Driver.Navigate().GoToUrl("javascript:document.getElementById('overridelink').click()");
            //BrowserDriver.Instance.Driver.FindElement(By.Id("overridelink")).Click();
            WaitForElementToVisible(By.Id("tgx-main-header"));
            //  BrowserDriver.Instance.Driver.Manage().Window.Maximize();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Id("userNameTextBox")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.user));
            BrowserDriver.Instance.Driver.FindElement(By.Id("passwordTextBox")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.password));
            BrowserDriver.Instance.Driver.FindElement(By.Name("Submit")).Click();
            WaitForElementToVisible(By.Id("menuMainHome"));
        }


       #endregion



        #region
        public void javascriptClick(By by)
        {
            IWebElement element = BrowserDriver.Instance.Driver.FindElement(by);
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("arguments[0].click();", element);
        }

        public void javascriptdropdownById(By by)
        {
            IWebElement element1 = BrowserDriver.Instance.Driver.FindElement(by);
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById(by).selectedIndex = 1;", element1);
          

        }

        public void javascriptdropdownByName(By by)
        {
            IWebElement element1 = BrowserDriver.Instance.Driver.FindElement(by);
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName(by).selectedIndex = 1;", element1);


        }
        #endregion

        public int RandomNumbergeneratorL()
        {

            Random random = new Random();

            int randomNumber = random.Next(0, 10000);

            return randomNumber;




        }

        public void Delete()
        {
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) { return true; }");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(Inven.Default.DeleteB)).Click();
        }

        public void CheckNavigation(String title)
        {
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            if (true)
            {
                Assert.AreEqual(BrowserDriver.Instance.Driver.FindElement(By.LinkText(" + title + ")), "Navigation Unsuccessful");
                Console.WriteLine("Navigation Successful");

            }
            else
            {
                Console.WriteLine("Navigation not Successful");
            }
        }

        #region Javascript Executor
       
        //Enter text with ID
        public void typeDataID(string field, string data)
        {
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('"+field+"').value='"+data+"'");
        }

        public void SelectfromDropdownByText(string field, string index)
        {
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('" + field + "').selectedText='" + index + "'");

        }

        //Enter text with Name
        public void typeDataName(string field, string data)//Include this for index ,int index)
        {
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('" + field + "')[0].value='" + data + "'");
        }

        public void SelectfromDropdown(string field, string index)
        {
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('" + field + "').selectedIndex='" + index + "'");
        
        }
        //((JavascriptExecutor) driver).executeScript("return document.getElementById('id').selectedIndex = '" + index + "';)
        #endregion
        public void SelectfromDropdownByName(string field, string index)
        {
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('" + field + "').selectedIndex='" + index + "'");

        }
       

        #region Clicking Submit Button
        public void ClickSubmit()
        {
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //WaitForElementToVisible(By.XPath(".//*[@id='tab1']"));
           // WaitForElementToVisible(By.XPath(".//*[@id='splashDiv']/p"));
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='queryEntitiesNewFormDV']/div/div/table/tbody/tr/td[2]/input")).Click();
            Thread.Sleep(2000);
            WaitForTableDataToAppear("There are no entities to display.", "Entity data found");
                      
        }
        #endregion
      

























    }
}