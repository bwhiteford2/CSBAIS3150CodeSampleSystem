Imports Microsoft.VisualBasic

Public Class Student
    Private mStudentID As String
    Public Property StudentID() As String
        Get
            Return mStudentID
        End Get
        Set(ByVal value As String)
            mStudentID = value
        End Set
    End Property

    Private mFirstName As String
    Public Property FirstName() As String
        Get
            Return mFirstName
        End Get
        Set(ByVal value As String)
            mFirstName = value
        End Set
    End Property

    Private mLastName As String
    Public Property LastName() As String
        Get
            Return mLastName
        End Get
        Set(ByVal value As String)
            mLastName = value
        End Set
    End Property

    Private mEmail As String
    Public Property Email() As String
        Get
            Return mEmail
        End Get
        Set(ByVal value As String)
            mEmail = value
        End Set
    End Property



End Class
