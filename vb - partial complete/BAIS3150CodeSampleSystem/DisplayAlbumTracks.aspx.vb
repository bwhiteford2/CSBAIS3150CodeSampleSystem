
Imports System.Data
Imports System.Data.SqlClient

Partial Class DisplayAlbumTracks
    Inherits System.Web.UI.Page

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load

        ' Create a connection string
        Const dbConnectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Chinook;Integrated Security=true"
        ' crate a SqlConnection instance 
        Dim dbConnection As SqlConnection = New SqlConnection()
        dbConnection.ConnectionString = dbConnectionString

        ' open a connection to the database
        dbConnection.Open()

        ' create a SqlCommand
        Dim getAlbumByAlbumId As SqlCommand = New SqlCommand()

        ' Set the Connection for the command 
        getAlbumByAlbumId.Connection = dbConnection

        ' Set the command type 
        getAlbumByAlbumId.CommandType = CommandType.StoredProcedure

        'set the command text to the stored proc name
        getAlbumByAlbumId.CommandText = "uspGetAlbumByAlbumId"

        getAlbumByAlbumId.Parameters.AddWithValue("@AlbumId", 51)


        'Create a SqlDatareader instance to process the command results 
        Dim queryResultsReader As SqlDataReader = getAlbumByAlbumId.ExecuteReader()

        'Determine the index position of the columns in the query
        Dim indexAlbumId As Integer = queryResultsReader.GetOrdinal("AlbumId")
        Dim indexTitle As Integer = queryResultsReader.GetOrdinal("Title")
        Dim indexArtist As Integer = queryResultsReader.GetOrdinal("Name")

        ' Iterate through each row

        While queryResultsReader.Read()
            Dim albumId As Integer = queryResultsReader.GetInt32(indexAlbumId)
            Dim title As String = queryResultsReader.GetString(indexTitle)
            Dim artist As String = queryResultsReader.GetString(indexArtist)
            Response.Write(albumId & " " & title & " " & artist)
        End While

        queryResultsReader.Close()

        ' close connection
        dbConnection.Close()

        dbConnection.Open()
        ' Start the second commmand
        Dim getTracksByAlbumId As SqlCommand = New SqlCommand()

        ' set parameter 
        getTracksByAlbumId.Parameters.AddWithValue("@AlbumID", 185)

        getTracksByAlbumId.CommandText = "uspGetTracksByAlbumId"
        getTracksByAlbumId.CommandType = CommandType.StoredProcedure
        getTracksByAlbumId.Connection = dbConnection


        queryResultsReader = getTracksByAlbumId.ExecuteReader()

        Dim indexTrackId As Integer = queryResultsReader.GetOrdinal("TrackId")
        Dim indexTrack As Integer = queryResultsReader.GetOrdinal("TrackName")

        While queryResultsReader.Read()
            Dim trackid As Integer = queryResultsReader.GetInt32(indexTrackId)
            Dim name As String = queryResultsReader.GetString(indexTrack)

            Response.Write("<br/> " & trackid & " " & name)
        End While
        queryResultsReader.Close()
        dbConnection.Close()

    End Sub
End Class
