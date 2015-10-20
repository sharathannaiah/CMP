WinActivate("Choose file");
Local $file = "D:\CMP Automation 6-10-2015\AutomatedTests\External\TangoeContractExpirationNotification.jar"
ControlSetText("Choose file", "", "Edit1", $file )
ControlClick("Choose file", "", "Button2")
