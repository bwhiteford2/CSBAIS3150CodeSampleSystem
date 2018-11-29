<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapMasterPage.master" AutoEventWireup="true" CodeFile="FindStudent.aspx.cs" Inherits="FindStudent" Theme="RedTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <div class="jumbotron">
        <h1>Find Student</h1>
    </div>

    <div class="col-md-6 form-group form-body">

        <asp:Label ID="MessageLabel" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="FindStudentLabel" runat="server" Text="Find Student"></asp:Label>
        <br />
        <asp:TextBox ID="FindStudentTextBox" runat="server" class="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="findStudentValidator" runat="server" ErrorMessage="Student Id is required" ControlToValidate="FindStudentTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" class="btn btn-primary" />

        <br />

        <asp:Panel ID="Panel1" runat="server" Visible="false">

            <asp:Label ID="Label1" runat="server" Text="First Name: "></asp:Label>
            <asp:Label ID="FirstName" runat="server" Text=""></asp:Label>

            <br />

            <asp:Label ID="Label2" runat="server" Text="Last Name: "></asp:Label>
            <asp:Label ID="LastName" runat="server" Text=""></asp:Label>

            <br />

            <asp:Label ID="Label4" runat="server" Text="Email: "></asp:Label>
            <asp:Label ID="Email" runat="server" Text=""></asp:Label>

            <br />

        </asp:Panel>

    </div>
</asp:Content>

