<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapMasterPage.master" AutoEventWireup="true" CodeFile="DeleteStudent.aspx.cs" Inherits="DeleteStudent" Theme="BlueTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">

    <div class="jumbotron">
        <h1>Delete Student</h1>
    </div>

    <div class="col-md-6 form-group form-body">

        <asp:Label ID="MessageLabel" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="DeleteStudentLabel" runat="server" Text="Delete Student"></asp:Label>
        <br />

        <asp:TextBox ID="DeleteStudentTextBox" runat="server" class="form-control"></asp:TextBox>
        <asp:RegularExpressionValidator ID="DeleteStudentRegexValidator" runat="server" ErrorMessage="Must be between 1-10 alpha-numeric characters" ControlToValidate="DeleteStudentTextBox" ValidationExpression="^[a-zA-Z0-9]{1,10}$"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="DeleteTextBoxRequiredValidator" runat="server" ErrorMessage="Must enter a value to delete" ControlToValidate="DeleteStudentTextBox"></asp:RequiredFieldValidator>

        <br />
        <asp:Button ID="SubmitButton" runat="server" Text="Lookup" OnClick="SubmitButton_Click" class="btn btn-primary" />

        <asp:Panel ID="Panel1" runat="server" Visible="false">

            <asp:Label ID="Label3" runat="server" Text="StudentId: "></asp:Label>
            <asp:Label ID="StudentId" runat="server" Text=""></asp:Label>

            <br />

            <asp:Label ID="Label1" runat="server" Text="First Name: "></asp:Label>
            <asp:Label ID="FirstName" runat="server" Text=""></asp:Label>

            <br />

            <asp:Label ID="Label2" runat="server" Text="Last Name: "></asp:Label>
            <asp:Label ID="LastName" runat="server" Text=""></asp:Label>

            <br />

            <asp:Label ID="Label4" runat="server" Text="Email: "></asp:Label>
            <asp:Label ID="Email" runat="server" Text=""></asp:Label>

            <br />
            <asp:Button ID="DeleteBtn" runat="server" Text="Delete" OnClick="DeleteBtn_Click" OnClientClick="return confirm('Are you sure you want to delete this student?');" class="btn btn-danger" CausesValidation="false" />

            <br />

        </asp:Panel>
    </div>
</asp:Content>

