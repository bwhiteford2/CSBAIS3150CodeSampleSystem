<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapMasterPage.master" AutoEventWireup="true" CodeFile="ModifyStudent.aspx.cs" Inherits="ModifyStudent" Theme="BlueTheme" %>

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
        <asp:RequiredFieldValidator ID="studentIDValidator" runat="server" ErrorMessage="Student Id is required" ControlToValidate="StudentIdTextBox" Display="Dynamic" ValidationGroup="Find"></asp:RequiredFieldValidator>
            <br />
        <asp:Button ID="FindStudentButton" runat="server" Text="Find Student" OnClick="FindStudentButton_Click" ValidationGroup="Find" CssClass="btn btn-primary" />
        <br />
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <br />
                <asp:Label ID="StudentIdLbl" runat="server" Text="Student Id: "></asp:Label>
                <br />
                <asp:TextBox ID="StudentIdTB" runat="server" Text="" ReadOnly="true" CssClass="form-control"></asp:TextBox>
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
                <asp:Button ID="ModifyStudentButton" runat="server" Text="Modify Student" OnClick="ModifyStudentButton_Click" ValidationGroup="Modify" CssClass="btn btn-outline-primary" />
            </asp:Panel>


            
            

    </div>
</asp:Content>

