<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapMasterPage.master" AutoEventWireup="true" CodeFile="EnrollStudent.aspx.cs" Inherits="EnrollStudent" Theme="BlueTheme"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">

    <div class="jumbotron">
        <h1>Enroll Student</h1>
    </div>


    <div class="form-group col-md-6 form-body">
        <asp:Label ID="MessagesLabel" runat="server" class="alert alert-primary" Visible="false"></asp:Label>
        <br />
        <br />

        <asp:Label ID="ProgramLabel" runat="server" Text="Program" ></asp:Label>
        <asp:TextBox ID="ProgramTextBox" runat="server" CssClass="form-control"></asp:TextBox>        
        <asp:RequiredFieldValidator ID="programTBValidator" runat="server" ErrorMessage="Program code is required" ControlToValidate="ProgramTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
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
</asp:Content>

