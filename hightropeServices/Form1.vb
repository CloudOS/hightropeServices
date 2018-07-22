Public Class Form1

    Dim OpenSansRegularPath As String = fontDirPath + "\Open Sans\OpenSans-Regular.ttf"
    Dim OpenSansLightPath As String = fontDirPath + "\Open Sans\OpenSans-Light.ttf"
    Dim RobotoMediumPath As String = fontDirPath + "\Roboto\Roboto-Medium.ttf"
    Dim RobotoLightPath As String = fontDirPath + "\Roboto\Roboto-Light.ttf"
    Dim RobotoThinPath As String = fontDirPath + "\Roboto\Roboto-Thin.ttf"
    Dim fontDirPath As String = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts)
    Dim directoryPath As String = My.Application.Info.DirectoryPath
    Dim tool As String = directoryPath + "\hightropeServicesUpdater.exe"
    Dim wClient As New System.Net.WebClient


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        checkForFonts()
        checkUpdates()
    End Sub
    Public Sub checkUpdates()
        Try
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://www.dropbox.com/s/vkpycc8m6boxeac/updatenum.txt?dl=1")
            Dim response As System.Net.HttpWebResponse = request.GetResponse()

            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())

            Dim newestversion As String = sr.ReadToEnd()
            Dim currentversion As String = Application.ProductVersion

            If newestversion.Contains(currentversion) Then

                'Do nothing

            Else

                wClient.DownloadFileAsync(New Uri("https://www.dropbox.com/s/ix538vn6pojw61q/hightropeServicesUpdater.exe?dl=1"), directoryPath + "\hightropeServicesUpdater.exe")
                Timer1.Start()
            End If
        Catch ex As exception
        End Try
    End Sub
    Public Sub checkForFonts()
        'OpenSansRegular
        Try
            If System.IO.File.Exists(OpenSansRegularPath) Then
                Form2.Show()
                Me.Hide()
            Else
                MsgBox("It seems that not all of the required fonts are found. Please install those found in the launched folder.", 0, "Hm..")
                Shell("explorer" + " " + directoryPath + "\fonts", AppWinStyle.NormalFocus)
                Close()
            End If
        Catch ex As exception
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Process.Start(directoryPath + "\hightropeServicesUpdater.exe")
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
    End Sub
End Class
