﻿Public Class Chemistry
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

    ' /////////////////////////////////////////////////////////////////////////
    Public Function CLkel(vol1 As Double, kel As Double, vol2 As Double) As Double
        Return (vol1 * kel) / vol2
    End Function

    ' /////////////////////////////////////////////////////////////////////////
    Public Function BLvolch(vol1 As Double, pres1 As Double, pres2 As Double) As Double
        Return (vol1 * pres1) / pres2
    End Function

    ' /////////////////////////////////////////////////////////////////////////
    Public Function BLpresch(vol1 As Double, vol2 As Double, pres1 As Double) As Double
        Return (vol1 * pres1) / vol2
    End Function
    ' /////////////////////////////////////////////////////////////////////////
    Public Function ElecPlateTime(elec As Double, g As Double, metal As String, volt As Double) As Double
        Dim aloy As formula = New formula(metal)
        Return (elec * g * (1 / aloy.getMol()) * 96485) / volt
    End Function

    Public Function ElecPlateAtom(elec As Double, g As Double, volt As Double, time As Double) As Double
        Return 1 / ((time * volt) / (elec * g * 96485))
    End Function

    Public Function ElecPlateGram(elec As Double, metal As String, volt As Double, time As Double) As Double
        Dim aloy As formula = New formula(metal)
        Return ((time * volt) / (96485 * (1 / aloy.getMol) * elec))
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
                Case "boyllaw"
                    ChemistryBoyllaw()
                Case "elecplat"
                    elecplat()
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
                          "charlaw", "Find volumes of gases from temp"))
        Console.WriteLine(String.Format("{0,15} {1,40}",
                          "boyllaw", "Find volumes/presure of an ideal gas"))
        Console.WriteLine(String.Format("{0,15} {1,40}",
                          "elecplat", "Find the time/amout for electroplating"))
        Console.WriteLine(String.Format("{0,15} {1,40}",
                          "stoic", "common stoichiometric formulas"))
        '



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
                        "the molar weight of the compound is: " &
                        (molmas(input)).ToString("F5"))
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
                    Console.WriteLine("the gass at " & k2.ToString("F5") &
                                      " will take up a space of " &
                                      v.ToString("F5") & "L")
                Case "kel"
                    Console.Write("    Enter inical temp in kelven: ")
                    k1 = res.strToD(Console.ReadLine)
                    Console.Write("    Enter inical volume of gass: ")
                    v = res.strToD(Console.ReadLine)
                    Console.Write("    Enter final volume of gass:  ")
                    v2 = res.strToD(Console.ReadLine)

                    k1 = CLkel(v, k1, v2)
                    Console.WriteLine("the gass at " & k1.ToString("F5") &
                                      " will take up a space of " &
                                      v.ToString("F5") & "L")
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

    Private Function ChemistryBoyllaw() As String
        Dim sel As String
        Dim input As String
        Dim pres1, pres2, v, v2 As Double

        While True
            Console.Write(vbNewLine & "Viper_Chem_>BoylLaw: ")
            sel = Console.ReadLine()
            sel = sel.ToLower()

            Select Case sel
                Case "volch"
                    Console.Write("    Enter inichal volume:  ")
                    v = res.strToD(Console.ReadLine)
                    Console.Write("    Enter inical pressure: ")
                    pres1 = res.strToD(Console.ReadLine)
                    Console.Write("    Enter final presure:   ")
                    pres2 = res.strToD(Console.ReadLine)

                    v = BLvolch(v, pres1, pres2)
                    Console.WriteLine("the gass at " & v.ToString("F5") &
                                      " will take up a space of " &
                                      v.ToString("F5") & "L")
                Case "presch"
                    Console.Write("    Enter inichal volume:  ")
                    v = res.strToD(Console.ReadLine)
                    Console.Write("    Enter inical pressure: ")
                    pres1 = res.strToD(Console.ReadLine)
                    Console.Write("    Enter final volume:    ")
                    v2 = res.strToD(Console.ReadLine)

                    v = BLpresch(v, v2, pres1)
                    Console.WriteLine("Final pressure is: " &
                                      v.ToString("F5"))
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
                    String.Format("{0,15} {1,40}", "volch",
                                  "find new volume of an ideal gas"))
                Console.WriteLine(
                    String.Format("{0,15} {1,40}", "presch",
                                  "find presure of an ideal gas"))
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

    Private Function elecplat() As String
        Dim sel As String
        Dim input, aloy As String
        Dim elec, g, volt, ans, time As Double

        While True
            Console.Write(vbNewLine & "Viper_Chem_>Elecplat: ")
            sel = Console.ReadLine()
            sel = sel.ToLower()

            Select Case sel
                Case "time"
                    Console.Write("    enter moles of -e:                ")
                    elec = res.strToD(Console.ReadLine)
                    Console.Write("    enter grames deposited:           ")
                    g = res.strToD(Console.ReadLine)
                    Console.Write("    enter atomic symbol/aloy formula: ")
                    aloy = Console.ReadLine
                    Console.Write("    enter the volts:                  ")
                    volt = res.strToD(Console.ReadLine)

                    ans = ElecPlateTime(elec, g, aloy, volt)
                    Console.WriteLine(
                        vbNewLine & "to deposit " & g &
                        "of material you must wait " &
                        ans.ToString("F5") & "s")
                Case "atom"
                    Console.Write("    enter moles of -e:           ")
                    elec = res.strToD(Console.ReadLine)
                    Console.Write("    enter grames deposited:      ")
                    g = res.strToD(Console.ReadLine)
                    Console.Write("    enter time for prosess:      ")
                    time = res.strToD(Console.ReadLine)
                    Console.Write("    enter the volts:             ")
                    volt = res.strToD(Console.ReadLine)

                    ans = ElecPlateAtom(elec, g, volt, time)
                    Console.WriteLine(
                        vbNewLine & "the atomic waight of" &
                        " deposited material is " & ans.ToString("F5"))
                Case "gram"
                    Console.Write("    enter moles of -e:                ")
                    elec = res.strToD(Console.ReadLine)
                    Console.Write("    enter atomic symbol/aloy formula: ")
                    aloy = Console.ReadLine
                    Console.Write("    enter time for prosess:           ")
                    time = res.strToD(Console.ReadLine)
                    Console.Write("    enter the volts:                  ")
                    volt = res.strToD(Console.ReadLine)

                    ans = ElecPlateGram(elec, aloy, volt, time)
                    Console.WriteLine(
                        vbNewLine & "the amout of deposited meterial is " &
                        ans.ToString("F5") & "g")
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
                    String.Format("{0,15} {1,40}", "atom",
                                  "find atomiMcass of electroplated mater"))
                Console.WriteLine(
                    String.Format("{0,15} {1,40}", "gram",
                                  "find grams of electroplat material"))
                Console.WriteLine(
                    String.Format("{0,15} {1,40}", "time",
                                  "find time to electroplate the object"))
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
