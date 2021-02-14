Imports System.Collections.Specialized
Imports System.IO, System.Net, System.Text, System.Text.RegularExpressions, System.Console
Imports System.Threading
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Imports RestSharp, System.Management
Public Class Form1
    Dim name, msgboxswap, target1, username1, password1 As String
    Dim bio, email, phone As String
    Dim contactpoint As String
    Dim mainacccookies, cookies As New Net.CookieContainer
    Dim turbo_status As Boolean
    Dim attempts, thread1 As Integer
    ' Programmed By Hamdan Alrostamani | Follow me on insta @xaed
    Sub login()
        If NewLogin(username1, password1) Then
            Me.Refresh()
            STATUS.Text = "STATUS : LOGGED IN"
        Else
            MsgBox("Wrong Information", MsgBoxStyle.Critical, "Try Again")
        End If
        InfoGrabber()
backagain:
        Dim choicespam As String
        choicespam = InputBox("[X] Do You want to check the spam Block?" + vbNewLine + "[+] Enter 1 to checkblock" + vbNewLine + "[+] Enter 2 to continue without checking" + vbNewLine + "[?] Enter Your Choice : ")
        If choicespam = "1" Then
            If checkspamblock(target1, phone, email) Then
                MsgBox("Account Is Not Blocked", MsgBoxStyle.Information, "Success !")
                swap()
            End If
        ElseIf choicespam = "2" Then
            swap()
        Else
            MsgBox("Choose 1 or 2 !", MsgBoxStyle.Critical, "Try Again")
            GoTo backagain
        End If
    End Sub
    ' Programmed By Hamdan Alrostamani | Follow me on insta @xaed
    Sub swap()
        MsgBox("Your Target : @" + target1 + vbNewLine + "Your Threads : " & thread1, MsgBoxStyle.Exclamation, "Press Ok To Start")
        turbo_status = True
        Control.CheckForIllegalCrossThreadCalls = False
        For Threads As Integer = 0 To Conversions.ToInteger(thread1)
            Dim swapstart As New Thread(New ParameterizedThreadStart(AddressOf swapping))
            swapstart.Start()
            swapstart.Priority = ThreadPriority.Highest
        Next
    End Sub
    ' Programmed By Hamdan Alrostamani | Follow me on insta @xaed

    Function NewLogin(user As String, pass As String) As Boolean
        Dim RestClient As New RestClient("https://i.instagram.com/api/v1")
        Dim RestRequest As New RestRequest("/accounts/login/", Method.POST)
        RestClient.UserAgent = "Instagram 100.1.0.29.135 Android (25/7.1.2; 192dpi; 720x1280; google; G011A; G011A; qcom; en_US; 262886984)"
        RestClient.AddDefaultHeader("Content-Type", "application/x-www-form-urlencoded")
        RestRequest.AddParameter("", $"username={user}&password={pass}&device_id={Guid.NewGuid}&login_attempt_count=0", ParameterType.RequestBody)
        RestClient.CookieContainer = Cookies
        Dim Response As String = RestClient.Execute(RestRequest).Content
        If Response.Contains("logged_in_user") Then
            Return True
        ElseIf Response.Contains("challenge_required") Then
            Dim url As String = Regex.Match(Response, """api_path"":""(.*?)""").Groups(1).Value
