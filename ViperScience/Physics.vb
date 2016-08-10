Public Class Physics
    Private res As resources = New resources("phys")
#Region "Public working functions"

    ' /////////////////////////////////////////////////////////////////////////
    ' final velocity from inital and time
    Public Function consAcc_FVIVT(velocity As Double,
                                  time As Double) As Double
        Return consAcc_FITVA(velocity, time, 9.8)
    End Function

    ' /////////////////////////////////////////////////////////////////////////
    ' initial velocity from final velocity with time
    Public Function consAcc_IVFVT(finalVel As Double,
                                  time As Double) As Double
        Return consAcc_IVFVTA(finalVel, time, 9.8)
    End Function

    ' /////////////////////////////////////////////////////////////////////////
    ' Time from inital and final velocity
    Public Function consAcc_TIVFV(finalVel As Double,
                                  initVel As Double) As Double
        Return consAcc_TIVFV(finalVel, initVel, 9.8)
    End Function

    ' /////////////////////////////////////////////////////////////////////////
    ' final velocity from initial and time (varying acceloration)
    Public Function consAcc_FITVA(velocity As Double, time As Double,
                                  acc As Double) As Double
        Return velocity + (acc * time)
    End Function

    ' /////////////////////////////////////////////////////////////////////////
    ' initial velocity from final velocity with time (varying acceloration)
    Public Function consAcc_IVFVTA(finalVel As Double, time As Double,
                                   acc As Double) As Double
        Return finalVel - acc * time
    End Function

    ' /////////////////////////////////////////////////////////////////////////
    ' Time from inital and final velocity
    Public Function consAcc_TIVFV(finalVel As Double, initVel As Double,
                                  acc As Double) As Double
        Return (finalVel - initVel) / acc
    End Function
#End Region

#Region "public directory functions"

    ' /////////////////////////////////////////////////////////////////////////
    Public Function PhysicsMain() As String
        Dim sel As String

        While True
            Console.Write(vbNewLine & "Viper_>Phys: ")
            sel = Console.ReadLine()
            sel = sel.ToLower()

            If sel.Substring(0, 2) = "cd" Then
                Return res.changeDirectory(sel)
            End If

            Select Case sel
                Case "constacc"
                    consAccMain()
                Case "help"
                    help()
                Case "ls"
                    help()
                Case "exit"
                    Exit While
            End Select

        End While

        Return "exit"
    End Function

    ' /////////////////////////////////////////////////////////////////////////
    Private Sub help()
        Console.WriteLine(
            "_________________________________________________________")
        Console.WriteLine(String.Format(
                          "{0,15} {1,40}",
                          "constAcc", "Constant acceleration problems"))


        Console.WriteLine("")
    End Sub

    ' /////////////////////////////////////////////////////////////////////////
    Private Sub consAccMain()
        Dim sel, tmp As String
        Dim t, vi, vf As Double
        Dim a, xi, xf As Double

        While True
            Console.Write(vbNewLine & "Viper_Science_Physics_>constantAccel: ")
            sel = Console.ReadLine()
            sel = sel.ToLower()

            If sel = "help" Or sel = "ls" Then
                Console.WriteLine(
            "_________________________________________________________")
                Console.WriteLine(
                    String.Format("{0,15} {1,40}",
                                  "fvelotim", "final velocity from time"))
                Console.WriteLine(
                    String.Format("{0,15} {1,40}",
                                  "ivelotim", "inical velocity from time"))

            End If

            Select Case sel
                Case "fvelotim"
                    Console.Write("    Enter acceleration:     ")
                    a = res.strToD(Console.ReadLine())
                    Console.Write("    Enter total time:       ")
                    t = res.strToD(Console.ReadLine())
                    Console.Write("    Enter initial velocity: ")
                    vi = res.strToD(Console.ReadLine())

                    vf = consAcc_FITVA(vi, t, a)
                    Console.WriteLine("Final velocity is: " & vf & vbNewLine)
                Case "ivelotim"
                Case "cd"
                    Exit While
            End Select
        End While
    End Sub
#End Region
End Class
