Public Class Chemistry
    Private res As resources = New resources("chem")

#Region "Public working functions"
    Public Function molmas(compound As String)
        Dim form As formula = New formula(compound)
        Return form.getMol()
    End Function

    ' /////////////////////////////////////////////////////////////////////////
    Public Function masprct(compound As String) As List(Of Double)
        Dim form As formula = New formula(compound)
        Return form.getmasprcnt()
    End Function

    ' /////////////////////////////////////////////////////////////////////////
    Public Function CLVol(vol1 As Double, kel2 As Double, kel1 As Double) As Double
        Return (vol1 * kel2) / kel1
    End Function

    Public Function CLkel(vol1 As Double, kel As Double, vol2 As Double) As Double
        Return (vol1 * kel) / vol2
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
                Case "charlaw"
                    ChemistryCharlaw()
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
        Console.WriteLine(String.Format("{0,15} {1,40}",
                          "charlaw", "Find volumes of gases from temp"))



        Console.WriteLine("")
    End Sub

    ' /////////////////////////////////////////////////////////////////////////
    Private Function ChemistryStoichMain() As String
        Dim sel As String
        Dim input As String
        Dim el As List(Of Double)
        While True
            Console.Write(vbNewLine & "Viper_Chem_>Stoichiometry: ")
            sel = Console.ReadLine()
            sel = sel.ToLower()

            Select Case sel
                Case "masprcnt"
                    Console.Write(
                        vbNewLine & "    Enter the formula of the compound: ")
                    input = Console.ReadLine()

                    el = masprct(input)
                    For i As Integer = 0 To el.Count - 1

                    Next

                Case "molmas"
                    Console.Write(
                        vbNewLine & "    Enter the formula of the compound: ")
                    input = Console.ReadLine()

                    Console.WriteLine(
                        "the molar weight of the compound is: " & molmas(input))
                Case "calc"
                    Console.Write(">>> ")
                    input = Console.ReadLine
                    Console.WriteLine(res.calc(input))
                Case "cd"
                    Return ""
            End Select

            If sel = "help" Or sel = "ls" Then
                Console.WriteLine(
                    "_________________________________________________________")
                Console.WriteLine(
                    String.Format("{0,15} {1,40}", "masprnt",
                                  "Find mass precent of the compound"))
                Console.WriteLine(
                    String.Format("{0,15} {1,40}", "molformla",
                                  "Find muleculer formula"))
                Console.WriteLine(
                    String.Format("{0,15} {1,40}", "molmas",
                                  "Find molar mass of compound"))
                Console.WriteLine(
                    String.Format("{0,15} {1,40}", "limreac",
                                  "Find limiting reactant"))
                Console.WriteLine(
                    String.Format("{0,15} {1,40}", "calc",
                                  "Simple calculater"))
                Console.WriteLine(
                    String.Format("{0,15} {1,40}", "cd",
                                  "Return to parent directory"))
                Console.WriteLine(
                    String.Format("{0,15} {1,40}", "clear",
                                  "Clear screen"))

                Console.WriteLine(String.Format("{0,15} {1,40}", "", ""))
            End If

        End While

        Return "exit"
    End Function

    ' /////////////////////////////////////////////////////////////////////////
    Private Function ChemistryCharlaw() As String
        Dim sel As String
        Dim input As String
        Dim k1, k2, v, v2 As Double

        While True
            Console.Write(vbNewLine & "Viper_Chem_>Charlaw: ")
            sel = Console.ReadLine()
            sel = sel.ToLower()

            Select Case sel
                Case "vol"
                    Console.Write("    Enter inical temp in kelven: ")
                    k1 = res.strToD(Console.ReadLine)
                    Console.Write("    Enter inical volume of gass: ")
                    v = res.strToD(Console.ReadLine)
                    Console.Write("    Enter final temp in kelven:  ")
                    k2 = res.strToD(Console.ReadLine)

                    v = CLVol(v, k2, k1)
                    Console.WriteLine("the gass at " & k2 &
                                      " will take up a space of " & v & "L")
                Case "kel"
                    Console.Write("    Enter inical temp in kelven: ")
                    k1 = res.strToD(Console.ReadLine)
                    Console.Write("    Enter inical volume of gass: ")
                    v = res.strToD(Console.ReadLine)
                    Console.Write("    Enter final volume of gass:  ")
                    v2 = res.strToD(Console.ReadLine)

                    k1 = CLkel(v, k1, v2)
                    Console.WriteLine("the gass at " & k1 &
                                      " will take up a space of " & v & "L")
                Case "calc"
                    Console.Write(">>> ")
                    input = Console.ReadLine
                    Console.WriteLine(res.calc(input))
                Case "clear"
                    Console.Clear()
                Case "cd"
                    Return ""
            End Select

            If sel = "help" Or sel = "ls" Then
                Console.WriteLine(
                    "_________________________________________________________")
                Console.WriteLine(
                    String.Format("{0,15} {1,40}", "vol",
                                  "Find volume of an ideal gas"))
                Console.WriteLine(
                    String.Format("{0,15} {1,40}", "kel",
                                  "Find kelvin temprature of an ideal gas"))
                Console.WriteLine(
                    String.Format("{0,15} {1,40}", "calc",
                                  "Simple calculater"))
                Console.WriteLine(
                    String.Format("{0,15} {1,40}", "cd",
                                  "Return to parent directory"))
                Console.WriteLine(
                    String.Format("{0,15} {1,40}", "clear",
                                  "Clear screen"))

                Console.WriteLine(String.Format("{0,15} {1,40}", "", ""))
            End If

        End While

        Return "exit"
    End Function


#End Region
End Class
