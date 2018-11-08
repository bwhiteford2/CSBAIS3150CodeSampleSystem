<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapMasterPage.master" AutoEventWireup="true" CodeFile="ModifyStudent.aspx.cs" Inherits="ModifyStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <div class="jumbotron"><h1>Modify Student</h1></div>

    <div class="form-body form-group col-md-6">
        <asp:Label ID="MessageLabel" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="StudentIdLabel" runat="server" Text="StudentID to Modify"></asp:Label>
            <br />
            <asp:TextBox ID="StudentIdTextBox" runat="server" CssClass="form-control"></asp:TextBox>

            <br />

            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <br />
                <asp:Label ID="FirstNameLabel" runat="server" Text="First Name"></asp:Label>
                <br />
                <asp:TextBox ID="FirstNameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqFirstNameValidator" runat="server" ErrorMessage="First name is required" ControlToValidate="FirstNameTextBox" Display="Dynamic" ValidationGroup="Modify"></asp:RequiredFieldValidator>
                <br />

                <asp:Label ID="LastNameLabel" runat="server" Text="Last Name"></asp:Label>
                <br />
                <asp:TextBox ID="LastNameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqLastNameValidator" runat="server" ErrorMessage="Last name is required" ControlToValidate="LastNameTextBox" Display="Dynamic" ValidationGroup="Modify"></asp:RequiredFieldValidator>
                <br />

                <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
                <br />
                <asp:TextBox ID="EmailTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                <br />

                <asp:Label ID="ProgramCodeLabel" runat="server" Text="Program Code" ></asp:Label>
                <br />
                <asp:TextBox ID="ProgramCodeTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                <br />
            </asp:Panel>


            <asp:Button ID="FindStudentButton" runat="server" Text="Find Student" OnClick="FindStudentButton_Click" ValidationGroup="Find" CssClass="btn btn-primary" />
            <asp:Button ID="ModifyStudentButton" runat="server" Text="Modify Student" OnClick="ModifyStudentButton_Click" ValidationGroup="Modify" CssClass="btn btn-outline-primary" />

    </div>
</asp:Content>

