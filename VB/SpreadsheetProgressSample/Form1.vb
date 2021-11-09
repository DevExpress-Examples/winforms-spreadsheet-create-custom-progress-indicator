Imports System
Imports System.Threading
Imports DevExpress.Office.Services
Imports DevExpress.Office.Services.Implementation
Imports DevExpress.Services

Namespace SpreadsheetProgressSample

    Public Partial Class Form1
        Inherits DevExpress.XtraBars.Ribbon.RibbonForm
        Implements IProgressIndicationService

        Private cancellationTokenSource As CancellationTokenSource

        Private savedCancellationTokenProvider As ICancellationTokenProvider

        Public Sub New()
            InitializeComponent()
            ' Replace the default progress indication service
            ' with a custom service.
            spreadsheetControl1.ReplaceService(Of IProgressIndicationService)(Me)
        End Sub

        Private Sub Begin(ByVal displayName As String, ByVal minProgress As Integer, ByVal maxProgress As Integer, ByVal currentProgress As Integer)
            cancellationTokenSource = New CancellationTokenSource()
            ' Register a new CancellationTokenProvider instance
            ' to process cancellation requests. Save the reference
            ' to the previously registered service.
            savedCancellationTokenProvider = spreadsheetControl1.ReplaceService(Of ICancellationTokenProvider)(New CancellationTokenProvider(cancellationTokenSource.Token))
            splashScreenManager1.ShowWaitForm()
            ' Display the name of the running operation in the Wait Form.
            splashScreenManager1.SetWaitFormCaption(displayName)
            ' Display the progress of the running operation in the Wait Form.
            splashScreenManager1.SetWaitFormDescription($"{currentProgress}%")
            ' Send a command to the Wait Form
            ' to specify the CancellationTokenSource object
            ' used to generate cancellation tokens for the task cancellation.
            splashScreenManager1.SendCommand(WaitForm1.WaitFormCommand.SetCancellationTokenSource, cancellationTokenSource)
        End Sub

        Private Sub [End]()
            ' Close the Wait Form.
            If splashScreenManager1.IsSplashFormVisible Then splashScreenManager1.CloseWaitForm()
            ' Restore previous CancellationTokenProvider.
            spreadsheetControl1.ReplaceService(savedCancellationTokenProvider)
            spreadsheetControl1.UpdateCommandUI()
            ' Dispose the CancellationTokenSource object.
            cancellationTokenSource?.Dispose()
            cancellationTokenSource = Nothing
        End Sub

        Private Sub SetProgress(ByVal currentProgress As Integer)
            ' Display the progress of the running operation in the Wait Form.
            splashScreenManager1.SetWaitFormDescription($"{currentProgress}%")
        End Sub

        Private Sub spreadsheetControl1_UnhandledException(ByVal sender As Object, ByVal e As DevExpress.XtraSpreadsheet.SpreadsheetUnhandledExceptionEventArgs)
            ' Handle OperationCanceledException
            ' that is thrown when a user cancels the operation.
            If TypeOf e.Exception Is OperationCanceledException Then e.Handled = True
        End Sub
    End Class
End Namespace
