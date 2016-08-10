Public Class Chemistry
    Private res As resources = New resources("chem")

#Region "Public working functions"
    Public Function molmas(compound As String)
        Dim form As formula = New formula(compound)
        Return form.getMol()
    End Function
#End Region

#Region "public directory functions"
    Public Function ChemistryMain() As String
        Dim sel As String

        While True
            Console.Write(vbNewLine & "Viper_>Chem: ")
            sel = Console.ReadLine()
            sel = sel.ToLower()

            If sel.Substring(0, 2) = "cd" Then
                Return res.changeDirectory(sel)
            End If

            Select Case sel
                Case "stoic"
                    ChemistryStoichMain()
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
        Console.WriteLine(String.Format("{0,15} {1,40}",
                          "stoic", "common stoichiometric formulas"))


        Console.WriteLine("")
    End Sub

    ' /////////////////////////////////////////////////////////////////////////
    Function ChemistryStoichMain() As String
        Dim sel As String
        Dim input As String
        Dim el As List(Of String)
        While True
            Console.Write(vbNewLine & "Viper_Chem_>Stoichiometry: ")
            sel = Console.ReadLine()
            sel = sel.ToLower()

            Select Case sel
                Case "molmas"
                    Console.Write(
                        vbNewLine & "    Enter the formula of the compound: ")
                    input = Console.ReadLine()

                    Console.WriteLine(
                        "the molar weight of the compound is: " & molmas(input))
                Case "cd"
                    Return ""
            End Select

            If sel = "help" Or sel = "ls" Then
                Console.WriteLine(
                    "_________________________________________________________")
                Console.WriteLine(
                    String.Format("{0,15} {1,40}", "masprnt",
                                  "find mass precent of the compound"))
                Console.WriteLine(
                    String.Format("{0,15} {1,40}", "molformla",
                                  "find muleculer formula"))
                Console.WriteLine(
                    String.Format("{0,15} {1,40}", "molmas",
                                  "find molar mass of compound"))
                Console.WriteLine(
                    String.Format("{0,15} {1,40}", "limreac",
                                  "find limiting reactant"))
                Console.WriteLine(
                    String.Format("{0,15} {1,40}", "calc",
                                  "simple calculater"))
                Console.WriteLine(
                    String.Format("{0,15} {1,40}", "clear", "Clear screen"))
                Console.WriteLine(
                    String.Format("{0,15} {1,40}", "cd", ""))

                Console.WriteLine(String.Format("{0,15} {1,40}", "", ""))
            End If

        End While

        Return "exit"
    End Function
#End Region
End Class