erroragain:
            Dim choice As String
            choice = InputBox("[1] Phone Number | [2] Email " + vbNewLine + "Choice [ 1 or 2 ] : ")
            If choice = "1" Then
                Return SendEmail(url, "0")
            ElseIf choice = "2" Then
                Return SendEmail(url, "1")
            Else
                MsgBox("PLEASE WRITE 1 OR 2 !", MsgBoxStyle.Critical, "Error")
                GoTo erroragain
            End If
        ElseIf Response.Contains("bad_password") Then
            STATUS.Text = "STATUS : WRONG "
            Return False
        End If
    End Function
    ' Programmed By Hamdan Alrostamani | Follow me on insta @xaed

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Start.Click
        username1 = USERNAME.Text
        password1 = PASSWORD.Text
        thread1 = THREAD.Text
        target1 = TARGET.Text
        login()
    End Sub
    ' Programmed By Hamdan Alrostamani | Follow me on insta @xaed

    Function InfoGrabber() As Boolean
        Try

            Dim Encoding As New Text.UTF8Encoding
            Dim Bytes As Byte() = Encoding.GetBytes("")
            Dim AJ As Net.HttpWebRequest = DirectCast(Net.WebRequest.Create("https://i.instagram.com/api/v1/accounts/current_user/?edit=true"), Net.HttpWebRequest)
            With AJ
                .Method = "GET"
                .Proxy = Nothing
                .UserAgent = "Instagram 7.10.0 Android (24/5.0; 515dpi; 1440x2416; huawei/google; Nexus 6P; angler; angler; en_US)"
                .Headers.Add("Accept-Language: ar;q=1, en;q=0.9")
                .ContentType = "multipart/form-data; boundary=67155DA6-16EC-4AB2-884C-070051E65EA1"
                .Host = "i.instagram.com"
                .CookieContainer = cookies
            End With
            Dim Response As Net.HttpWebResponse = DirectCast(AJ.GetResponse, Net.HttpWebResponse)
            Dim reader As New IO.StreamReader(Response.GetResponseStream)
            Dim text As String = reader.ReadToEnd
            Try
                email = Regex.Match(text, """email"":""(.*?)""").Groups(1).Value
                phone = Regex.Match(text, """phone_number"":""(.*?)""").Groups(1).Value
                bio = Regex.Match(text, """bio"":""(.*?)""").Groups(1).Value
                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
            reader.Dispose()
            reader.Close()
            Response.Dispose()
            Response.Close()
        Catch ex As WebException
        End Try
    End Function
    ' Programmed By Hamdan Alrostamani | Follow me on insta @xaed

    Function SendEmail(url As String, choice As String) As Boolean
        Dim RestClient As New RestClient("https://i.instagram.com/api/v1")
        Dim RestRequest As New RestRequest(url, Method.POST)
        RestClient.UserAgent = "Instagram 100.1.0.29.135 Android (25/7.1.2; 192dpi; 720x1280; google; G011A; G011A; qcom; en_US; 262886984)"
        RestClient.AddDefaultHeader("Content-Type", "application/x-www-form-urlencoded")
        RestRequest.AddParameter("", $"choice={choice}", ParameterType.RequestBody)
        RestClient.CookieContainer = cookies
        Dim Response As String = RestClient.Execute(RestRequest).Content
        If Response.Contains("security_code") Then
            contactpoint = Regex.Match(Response, """contact_point"":""(.*?)""").Groups(1).Value
            Return Security_code(url, choice)
        Else
            MsgBox("Error in code sending !")
        End If
    End Function
    ' Programmed By Hamdan Alrostamani | Follow me on insta @xaed

    Function Security_code(url As String, choice As String) As Boolean
        Dim code As String
        Dim ae As String
        If choice = "0" Then
            ae = "Phone Number"
        ElseIf choice = "1" Then
            ae = "Email"
        End If
