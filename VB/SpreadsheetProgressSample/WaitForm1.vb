Imports System
Imports System.Threading
Imports DevExpress.XtraWaitForm

Namespace SpreadsheetProgressSample

    Public Partial Class WaitForm1
        Inherits WaitForm

        Private cancellationTokenSource As CancellationTokenSource

        Public Sub New()
            InitializeComponent()
            progressPanel1.AutoSize = True
        End Sub

        Public Overrides Sub SetCaption(ByVal caption As String)
            MyBase.SetCaption(caption)
            progressPanel1.Caption = caption
        End Sub

        Public Overrides Sub SetDescription(ByVal description As String)
            MyBase.SetDescription(description)
            progressPanel1.Description = description
        End Sub

        Public Overrides Sub ProcessCommand(ByVal cmd As [Enum], ByVal arg As Object)
            MyBase.ProcessCommand(cmd, arg)
            Dim command As WaitFormCommand = CType(cmd, WaitFormCommand)
            If command = WaitFormCommand.SetCancellationTokenSource Then cancellationTokenSource = CType(arg, CancellationTokenSource)
        End Sub

        Public Enum WaitFormCommand
            SetCancellationTokenSource
        End Enum

        Private Sub Cancel_Click(ByVal sender As Object, ByVal e As EventArgs)
            cancellationTokenSource?.Cancel()
        End Sub
    End Class
End Namespace
