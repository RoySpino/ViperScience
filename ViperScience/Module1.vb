Module Module1

    Sub Main()
        Dim workingDir As String = "phys"
        Dim phy As Physics = New Physics()

        While True
            Select Case workingDir
                Case "phys"
                    workingDir = phy.PhysicsMain()
                Case "chem"
                Case "math"
                Case "exit"
                    Exit While
            End Select

        End While
    End Sub

End Module
