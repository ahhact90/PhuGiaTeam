Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Protected Overrides Function OnStartup(eventArgs As StartupEventArgs) As Boolean
            UpdateCurrentCulture()
            If Not IO.File.Exists(My.Application.Info.DirectoryPath & "\connect.sys") Then
                Dim fff As New frmConfigConnect
                If fff.ShowDialog() = DialogResult.Cancel Then End
            End If
            Dim cns As New ConnectSRP()
            dbHis = New MyData.Database(GetConnect(DuLieu.His))
            dbXML = New MyData.Database(GetConnect(DuLieu.XML))
            Return MyBase.OnStartup(eventArgs)
        End Function
    End Class
End Namespace
