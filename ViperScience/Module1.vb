Module Module1

    Sub Main()
        Dim workingDir As String = "phys"
        Dim phy As Physics = New Physics()
        Dim chm As Chemistry = New Chemistry()

        While True
            Select Case workingDir
                Case "phys"
                    workingDir = phy.PhysicsMain()
                Case "chem"
                    workingDir = chm.ChemistryMain()
                Case "math"
                Case "exit"
                    Exit While
            End Select

        End While
    End Sub

End Module
