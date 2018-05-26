Public Class Form1

    Dim directoryPath As String = My.Application.Info.DirectoryPath
    Dim tool As String = directoryPath + "\hightropeServicesUpdater.exe"
    Dim wClient As New System.Net.WebClient


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        checkUpdates()

    End Sub

    Public Sub checkUpdates()

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

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Process.Start(directoryPath + "\hightropeServicesUpdater.exe")
        Application.Exit()
    End Sub
End Class
