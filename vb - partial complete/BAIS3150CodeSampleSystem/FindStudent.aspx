<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FindStudent.aspx.vb" Inherits="FindStudent" %>

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
        <asp:Label ID="FindStudentLabel" runat="server" Text="Find Student"></asp:Label>
        <br />
        <asp:TextBox ID="FindStudentTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />
    </div>
    </form>
</body>
</html>
