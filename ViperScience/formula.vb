Public Class formula
    Private chemString As String = ""
    Private mol As Double
    Private ElCnt As Integer
    Private elementsInFoumula As List(Of String)
    Private formulaStr As String
    Private pt As List(Of elements) = New List(Of elements)

    ' /////////////////////////////////////////////////////////////////////////
    Private Class elements
        Sub New(sym As String, w As Double)
            symbol = sym
            weight = w
        End Sub
        Public cnt As Integer
        Public weight As Double
        Public symbol As String
        Public atomicNum As Integer
    End Class

    ' /////////////////////////////////////////////////////////////////////////
    Sub New()
        setupTable()
        mol = 0
        ElCnt = 0
        elementsInFoumula = New List(Of String)()
    End Sub

    ' /////////////////////////////////////////////////////////////////////////
    Sub New(raw As String)
        setupTable()
        mol = findMol(raw)
        ElCnt = 0
        elementsInFoumula = getElements(raw)
        formulaStr = raw
    End Sub

    ' /////////////////////////////////////////////////////////////////////////
    Private Sub setupTable()
        pt.Add(New elements("Ac", 227))
        pt.Add(New elements("Ag", 107.8682))
        pt.Add(New elements("Al", 26.9815))
        pt.Add(New elements("Am", 243))
        pt.Add(New elements("Ar", 39.948))
        pt.Add(New elements("As", 74.9216))
        pt.Add(New elements("At", 210))
        pt.Add(New elements("Au", 196.9665))
        pt.Add(New elements("B", 10.811))
        pt.Add(New elements("Ba", 137.327))
        pt.Add(New elements("Be", 9.0122))
        pt.Add(New elements("Bh", 264))
        pt.Add(New elements("Bi", 208.9804))
        pt.Add(New elements("Bk", 247))
        pt.Add(New elements("Br", 79.904))
        pt.Add(New elements("C", 12.107))
        pt.Add(New elements("Ca", 40.078))
        pt.Add(New elements("Cd", 112.411))
        pt.Add(New elements("Ce", 140.116))
        pt.Add(New elements("Cf", 251))
        pt.Add(New elements("Cl", 35.453))
        pt.Add(New elements("Cm", 247))
        pt.Add(New elements("Cn", 285))
        pt.Add(New elements("Co", 58.9332))
        pt.Add(New elements("Cr", 51.9961))
        pt.Add(New elements("Cs", 132.9055))
        pt.Add(New elements("Cu", 63.546))
        pt.Add(New elements("Db", 262))
        pt.Add(New elements("Ds", 281))
        pt.Add(New elements("Dy", 162.5))
        pt.Add(New elements("Er", 167.259))
        pt.Add(New elements("Es", 252))
        pt.Add(New elements("Eu", 151.964))
        pt.Add(New elements("F", 18.9984))
        pt.Add(New elements("Fe", 55.845))
        pt.Add(New elements("Fl", 289))
        pt.Add(New elements("Fm", 257))
        pt.Add(New elements("Fr", 223))
        pt.Add(New elements("Ga", 69.723))
        pt.Add(New elements("Gd", 157.25))
        pt.Add(New elements("Ge", 72.64))
        pt.Add(New elements("H", 1.0079))
        pt.Add(New elements("He", 4.0026))
        pt.Add(New elements("Hf", 178.49))
        pt.Add(New elements("Hg", 200.59))
        pt.Add(New elements("Ho", 164.9303))
        pt.Add(New elements("Hs", 277))
        pt.Add(New elements("I", 126.9045))
        pt.Add(New elements("In", 114.818))
        pt.Add(New elements("Ir", 192.217))
        pt.Add(New elements("K", 39.0983))
        pt.Add(New elements("Kr", 83.8))
        pt.Add(New elements("La", 138.9055))
        pt.Add(New elements("Li", 6.941))
        pt.Add(New elements("Lr", 262))
        pt.Add(New elements("Lu", 174.967))
        pt.Add(New elements("Lv", 293))
        pt.Add(New elements("Md", 258))
        pt.Add(New elements("Mg", 24.305))
        pt.Add(New elements("Mn", 54.938))
        pt.Add(New elements("Mo", 95.94))
        pt.Add(New elements("Mt", 268))
        pt.Add(New elements("N", 14.0067))
        pt.Add(New elements("Na", 22.9897))
        pt.Add(New elements("Nb", 92.9064))
        pt.Add(New elements("Nd", 144.24))
        pt.Add(New elements("Ne", 20.1797))
        pt.Add(New elements("Ni", 58.6934))
        pt.Add(New elements("No", 259))
        pt.Add(New elements("Np", 237))
        pt.Add(New elements("O", 15.9994))
        pt.Add(New elements("Os", 190.23))
        pt.Add(New elements("P", 30.9738))
        pt.Add(New elements("Pa", 231.0359))
        pt.Add(New elements("Pb", 207.2))
        pt.Add(New elements("Pd", 106.42))
        pt.Add(New elements("Pm", 145))
        pt.Add(New elements("Po", 209))
        pt.Add(New elements("Pr", 140.9077))
        pt.Add(New elements("Pt", 195.078))
        pt.Add(New elements("Pu", 244))
        pt.Add(New elements("Ra", 226))
        pt.Add(New elements("Rb", 85.4678))
        pt.Add(New elements("Re", 186.207))
        pt.Add(New elements("Rf", 261))
        pt.Add(New elements("Rg", 281))
        pt.Add(New elements("Rh", 102.9055))
        pt.Add(New elements("Rn", 222))
        pt.Add(New elements("Ru", 101.07))
        pt.Add(New elements("S", 32.065))
        pt.Add(New elements("Sb", 121.76))
        pt.Add(New elements("Sc", 44.9559))
        pt.Add(New elements("Se", 78.96))
        pt.Add(New elements("Sg", 266))
        pt.Add(New elements("Si", 28.0855))
        pt.Add(New elements("Sm", 150.36))
        pt.Add(New elements("Sn", 118.71))
        pt.Add(New elements("Sr", 87.62))
        pt.Add(New elements("Ta", 180.9479))
        pt.Add(New elements("Tb", 127.6))
        pt.Add(New elements("Tc", 98))
        pt.Add(New elements("Te", 180.9479))
        pt.Add(New elements("Th", 232.0381))
        pt.Add(New elements("Ti", 47.867))
        pt.Add(New elements("Tl", 204.3833))
        pt.Add(New elements("Tm", 168.9342))
        pt.Add(New elements("U", 238.0289))
        pt.Add(New elements("Uub", 285))
        pt.Add(New elements("Uuh", 293))
        pt.Add(New elements("Uuo", 294))
        pt.Add(New elements("Uup", 299))
        pt.Add(New elements("Uuq", 289))
        pt.Add(New elements("Uus", 2.94))
        pt.Add(New elements("Uut", 286))
        pt.Add(New elements("V", 59.9415))
        pt.Add(New elements("W", 183.84))
        pt.Add(New elements("Xe", 131.293))
        pt.Add(New elements("Y", 88.9059))
        pt.Add(New elements("Yb", 173.04))
        pt.Add(New elements("Zn", 65.39))
        pt.Add(New elements("Zr", 91.224))

    End Sub

    ' /////////////////////////////////////////////////////////////////////////
    Private Function getElements(rawFormula As String) As List(Of String)
        Dim ret As List(Of String) = New List(Of String)()
        Dim tmp As String = ""
        Dim cnt As Integer = 0

        For i As Integer = 0 To rawFormula.Length - 1
            If (i > 0 And Asc(rawFormula(i)) >= 65 And
                Asc(rawFormula(i)) <= 90) Or (i + 1) = rawFormula.Length Then
                ret.Add(tmp)
                tmp = ""
            End If

            If Asc(rawFormula(i)) < 48 Or Asc(rawFormula(i)) > 57 Then
                tmp &= rawFormula(i)
            End If
        Next

        Return ret
    End Function

    ' /////////////////////////////////////////////////////////////////////////
    Private Function findMol(rawFormula As String) As Double
        Dim ret As Double = 0
        Dim tmp As String = ""
        Dim ecnt As String = ""
        Dim cnt As Integer = 1
        Dim arr() As String

        ' handle complex compounds
        If rawFormula.Contains("*") Then
            arr = rawFormula.Split("*")
            For i As Integer = 0 To arr(1).Length
                If Asc(arr(1)(i)) >= 48 And Asc(arr(1)(i)) <= 57 Then
                    ecnt &= arr(1)(i)
                Else
                    Exit For
                End If
            Next
            ret += findMol(arr(1)) * strToI(ecnt)
            rawFormula = arr(0)
            ecnt = ""
        End If
        If rawFormula.Contains(".") Then
            arr = rawFormula.Split(".")
            For i As Integer = 0 To arr(1).Length
                If Asc(arr(1)(i)) >= 48 And Asc(arr(1)(i)) <= 57 Then
                    ecnt &= arr(1)(i)
                Else
                    Exit For
                End If
            Next
            ret += findMol(arr(1)) * strToI(ecnt)
            rawFormula = arr(0)
            ecnt = ""
        End If
        If rawFormula.Contains("(") Then
            arr = rawFormula.Split("(")
            For i As Integer = arr(1).Length - 1 To 0 Step -1
                If Asc(arr(1)(i)) >= 48 And Asc(arr(1)(i)) <= 57 Then
                    ecnt &= arr(1)(i)
                Else
                    Exit For
                End If
            Next
            arr(1) = arr(1).Substring(0, arr(1).IndexOf(")"))
            ret += findMol(arr(1)) * strToI(ecnt)
            rawFormula = arr(0)
            ecnt = ""
        End If

        ' add end check character
        rawFormula &= "#"

        ' break formula down
        For i As Integer = 0 To rawFormula.Length - 1
            If (i > 0 And Asc(rawFormula(i)) >= 65 And
                Asc(rawFormula(i)) <= 90) Or rawFormula(i) = "#" Then

                ret += getWeight(tmp) * strToI(ecnt)
                tmp = ""
                ecnt = ""
            End If

            If Asc(rawFormula(i)) < 48 Or Asc(rawFormula(i)) > 57 Then
                tmp &= rawFormula(i)
            Else
                ecnt &= rawFormula(i)
            End If
        Next

        Return ret
    End Function

    ' /////////////////////////////////////////////////////////////////////////
    Private Function findMasPcnt(rawFormula As String) As Double

        For i As Integer = 0 To elementsInFoumula.Count
            If elementsInFoumula(i) = 
        Next
    End Function

    ' /////////////////////////////////////////////////////////////////////////
    Private Function elementCount(element As String, compound As String) As Double
        Dim ret As Double = 0
        Dim tmp As String = ""
        Dim ecnt As String = ""
        Dim cnt As Integer = 1
        'Dim arr() As String


        ' add end check character
        compound &= "#"

        ' break formula down
        For i As Integer = 0 To compound.Length - 1
            If (i > 0 And Asc(compound(i)) >= 65 And
                Asc(compound(i)) <= 90) Or compound(i) = "#" Then

                If tmp = element Then
                    ret += strToI(ecnt)
                    tmp = ""
                    ecnt = ""
                End If
            End If

            ' add characters to produce element symbol
            If Asc(compound(i)) < 48 Or Asc(compound(i)) > 57 Then
                tmp &= compound(i)
            Else
                ' add characters to produce number of elements
                ecnt &= compound(i)
            End If
        Next

        Return ret
    End Function
    ' /////////////////////////////////////////////////////////////////////////
    Private Function getWeight(sym As String) As Double
        Dim min, mid, max As Integer

        min = 0
        max = pt.Count
        mid = max / 2

        ' do binary search to find element in Periodic table
        While True
            ' found return the weight
            If sym = pt(mid).symbol Then
                Return pt(mid).weight
            End If

            ' quit if not found
            If (max - min) = 1 Then
                Exit While
            End If

            ' resize range
            If pt(mid).symbol.CompareTo(sym) < 0 Then
                min = mid
            Else
                max = mid
            End If

            ' get new mid point
            mid = (max - min) >> 1
            mid += min
        End While

        Return 0
    End Function

    ' /////////////////////////////////////////////////////////////////////////
    Public Function getElements() As List(Of String)
        Return elementsInFoumula
    End Function

    ' /////////////////////////////////////////////////////////////////////////
    Public Function getMol() As Double
        Return mol
    End Function

    ' /////////////////////////////////////////////////////////////////////////
    Sub assign(raw As String)
        mol = findMol(raw)
        ElCnt = 0
        elementsInFoumula = getElements(raw)
        formulaStr = raw
    End Sub

    ' /////////////////////////////////////////////////////////////////////////
    Sub assign(raw As formula)
        mol = findMol(raw.formulaStr)
        ElCnt = 0
        elementsInFoumula = getElements(raw.formulaStr)
        formulaStr = raw.formulaStr
    End Sub

    Private Function strToI(s As String)
        Try
            Return Int(Convert.ToDouble(s))
        Catch ex As Exception
            Return 1
        End Try
    End Function

    ' /////////////////////////////////////////////////////////////////////////
    ' ////////////////////////////////////////////////////////////////////////
    ' ///////////////////////////////////////////////////////////////////////

    Public Shared Operator =(ByVal A As formula, ByVal B As String) As Boolean
        Return A.formulaStr = B
    End Operator

    ' /////////////////////////////////////////////////////////////////////////
    Public Shared Operator =(ByVal A As String, ByVal B As formula) As Boolean
        Return A = B.formulaStr
    End Operator

    ' /////////////////////////////////////////////////////////////////////////
    Public Shared Operator <>(ByVal A As formula, ByVal B As String) As Boolean
        Return A.formulaStr <> B
    End Operator

    ' /////////////////////////////////////////////////////////////////////////
    Public Shared Operator <>(ByVal A As String, ByVal B As formula) As Boolean
        Return A <> B.formulaStr
    End Operator
End Class
