Public Class Physics
#Region "Public working functions"

    ' final velocity from inital and time
    Public Function consAcc_FVIVT(velocity As Double, time As Double) As Double
        Return consAcc_FITVA(velocity, time, 9.8)
    End Function
    ' initial velocity from final velocity with time
    Public Function consAcc_IVFVT(finalVel As Double, time As Double) As Double
        Return consAcc_IVFVTA(finalVel, time, 9.8)
    End Function
    ' Time from inital and final velocity
    Public Function consAcc_TIVFV(finalVel As Double, initVel As Double) As Double
        Return consAcc_TIVFV(finalVel, initVel, 9.8)
    End Function
    ' final velocity from initial and time (varying acceloration)
    Public Function consAcc_FITVA(velocity As Double, time As Double, acc As Double) As Double
        Return velocity + (acc * time)
    End Function
    ' initial velocity from final velocity with time (varying acceloration)
    Public Function consAcc_IVFVTA(finalVel As Double, time As Double, acc As Double) As Double
        Return finalVel - acc * time
    End Function
    ' Time from inital and final velocity
    Public Function consAcc_TIVFV(finalVel As Double, initVel As Double, acc As Double) As Double
        Return (finalVel - initVel) / acc
    End Function
#End Region

#Region "public dirrectory functions"
    Public Function PhysicsMain() As String
        Dim sel As String

        While True
            Console.Write("Viper_Science_>Physics: ")
            sel = Console.ReadLine()
            sel = sel.ToLower()

            Select Case sel
                Case "constAcc"
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

    Private Sub help()
        Console.WriteLine("_________________________________________________________")
        Console.WriteLine(String.Format("{0,15} {1,40}", "constAcc", "Constant acceleration problems"))


        Console.WriteLine("")
    End Sub

    Private Sub consAccMain()
        Dim sel As String

        While True
            Console.Write("Viper_Science_Physics_>Const-Acc: ")
            sel = Console.ReadLine()
            sel = sel.ToLower()

            Select Case sel
                Case "constAcc"
                Case "help"
                    help()
                Case "ls"
                    help()
                Case "cd"
                    Exit While
            End Select
        End While
    End Sub
#End Region
End Class
