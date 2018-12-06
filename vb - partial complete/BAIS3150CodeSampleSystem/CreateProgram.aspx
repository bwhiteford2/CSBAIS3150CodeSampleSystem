<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CreateProgram.aspx.vb" Inherits="CreateProgram" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:ValidationSummary ID="SampleValidationSummary" runat="server" DisplayMode="BulletList" ShowSummary="true" />

        <asp:Label ID="MessagesLabel" runat="server" ></asp:Label>
        <br />
        <asp:Label ID="ProgramCodeLabel" runat="server" Text="Program Code"></asp:Label>
        <asp:TextBox ID="ProgramCodeTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ProgramCodeRequiredFieldValidator" runat="server" ErrorMessage="Program Code value is required" ControlToValidate="ProgramCodeTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="ProgramCodeRegexValidator" runat="server" ErrorMessage="Program code must be between 2 - 10 characters" ControlToValidate="ProgramCodeTextBox" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9]{2,10}$"></asp:RegularExpressionValidator>

        <br />
        <asp:Label ID="DescriptionLabel" runat="server" Text="Description"></asp:Label>
        <asp:TextBox ID="DescriptionTextBox" TextMode="MultiLine" runat="server" ></asp:TextBox>

        <br />

        <asp:Button ID="SubmitButton" runat="server" Text="Submit"  />



    </div>
    </form>
</body>
</html>
