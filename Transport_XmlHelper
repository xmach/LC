Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Xml.Serialization
Imports System.IO
Imports System.Xml

Public Module XmlHelper

    Private Sub XmlSerializeInternal(ByVal stream As Stream, ByVal o As Object, ByVal encoding As Encoding)

        If (o Is Nothing) Then
            Throw New ArgumentNullException("o")
        End If
        If (encoding Is Nothing) Then
            Throw New ArgumentNullException("encoding")
        End If
        Dim serializer As XmlSerializer = New XmlSerializer(o.GetType())

        Dim settings As XmlWriterSettings = New XmlWriterSettings()
        settings.Indent = True
        settings.NewLineChars = Environment.NewLine
        settings.Encoding = encoding
        settings.IndentChars = Chr(9)

        Using writer As XmlWriter = XmlWriter.Create(stream, settings)
            serializer.Serialize(writer, o)
            writer.Close()
        End Using
    End Sub

    Public Function XmlSerialize(ByVal o As Object, ByVal encoding As Encoding) As String

        Using stream As MemoryStream = New MemoryStream()
            XmlSerializeInternal(stream, o, encoding)

            stream.Position = 0
            Using reader As StreamReader = New StreamReader(stream, encoding)
                Return reader.ReadToEnd()
            End Using
        End Using
    End Function

    Public Sub XmlSerializeToFile(ByVal o As Object, ByVal path As String, ByVal encoding As Encoding)

        If (String.IsNullOrEmpty(path)) Then
            Throw New ArgumentNullException("path")
        End If
        Using file As FileStream = New FileStream(path, FileMode.Create, FileAccess.Write)
            XmlSerializeInternal(file, o, encoding)
        End Using
    End Sub

    Public Function XmlDeserialize(Of T)(ByVal s As String, ByVal encoding As Encoding) As T

        If (String.IsNullOrEmpty(s)) Then
            Throw New ArgumentNullException("s")
        End If
        If (encoding Is Nothing) Then
            Throw New ArgumentNullException("encoding")
        End If
        Dim mySerializer As XmlSerializer = New XmlSerializer(GetType(T))
        Using ms As MemoryStream = New MemoryStream(encoding.GetBytes(s))
            Using sr As StreamReader = New StreamReader(ms, encoding)
                Return CType(mySerializer.Deserialize(sr), T)
            End Using
        End Using
    End Function

    Public Function XmlDeserializeFromFile(Of T)(ByVal path As String, ByVal encoding As Encoding) As T

        If (String.IsNullOrEmpty(Path)) Then
            Throw New ArgumentNullException("path")
        End If
        If (encoding Is Nothing) Then
            Throw New ArgumentNullException("encoding")
        End If
        Dim xml As String = File.ReadAllText(Path, encoding)
        Return XmlDeserialize(Of T)(xml, encoding)

    End Function
End Module
