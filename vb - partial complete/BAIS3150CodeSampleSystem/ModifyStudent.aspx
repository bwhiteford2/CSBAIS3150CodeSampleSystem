<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ModifyStudent.aspx.vb" Inherits="ModifyStudent" %>

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
            <asp:Label ID="StudentIdLabel" runat="server" Text="StudentID to Modify"></asp:Label>
            <br />
            <asp:TextBox ID="StudentIdTextBox" runat="server"></asp:TextBox>

            <br />

            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <br />
                <asp:Label ID="FirstNameLabel" runat="server" Text="First Name"></asp:Label>
                <br />
                <asp:TextBox ID="FirstNameTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqFirstNameValidator" runat="server" ErrorMessage="First name is required" ControlToValidate="FirstNameTextBox" Display="Dynamic" ValidationGroup="Modify"></asp:RequiredFieldValidator>
                <br />

                <asp:Label ID="LastNameLabel" runat="server" Text="Last Name"></asp:Label>
                <br />
                <asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqLastNameValidator" runat="server" ErrorMessage="Last name is required" ControlToValidate="LastNameTextBox" Display="Dynamic" ValidationGroup="Modify"></asp:RequiredFieldValidator>
                <br />

                <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
                <br />
                <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
                <br />

                <asp:Label ID="ProgramCodeLabel" runat="server" Text="Program Code"></asp:Label>
                <br />
                <asp:TextBox ID="ProgramCodeTextBox" runat="server"></asp:TextBox>
                <br />
            </asp:Panel>


            <asp:Button ID="FindStudentButton" runat="server" Text="Find Student" OnClick="FindStudentButton_Click" ValidationGroup="Find" />
            <asp:Button ID="ModifyStudentButton" runat="server" Text="Modify Student" OnClick="ModifyStudentButton_Click" ValidationGroup="Modify" />

        </div>
    </form>
</body>
</html>
