<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/368842182/21.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T999523)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WinForms Spreadsheet - How to Create a Custom Progress Indicator

This example demonstrates how to use a [DevExpress Wait Form](https://docs.devexpress.com/WindowsForms/10824/controls-and-libraries/forms-and-user-controls/splash-screen-manager/wait-form) to indicate the progress of lengthy operations (file load/save operations and export to PDF/HTML).

![Spreadsheet - Custom Progress Indicator](./images/spreadsheet-custom-progress-indicator.png)

Use [IProgressIndicationService](https://docs.devexpress.com/CoreLibraries/DevExpress.Services.IProgressIndicationService) to create a custom progress indicator. Create a class that implements this interface and pass a class instance to the [SpreadsheetControl.ReplaceService](https://docs.devexpress.com/WindowsForms/DevExpress.XtraSpreadsheet.SpreadsheetControl.ReplaceService--1(--0)) method to replace the default progress indication service with your own service.

# Files to Review

* [Form1.cs](./CS/SpreadsheetProgressSample/Form1.cs) (VB: [Form1.vb](./VB/SpreadsheetProgressSample/Form1.vb))
* [WaitForm1.cs](./CS/SpreadsheetProgressSample/WaitForm1.cs) (VB: [WaitForm1.vb](./VB/SpreadsheetProgressSample/WaitForm1.vb))


# Documentation

- [Create a Custom Progress Indicator for the Spreadsheet Control](https://docs.devexpress.com/WindowsForms/403146/controls-and-libraries/spreadsheet/examples/customization/how-to-create-a-custom-progress-indicator-for-the-spreadsheet-control)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-spreadsheet-create-custom-progress-indicator&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-spreadsheet-create-custom-progress-indicator&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
