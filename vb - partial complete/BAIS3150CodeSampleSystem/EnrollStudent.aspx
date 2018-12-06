<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EnrollStudent.aspx.vb" Inherits="EnrollStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous"/>

</head>
<body>
    <form id="form1" runat="server">
    <div class="form-group col-md-6">
        
        <h1>Enroll Student</h1>
        <asp:Label ID="MessagesLabel" runat="server" ></asp:Label>
        <br />

        <asp:DropDownList ID="ProgramDropDownList" runat="server" class="form-control">
            <asp:ListItem Text="--> Select a Program <--" Value=""></asp:ListItem>
            <asp:ListItem Text="Bachelor of Applied Information Systems Technology" Value="BAIST"></asp:ListItem>
            <asp:ListItem Text="Digital Media and IT" Value="DMIT"></asp:ListItem>
            <asp:ListItem Text="Computer Network Engineering Technology" Value="CNT"></asp:ListItem>
        </asp:DropDownList>

        <br />
        <asp:Label ID="StudentIdLabel" runat="server" Text="Student ID"></asp:Label>
        <asp:TextBox ID="StudentIdTextBox" runat="server" class="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ReqIdValidator" runat="server" ErrorMessage="StudentId is required" ControlToValidate="StudentIdTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
        
        <br />
        <asp:Label ID="FirstNameLabel" runat="server" Text="First Name"></asp:Label>
        <asp:TextBox ID="FirstNameTextBox" runat="server" class="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ReqFirstNameValidator" runat="server" ErrorMessage="First name is required" ControlToValidate="FirstNameTextBox" Display="Dynamic"></asp:RequiredFieldValidator>

        <br />
        <asp:Label ID="LastNameLabel" runat="server" Text="Last Name"></asp:Label>
        <asp:TextBox ID="LastNameTextBox" runat="server" class="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ReqLastNameValidator" runat="server" ErrorMessage="Last name is required" ControlToValidate="LastNameTextBox" Display="Dynamic"></asp:RequiredFieldValidator>

        <br />
        <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="EmailTextBox" runat="server" class="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ReqEmailValidator" runat="server" ErrorMessage="Email is required" ControlToValidate="EmailTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
        <br />


        <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" class="btn-primary btn" />

    </div>
    </form>
</body>
</html>
