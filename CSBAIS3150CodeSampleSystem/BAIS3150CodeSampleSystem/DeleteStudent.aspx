<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapMasterPage.master" AutoEventWireup="true" CodeFile="DeleteStudent.aspx.cs" Inherits="DeleteStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">

    <div class="jumbotron"><h1>Delete Student</h1></div>

    <div class="col-md-6 form-group form-body">
        
        <asp:Label ID="MessageLabel" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="DeleteStudentLabel" runat="server" Text="Delete Student"></asp:Label>
        <br />
        
        <asp:TextBox ID="DeleteStudentTextBox" runat="server" class="form-control" ></asp:TextBox>
        <asp:RegularExpressionValidator ID="DeleteStudentRegexValidator" runat="server" ErrorMessage="Must be between 1-10 alpha-numeric characters" ControlToValidate="DeleteStudentTextBox" ValidationExpression="^[a-zA-Z0-9]{1,10}$" ></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="DeleteTextBoxRequiredValidator" runat="server" ErrorMessage="Must enter a value to delete" ControlToValidate="DeleteStudentTextBox"></asp:RequiredFieldValidator>

        <br />
        <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" OnClientClick="return confirm('Are you sure you want to delete this student?');" class="btn btn-primary" />


    </div>
</asp:Content>

