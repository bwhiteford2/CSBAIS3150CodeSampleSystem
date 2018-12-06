<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FindStudentsByProgram.aspx.vb" Inherits="FindStudentsByProgram" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="MessageLabel" runat="server" Text=""></asp:Label>
            <br />

            <asp:Label ID="FindStudentsByProgramLabel" runat="server" Text="Find Students by Program"></asp:Label>
            <asp:TextBox ID="FindStudentsByProgramTextBox" runat="server"></asp:TextBox>

            <br />
            <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />
            <br />

            <asp:Table ID="StudentTable" runat="server" ></asp:Table>
        </div>
    </form>
</body>
</html>
