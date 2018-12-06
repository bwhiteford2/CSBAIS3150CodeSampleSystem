<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DeleteStudent.aspx.vb" Inherits="DeleteStudent" %>

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
        <asp:Label ID="DeleteStudentLabel" runat="server" Text="Delete Student"></asp:Label>
        <br />
        
        <asp:TextBox ID="DeleteStudentTextBox" runat="server" ></asp:TextBox>
        <asp:RegularExpressionValidator ID="DeleteStudentRegexValidator" runat="server" ErrorMessage="Must be between 1-10 alpha-numeric characters" ControlToValidate="DeleteStudentTextBox" ValidationExpression="^[a-zA-Z0-9]{1,10}$" ></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="DeleteTextBoxRequiredValidator" runat="server" ErrorMessage="Must enter a value to delete" ControlToValidate="DeleteStudentTextBox"></asp:RequiredFieldValidator>

        <br />
        <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
    </div>
    </form>
</body>
</html>
