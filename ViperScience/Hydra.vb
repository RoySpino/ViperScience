Imports System.IO
Public Class Hydra
    Protected Class head
        Public Program As String
        Public dir As String
        Public islike As String
        Public left As head
        Public right As head

        Public Sub New(p As String,
                       d As String,
                       l As String)
            Program = p
            dir = d
            islike = l
            left = Nothing
            right = Nothing
        End Sub
    End Class

    Protected Class body
        Public headRoot As head
        Public nxt As body
        Public prev As body

        Public Sub New(hd As head)
            headRoot = hd
            nxt = Nothing
            prev = Nothing
        End Sub
    End Class

    Private Sub setupArray()
        Dim data As String
        Dim line() As String
        Dim NodeLine() As String
        Dim dir As String = ""

        Using sr As New StreamReader("", FileAccess.Read)
            Try
                Try
                    data = sr.ReadToEnd()
                Finally
                    sr.Close()
                End Try
            Catch ex As Exception
                Return
            End Try
        End Using

        line = data.Split(vbNewLine)

        For i As Integer = 0 To line.Length - 1
            Select Case line(0)
                Case "@"
                    ' get directory information
                    dir = line(i).Substring(1, line.Length - 1)
                Case "#"
                    ' ignor comments
                    Continue For
                Case Else
                    NodeLine = line(i).Split(",")
                    For u As Integer = 0 To NodeLine.Length - 1
                        add(dir, NodeLine(0), NodeLine(i))
                    Next
            End Select
        Next
    End Sub

    Private Sub add(dir As String,
                    programName As String,
                    isLike As String)
        Dim NewNode As head = New head(programName, dir, isLike)


    End Sub
End Class
