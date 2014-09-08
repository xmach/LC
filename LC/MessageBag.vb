Imports System.Xml
Imports System.Xml.Serialization
<Serializable()> _
<XmlRootAttribute("MessageBag", _
 Namespace:="LC", IsNullable:=False)> _
Public Class MessageBag
    <XmlAttribute()> _
    Public PlayorName As String
    <XmlAttribute()> _
    Public clientIP As String
    <XmlAttribute()> _
    Public clientID As String
    <XmlAttribute()> _
    Public MsgType As MsgType
    <XmlAttribute()> _
       Public Phase1Decision As String
    <XmlAttribute()> _
    Public Phase2Decision As String
    <XmlElement()> _
    Public Decision As String()
    <XmlElement()> _
    Public Score As Nullable(Of Integer)
    <XmlElement()> _
    Public Round As Nullable(Of Integer)
    <XmlAttribute()> _
    Public randomSelectedDecision As String

    <XmlElement()> _
    Public Vocabulary As LC.Vocabulary
    <XmlElement()> _
    Public scoreMatrix As LC.ScoreMatrix
    <XmlAttribute()> _
    Public learn As Integer
    <XmlElement()> _
    Public invent As Tuple(Of String, String)()
    <XmlElement()> _
    Public symbols As String()
    <XmlElement()> _
    Public meanings As String()
End Class
