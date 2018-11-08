<%@ Page Title="Create Program" Language="C#" MasterPageFile="~/BootstrapMasterPage.master" AutoEventWireup="true" CodeFile="CreateProgram.aspx.cs" Inherits="CreateProgram" Theme="RedTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">

    <div class="jumbotron">
        <h1>Create Program</h1>
    </div>
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

</asp:Content>

