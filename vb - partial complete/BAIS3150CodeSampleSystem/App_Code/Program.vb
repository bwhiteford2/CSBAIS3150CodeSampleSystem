Imports Microsoft.VisualBasic



Public Class Program

    Private mProgramCode As String
    Public Property ProgramCode() As String
        Get
            Return mProgramCode
        End Get
        Set(ByVal value As String)
            mProgramCode = value
        End Set
    End Property

    Private mDescription As String
    Public Property Description() As String
        Get
            Return mDescription
        End Get
        Set(ByVal value As String)
            mDescription = value
        End Set
    End Property

    Private mEnrolledStudents As List(Of Student)
    Public ReadOnly Property EnrolledStudents() As List(Of Student)
        Get
            Return mEnrolledStudents
        End Get
    End Property

    Public Sub New() 'Sub is the equivalent in VB of the constructor method named as the class in c#
        mEnrolledStudents = New List(Of Student)
    End Sub

End Class
