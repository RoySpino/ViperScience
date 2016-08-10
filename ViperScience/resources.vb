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
        Try
            Return path.Split(" ")(1)
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

        ' do binary search to find element in Periodic table
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

        ' do binary search to find element in Periodic table
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

    Public Function strToD(raw As String) As Double
        Try
            Return Convert.ToDouble(raw)
        Catch ex As Exception
            Return 0
        End Try
    End Function
End Class
