'<LICENSE>
'   Open Web Studio - http://www.OpenWebStudio.com
'   Copyright (c) 2007-2008
'   by R2Integrated Inc. http://www.R2integrated.com
'      
'   Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
'   documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
'   the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
'   to permit persons to whom the Software is furnished to do so, subject to the following conditions:
'    
'   The above copyright notice and this permission notice shall be included in all copies or substantial portions of 
'   the Software.
'   
'   This Software and associated documentation files are subject to the terms and conditions of the Open Web Studio 
'   End User License Agreement and version 2 of the GNU General Public License.
'    
'   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
'   TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
'   THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
'   CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
'   DEALINGS IN THE SOFTWARE.
'</LICENSE>
Imports System
Imports System.Collections
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Diagnostics
Imports r2i.OWS.Framework
Imports r2i.OWS.Framework.Plugins.Formatters

Namespace r2i.OWS.Formatters
    Public Class Split : Inherits FormatterBase

        Public Overrides Function Handle_Render(ByRef Caller As EngineBase, ByVal Index As Integer, ByRef Value As String, ByRef Parameters As String, ByRef Source As String, ByRef DS As System.Data.DataSet, ByRef DR As System.Data.DataRow, ByRef RuntimeMessages As System.Collections.Generic.SortedList(Of String, String), ByVal NullReturn As Boolean, ByVal NullOverride As Boolean, ByVal ProtectSession As Boolean, ByVal SessionDelimiter As String, ByVal useSessionQuotes As Boolean, ByVal useAggregations As Boolean, ByRef FilterText As String, ByRef FilterField As String, ByRef Debugger As Framework.Debugger) As Boolean
            'VERSION: 1.9.7 - Added List Tag "{LIST:Pre,Post,/}
            Dim fParameters As String() = ParameterizeString(Parameters.Substring(7).TrimEnd(New Char() {"}"c}), ","c, """"c, "\"c)
            If fParameters.Length = 2 Then
                If Not Value Is Nothing Then
                    Dim delimiter As String = fParameters(0)
                    Dim position As Integer = 0
                    If Microsoft.VisualBasic.IsNumeric(fParameters(1)) Then
                        position = fParameters(1)
                    End If
                    Dim strs() As String = Value.Split(delimiter)
                    If strs.Length >= position Then
                        Source = strs(position)
                    End If
                Else
                    Source = Value
                End If
                Return True
            End If
            Return False
        End Function

        Public Overrides ReadOnly Property RenderTag() As String
            Get
                Return "split"
            End Get
        End Property
    End Class
End Namespace