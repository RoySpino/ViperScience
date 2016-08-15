Public Class resources
    Private parentDirecory As String

    Sub New()
        parentDirecory = "phys"
    End Sub

    ' /////////////////////////////////////////////////////////////////////////
    Sub New(dir As String)
        parentDirecory = dir
    End Sub

    ' /////////////////////////////////////////////////////////////////////////
    Public Function changeDirectory(path As String) As String
        Dim arr() As String

        arr = path.Split(" ")
        Try
            ' get the directory name
            If arr(1).Length > 0 Then
                Return arr(1)
            Else
                ' loop through the arry to find a command
                For i As Integer = 1 To arr.Length
                    If arr(i).Length > 0 Then
                        Return arr(1)
                    End If
                Next
            End If

        Catch ex As Exception
            Return parentDirecory
        End Try
    End Function

    ' /////////////////////////////////////////////////////////////////////////
    Private Function binarySearch_Str(lst As List(Of String),
                                      whatToFind As String) As String
        Dim min, mid, max As Integer
        lst.Sort()

        min = 0
        max = lst.Count
        mid = max / 2

        ' do binary search to find a item in list
        While True
            If whatToFind = lst(mid) Then
                Return lst(mid)
            End If

            If lst(mid).CompareTo(whatToFind) > 0 Then
                min = mid
            Else
                max = mid
            End If

            ' get new mid point
            mid = (max - min) >> 1
            mid += min
        End While

        Return ""
    End Function

    ' /////////////////////////////////////////////////////////////////////////
    Private Function binarySearch_Dou(lst As List(Of Double),
                                      whatToFind As Double) As String
        Dim min, mid, max As Integer
        lst.Sort()

        min = 0
        max = lst.Count
        mid = max / 2

        ' do binary search to find a item in list
        While True
            If whatToFind = lst(mid) Then
                Return lst(mid)
            End If

            If lst(mid).CompareTo(whatToFind) > 0 Then
                min = mid
            Else
                max = mid
            End If

            ' get new mid point
            mid = (max - min) >> 1
            mid += min
        End While

        Return ""
    End Function

    ' /////////////////////////////////////////////////////////////////////////
    Public Function strToD(raw As String) As Double
        Try
            Return Convert.ToDouble(raw)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    ' /////////////////////////////////////////////////////////////////////////
    Public Function calc(rawLine As String)
        Dim arr() As String
        Dim action As String
        Dim tmp1, tmp2 As String

        ' get action and split the string
        If rawLine.Contains("*") Then
            action = "mult"
            arr = rawLine.Split("*")
        ElseIf rawLine.Contains("/") Then
            action = "div"
            arr = rawLine.Split("/")
        ElseIf rawLine.Contains("+") Then
            action = "add"
            arr = rawLine.Split("+")
        Else
            action = "sub"
            arr = rawLine.Split("-")
        End If

        tmp1 = ""
        tmp2 = ""

        ' convert both the string to a number filtering 
        ' out non numeric characters
        For i As Integer = 0 To arr(0).Length - 1
            If Asc(arr(0)(i)) >= 48 And Asc(arr(0)(i)) <= 57 Or
                Asc(arr(0)(i)) = 46 Then
                tmp1 &= arr(0)(i)
            End If
        Next

        For i As Integer = 0 To arr(1).Length - 1
            If Asc(arr(1)(i)) >= 48 And Asc(arr(1)(i)) <= 57 Or
                Asc(arr(0)(i)) = 46 Then
                tmp2 &= arr(1)(i)
            End If
        Next

        ' preform operation
        Select Case action
            Case "mult"
                Return Convert.ToDouble(tmp1) *
                    Convert.ToDouble(tmp2)
            Case "div"
                Return Convert.ToDouble(tmp1) /
                    Convert.ToDouble(tmp2)
            Case "add"
                Return Convert.ToDouble(tmp1) +
                    Convert.ToDouble(tmp2)
            Case Else
                Return Convert.ToDouble(tmp1) -
                    Convert.ToDouble(tmp2)
        End Select
    End Function
End Class