again:
        code = InputBox($"Enter The Code Which has been sent to {ae} [ {contactpoint} ] : ")
        Dim RestClient As New RestClient("https://i.instagram.com/api/v1")
        Dim RestRequest As New RestRequest(url, Method.POST)
        RestClient.UserAgent = "Instagram 100.1.0.29.135 Android (25/7.1.2; 192dpi; 720x1280; google; G011A; G011A; qcom; en_US; 262886984)"
        RestClient.AddDefaultHeader("Content-Type", "application/x-www-form-urlencoded")
        RestRequest.AddParameter("", $"security_code={code}", ParameterType.RequestBody)
        RestClient.CookieContainer = Cookies
        Dim Response As String = RestClient.Execute(RestRequest).Content
        If Response.Contains("logged_in_user") Then
            Return True
        ElseIf Response.Contains("Please check the code we sent you and try again") Then
            MsgBox("Error In Code !")
            GoTo again
        Else
        End If
    End Function
    ' Programmed By Hamdan Alrostamani | Follow me on insta @xaed

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        name = InputBox("NAME ?")
        msgboxswap = InputBox("MSG BOX ?")
    End Sub
    ' Programmed By Hamdan Alrostamani | Follow me on insta @xaed

    Function checkspamblock(USERNAME As String, phone As String, email As String) As Boolean
        Dim returnvalue As Boolean
        Try
            Dim uuid As String = Guid.NewGuid.ToString.ToUpper
            Net.ServicePointManager.CheckCertificateRevocationList = False
            Net.ServicePointManager.DefaultConnectionLimit = 300
            Net.ServicePointManager.UseNagleAlgorithm = False
            Net.ServicePointManager.Expect100Continue = False
            Net.ServicePointManager.SecurityProtocol = 3072
            Dim Encoding As New Text.UTF8Encoding
            Dim Bytes As Byte() = Encoding.GetBytes("signed_body=SIGNATURE.{""external_url"":"""",""phone_number"":""" & phone & """,""_csrftoken"":""zSxtIiJpDxtp1xfgTckNaj8hD5pKymeC"",""username"":""" & USERNAME + ".xswp" & """,""first_name"":"""",""_uid"":""44746289759"",""device_id"":""android-b994ff2e09c9ff83"",""biography"":"""",""_uuid"":""" & uuid & """,""email"":""" + email + """}")
            Dim AJ As Net.HttpWebRequest = DirectCast(Net.WebRequest.Create("https://i.instagram.com/api/v1/accounts/edit_profile/"), Net.HttpWebRequest)
            With AJ
                .Method = "POST"
                .Proxy = Nothing
                .UserAgent = "Instagram 159.0.0.40.122 Android (25/7.1.2; 192dpi; 1280x720; google; G011A; G011A; qcom; en_US; 245196047)"
                .Headers.Add("Accept-Language: en-US")
                .CookieContainer = cookies
                .Headers.Add("X-MID: X8JGAgABAAEbEzcF51HFK-6WkuOa")
                .ContentType = "application/x-www-form-urlencoded; charset=UTF-8"
                .AutomaticDecompression = Net.DecompressionMethods.Deflate Or Net.DecompressionMethods.GZip
                .Host = "i.instagram.com"
                .ContentLength = Bytes.Length
            End With
            Dim Stream As IO.Stream = AJ.GetRequestStream()
            Stream.Write(Bytes, 0, Bytes.Length)
            Stream.Dispose()
            Stream.Close()
            Dim Reader As New IO.StreamReader(DirectCast(AJ.GetResponse(), Net.HttpWebResponse).GetResponseStream())
            Dim Text As String = Reader.ReadToEnd

            If Text.Contains("status"":""ok") Then
                returnvalue = True
            ElseIf Text.Contains("status"":""fail") Then
                returnvalue = False
            End If

            Reader.Dispose()
            Reader.Close()
        Catch ex As WebException
            Dim AJJ As String = New IO.StreamReader(ex.Response.GetResponseStream()).ReadToEnd()
        End Try
        Return returnvalue
        Dim canswap2 As Boolean
        Try
            Dim pass As String = "qjdhdhdu1827sn"
            Dim bit As Byte() = Encoding.Default.GetBytes("username=" & USERNAME & ".xswp" & "&enc_password=#PWD_INSTAGRAM_BROWSER:0:1589682409:" & pass & "&queryParams={}&optIntoOneTap=false")
            Dim web As HttpWebRequest = DirectCast(WebRequest.Create("https://www.instagram.com/accounts/login/ajax/"), HttpWebRequest)
            web.Method = "POST"
            web.Host = "www.instagram.com"
            web.KeepAlive = True
            web.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.111 Safari/537.36"
            web.Accept = "*/*"
            web.ContentType = "application/x-www-form-urlencoded"
            web.Headers.Add("X-Requested-With", "XMLHttpRequest")
            web.Headers.Add("X-IG-App-ID", "936619743392459")
            web.Headers.Add("X-Instagram-AJAX", "missing")
            web.Headers.Add("X-CSRFToken", "missing")
            web.Headers.Add("Accept-Language", "en-US,en;q=0.9")
            web.ContentLength = bit.Length
            Dim stream As Stream = web.GetRequestStream
            stream.Write(bit, 0, bit.Length)
            Dim httpwebresponse As HttpWebResponse = web.GetResponse
            Dim streamreader As New StreamReader(httpwebresponse.GetResponseStream())
            Dim response As String = streamreader.ReadToEnd

            Dim howw As String
            howw = httpwebresponse.Headers("Set-Cookie")
            If response.Contains("""authenticated"": true") Then
                canswap2 = True
            Else
                If response.Contains("""authenticated"": false") Then
                    canswap2 = False
                End If
            End If
        Catch ex As Exception
            canswap2 = False

        End Try
        Return canswap2
        If canswap2 = True Then
            returnvalue = True
        ElseIf canswap2 = False Then
            returnvalue = False
        End If
    End Function
    ' Programmed By Hamdan Alrostamani | Follow me on insta @xaed

    Function edit(user As String) As Boolean
        Dim returnvalue As Boolean
        Try

            Dim Bytes As Byte() = New UTF8Encoding().GetBytes($"username={user}")
            Dim se As HttpWebRequest = DirectCast(WebRequest.Create("https://i.instagram.com/api/v1/accounts/set_username/"), HttpWebRequest)
            se.Method = "POST"
            se.UserAgent = "Instagram 9.4.0 Android (18/4.3; 320dpi; 720x1280; Xiaomi; HM 1SW; armani; qcom; en_US)"
            se.ContentType = "application/x-www-form-urlencoded"
            se.Headers.Add("Accept-Language", "en-US")
            se.CookieContainer = cookies
            se.ContentLength = Bytes.Length
            Dim Stream As Stream = se.GetRequestStream()
            Stream.Write(Bytes, 0, Bytes.Length)
            Stream.Dispose()
            Stream.Close()
            Dim Response As HttpWebResponse
            Try
                Response = DirectCast(se.GetResponse, HttpWebResponse)
            Catch ex As WebException
                Response = DirectCast(ex.Response, HttpWebResponse)
            End Try
            Dim StreamReader As StreamReader = New StreamReader(Response.GetResponseStream())
            Dim responsee As String = StreamReader.ReadToEnd().ToString
            If responsee.Contains("status"":""ok") Then
                returnvalue = True
                turbo_status = False
            ElseIf responsee.Contains("spam") Or responsee.Contains("wait") Then
                If turbo_status = True Then
                    MsgBox("[X] Spam Blocked : @" & user & " Press Ok To Exit")
                    Environment.Exit(0)
                End If
            Else
                returnvalue = False
            End If
            StreamReader.Dispose()
            StreamReader.Close()
        Catch ex As Exception
        End Try
        Return returnvalue
    End Function
    ' Programmed By Hamdan Alrostamani | Follow me on insta @xaed

    Sub swapping()
        If edit(target1) = True Then
            turbo_status = False
            swapped()
        End If
        While turbo_status = True
            edit(target1)
            ATTEMPT.Text = attempts.ToString
            attempts += 1
        End While
    End Sub
    ' Programmed By Hamdan Alrostamani | Follow me on insta @xaed

    Sub swapped()
        If attempts = 0 Then
            ATTEMPT.Text = "1"
        End If
        USERNAME.Text = "Swapped !"
        TARGET.Text = "Done @" & target1
        If attempts = 0 Then
            attempts = 1
        End If
        discordsend(target1, attempts)
        My.Computer.FileSystem.WriteAllText("@" + target1 + " info.txt", "NewUser : " + target1 + vbNewLine + "Password : " + password1 + vbNewLine + "Time : " & DateTime.Now + vbNewLine + "Swapped By " & name, False)
        MsgBox(msgboxswap + "@" & target1 + vbNewLine + "Attempts => " & attempts, MsgBoxStyle.Information, name)
    End Sub
    ' Programmed By Hamdan Alrostamani | Follow me on insta @xaed

    Sub discordsend(username As String, attempts As Integer)
        If username.Length = 4 Then
            Try
                Dim dwas As WebClient = New WebClient
                Dim null As New NameValueCollection
                Dim postdata As String = "{""content"":"""",""embeds"": [{""title"": ""New Swap !"",""footer"": {""text"": "" Nice :) | " + DateTime.Now + """,""icon_url"": ""https://instagram.ffjr1-2.fna.fbcdn.net/v/t51.2885-19/s150x150/137271765_223186262615306_5821660193508881201_n.jpg?_nc_ht=instagram.ffjr1-2.fna.fbcdn.net&_nc_ohc=aGsTANbTR2MAX_-zoTR&tp=1&oh=615faedd2df60eb0136be7b9ba697574&oe=60245A9F""},""fields"": [{""name"": ""@" + username + """,""value"": ""Attempts => " & attempts.ToString + """,""inline"": false}],""thumbnail"": {""url"": ""https://media1.tenor.com/images/cf8a83dbdf57ae8b6bd15353d1c2bb86/tenor.gif?itemid=17477956""},""description"": ""By " & name + """}]}"
                dwas.Headers.Add("Content-Type", "application/json")
                dwas.UploadString("حط الويب هوك حقك هنا", postdata)
            Catch ex As Exception
            End Try
        Else
        End If
        If username.Length = 3 Then
            Try
                Dim dwas As WebClient = New WebClient
                Dim null As New NameValueCollection
                Dim postdata As String = "{""content"":"""",""embeds"": [{""title"": ""New Swap !"",""footer"": {""text"": "" Nice :) | " + DateTime.Now + """,""icon_url"": ""https://instagram.ffjr1-2.fna.fbcdn.net/v/t51.2885-19/s150x150/137271765_223186262615306_5821660193508881201_n.jpg?_nc_ht=instagram.ffjr1-2.fna.fbcdn.net&_nc_ohc=aGsTANbTR2MAX_-zoTR&tp=1&oh=615faedd2df60eb0136be7b9ba697574&oe=60245A9F""},""fields"": [{""name"": ""@" + username + """,""value"": ""Attempts => " & attempts.ToString + """,""inline"": false}],""thumbnail"": {""url"": ""https://media1.tenor.com/images/cf8a83dbdf57ae8b6bd15353d1c2bb86/tenor.gif?itemid=17477956""},""description"": ""By " & name + """}]}"
                dwas.Headers.Add("Content-Type", "application/json")
                dwas.UploadString("حط الويب هوك حقك هنا", postdata)
            Catch ex As Exception
            End Try
        Else
        End If
        If username.Length = 2 Then
            Try
                Dim dwas As WebClient = New WebClient
                Dim null As New NameValueCollection
                Dim postdata As String = "{""content"":"""",""embeds"": [{""title"": ""New Swap !"",""footer"": {""text"": "" Nice :) | " + DateTime.Now + """,""icon_url"": ""https://instagram.ffjr1-2.fna.fbcdn.net/v/t51.2885-19/s150x150/137271765_223186262615306_5821660193508881201_n.jpg?_nc_ht=instagram.ffjr1-2.fna.fbcdn.net&_nc_ohc=aGsTANbTR2MAX_-zoTR&tp=1&oh=615faedd2df60eb0136be7b9ba697574&oe=60245A9F""},""fields"": [{""name"": ""@" + username + """,""value"": ""Attempts => " & attempts.ToString + """,""inline"": false}],""thumbnail"": {""url"": ""https://media1.tenor.com/images/cf8a83dbdf57ae8b6bd15353d1c2bb86/tenor.gif?itemid=17477956""},""description"": ""By " & name + """}]}"
                dwas.Headers.Add("Content-Type", "application/json")
                dwas.UploadString("حط الويب هوك حقك هنا", postdata)
            Catch ex As Exception
            End Try
        Else
        End If
        If username.Length = 1 Then
            Try
                Dim dwas As WebClient = New WebClient
                Dim null As New NameValueCollection
                Dim postdata As String = "{""content"":"""",""embeds"": [{""title"": ""New Swap !"",""footer"": {""text"": "" Nice :) | " + DateTime.Now + """,""icon_url"": ""https://instagram.ffjr1-2.fna.fbcdn.net/v/t51.2885-19/s150x150/137271765_223186262615306_5821660193508881201_n.jpg?_nc_ht=instagram.ffjr1-2.fna.fbcdn.net&_nc_ohc=aGsTANbTR2MAX_-zoTR&tp=1&oh=615faedd2df60eb0136be7b9ba697574&oe=60245A9F""},""fields"": [{""name"": ""@" + username + """,""value"": ""Attempts => " & attempts.ToString + """,""inline"": false}],""thumbnail"": {""url"": ""https://media1.tenor.com/images/cf8a83dbdf57ae8b6bd15353d1c2bb86/tenor.gif?itemid=17477956""},""description"": ""By " & name + """}]}"
                dwas.Headers.Add("Content-Type", "application/json")
                dwas.UploadString("حط الويب هوك حقك هنا", postdata)
            Catch ex As Exception
            End Try
        Else
        End If
    End Sub
End Class

